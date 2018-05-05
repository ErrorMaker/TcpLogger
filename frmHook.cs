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
    public partial class frmHook : Form
    {
        private DataTable _incomingDataTable;
        private DataTable _outgoingDataTable;

        private List<int> _hookedIncomingIds;
        private List<int> _hookedOutgoingIds;

        public frmHook()
        {
            InitializeComponent();
        }

        private void frmHook_Load(object sender, EventArgs e)
        {
            _hookedIncomingIds = new List<int>();
            _hookedOutgoingIds = new List<int>();

            _incomingDataTable = new DataTable();
            _outgoingDataTable = new DataTable();

            incomingGridView.DataSource = _incomingDataTable;
            outgoingGridView.DataSource = _outgoingDataTable;

            var columnTypes = new List<KeyValuePair<string, Type>>();
            columnTypes.Add(new KeyValuePair<string, Type>("Header Id", typeof(string)));
            columnTypes.Add(new KeyValuePair<string, Type>("Header", typeof(string)));

            foreach (var kvp in columnTypes)
            {
                _incomingDataTable.Columns.Add(kvp.Key, kvp.Value);
                _outgoingDataTable.Columns.Add(kvp.Key, kvp.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessPacketHooking(true);
        }

        public void ProcessPacketHooking(bool showMessage)
        {
            _hookedIncomingIds.Clear();
            _hookedOutgoingIds.Clear();

            foreach (DataRow row in _incomingDataTable.Rows)
            {
                string headerId = row.Field<string>(0);
                string header = row.Field<string>(1);

                if (headerId.Length > 0)
                {
                    try
                    {
                        _hookedIncomingIds.Add(int.Parse(headerId));
                        continue;
                    }
                    catch { }
                }

                if (header.Length > 0)
                {
                    _hookedIncomingIds.Add(Base64Encoding.DecodeInt32(headerId));
                }
            }

            foreach (DataRow row in _outgoingDataTable.Rows)
            {
                string headerId = row.Field<string>(0);
                string header = row.Field<string>(1);

                if (headerId.Length > 0)
                {
                    try
                    {
                        _hookedOutgoingIds.Add(int.Parse(headerId));
                        continue;
                    }
                    catch { }
                }

                if (header.Length > 0)
                {
                    _hookedOutgoingIds.Add(Base64Encoding.DecodeInt32(headerId));
                }
            }

            MessageBox.Show("Added " + _hookedIncomingIds.Count + " incoming headers and " + _hookedOutgoingIds.Count + " outgoing headers to be hooked.");
        }
    }
}
