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
            GameLauncher.LaunchBotgame((string)BGTabMapsCombo.SelectedItem, (string)BGTabGamemodesCombo.SelectedItem, (int)BGTabBotCountNum.Value, () => this.Close());
        }

        private void ClientLaunchButton_Click(object sender, EventArgs e)
        {
            if (ClientTabCustomURLCheckBox.Checked)
            {
                GameLauncher.LaunchClient("", $"{Config.DefaultLocalHostPort}", ClientTabCustomURLTextBox.Text);
            }
            else
            {
                string currentPlayerName = ClientTabPlayerNameTextBox.Text;
                if (!UserUtil.IsValidPlayerName(currentPlayerName))
                {
                    MessageBox.Show("Missing or invalid Player Name!");
                    return;
                }
                else
                {
                    UserUtil.SavePlayerName(currentPlayerName);
                }

                string currentServerAddress = ClientTabLocalConnectCheckBox.Checked ? Config.DefaultLocalHostIp : ClientTabServerAddressTextBox.Text;
                string options = $"?Name={currentPlayerName}{ClientTabLaunchOptionsTextBox.Text}";
                
                string ipString = ClientTabLocalConnectCheckBox.Checked ? currentServerAddress : NetworkUtil.GetHostIp(currentServerAddress);
                // check if the address is valid either by IP or IP resolved from server name
                if (!NetworkUtil.IsValidIPv4(ipString))
                {
                    MessageBox.Show("Could not resolve host name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // use valid server name or IP, the way the user added it 
                NetworkUtil.SaveAsPreviousServerAddress(currentServerAddress);
                Config.PreviousServerPort = (int)ClientTabServerPortNum.Value;
                Config.Save();
                GameLauncher.LaunchClient(currentServerAddress, ClientTabServerPortNum.Value.ToString(), options);
            }
        }

        private void ServerLaunchButton_Click(object sender, EventArgs e)
        {
            if (ServerTabCustomURLCheckbox.Checked)
                GameLauncher.LaunchServer(ServerTabLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabGamemodesCombo.SelectedItem, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, ServerTabLaunchOptionsTextBox.Text);
        }

        private void ClientCustomURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // this condition can be condensed simplified, keep it like this to be easy to read, that is: apply flag toggle only if not checked 
            ClientTabServerAddressTextBox.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabServerAddressTextBox.Enabled : false;
            ClientTabPlayerNameTextBox.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabPlayerNameTextBox.Enabled : false;
            ClientTabLaunchOptionsTextBox.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabLaunchOptionsTextBox.Enabled : false;
            ClientTabServerAddressSaveButton.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabServerAddressSaveButton.Enabled : false;
            ClientTabHostServersResetButton.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabHostServersResetButton.Enabled : false;
            ClientTabHostServersBackupButton.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabHostServersBackupButton.Enabled : false;
            ClientTabHostServersRestoreButton.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabHostServersRestoreButton.Enabled : false;
            ClientTabHostServersComboBox.Enabled = !ClientTabLocalConnectCheckBox.Checked ? !ClientTabHostServersComboBox.Enabled : false;

            ClientTabCustomURLTextBox.Enabled = !ClientTabCustomURLTextBox.Enabled;
            ClientTabLocalConnectCheckBox.Enabled = !ClientTabLocalConnectCheckBox.Enabled;
        }

        private void ClientLocalConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClientTabServerAddressTextBox.Enabled = !ClientTabServerAddressTextBox.Enabled;
            ClientTabServerPortNum.Enabled = !ClientTabServerPortNum.Enabled;
            ClientTabServerAddressSaveButton.Enabled = !ClientTabServerAddressSaveButton.Enabled;

            ClientTabHostServersResetButton.Enabled = !ClientTabHostServersResetButton.Enabled;
            ClientTabHostServersBackupButton.Enabled = !ClientTabHostServersBackupButton.Enabled;
            ClientTabHostServersRestoreButton.Enabled = !ClientTabHostServersRestoreButton.Enabled;
            ClientTabHostServersComboBox.Enabled = !ClientTabHostServersComboBox.Enabled;
        }

        private void ServerCustomURLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ServerTabGamemodesCombo.Enabled = !ServerTabGamemodesCombo.Enabled;
            ServerTabMapsCombo.Enabled = !ServerTabMapsCombo.Enabled;
            ServerTabBotCountNum.Enabled = !ServerTabBotCountNum.Enabled;
            ServerTabPlayerCountNum.Enabled = !ServerTabPlayerCountNum.Enabled;
            ServerTabLaunchOptionsTextBox.Enabled = !ServerTabLaunchOptionsTextBox.Enabled;
            ServerTabCustomURLTextBox.Enabled = !ServerTabCustomURLTextBox.Enabled;
            ServerTabPortNum.Enabled = !ServerTabPortNum.Enabled;
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
            bool isUpdated = NetworkUtil.UpdateHostsList((string)ClientTabServerAddressTextBox.Text);
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
            BGTabGamemodesCombo.DataSource = Config.Gamemodes;
            BGTabGamemodesCombo.SelectedIndex = 1;
            BGTabMapsCombo.DataSource = Config.Maps;
            BGTabMapsCombo.SelectedIndex = 9;
            BGTabBotCountNum.Value = 10;

            // don't select anything on initial load to prevent overwrite of PreviousServerAddress restore if exists
            ClientTabHostServersComboBox.DataSource = Config.Hosts;

            ClientTabPlayerNameTextBox.Text = UserUtil.IsValidPlayerName(Config.Username) ? Config.Username : Config.DefaultPlayerName;

            ServerTabGamemodesCombo.DataSource = Config.Gamemodes;
            ServerTabGamemodesCombo.SelectedIndex = 1;
            ServerTabMapsCombo.DataSource = Config.Maps;
            ServerTabMapsCombo.SelectedIndex = 9;
            ServerTabBotCountNum.Value = 0;
            ServerTabPlayerCountNum.Value = 16;
            
            if (!String.IsNullOrWhiteSpace(Config.PreviousServerAddress))
                ClientTabServerAddressTextBox.Text = Config.PreviousServerAddress;
            else
                Update_ClientServerAddressTextBox();
            if (Config.Get().PreviousServerPort != 0)
                ClientTabServerPortNum.Value = Config.Get().PreviousServerPort;
            else
                ClientTabServerPortNum.Value = Config.DefaultLocalHostPort;
        }

        private void Update_ClientServerAddressTextBox()
        {
            string selectedHost = (string)ClientTabHostServersComboBox.SelectedItem;
            ClientTabServerAddressTextBox.Text = !String.IsNullOrWhiteSpace(selectedHost) ? selectedHost : NetworkUtil.GetDefaultHost();
        }

        private void Update_ClientHostServersComboBox(int selectedIndex)
        {
            ClientTabHostServersComboBox.DataSource = Config.Hosts;
            ClientTabHostServersComboBox.SelectedIndex = selectedIndex;
        }
    }
}
