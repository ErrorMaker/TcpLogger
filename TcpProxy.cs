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

                    List<PacketSummary> packets = new List<PacketSummary>();

                    if (this._incoming)
                    {
                        packets.AddRange(HandleIncomingData(str));
                    }
                    else
                    {
                        packets.AddRange(HandleOutgoingData(str));
                    }

                    foreach (PacketSummary packet in packets)
                    {
                        string outputStr = packet.Data;

                        for (int i = 0; i < 13; i++)
                        {
                            outputStr = outputStr.Replace("" + (char)i, "{" + i + "}");
                        }

                        string logData = packet.HeaderId + " / " + packet.Header + Environment.NewLine + outputStr + Environment.NewLine;// + Environment.NewLine;

                        if (outputStr.Length > 0)
                        {
                            logData += Environment.NewLine;
                        }

                        if (this._incoming)
                        {
                            frmMain.AppendIncomingTextBox(frmMain.Form, "- " + logData);

                        }
                        else
                        {
                            frmMain.AppendOutgoingTextBox(frmMain.Form, "- " + logData);
                        }

                        if (frmMain.Form.chkLog.Checked)
                        {
                            File.AppendAllText("packet.log", (this._incoming ? "INCOMING DATA: " : "OUTGOING DATA: ") + logData);
                        }


                        /*string response;

                        if (this._incoming)
                        {
                            response = packet.Header + packet.Data;
                            response = "@" + Base64Encoding.EncodeInt32(response.Length, 2) + response;
                        }
                        else
                        {
                            response = packet.Header + packet.Data;
                        }

                        byte[] processSend = Encoding.Default.GetBytes(response);
                        state.DestinationSocket.Send(processSend, processSend.Length, SocketFlags.None);*/
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

        private List<PacketSummary> HandleIncomingData(string str)
        {
            List<PacketSummary> packets = new List<PacketSummary>();

            try
            {
                int amountRead = 0;

                while (amountRead < str.Length)
                {
                    int recieveLength = Base64Encoding.DecodeInt32(str.Substring(amountRead, 3));
                    amountRead += 3;

                    string packet = str.Substring(amountRead, recieveLength);

                    PacketSummary summary = new PacketSummary(packet.Substring(0, 2), (packet.Substring(0, 2).Length > 0 ? packet.Substring(2) : ""));
                    packets.Add(summary);

                    amountRead += recieveLength;
                }
            }
            catch {  }

            return packets;
        }

        private List<PacketSummary> HandleOutgoingData(string str)
        {
            List<PacketSummary> packets = new List<PacketSummary>();

            try
            {
                foreach (string packet in str.Split(new char[] { (char)1 }))
                {
                    if (packet.Length < 2)
                    {
                        continue;
                    }

                    String newPacket = packet.Replace("" + (char)1, "");

                    if (newPacket.StartsWith("@A") && frmMain.Form.chkDecodeEncryption.Checked)
                    {
                        String encodeKey = packet.Substring(2);
                        frmMain.Form.TcpForwarder._rc4Provider = new rc4Provider(encodeKey);
                    }

                    PacketSummary summary = new PacketSummary(packet.Substring(0, 2), (packet.Substring(0, 2).Length > 0 ? packet.Substring(2) : "") + (char)1);
                    packets.Add(summary);
                }
            }
            catch { }

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
                Buffer = new byte[4096];
            }
        }

        public class PacketSummary
        {
            public int HeaderId { get; private set; }
            public string Header { get; private set; }
            public string Data { get; private set; }

            public PacketSummary(string Header, string Data)
            {
                this.Header = Header;
                this.HeaderId = Base64Encoding.DecodeInt32(this.Header);
                this.Data = Data;
            }
        }
    }
}
