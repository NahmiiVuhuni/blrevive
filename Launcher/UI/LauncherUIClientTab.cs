using System;
using System.Linq;
using Avalonia.Interactivity;
using Avalonia.Controls;

namespace BLRevive.Launcher
{
    public partial class LauncherUI : Window
    {
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
    }
}
