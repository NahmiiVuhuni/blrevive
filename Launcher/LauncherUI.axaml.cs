using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace BLRevive.Launcher
{
    public class LauncherUI : Window
    {
        public LauncherUI()
        {
            // initialize app
            Logging.Initialize();
            Config.Get();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public void BGTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var BGTabMapsCombo = this.Find<ComboBox>("BGTabMapsCombo");
            var BGTabGamemodesCombo = this.Find<ComboBox>("BGTabGamemodesCombo");
            var BGTabBotCountNum = this.Find<NumericUpDown>("BGTabBotCountNum");

            GameLauncher.LaunchBotgame((string)BGTabMapsCombo.SelectedItem, (string)BGTabGamemodesCombo.SelectedItem, (int)BGTabBotCountNum.Value, () => this.Close());
        }
        private void ClientTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var ClientTabCustomURLCheckBox = this.Find<CheckBox>("ClientTabCustomURLCheckBox");
            var ClientTabCustomURLTextBox = this.Find<TextBox>("ClientTabCustomURLTextBox");
            var ClientTabPlayerNameTextBox = this.Find<TextBox>("ClientTabPlayerNameTextBox");
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");
            var ClientTabLaunchOptionsTextBox = this.Find<TextBox>("ClientTabLaunchOptionsTextBox");

            if (ClientTabCustomURLCheckBox.IsChecked ?? false)
            {
                GameLauncher.LaunchClient("", $"{Config.DefaultLocalHostServer.Port}", ClientTabCustomURLTextBox.Text);
            }
            else
            {
                string currentPlayerName = ClientTabPlayerNameTextBox.Text;
                if (!UserUtil.IsValidPlayerName(currentPlayerName))
                {
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "Missing or invalid Player Name!")
                    .Show();
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
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "Could not resolve host name!")
                    .Show();
                    return;
                }

                // use valid server name or IP, the way the user added it 
                NetworkUtil.SaveAsPreviousServer(currentServerAddress, currentServerPort);
                // always use the IP for client cmd, DNS is not supported in the cmd 
                GameLauncher.LaunchClient(ipString, currentServerPort, options);
            }
        }
        private void ServerTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var ServerTabCustomURLCheckbox = this.Find<CheckBox>("ServerTabCustomURLCheckbox");
            var ServerTabLaunchOptionsTextBox = this.Find<TextBox>("ServerTabLaunchOptionsTextBox");
            var ServerTabPlaylistsCombo = this.Find<ComboBox>("ServerTabPlaylistsCombo");
            var ServerTabMapsCombo = this.Find<ComboBox>("ServerTabMapsCombo");
            var ServerTabNameTextBox = this.Find<TextBox>("ServerTabNameTextBox");
            var ServerTabPortNum = this.Find<NumericUpDown>("ServerTabPortNum");
            var ServerTabBotCountNum = this.Find<NumericUpDown>("ServerTabBotCountNum");
            var ServerTabPlayerCountNum = this.Find<NumericUpDown>("ServerTabPlayerCountNum");
            var ServerTabGamemodesCombo = this.Find<ComboBox>("ServerTabGamemodesCombo");

            if (ServerTabCustomURLCheckbox.IsChecked ?? false)
                GameLauncher.LaunchServer(ServerTabLaunchOptionsTextBox.Text);
            else if (ServerTabPlaylistsCombo.SelectedIndex != 0)
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabGamemodesCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
        }
        private void ClientTabCustomURLCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var ClientTabCustomURLCheckBox = this.Find<CheckBox>("ClientTabCustomURLCheckBox");
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");
            var ClientTabPlayerNameTextBox = this.Find<TextBox>("ClientTabPlayerNameTextBox");
            var ClientTabLaunchOptionsTextBox = this.Find<TextBox>("ClientTabLaunchOptionsTextBox");
            var ClientTabServerAddressSaveButton = this.Find<Button>("ClientTabServerAddressSaveButton");
            var ClientTabHostServersResetButton = this.Find<Button>("ClientTabHostServersResetButton");
            var ClientTabHostServersBackupButton = this.Find<Button>("ClientTabHostServersBackupButton");
            var ClientTabHostServersRestoreButton = this.Find<Button>("ClientTabHostServersRestoreButton");
            var ClientTabHostServersComboBox = this.Find<ComboBox>("ClientTabHostServersComboBox");
            var ClientTabCustomURLTextBox = this.Find<TextBox>("ClientTabCustomURLTextBox");

            ClientTabServerAddressTextBox.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabServerPortNum.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabPlayerNameTextBox.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabLaunchOptionsTextBox.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabServerAddressSaveButton.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabHostServersResetButton.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabHostServersBackupButton.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabHostServersRestoreButton.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;
            ClientTabHostServersComboBox.IsEnabled = !ClientTabCustomURLCheckBox.IsChecked ?? false;

            ClientTabCustomURLTextBox.IsEnabled = ClientTabCustomURLCheckBox.IsChecked ?? false;
        }
        private void ServerTabCustomURLCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var ServerTabCustomURLCheckbox = this.Find<CheckBox>("ServerTabCustomURLCheckbox");
            var ServerTabPlaylistsCombo = this.Find<ComboBox>("ServerTabPlaylistsCombo");
            var ServerTabGamemodesCombo = this.Find<ComboBox>("ServerTabGamemodesCombo");
            var ServerTabMapsCombo = this.Find<ComboBox>("ServerTabMapsCombo");
            var ServerTabNameTextBox = this.Find<TextBox>("ServerTabNameTextBox");
            var ServerTabBotCountNum = this.Find<NumericUpDown>("ServerTabBotCountNum");
            var ServerTabPlayerCountNum = this.Find<NumericUpDown>("ServerTabPlayerCountNum");
            var ServerTabLaunchOptionsTextBox = this.Find<TextBox>("ServerTabLaunchOptionsTextBox");
            var ServerTabPortNum = this.Find<NumericUpDown>("ServerTabPortNum");
            var ServerTabCustomURLTextBox = this.Find<TextBox>("ServerTabCustomURLTextBox");

            ServerTabPlaylistsCombo.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;
            ServerTabGamemodesCombo.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false && ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabMapsCombo.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false && ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabNameTextBox.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;
            ServerTabBotCountNum.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;
            ServerTabPlayerCountNum.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;
            ServerTabLaunchOptionsTextBox.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;
            ServerTabPortNum.IsEnabled = !ServerTabCustomURLCheckbox.IsChecked ?? false;

            ServerTabCustomURLTextBox.IsEnabled = ServerTabCustomURLCheckbox.IsChecked ?? false;
        }
        private void ClientTabHostServersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update_ClientTabServerAddressTextBox();
        }
        private void ClientTabHostServersResetButton_Click(object sender, RoutedEventArgs e)
        {
            NetworkUtil.ResetHostsList();
            Update_ClientTabHostServersComboBox(0);
            Update_ClientTabServerAddressTextBox();
        }
        private void ClientTabServerAddressSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");

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
        private void ClientTabHostServersRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            bool isRestored = NetworkUtil.RestoreHostsListFromBackup();
            if (isRestored)
            {
                Update_ClientTabHostServersComboBox(0);
                MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Notice", $"Restored hosts list from: {HostsConfig.HostsConfigFileName}!")
                    .Show();
            }
        }
        private void ClientTabHostServersBackupButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSaved = NetworkUtil.BackupHostsList();
            if (isSaved)
            {
                MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Notice", $"Hosts backed-up to: {HostsConfig.HostsConfigFileName}!")
                    .Show();
            }
        }
        private void LauncherWindow_Opened(object sender, EventArgs e)
        {
            var BGTabGamemodesCombo = this.Find<ComboBox>("BGTabGamemodesCombo");
            var BGTabMapsCombo = this.Find<ComboBox>("BGTabMapsCombo");
            var BGTabBotCountNum = this.Find<NumericUpDown>("BGTabBotCountNum");
            var ClientTabPlayerNameTextBox = this.Find<TextBox>("ClientTabPlayerNameTextBox");
            var ServerTabPlaylistsCombo = this.Find<ComboBox>("ServerTabPlaylistsCombo");
            var ServerTabGamemodesCombo = this.Find<ComboBox>("ServerTabGamemodesCombo");
            var ServerTabMapsCombo = this.Find<ComboBox>("ServerTabMapsCombo");
            var ServerTabBotCountNum = this.Find<NumericUpDown>("ServerTabBotCountNum");
            var ServerTabPlayerCountNum = this.Find<NumericUpDown>("ServerTabPlayerCountNum");
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");
            var LauncherTabControl = this.Find<TabControl>("LauncherTabControl");

            BGTabGamemodesCombo.Items = Config.Get().Gamemodes;
            BGTabGamemodesCombo.SelectedIndex = 1;
            BGTabMapsCombo.Items = Config.Get().Maps;
            BGTabMapsCombo.SelectedIndex = 9;
            BGTabBotCountNum.Value = 10;

            // don't select anything on initial load to prevent overwrite of PreviousServerAddress restore if exists
            SetClientTabHostServersComboBoxDataSource();

            ClientTabPlayerNameTextBox.Text = UserUtil.IsValidPlayerName(Config.Get().Username) ? Config.Get().Username : Config.DefaultPlayerName;

            ServerTabPlaylistsCombo.Items = Config.Get().Playlists;
            ServerTabPlaylistsCombo.SelectedIndex = 0;
            ServerTabGamemodesCombo.Items = Config.Get().Gamemodes;
            ServerTabGamemodesCombo.SelectedIndex = 1;
            ServerTabMapsCombo.Items = Config.Get().Maps;
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
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "Could not find a valid blacklight installation. Please head over to Settings and browse to your blacklight directory.")
                    .Show();
                    LauncherTabControl.SelectedItem = "SettingsTab";
                }
            } else
            {
                TrySetGameDirectory(Config.Get().GameFolder);
            }
        }
        private void SettingsTabBlacklightDirectoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var SettingsTabBlacklightDirectoryTextBox = this.Find<TextBox>("SettingsTabBlacklightDirectoryTextBox");

            if(e.Key == Key.Enter)
                TrySetGameDirectory(SettingsTabBlacklightDirectoryTextBox.Text);
        }

        private void Update_ClientTabServerAddressTextBox()
        {
            var ClientTabHostServersComboBox = this.Find<ComboBox>("ClientTabHostServersComboBox");
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");

            Server selectedHost = (Server)ClientTabHostServersComboBox.SelectedItem;
            ClientTabServerAddressTextBox.Text = !String.IsNullOrWhiteSpace(selectedHost.Address) ? selectedHost.Address : NetworkUtil.GetDefaultHostServer().Address;
            ClientTabServerPortNum.Value = !String.IsNullOrWhiteSpace(selectedHost.Port) ? Int16.Parse(selectedHost.Port) : Int16.Parse(NetworkUtil.GetDefaultHostServer().Port);
        }

        private void Update_ClientTabHostServersComboBox(int selectedIndex)
        {
            var ClientTabHostServersComboBox = this.Find<ComboBox>("ClientTabHostServersComboBox");

            SetClientTabHostServersComboBoxDataSource();
            ClientTabHostServersComboBox.SelectedIndex = selectedIndex;
        }

        private void SetClientTabHostServersComboBoxDataSource()
        {
            var ClientTabHostServersComboBox = this.Find<ComboBox>("ClientTabHostServersComboBox");

            // this is the name of the class/object in Hosts List, the combobox with will display a server "Address:Port", see class Server.toString() overwrite  
            // Hubok: Disabled because these don't exist. Might break things.
            //ClientTabHostServersComboBox.DisplayMember = "Server"; 
            //ClientTabHostServersComboBox.ValueMember = null;
            // set new list instance as data source, otherwise the combobox won't react to items changed/added inside the hosts list(combobox)  
            if (Config.Get().Hosts != null && Config.Get().Hosts.Count != 0)
                ClientTabHostServersComboBox.Items = Config.Get().Hosts.ToList(); 
        }

        private void PatchTabPatchFileButton_Click(object sender, RoutedEventArgs e)
        {
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");
            var PatchTabGameFileOutputTextBox = this.Find<TextBox>("PatchTabGameFileOutputTextBox");
            var PatchTabASLROnlyCheckBox = this.Find<CheckBox>("PatchTabASLROnlyCheckBox");
            var PatchTabNoEmblemPatchCheckBox = this.Find<CheckBox>("PatchTabNoEmblemPatchCheckBox");
            var PatchTabNoProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabNoProxyInjectionCheckBox");

            GameLauncher.LaunchPatcher(PatchTabGameFileInputTextBox.Text, PatchTabGameFileOutputTextBox.Text,
                PatchTabASLROnlyCheckBox.IsChecked ?? false, PatchTabNoEmblemPatchCheckBox.IsChecked ?? false, PatchTabNoProxyInjectionCheckBox.IsChecked ?? false);

            if(!Directory.GetCurrentDirectory().Contains("{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32"))
            {
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Proxy.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}Proxy.dll", true);
#if DEBUG
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}fmtd.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}fmtd.dll", true);
    #else
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}fmt.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}fmt.dll", true);
    #endif
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}BLRevive.json", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}BLRevive.json", true);
            }
            
            File.Copy($"{PatchTabGameFileOutputTextBox.Text}", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}{GameLauncher.ServerExe}", true);
        }

        private void PatchTabOpenGameInputDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");

            var fileDialog = new OpenFileDialog();
            var folder = $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32";
            if(Directory.Exists(folder))
                fileDialog.Directory = folder;
            fileDialog.Filters = new List<FileDialogFilter> { new FileDialogFilter { Extensions = new List<string> {"exe"}}};

            var result = fileDialog.ShowAsync(LauncherWindow);
            if (result.IsCompletedSuccessfully)
            {
                // Hubok: Changed because FileName doesn't exist. Might break things.
                // http://reference.avaloniaui.net/api/Avalonia.Controls/OpenFileDialog/
                PatchTabGameFileInputTextBox.Text = fileDialog.InitialFileName;
            }
        }

        private void PatchTabASLROnlyCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var PatchTabNoProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabNoProxyInjectionCheckBox");
            var PatchTabASLROnlyCheckBox = this.Find<CheckBox>("PatchTabASLROnlyCheckBox");

            PatchTabNoProxyInjectionCheckBox.IsEnabled = !PatchTabASLROnlyCheckBox.IsChecked ?? false;
        }

        private void SettingsTabBlacklightDirectoryBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");

            var folderDialog = new OpenFolderDialog();
            folderDialog.Directory = Config.Get().GameFolder;

            var result = folderDialog.ShowAsync(LauncherWindow);
            if (result.IsCompletedSuccessfully)
            {
                // http://reference.avaloniaui.net/api/Avalonia.Controls/OpenFolderDialog/
                TrySetGameDirectory(folderDialog.Directory);
            }
        }

        private bool TrySetGameDirectory(string path, bool displayErrors = true)
        {
            var SettingsTabBlacklightDirectoryTextBox = this.Find<TextBox>("SettingsTabBlacklightDirectoryTextBox");
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");
            var PatchTabGameFileOutputTextBox = this.Find<TextBox>("PatchTabGameFileOutputTextBox");

            if (!Directory.Exists(path))
            {
                if (displayErrors)
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "The path does not exist!")
                    .Show();
                return false;
            }


            if (!GameLauncher.IsValidGameDirectory(path))
            {
                if (displayErrors)
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "The path you selected is not a valid blacklight installation directory!")
                    .Show();
                return false;
            }

            Config.Get().GameFolder = path;
            Config.Save();

            SettingsTabBlacklightDirectoryTextBox.Text = path;

            if(String.IsNullOrWhiteSpace(PatchTabGameFileInputTextBox.Text))
                PatchTabGameFileInputTextBox.Text = $"{path}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}FoxGame-win32-Shipping.exe";

            if(String.IsNullOrWhiteSpace(PatchTabGameFileOutputTextBox.Text))
                PatchTabGameFileOutputTextBox.Text = $"{path}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}FoxGame-win32-Shipping-Patched.exe";

            return true;
        }

        private void PatchTabOpenGameOutputDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");
            var PatchTabGameFileOutputTextBox = this.Find<TextBox>("PatchTabGameFileOutputTextBox");

            var fileDialog = new SaveFileDialog();
            fileDialog.Directory = Directory.GetCurrentDirectory();
            fileDialog.InitialFileName = "FoxGame-win32-Shipping-Patched.exe";

            var result = fileDialog.ShowAsync(LauncherWindow);
            if (result.IsCompletedSuccessfully)
            {
                // http://reference.avaloniaui.net/api/Avalonia.Controls/SaveFileDialog/
                PatchTabGameFileOutputTextBox.Text = fileDialog.InitialFileName;
            }
        }

        private void ServerTabPlaylistsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ServerTabGamemodesCombo = this.Find<ComboBox>("ServerTabGamemodesCombo");
            var ServerTabPlaylistsCombo = this.Find<ComboBox>("ServerTabPlaylistsCombo");
            var ServerTabMapsCombo = this.Find<ComboBox>("ServerTabMapsCombo");

            ServerTabGamemodesCombo.IsEnabled = ServerTabPlaylistsCombo.SelectedIndex == 0;
            ServerTabMapsCombo.IsEnabled = ServerTabPlaylistsCombo.SelectedIndex == 0;
        }
    }
}