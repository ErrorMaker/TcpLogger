using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewLogger
{
    public partial class frmEncoder : Form
    {
        public frmEncoder()
        {
            InitializeComponent();
        }

        private void frmEncoder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnToB64_Click(object sender, EventArgs e)
        {
            try
            {
                string value = Base64Encoding.EncodeInt32(int.Parse(txtToB64.Text), 2);
                txtFromB64.Text = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFromB64_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int num;
                    int value = Base64Encoding.DecodeInt32(txtFromB64.Text);
                    txtToB64.Text = value + "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnToVL64_Click(object sender, EventArgs e)
        {
            try
            {
                string value = WireEncoding.EncodeInt32(int.Parse(txtToVL64.Text));
                txtFromVL64.Text = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFromVL64_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                int value = WireEncoding.DecodeInt32(txtFromVL64.Text, out i);
                txtToVL64.Text = value + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
