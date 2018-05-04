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
    public class TcpProxy
    {
        private Socket _mainSocket;
        private TcpProxy _destination;
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

        public TcpProxy Destination
        {
            get { return this._destination; }
        }

        public TcpProxy(bool incoming)
        {
            this._mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._incoming = incoming;
            this._rc4Provider = null;
        }

        public void Start(IPEndPoint local, IPEndPoint remote)
        {
            _mainSocket.Bind(local);
            _mainSocket.Listen(10);

            while (frmMain.Form.ServerConnected)
            {
                try
                {
                    var source = _mainSocket.Accept();
                    this._destination = new TcpProxy(false);
                    _destinationState = new State(source, _destination._mainSocket);
                    _destination.Connect(remote, source);
                    source.BeginReceive(_destinationState.Buffer, 0, _destinationState.Buffer.Length, 0, OnDataReceive, _destinationState);
                } catch { }
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
                            frmMain.AppendIncomingTextBox(frmMain.Form, "- " + outputStr + Environment.NewLine);

                        }
                        else
                        {
                            frmMain.AppendOutgoingTextBox(frmMain.Form, "- " + outputStr + Environment.NewLine);
                        }

                        if (frmMain.Form.chkLog.Checked)
                        {
                            File.AppendAllText("packet.log", "INCOMING DATA: " + outputStr + Environment.NewLine + Environment.NewLine);
                        }
                    }

                    state.DestinationSocket.Send(state.Buffer, bytesRead, SocketFlags.None);
                    state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, OnDataReceive, state);

                }
            }
            catch
            {
                Close(this, state);
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
            catch {  }

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

                if (newPacket.StartsWith("@A") && frmMain.Form.chkDecodeEncryption.Checked)
                {
                    String encodeKey = packet.Substring(2);
                    frmMain.Form.TcpForwarder._rc4Provider = new rc4Provider(encodeKey);
                }

                packets.Add(packet + (char)1);
            }

            return packets;
        }

        public void Close(TcpProxy proxy, State state)
        {
            try
            {
                state.DestinationSocket.Close();
            }
            catch { }

            try
            {
                state.SourceSocket.Close();
            }
            catch { }

            try
            {
                proxy.Socket.Close();
            }
            catch { }
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
