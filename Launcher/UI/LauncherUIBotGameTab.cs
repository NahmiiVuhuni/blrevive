using Avalonia.Interactivity;
using Avalonia.Controls;
using Launcher.Utils;
using System;
using Serilog;

namespace Launcher.UI
{
    public partial class MainWindow : Window
    {
        public void BGTabLaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var BGTabMapsCombo = this.Find<ComboBox>("BGTabMapsCombo");
            var BGTabGamemodesCombo = this.Find<ComboBox>("BGTabGamemodesCombo");
            var BGTabBotCountNum = this.Find<NumericUpDown>("BGTabBotCountNum");

            try
            {
                GameInstanceManager.StartServer( cfg => {
                    cfg.Map = (string)BGTabMapsCombo.SelectedItem;
                    cfg.Gamemode = (string)BGTabGamemodesCombo.SelectedItem;
                    cfg.BotCount = (int)BGTabBotCountNum.Value;
                });

                GameInstanceManager.StartClient( cfg => {
                    cfg.IP = "127.0.0.1";
                    cfg.Playername = "Player";
                });
            } 
            catch(UserInputException ex) 
            {
                MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Error", ex.Message).Show();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception while starting botgame!");
            }
        }
    }
}
