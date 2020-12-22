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
    public partial class BotgameLauncher : Form
    {
        public BotgameLauncher()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameLauncher.LaunchBotgame((string)MapsCombo.SelectedItem, (string)GameModesCombo.SelectedItem, () => this.Close());
        }

        private void BotgameLauncher_Load(object sender, EventArgs e)
        {
            GameModesCombo.DataSource = GameLauncher.GetConfig().GameModes;
            GameModesCombo.SelectedIndex = 1;
            MapsCombo.DataSource = GameLauncher.GetConfig().Maps;
            MapsCombo.SelectedIndex = 9;
        }
    }
}
