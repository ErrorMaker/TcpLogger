using JewLogger.Ciphering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewLogger
{
    public class TcpForwarderSlim
    {
        private Form1 _mainForm;
        private State _state;
        private Socket _mainSocket;
        private TcpForwarderSlim _destination;
        private rc4Provider _rc4Provider;

        private State _connectState;
        private State _destinationState;

        private bool _incoming;

        public Socket Socket
        {
            get { return this._mainSocket; }
        }

        public State ConnectState
        {
            get { return this._connectState; }
        }

        public State DestinationState
        {
            get { return this._destinationState; }
        }

        public TcpForwarderSlim Destination
        {
            get { return this._destination; }
        }

        public TcpForwarderSlim(Form1 mainForm, bool incoming)
        {
            this._mainForm = mainForm;
            this._mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._incoming = incoming;
            this._rc4Provider = null;
        }

        public void Start(IPEndPoint local, IPEndPoint remote)
        {
            _mainSocket.Bind(local);
            _mainSocket.Listen(10);

            while (true)
            {
                var source = _mainSocket.Accept();
                this._destination = new TcpForwarderSlim(this._mainForm, false);
                _destinationState = new State(source, _destination._mainSocket);
                _destination.Connect(remote, source);
                source.BeginReceive(_destinationState.Buffer, 0, _destinationState.Buffer.Length, 0, OnDataReceive, _destinationState);
            }
        }

        private void Connect(EndPoint remoteEndpoint, Socket destination)
        {
            _connectState = new State(_mainSocket, destination);
            _mainSocket.Connect(remoteEndpoint);
            _mainSocket.BeginReceive(_connectState.Buffer, 0, _connectState.Buffer.Length, SocketFlags.None, OnDataReceive, _connectState);
        }

        private void OnDataReceive(IAsyncResult result)
        {
            var state = (State)result.AsyncState;
            try
            {
                var bytesRead = state.SourceSocket.EndReceive(result);
                if (bytesRead > 0)
                {
                    string str = Encoding.Default.GetString(state.Buffer, 0, bytesRead);

                    if (this._incoming)
                    {
                        if (_rc4Provider != null)
                        {
                            str = this._rc4Provider.Decipher(str, bytesRead);

                        }
                    }

                    List<string> packets = new List<string>();

                    if (this._incoming)
                    {
                        packets.AddRange(HandleIncomingData(str));
                    }
                    else
                    {
                        packets.AddRange(HandleOutgoingData(str));
                    }

                    foreach (string packet in packets)
                    {
                        string outputStr = packet;

                        for (int i = 0; i < 13; i++)
                        {
                            outputStr = outputStr.Replace("" + (char)i, "{" + i + "}");
                        }


                        if (this._incoming)
                        {
                            Form1.AppendIncomingTextBox(this._mainForm, "- " + outputStr + Environment.NewLine);
                            File.AppendAllText("packet.log", "INCOMING DATA: " + outputStr + Environment.NewLine + Environment.NewLine);
                        }
                        else
                        {
                            Form1.AppendOutgoingTextBox(this._mainForm, "- " + outputStr + Environment.NewLine);
                            File.AppendAllText("packet.log", "OUTGOING DATA: " + outputStr + Environment.NewLine + Environment.NewLine);
                        }
                    }

                    state.DestinationSocket.Send(state.Buffer, bytesRead, SocketFlags.None);
                    state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnDataReceive, state);

                }
            }
            catch
            {
                state.DestinationSocket.Close();
                state.SourceSocket.Close();
            }
        }

        private List<string> HandleIncomingData(string str)
        {
            List<string> packets = new List<string>();

            try
            {
                int amountRead = 0;

                while (amountRead < str.Length)
                {
                    int recieveLength = HabboEncoding.decodeB64(str.Substring(amountRead, 3));
                    amountRead += 3;

                    packets.Add(str.Substring(amountRead, recieveLength));
                    amountRead += recieveLength;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(str + "\n" + ex.ToString());
            }

            return packets;
        }

        private List<string> HandleOutgoingData(string str)
        {
            List<string> packets = new List<string>();

            foreach (string packet in str.Split(new char[] { (char)1 }))
            {
                if (packet.Length == 0)
                {
                    continue;
                }

                String newPacket = packet.Replace("" + (char)1, "");

                if (newPacket.StartsWith("@A") && _mainForm.chkDecodeEncryption.Checked)
                {
                    String encodeKey = packet.Substring(2);
                    File.AppendAllText("packet.log", "ENCODE KEY: " + encodeKey + Environment.NewLine + Environment.NewLine);

                    Form1.frmMain.TcpForwarder._rc4Provider = new rc4Provider(encodeKey);
                }

                packets.Add(packet + (char)1);
            }

            return packets;
        }

        public class State
        {
            public Socket SourceSocket { get; private set; }
            public Socket DestinationSocket { get; private set; }
            public byte[] Buffer { get; private set; }

            public State(Socket source, Socket destination)
            {
                SourceSocket = source;
                DestinationSocket = destination;
                Buffer = new byte[8192];
            }
        }
    }
}
