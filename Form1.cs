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
    public partial class Form1 : Form
    {
        private bool _serverStarted = false;
        private TcpForwarderSlim _tcpForwarder;
        private Thread _listenerThread;
        public static Form1 frmMain;

        public TcpForwarderSlim TcpForwarder
        {
            get { return this._tcpForwarder; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmMain = this;
            this.btnStartListen.Enabled = true;
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
                _tcpForwarder = new TcpForwarderSlim(this, true);

                _listenerThread = new Thread(RunListener);
                _listenerThread.Start();

                this.btnStartListen.Enabled = false;

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

            _tcpForwarder.Destination.Socket.Close();
            _tcpForwarder.Socket.Close();

            this.btnStartListen.Enabled = true;
        }

        public static void AppendOutgoingTextBox(Form1 instance, string value)
        {
            if (instance.InvokeRequired)
            {
                instance.Invoke(new Action<Form1, string>(AppendOutgoingTextBox), new object[] { instance, value });
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

        public static void AppendIncomingTextBox(Form1 instance, string value)
        {
            if (instance.InvokeRequired)
            {
                instance.Invoke(new Action<Form1, string>(AppendIncomingTextBox), new object[] { instance, value });
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSending frm = new frmSending();
            frm.Show();
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
