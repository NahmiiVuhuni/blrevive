using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bootstrapper
{
    public partial class LauncherEntry : Form
    {
        public LauncherEntry()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void netModeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(netModeSelect.SelectedIndex == 0)
            {
                BotgameLauncher bl = new BotgameLauncher();
                this.Hide();
                bl.FormClosed += Bl_FormClosed;
                bl.Show();
            } else
            {
                MessageBox.Show("NetMode " + (string)netModeSelect.SelectedItem + " is currently not implemented!");
            }
        }

        private void Bl_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
