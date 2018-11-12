using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpLogger
{
    public partial class frmSend : Form
    {
        public frmSend()
        {
            InitializeComponent();
        }

        private void frmSending_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnSendToClient_Click(object sender, EventArgs e)
        {

            string clientPacket = AddUnreadableCharacters(txtSendData.Text + (char)1);
            byte[] data = Encoding.Default.GetBytes(clientPacket);

            try
            {
                frmMain.Form.TcpForwarder.DestinationState.SourceSocket.Send(data, data.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSendToServer_Click(object sender, EventArgs e)
        {
            string sendPacket = AddUnreadableCharacters("@" + Base64Encoding.EncodeInt32(txtSendData.Text.Length, 2) + txtSendData.Text);
            byte[] data = Encoding.Default.GetBytes(sendPacket);
            try
            {
                frmMain.Form.TcpForwarder.DestinationState.DestinationSocket.Send(data, data.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
        public static string AddUnreadableCharacters(string packet)
        {
            string newPacket = packet;

            for (int i = 0; i < 14; i++)
            {
                newPacket = newPacket.Replace("{" + i + "}", "" + (char)i);
            }

            return newPacket;
        }

        public static string AddReadableCharacters(string packet)
        {
            string newPacket = packet;

            for (int i = 0; i < 14; i++)
            {
                newPacket = newPacket.Replace("" + (char)i, "{" + i + "}");
            }

            return newPacket;
        }
    }
}
