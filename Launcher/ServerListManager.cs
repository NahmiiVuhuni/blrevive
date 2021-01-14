using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLRevive.Launcher
{
    public partial class ServerListManager : Form
    {
        public ServerListManager()
        {
            InitializeComponent();
        }

        private void ClientTabServerListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // we don't want to allow users to resize the columns
            // this is not a pretty fix and can probably be done better

            e.Cancel = true;
            e.NewWidth = ServerListMgrListview.Columns[e.ColumnIndex].Width;
        }
    }
}
