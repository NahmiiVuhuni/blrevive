using System;
using System.Linq;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Launcher.Utils;
using Launcher.Configuration;
using Serilog;


namespace Launcher.UI
{
    public partial class MainWindow : Window
    {
        private void ClientTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var ClientTabCustomURLCheckBox = this.Find<CheckBox>("ClientTabCustomURLCheckBox");
            var ClientTabCustomURLTextBox = this.Find<TextBox>("ClientTabCustomURLTextBox");
            var ClientTabPlayerNameTextBox = this.Find<TextBox>("ClientTabPlayerNameTextBox");
            var ClientTabServerAddressTextBox = this.Find<TextBox>("ClientTabServerAddressTextBox");
            var ClientTabServerPortNum = this.Find<NumericUpDown>("ClientTabServerPortNum");
            var ClientTabLaunchOptionsTextBox = this.Find<TextBox>("ClientTabLaunchOptionsTextBox");

            try
            {
                if (ClientTabCustomURLCheckBox.IsChecked ?? false)
                {
                    GameInstanceManager.StartClient(cfg => cfg.CustomParams = ClientTabCustomURLTextBox.Text);
                }
                else
                {
                    NetworkUtil.SaveAsPreviousServer(ClientTabServerAddressTextBox.Text, ClientTabServerPortNum.Text);
                    GameInstanceManager.StartClient(cfg => {
                        cfg.IP = ClientTabServerAddressTextBox.Text;
                        cfg.Port = (int)ClientTabServerPortNum.Value;
                        cfg.Playername = ClientTabPlayerNameTextBox.Text;
                        cfg.CustomParams = ClientTabLaunchOptionsTextBox.Text;
                    });
                }
            } 
            catch(UserInputException ex)
            {
                MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Error", ex.Message);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception when starting client!");
                throw;
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

            NetworkUtil.UpdateHostsList(new Server()
            {
                Address = ClientTabServerAddressTextBox.Text,
                Port = ClientTabServerPortNum.Value.ToString()
            });

            int lastAddedHostSelectionIndex;
            if (Config.ServerList.Hosts.Count > 0)
                lastAddedHostSelectionIndex = Config.ServerList.Hosts.Count - 1;
            else
                lastAddedHostSelectionIndex = 0;
            Update_ClientTabHostServersComboBox(lastAddedHostSelectionIndex);
        }
        private void ClientTabHostServersRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            NetworkUtil.RestoreHostsListFromBackup();
            Update_ClientTabHostServersComboBox(0);
            MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Notice", $"Restored hosts list from: {(string)Config.Hosts.GetType().GetProperty("FileName").GetValue(null)}!")
                .Show();
        }
        private void ClientTabHostServersBackupButton_Click(object sender, RoutedEventArgs e)
        {
            NetworkUtil.BackupHostsList();
            MessageBox.Avalonia.MessageBoxManager.
                GetMessageBoxStandardWindow("Notice", $"Hosts backed-up to: {(string)Config.Hosts.GetType().GetProperty("FileName").GetValue(null)}!")
                .Show();
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
            if (Config.ServerList.Hosts != null && Config.ServerList.Hosts.Count != 0)
                ClientTabHostServersComboBox.Items = Config.ServerList.Hosts.ToList();
        }
    }
}
