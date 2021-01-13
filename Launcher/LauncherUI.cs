using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BLRevive.Launcher
{
    public partial class LauncherUI : Form
    {
        public LauncherUI()
        {
            InitializeComponent();
            // call this only to init the Config, always user Config.GET() in this class, since UI changes it dynamically
            Config.Get();
        }

        private void BGTabLaunchButton_Click(object sender, EventArgs e)
        {
            GameLauncher.LaunchBotgame((string)BGTabMapsCombo.SelectedItem, (string)BGTabGamemodesCombo.SelectedItem, (int)BGTabBotCountNum.Value, () => this.Close());
        }

        private void ClientTabLaunchButton_Click(object sender, EventArgs e)
        {
            if (ClientTabCustomURLCheckBox.Checked)
            {
                GameLauncher.LaunchClient("", $"{Config.DefaultLocalHostServer.Port}", ClientTabCustomURLTextBox.Text);
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

                string currentServerAddress = ClientTabServerAddressTextBox.Text;
                string currentServerPort = ClientTabServerPortNum.Value.ToString();
                string options = $"?Name={currentPlayerName}{ClientTabLaunchOptionsTextBox.Text}";
                
                string ipString = NetworkUtil.GetHostIp(currentServerAddress);
                // check if the address is valid either by IP or IP resolved from server name
                if (!NetworkUtil.IsValidIPv4(ipString))
                {
                    MessageBox.Show("Could not resolve host name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // use valid server name or IP, the way the user added it 
                NetworkUtil.SaveAsPreviousServer(currentServerAddress, currentServerPort);
                // always use the IP for client cmd, DNS is not supported in the cmd 
                GameLauncher.LaunchClient(ipString, currentServerPort, options);
            }
        }

        private void ServerTabLaunchButton_Click(object sender, EventArgs e)
        {
            if (ServerTabCustomURLCheckbox.Checked)
                GameLauncher.LaunchServer(ServerTabLaunchOptionsTextBox.Text);
            else if (ServerTabPlaylistsCombo.SelectedIndex != 0)
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabGamemodesCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
        }

        private void ClientTabCustomURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ClientTabServerAddressTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabServerPortNum.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabPlayerNameTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabLaunchOptionsTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabServerAddressSaveButton.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabHostServersResetButton.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabHostServersBackupButton.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabHostServersRestoreButton.Enabled = !ClientTabCustomURLCheckBox.Checked;
            ClientTabHostServersComboBox.Enabled = !ClientTabCustomURLCheckBox.Checked;

            ClientTabCustomURLTextBox.Enabled = ClientTabCustomURLCheckBox.Checked;
        }

        private void ServerTabCustomURLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ServerTabPlaylistsCombo.Enabled = !ServerTabCustomURLCheckbox.Checked;
            ServerTabGamemodesCombo.Enabled = !ServerTabCustomURLCheckbox.Checked && ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabMapsCombo.Enabled = !ServerTabCustomURLCheckbox.Checked && ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabNameTextBox.Enabled = !ServerTabCustomURLCheckbox.Checked;
            ServerTabBotCountNum.Enabled = !ServerTabCustomURLCheckbox.Checked;
            ServerTabPlayerCountNum.Enabled = !ServerTabCustomURLCheckbox.Checked;
            ServerTabLaunchOptionsTextBox.Enabled = !ServerTabCustomURLCheckbox.Checked;
            ServerTabPortNum.Enabled = !ServerTabCustomURLCheckbox.Checked;

            ServerTabCustomURLTextBox.Enabled = ServerTabCustomURLCheckbox.Checked;
        }


        private void ClientTabHostServersComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Update_ClientTabServerAddressTextBox();
        }

        private void ClientTabHostServersResetButton_Click(object sender, EventArgs e)
        {
            NetworkUtil.ResetHostsList();
            Update_ClientTabHostServersComboBox(0);
            Update_ClientTabServerAddressTextBox();
        }

        private void ClientTabServerAddressSaveButton_Click(object sender, EventArgs e)
        {
            bool isUpdated = NetworkUtil.UpdateHostsList(new Server()
            {
                Address = ClientTabServerAddressTextBox.Text, 
                Port = ClientTabServerPortNum.Value.ToString()
            });

            if (isUpdated)
            {
                int lastAddedHostSelectionIndex;
                if (Config.Get().Hosts.Count > 0)
                    lastAddedHostSelectionIndex = Config.Get().Hosts.Count - 1;
                else
                    lastAddedHostSelectionIndex = 0;
                Update_ClientTabHostServersComboBox(lastAddedHostSelectionIndex);
            }
        }

        private void ClientTabHostServersRestoreButton_Click(object sender, EventArgs e)
        {
            bool isRestored = NetworkUtil.RestoreHostsListFromBackup();
            if (isRestored)
            {
                Update_ClientTabHostServersComboBox(0);
                MessageBox.Show($"Restored hosts list from: {HostsConfig.HostsConfigFileName}!");
            }
        }

        private void ClientTabHostServersBackupButton_Click(object sender, EventArgs e)
        {
            bool isSaved = NetworkUtil.BackupHostsList();
            if (isSaved)
            {
                MessageBox.Show($"Hosts backed-up to: {HostsConfig.HostsConfigFileName}!");
            }
        }

        private void LauncherUI_Load(object sender, EventArgs e)
        {
            BGTabGamemodesCombo.DataSource = Config.Get().Gamemodes;
            BGTabGamemodesCombo.SelectedIndex = 1;
            BGTabMapsCombo.DataSource = Config.Get().Maps;
            BGTabMapsCombo.SelectedIndex = 9;
            BGTabBotCountNum.Value = 10;

            // don't select anything on initial load to prevent overwrite of PreviousServerAddress restore if exists
            SetClientTabHostServersComboBoxDataSource();

            ClientTabPlayerNameTextBox.Text = UserUtil.IsValidPlayerName(Config.Get().Username) ? Config.Get().Username : Config.DefaultPlayerName;

            ServerTabPlaylistsCombo.DataSource = Config.Get().Playlists;
            ServerTabPlaylistsCombo.SelectedIndex = 0;
            ServerTabGamemodesCombo.DataSource = Config.Get().Gamemodes;
            ServerTabGamemodesCombo.SelectedIndex = 1;
            ServerTabMapsCombo.DataSource = Config.Get().Maps;
            ServerTabMapsCombo.SelectedIndex = 9;
            ServerTabBotCountNum.Value = 0;
            ServerTabPlayerCountNum.Value = 16;

            if (Config.Get().PreviousHost != null && !String.IsNullOrWhiteSpace(Config.Get().PreviousHost.Server.Address))
                ClientTabServerAddressTextBox.Text = Config.Get().PreviousHost.Server.Address;
            else if (Config.Get().Hosts != null && Config.Get().Hosts.Count != 0)
                Update_ClientTabServerAddressTextBox();
            if (Config.Get().PreviousHost != null && Config.Get().PreviousHost.Server.Port != null)
                ClientTabServerPortNum.Value = Int16.Parse(Config.Get().PreviousHost.Server.Port);
            else
                ClientTabServerPortNum.Value = Int16.Parse(Config.DefaultLocalHostServer.Port);

            if(String.IsNullOrEmpty(Config.Get().GameFolder))
            {
                string defaultPath = GameLauncher.GetDefaultGamePath();
                if(String.IsNullOrWhiteSpace(Config.Get().GameFolder) || !TrySetGameDirectory(defaultPath, false))
                {
                    MessageBox.Show("Could not find a valid blacklight installation. Please head over to Settings and browse to your blacklight directory.");
                    LauncherTabControl.SelectedTab = SettingsTab;
                }
            } else
            {
                TrySetGameDirectory(Config.Get().GameFolder);
            }

        }

        private void SettingsTabBlacklightDirectoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                TrySetGameDirectory(SettingsTabBlacklightDirectoryTextBox.Text);
        }

        private void Update_ClientTabServerAddressTextBox()
        {
            Server selectedHost = (Server)ClientTabHostServersComboBox.SelectedItem;
            ClientTabServerAddressTextBox.Text = !String.IsNullOrWhiteSpace(selectedHost.Address) ? selectedHost.Address : NetworkUtil.GetDefaultHostServer().Address;
            ClientTabServerPortNum.Value = !String.IsNullOrWhiteSpace(selectedHost.Port) ? Int16.Parse(selectedHost.Port) : Int16.Parse(NetworkUtil.GetDefaultHostServer().Port);
        }

        private void Update_ClientTabHostServersComboBox(int selectedIndex)
        {
            SetClientTabHostServersComboBoxDataSource();
            ClientTabHostServersComboBox.SelectedIndex = selectedIndex;
        }

        private void SetClientTabHostServersComboBoxDataSource()
        {
            // this is the name of the class/object in Hosts List, the combobox with will display a server "Address:Port", see class Server.toString() overwrite  
            ClientTabHostServersComboBox.DisplayMember = "Server"; 
            ClientTabHostServersComboBox.ValueMember = null;
            // set new list instance as data source, otherwise the combobox won't react to items changed/added inside the hosts list(combobox)  
            if (Config.Get().Hosts != null && Config.Get().Hosts.Count != 0)
                ClientTabHostServersComboBox.DataSource = Config.Get().Hosts.ToList(); 
        }

        private void PatchTabPatchFileButton_Click(object sender, EventArgs e)
        {
            GameLauncher.LaunchPatcher(PatchTabGameFileInputTextBox.Text, PatchTabGameFileOutputTextBox.Text,
                PatchTabASLROnlyCheckBox.Checked, PatchTabNoEmblemPatchCheckBox.Checked, PatchTabNoProxyInjectionCheckBox.Checked);

            if(!Directory.GetCurrentDirectory().Contains("\\Binaries\\Win32"))
            {
                File.Copy($"{Directory.GetCurrentDirectory()}\\Proxy.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\Proxy.dll", true);
#if DEBUG
                File.Copy($"{Directory.GetCurrentDirectory()}\\fmtd.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\fmtd.dll", true);
    #else
                File.Copy($"{Directory.GetCurrentDirectory()}\\fmt.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\fmt.dll", true);
    #endif
                File.Copy($"{Directory.GetCurrentDirectory()}\\BLRevive.json", $"{Config.Get().GameFolder}\\Binaries\\Win32\\BLRevive.json", true);
            }
            
            File.Copy($"{PatchTabGameFileOutputTextBox.Text}", $"{Config.Get().GameFolder}\\Binaries\\Win32\\{GameLauncher.ServerExe}", true);
        }

        private void PatchTabOpenGameFileDialogButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var folder = $"{Config.Get().GameFolder}\\Binaries\\Win32";
            if(Directory.Exists(folder))
                fileDialog.InitialDirectory = folder;
            fileDialog.Filter = "Blacklight Gamefile|*.exe";

            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PatchTabGameFileInputTextBox.Text = fileDialog.FileName;
            }
        }

        private void PatchTabASLROnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatchTabNoProxyInjectionCheckBox.Enabled = !PatchTabASLROnlyCheckBox.Checked;
        }

        private void SettingsTabBlacklightDirectoryBrowseButton_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = Config.Get().GameFolder;

            if (folderDialog.ShowDialog() == DialogResult.OK)
                TrySetGameDirectory(folderDialog.SelectedPath);
        }

        private bool TrySetGameDirectory(string path, bool displayErrors = true)
        {
            if (!Directory.Exists(path))
            {
                if(displayErrors)
                    MessageBox.Show("The path does not exist!");
                return false;
            }


            if (!GameLauncher.IsValidGameDirectory(path))
            {
                if(displayErrors)
                    MessageBox.Show("The path you selected is not a valid blacklight installation directory!");
                return false;
            }

            Config.Get().GameFolder = path;
            Config.Save();

            SettingsTabBlacklightDirectoryTextBox.Text = path;

            if(String.IsNullOrWhiteSpace(PatchTabGameFileInputTextBox.Text))
                PatchTabGameFileInputTextBox.Text = $"{path}\\Binaries\\Win32\\FoxGame-win32-Shipping.exe";

            if(String.IsNullOrWhiteSpace(PatchTabGameFileOutputTextBox.Text))
                PatchTabGameFileOutputTextBox.Text = $"{path}\\Binaries\\Win32\\FoxGame-win32-Shipping-Patched.exe";

            return true;
        }

        private void PatchTabOpenGameOutputDialogButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.FileName = "FoxGame-win32-Shipping-Patched.exe";

            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PatchTabGameFileOutputTextBox.Text = fileDialog.FileName;
            }
        }

        private void ServerTabPlaylistsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerTabGamemodesCombo.Enabled = ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabMapsCombo.Enabled = ServerTabPlaylistsCombo.SelectedIndex == 0;
        }
    }
}
