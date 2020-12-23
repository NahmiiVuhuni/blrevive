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
    }
}
