using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace Bootstrapper
{
    public partial class LauncherUI : Form
    {
        protected Config Config;

        public LauncherUI()
        {
            InitializeComponent();
            Config = Bootstrapper.Config.Get();
        }

        private void BGLaunchButton_Click(object sender, EventArgs e)
        {
            GameLauncher.LaunchBotgame((string)BGMapsCombo.SelectedItem, (string)BGGamemodesCombo.SelectedItem, (int)BGBotCountNum.Value, () => this.Close());
        }

        private void ClientLaunchButton_Click(object sender, EventArgs e)
        {
            Config.Username = ClientPlayerNameTextBox.Text;
            Config.Save();

            if (ClientCustomURLCheckBox.Checked)
            {
                GameLauncher.LaunchClient("", ClientCustomURLTextBox.Text);
            }
            else
            {
                string options = $"?Name={ClientPlayerNameTextBox.Text}{ClientLaunchOptionsTextBox.Text}";
                string  ipString = ClientIPTextBox.Text;
                if (!Regex.IsMatch(ipString, "^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$"))
                {
                    try
                    {
                        IPAddress ipAddress = Dns.GetHostAddresses(ipString).First();
                        ipString = ipAddress.ToString();
                    }
                    catch (Exception exception)
                    {
                        Log.Error("Could not resolve host name: {0}", ipString);
                        MessageBox.Show("Could not resolve host name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                GameLauncher.LaunchClient(ipString, options);
            }
        }

        private void ServerLaunchButton_Click(object sender, EventArgs e)
        {
            if (ServerCustomURLCheckbox.Checked)
                GameLauncher.LaunchServer(ServerLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerMapsCombo.SelectedItem, (string)ServerGamemodesCombo.SelectedItem, (int)ServerBotCountNum.Value, (int)ServerPlayerCountNum.Value, ServerLaunchOptionsTextBox.Text);
        }

        private void ClientCustomURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClientIPTextBox.Enabled = !ClientIPTextBox.Enabled;
            ClientPlayerNameTextBox.Enabled = !ClientPlayerNameTextBox.Enabled;
            ClientLaunchOptionsTextBox.Enabled = !ClientLaunchOptionsTextBox.Enabled;
            ClientCustomURLTextBox.Enabled = !ClientCustomURLTextBox.Enabled;
        }

        private void ServerCustomURLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ServerGamemodesCombo.Enabled = !ServerGamemodesCombo.Enabled;
            ServerMapsCombo.Enabled = !ServerMapsCombo.Enabled;
            ServerBotCountNum.Enabled = !ServerBotCountNum.Enabled;
            ServerPlayerCountNum.Enabled = !ServerPlayerCountNum.Enabled;
            ServerLaunchOptionsTextBox.Enabled = !ServerLaunchOptionsTextBox.Enabled;
            ServerCustomURLTextBox.Enabled = !ServerCustomURLTextBox.Enabled;
        }
        private void LauncherUI_Load(object sender, EventArgs e)
        {
            BGGamemodesCombo.DataSource = Config.Gamemodes;
            BGGamemodesCombo.SelectedIndex = 1;
            BGMapsCombo.DataSource = Config.Maps;
            BGMapsCombo.SelectedIndex = 9;
            BGBotCountNum.Value = 10;

            if (Config.Username != null)
                ClientPlayerNameTextBox.Text = Config.Username;
            else
                ClientPlayerNameTextBox.Text = "Player";

            ServerGamemodesCombo.DataSource = Config.Gamemodes;
            ServerGamemodesCombo.SelectedIndex = 1;
            ServerMapsCombo.DataSource = Config.Maps;
            ServerMapsCombo.SelectedIndex = 9;
            ServerBotCountNum.Value = 0;
            ServerPlayerCountNum.Value = 16;
        }

        private void BotMatchTab_Click(object sender, EventArgs e)
        {

        }
    }
}
