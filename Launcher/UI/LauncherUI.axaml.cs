using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BLRevive.Launcher
{
    public partial class LauncherUI : Window
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

    }
}