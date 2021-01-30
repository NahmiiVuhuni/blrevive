using System;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Launcher.Utils;
using Launcher.Configuration;
using Serilog;

namespace Launcher.UI
{
    public partial class MainWindow : Window
    {
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

            try
            {
                if (ServerTabCustomURLCheckbox.IsChecked ?? false)
                {
                    GameInstanceManager.StartServer(cfg => cfg.CustomParams = ServerTabLaunchOptionsTextBox.Text);
                }
                else if (ServerTabPlaylistsCombo.SelectedIndex != 0)
                {
                    GameInstanceManager.StartServer(cfg => {
                        cfg.Map = (string)ServerTabMapsCombo.SelectedItem;
                        cfg.Playlist = (string)ServerTabPlaylistsCombo.SelectedItem;
                        cfg.Gamemode = (string)ServerTabGamemodesCombo.SelectedItem;
                        cfg.Servername = ServerTabNameTextBox.Text;
                        cfg.Port = (int)ServerTabPortNum.Value;
                        cfg.BotCount = (int)ServerTabBotCountNum.Value;
                        cfg.MaxPlayers = (int)ServerTabPlayerCountNum.Value;
                    });
                }
            } catch(UserInputException ex) {
                MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Error", ex.Message);
            } catch(Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception while starting process");
                throw;
            }
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
