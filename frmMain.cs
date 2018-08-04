using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewLogger
{
    public partial class frmMain : Form
    {
        private bool _serverStarted;
        private TcpProxy _tcpForwarder;
        private Thread _listenerThread;

        public static frmMain Form;
        public static frmHook Hooking;

        public TcpProxy TcpForwarder
        {
            get { return this._tcpForwarder; }
        }

        public bool ServerConnected
        {
            get { return this._serverStarted; }
        }

        public frmMain()
        {
            _serverStarted = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form = this;
            Hooking = new frmHook();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.btnSendData.Enabled = false;

            this.btnStartListen.Enabled = true;
            this.btnStopListen.Enabled = false;

            this.txtIncomingData.ScrollBars = ScrollBars.Vertical;
            this.txtIncomingData.ReadOnly = true;
            this.txtIncomingData.BackColor = Color.White;

            this.txtOutgoingData.ScrollBars = ScrollBars.Vertical;
            this.txtOutgoingData.ReadOnly = true;
            this.txtOutgoingData.BackColor = Color.White;
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serverStarted)
                {
                    return;
                }

                _serverStarted = true;
                _tcpForwarder = new TcpProxy(true);

                _listenerThread = new Thread(RunListener);
                _listenerThread.Start();

                this.btnStartListen.Enabled = false;
                this.btnStopListen.Enabled = true;
                this.btnSendData.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RunListener()
        {
            string localAddress = txtLocalAddress.Text;
            string remoteAddress = txtRemoteAddress.Text;

            if (!UriExtension.IsIPAddress(localAddress))
            {
                localAddress = UriExtension.ResolveHostname(localAddress);

                if (localAddress == "::1")
                {
                    localAddress = "127.0.0.1";
                }
            }

            if (!UriExtension.IsIPAddress(remoteAddress))
            {
                remoteAddress = UriExtension.ResolveHostname(remoteAddress);

                if (remoteAddress == "::1")
                {
                    remoteAddress = "127.0.0.1";
                }
            }

            _tcpForwarder.Start(new IPEndPoint(IPAddress.Parse(localAddress), int.Parse(txtLocalPort.Text)), new IPEndPoint(IPAddress.Parse(remoteAddress), int.Parse(txtRemotePort.Text)));
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            if (!_serverStarted)
            {
                return;
            }

            _serverStarted = false;

            try
            {
                _tcpForwarder.Close(_tcpForwarder, _tcpForwarder.DestinationState);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }


            this.btnStartListen.Enabled = true;
            this.btnStopListen.Enabled = false;
            this.btnSendData.Enabled = false;
        }

        public static void AppendOutgoingTextBox(frmMain instance, string value)
        {
            if (instance.InvokeRequired)
            {
                instance.Invoke(new Action<frmMain, string>(AppendOutgoingTextBox), new object[] { instance, value });
                return;
            }

            TextBox textBox = instance.txtOutgoingData;
            int position = textBox.SelectionStart;

            textBox.Text += value;

            if (instance.chkOutgoingAutoscroll.Checked)
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
            }
            else
            {
                textBox.SelectionStart = position;
                textBox.ScrollToCaret();
            }

        }

        public static void AppendIncomingTextBox(frmMain instance, string value)
        {
            if (!instance.chkLogScreen.Checked)
            {
                return;
            }

            if (instance.InvokeRequired)
            {
                instance.Invoke(new Action<frmMain, string>(AppendIncomingTextBox), new object[] { instance, value });
                return;
            }

            TextBox textBox = instance.txtIncomingData;
            int position = textBox.SelectionStart;

            textBox.Text += value;

            if (instance.chkIncomingAutoscroll.Checked)
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
            }
            else
            {
                textBox.SelectionStart = position;
                textBox.ScrollToCaret();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void b64VL64HelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEncoder frm = new frmEncoder();
            frm.Show();
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            frmSend frm = new frmSend();
            frm.Show();
        }

        private void btnClearIncoming_Click(object sender, EventArgs e)
        {
            txtIncomingData.Text = string.Empty;
        }

        private void btnClearOutgoing_Click(object sender, EventArgs e)
        {
            txtOutgoingData.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hooking.Show();
        }
    }

    public static class UriExtension
    {
        public static bool IsIPAddress(this string input)
        {
            var hostNameType = Uri.CheckHostName(input);
            return hostNameType == UriHostNameType.IPv4 || hostNameType == UriHostNameType.IPv6;
        }

        public static string ResolveHostname(string domain)
        {
            IPAddress[] addresslist = Dns.GetHostAddresses(domain);

            foreach (IPAddress theaddress in addresslist) {
                return theaddress.ToString();
            }

            return null;
        }
    }
}
