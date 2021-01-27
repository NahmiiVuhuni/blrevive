using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Configuration;
using Utils;

namespace Launcher
{
    public partial class LauncherUI : Window
    {
        public LauncherUI()
        {
            // initialize app
            Config.Load();
            Logging.Initialize();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
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
            var SettingsTabGamefolderTextbox = this.Find<TextBox>("SettingsTabBlacklightDirectoryTextBox");
            var LauncherTabControl = this.Find<TabControl>("LauncherTabControl");

            BGTabGamemodesCombo.Items = Config.Game.Gamemodes;
            BGTabGamemodesCombo.SelectedIndex = 1;
            BGTabMapsCombo.Items = Config.Game.Maps;
            BGTabMapsCombo.SelectedIndex = 9;
            BGTabBotCountNum.Value = 10;

            // don't select anything on initial load to prevent overwrite of PreviousServerAddress restore if exists
            SetClientTabHostServersComboBoxDataSource();

            ClientTabPlayerNameTextBox.Text = UserUtil.IsValidPlayerName(Config.User.Username) ? Config.User.Username : Config.Defaults.PlayerName;

            ServerTabPlaylistsCombo.Items = Config.Game.Playlists;
            ServerTabPlaylistsCombo.SelectedIndex = 0;
            ServerTabGamemodesCombo.Items = Config.Game.Gamemodes;
            ServerTabGamemodesCombo.SelectedIndex = 1;
            ServerTabMapsCombo.Items = Config.Game.Maps;
            ServerTabMapsCombo.SelectedIndex = 9;
            ServerTabBotCountNum.Value = 0;
            ServerTabPlayerCountNum.Value = 16;


            // TODO: refactor this config sectioc
            if (Config.Hosts.PreviousHost != null && !String.IsNullOrWhiteSpace(Config.Hosts.PreviousHost.Address))
                ClientTabServerAddressTextBox.Text = Config.Hosts.PreviousHost.Address;
            else if (Config.ServerList.Hosts != null && Config.ServerList.Hosts.Count != 0)
                Update_ClientTabServerAddressTextBox();
            if (Config.Hosts.PreviousHost != null && Config.Hosts.PreviousHost.Port != null)
                ClientTabServerPortNum.Value = Int16.Parse(Config.Hosts.PreviousHost.Port);
            else
                ClientTabServerPortNum.Value = Int16.Parse(Config.Defaults.LocalHostServer.Port);

            if(String.IsNullOrEmpty(Config.App.GameFolder))
            {
                string defaultPath = GameLauncher.GetDefaultGamePath();
                if(String.IsNullOrWhiteSpace(Config.App.GameFolder) || !TrySetGameDirectory(defaultPath, false))
                {
                    MessageBox.Avalonia.MessageBoxManager.
                    GetMessageBoxStandardWindow("Error", "Could not find a valid blacklight installation. Please head over to Settings and browse to your blacklight directory.")
                    .Show();
                    LauncherTabControl.SelectedIndex = 5;
                    SettingsTabGamefolderTextbox.Focus();
                }
            } else
            {
                TrySetGameDirectory(Config.App.GameFolder);
            }
        }

    }
}