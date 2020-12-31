using System;
using System.Windows.Forms;

namespace Bootstrapper
{
    public partial class LauncherUI : Form
    {
        protected Config Config;

        public LauncherUI()
        {
            InitializeComponent();
            Config = Config.Get();
        }

        private void BGLaunchButton_Click(object sender, EventArgs e)
        {
            GameLauncher.LaunchBotgame((string)BGMapsCombo.SelectedItem, (string)BGGamemodesCombo.SelectedItem, (int)BGBotCountNum.Value, () => this.Close());
        }

        private void ClientLaunchButton_Click(object sender, EventArgs e)
        {
            if (ClientCustomURLCheckBox.Checked)
            {
                GameLauncher.LaunchClient("", ClientCustomURLTextBox.Text);
            }
            else
            {
                string currentPlayerName = ClientPlayerNameTextBox.Text;
                if (!UserUtil.IsValidPlayerName(currentPlayerName))
                {
                    MessageBox.Show("Missing or invalid Player Name!");
                    return;
                }
                else
                {
                    UserUtil.SavePlayerName(currentPlayerName);
                }

                string currentServerAddress = ClientLocalConnectCheckBox.Checked ? Config.DefaultLocalHostIp : ClientServerAddressTextBox.Text;
                string options = $"?Name={currentPlayerName}{ClientLaunchOptionsTextBox.Text}";
                
                string ipString = ClientLocalConnectCheckBox.Checked ? currentServerAddress : NetworkUtil.GetHostIp(currentServerAddress);
                // check if the address is valid either by IP or IP resolved from server name
                if (!NetworkUtil.IsValidIPv4(ipString))
                {
                    MessageBox.Show("Could not resolve host name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // use valid server name or IP, the way the user added it 
                NetworkUtil.SaveAsPreviousServerAddress(currentServerAddress);
                GameLauncher.LaunchClient(currentServerAddress, options);
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
            // this condition can be condensed simplified, keep it like this to be easy to read, that is: apply flag toggle only if not checked 
            ClientServerAddressLable.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientServerAddressLable.Enabled : false;
            ClientServerAddressTextBox.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientServerAddressTextBox.Enabled : false;
            ClientPlayerNameTextBox.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientPlayerNameTextBox.Enabled : false;
            ClientPlayerNameLabel.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientPlayerNameLabel.Enabled : false;
            ClientLaunchOptionsTextBox.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientLaunchOptionsTextBox.Enabled : false;
            ClientServerAddressSaveButton.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientServerAddressSaveButton.Enabled : false;
            ClientHostServersResetButton.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientHostServersResetButton.Enabled : false;
            ClientHostServersRestoreButton.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientHostServersRestoreButton.Enabled : false;
            ClientHostServersComboBox.Enabled = !ClientLocalConnectCheckBox.Checked ? !ClientHostServersComboBox.Enabled : false;

            ClientCustomURLTextBox.Enabled = !ClientCustomURLTextBox.Enabled;
            ClientLocalConnectCheckBox.Enabled = !ClientLocalConnectCheckBox.Enabled;
        }

        private void ClientLocalConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClientServerAddressLable.Enabled = !ClientServerAddressLable.Enabled;
            ClientServerAddressTextBox.Enabled = !ClientServerAddressTextBox.Enabled;
            ClientServerAddressSaveButton.Enabled = !ClientServerAddressSaveButton.Enabled;

            ClientPlayerNameLabel.Enabled = !ClientPlayerNameLabel.Enabled;
            ClientPlayerNameTextBox.Enabled = !ClientPlayerNameTextBox.Enabled;
            ClientLaunchOptionsLable.Enabled = !ClientLaunchOptionsTextBox.Enabled;
            ClientLaunchOptionsTextBox.Enabled = !ClientLaunchOptionsTextBox.Enabled;

            ClientHostServersResetButton.Enabled = !ClientHostServersResetButton.Enabled;
            ClientHostServersRestoreButton.Enabled = !ClientHostServersRestoreButton.Enabled;
            ClientHostServersComboBox.Enabled = !ClientHostServersComboBox.Enabled;
            ClientHostServersLable.Enabled = !ClientHostServersLable.Enabled;
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

        private void ClientHostServersComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Update_ClientServerAddressTextBox();
        }

        private void ClientHostServersResetButton_Click(object sender, EventArgs e)
        {
            NetworkUtil.ResetHostsList();
            Update_ClientHostServersComboBox(0);
            Update_ClientServerAddressTextBox();
        }

        private void ClientServerAddressSaveButton_Click(object sender, EventArgs e)
        {
            bool isUpdated = NetworkUtil.UpdateHostsList((string)ClientServerAddressTextBox.Text);
            if (isUpdated)
            {
                int lastAddedHostSelectionIndex = Config.Hosts.Length - 1;
                Update_ClientHostServersComboBox(lastAddedHostSelectionIndex);
            }
        }

        private void ClientHostServersRestoreButton_Click(object sender, EventArgs e)
        {
            bool isRestored = NetworkUtil.RestoreHostsListFromBackup();
            if (isRestored)
            {
                Update_ClientHostServersComboBox(0);
                MessageBox.Show($"Restored successfully the hosts list from: {HostsConfig.HostsConfigFileName} !");
            }
        }

        private void ClientHostServersBackupButton_Click(object sender, EventArgs e)
        {
            bool isSaved = NetworkUtil.BackupHostsList();
            if (isSaved)
            {
                MessageBox.Show($"Hosts backup completed successfully to: {HostsConfig.HostsConfigFileName} !");
            }
        }

        private void LauncherUI_Load(object sender, EventArgs e)
        {
            BGGamemodesCombo.DataSource = Config.Gamemodes;
            BGGamemodesCombo.SelectedIndex = 1;
            BGMapsCombo.DataSource = Config.Maps;
            BGMapsCombo.SelectedIndex = 9;
            BGBotCountNum.Value = 10;

            // don't select anything on initial load to prevent overwrite of PreviousServerAddress restore if exists
            ClientHostServersComboBox.DataSource = Config.Hosts;

            ClientPlayerNameTextBox.Text = UserUtil.IsValidPlayerName(Config.Username) ? Config.Username : Config.DefaultPlayerName;

            ServerGamemodesCombo.DataSource = Config.Gamemodes;
            ServerGamemodesCombo.SelectedIndex = 1;
            ServerMapsCombo.DataSource = Config.Maps;
            ServerMapsCombo.SelectedIndex = 9;
            ServerBotCountNum.Value = 0;
            ServerPlayerCountNum.Value = 16;
            
            if (!String.IsNullOrWhiteSpace(Config.PreviousServerAddress))
                ClientServerAddressTextBox.Text = Config.PreviousServerAddress;
            else
                Update_ClientServerAddressTextBox();
        }

        private void Update_ClientServerAddressTextBox()
        {
            string selectedHost = (string)ClientHostServersComboBox.SelectedItem;
            ClientServerAddressTextBox.Text = !String.IsNullOrWhiteSpace(selectedHost) ? selectedHost : NetworkUtil.GetDefaultHost();
        }

        private void Update_ClientHostServersComboBox(int selectedIndex)
        {
            ClientHostServersComboBox.DataSource = Config.Hosts;
            ClientHostServersComboBox.SelectedIndex = selectedIndex;
        }
    }
}
