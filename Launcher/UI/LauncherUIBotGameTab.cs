using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Utils;

namespace Launcher
{
    public partial class LauncherUI : Window
    {
        public void BGTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var BGTabMapsCombo = this.Find<ComboBox>("BGTabMapsCombo");
            var BGTabGamemodesCombo = this.Find<ComboBox>("BGTabGamemodesCombo");
            var BGTabBotCountNum = this.Find<NumericUpDown>("BGTabBotCountNum");

            GameLauncher.LaunchBotgame((string)BGTabMapsCombo.SelectedItem, (string)BGTabGamemodesCombo.SelectedItem, (int)BGTabBotCountNum.Value, () => this.Close());
        }
    }
}
