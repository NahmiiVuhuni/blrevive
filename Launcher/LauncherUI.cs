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
                GameLauncher.LaunchClient(currentServerAddress, currentServerPort, options);
            }
        }

        private void ServerTabLaunchButton_Click(object sender, EventArgs e)
        {
            if (ServerTabCustomURLCheckbox.Checked)
                GameLauncher.LaunchServer(ServerTabLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabGamemodesCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, ServerTabLaunchOptionsTextBox.Text);
        }

        private void ClientTabCustomURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // this condition can be condensed simplified, keep it like this to be easy to read, that is: apply flag toggle only if not checked 
            ClientTabServerAddressTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabServerAddressTextBox.Enabled : false;
            ClientTabServerPortNum.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabServerPortNum.Enabled : false;
            ClientTabPlayerNameTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabPlayerNameTextBox.Enabled : false;
            ClientTabLaunchOptionsTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabLaunchOptionsTextBox.Enabled : false;
            ClientTabServerAddressSaveButton.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabServerAddressSaveButton.Enabled : false;
            ClientTabHostServersResetButton.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabHostServersResetButton.Enabled : false;
            ClientTabHostServersBackupButton.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabHostServersBackupButton.Enabled : false;
            ClientTabHostServersRestoreButton.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabHostServersRestoreButton.Enabled : false;
            ClientTabHostServersComboBox.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabHostServersComboBox.Enabled : false;

            ClientTabCustomURLTextBox.Enabled = !ClientTabCustomURLCheckBox.Checked ? !ClientTabCustomURLTextBox.Enabled : false;
        }

        private void ServerTabCustomURLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ServerTabGamemodesCombo.Enabled = !ServerTabGamemodesCombo.Enabled;
            ServerTabMapsCombo.Enabled = !ServerTabMapsCombo.Enabled;
            ServerTabBotCountNum.Enabled = !ServerTabBotCountNum.Enabled;
            ServerTabPlayerCountNum.Enabled = !ServerTabPlayerCountNum.Enabled;
            ServerTabLaunchOptionsTextBox.Enabled = !ServerTabLaunchOptionsTextBox.Enabled;
            ServerTabCustomURLTextBox.Enabled = !ServerTabCustomURLTextBox.Enabled;
            ServerTabPortNum.Enabled = !ServerTabPortNum.Enabled;
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

            if(Config.Get().GameFolder == null || String.IsNullOrWhiteSpace(Config.Get().GameFolder))
            {
                var defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\blacklightretribution";
                if (!Directory.Exists(defaultPath))
                    MessageBox.Show("Couldn't find a valid Blacklight: Retribution install directory. Please head to the Settings tab and fix the Game Folder!");
                else
                {
                    Config.Get().GameFolder = defaultPath;
                    Config.Save();
                }
            }
            SettingsTabBlacklightDirectoryTextBox.Text = Config.Get().GameFolder;

            PatchTabGameFileInputTextBox.Text = $"{Config.Get().GameFolder}\\Binaries\\Win32\\FoxGame-win32-Shipping.exe";
            PatchTabGameFileOutputTextBox.Text = $"{Config.Get().GameFolder}\\Binaries\\Win32\\FoxGame-win32-Shipping-Patched.exe";
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


            File.Copy($"{Directory.GetCurrentDirectory()}\\Proxy.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\Proxy.dll", true);
#if DEBUG
            File.Copy($"{Directory.GetCurrentDirectory()}\\fmtd.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\fmtd.dll", true);
#else
            File.Copy($"{Directory.GetCurrentDirectory()}\\fmt.dll", $"{Config.Get().GameFolder}\\Binaries\\Win32\\fmt.dll", true);
#endif
            File.Copy($"{Directory.GetCurrentDirectory()}\\BLRevive.json", $"{Config.Get().GameFolder}\\Binaries\\Win32\\BLRevive.json", true);
            File.Copy($"{PatchTabGameFileOutputTextBox.Text}", $"{Config.Get().GameFolder}\\Binaries\\Win32\\{GameLauncher.ServerExe}", true);
        }

        private void PatchTabOpenGameFileDialogButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var folder = $"{Config.Get().GameFolder}\\Binaries\\Win32";
            if(Directory.Exists(folder))
                fileDialog.InitialDirectory = folder;
            fileDialog.Filter = "Blacklight Gamefile (FoxGame-win32-Shipping.exe)";

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

            if(folderDialog.ShowDialog() == DialogResult.OK && !String.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                if(!Directory.Exists($"{folderDialog.SelectedPath}\\Binaries\\Win32") ||
                    !Directory.Exists($"{folderDialog.SelectedPath}\\FoxGame\\Logs"))
                {
                    MessageBox.Show("The path you selected is not a valid blacklight installation directory!");
                }
                else
                {
                    SettingsTabBlacklightDirectoryTextBox.Text = folderDialog.SelectedPath;
                    Config.Get().GameFolder = folderDialog.SelectedPath;
                    Config.Save();
                }
            }
        }

        private void PatchTabOpenGameOutputDialogButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.DefaultExt = ".exe";
            fileDialog.FileName = "FoxGame-win32-Shipping-Patched.exe";

            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PatchTabGameFileOutputTextBox.Text = fileDialog.FileName;
            }
        }
    }
}
