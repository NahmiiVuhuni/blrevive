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
    public partial class ServerLauncher : Form
    {
        public ServerLauncher()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (UseCustomUrlCheckbox.Checked)
                GameLauncher.LaunchServer(CustomUrlTextBox.Text);
            else
                GameLauncher.LaunchServer((string)MapsCombo.SelectedItem, (string)GameModesCombo.SelectedItem, (int)BotCountCombo.SelectedIndex, AdditionalOptionsTextBox.Text);
        }

        private void ServerLauncher_Load(object sender, EventArgs e)
        {
            GameModesCombo.DataSource = GameLauncher.GetConfig().GameModes;
            GameModesCombo.SelectedIndex = 1;
            MapsCombo.DataSource = GameLauncher.GetConfig().Maps;
            MapsCombo.SelectedIndex = 9;
            BotCountCombo.SelectedIndex = 10;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GameModesCombo.Enabled = !GameModesCombo.Enabled;
            MapsCombo.Enabled = !MapsCombo.Enabled;
            BotCountCombo.Enabled = !BotCountCombo.Enabled;
            AdditionalOptionsTextBox.Enabled = !AdditionalOptionsTextBox.Enabled;
            CustomUrlTextBox.Visible = !CustomUrlTextBox.Visible;
        }
    }
}
