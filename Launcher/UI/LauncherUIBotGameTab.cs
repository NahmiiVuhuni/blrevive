using Avalonia.Interactivity;
using Avalonia.Controls;
using Launcher.Utils;

namespace Launcher.UI
{
    public partial class MainWindow : Window
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
