using System;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Utils;
using Configuration;

namespace Launcher
{
    public partial class LauncherUI : Window
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

            if (ServerTabCustomURLCheckbox.IsChecked ?? false)
                GameLauncher.LaunchServer(ServerTabLaunchOptionsTextBox.Text);
            else if (ServerTabPlaylistsCombo.SelectedIndex != 0)
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
            else
                GameLauncher.LaunchServer((string)ServerTabMapsCombo.SelectedItem, (string)ServerTabGamemodesCombo.SelectedItem, ServerTabNameTextBox.Text, (int)ServerTabPortNum.Value, (int)ServerTabBotCountNum.Value, (int)ServerTabPlayerCountNum.Value, (string)ServerTabPlaylistsCombo.SelectedItem, ServerTabLaunchOptionsTextBox.Text);
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
