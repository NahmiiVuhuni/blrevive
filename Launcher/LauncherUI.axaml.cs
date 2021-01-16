using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
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
            // call this only to init the Config, always user Config.GET() in this class, since UI changes it dynamically
            Config.Get();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void BGTabLaunchButton_Click(object sender, EventArgs e)
        {
            //GameLauncher.LaunchBotgame((string)BGTabMapsCombo.SelectedItem, (string)BGTabGamemodesCombo.SelectedItem, (int)BGTabBotCountNum.Value, () => this.Close());
        }
    }
}