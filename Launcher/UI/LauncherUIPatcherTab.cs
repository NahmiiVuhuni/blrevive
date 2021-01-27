using System;
using System.IO;
using System.Collections.Generic;
using Avalonia.Interactivity;
using Avalonia.Controls;

namespace BLRevive.Launcher
{
    public partial class LauncherUI : Window
    {
        private void PatchTabPatchFileButton_Click(object sender, RoutedEventArgs e)
        {
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");
            var PatchTabGameFileOutputTextBox = this.Find<TextBox>("PatchTabGameFileOutputTextBox");
            var PatchTabASLROnlyCheckBox = this.Find<CheckBox>("PatchTabASLROnlyCheckBox");
            var PatchTabNoEmblemPatchCheckBox = this.Find<CheckBox>("PatchTabNoEmblemPatchCheckBox");
            var PatchTabNoProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabNoProxyInjectionCheckBox");

            GameLauncher.LaunchPatcher(PatchTabGameFileInputTextBox.Text, PatchTabGameFileOutputTextBox.Text,
                PatchTabASLROnlyCheckBox.IsChecked ?? false, PatchTabNoEmblemPatchCheckBox.IsChecked ?? false, PatchTabNoProxyInjectionCheckBox.IsChecked ?? false);

            if (!Directory.GetCurrentDirectory().Contains($"{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32"))
            {
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Proxy.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}Proxy.dll", true);
#if DEBUG
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}fmtd.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}fmtd.dll", true);
#else
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}fmt.dll", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}fmt.dll", true);
#endif
                File.Copy($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}BLRevive.json", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}BLRevive.json", true);
            }

            File.Copy($"{PatchTabGameFileOutputTextBox.Text}", $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32{Path.DirectorySeparatorChar}{GameLauncher.ServerExe}", true);
        }

        private async void PatchTabOpenGameInputDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");

            var fileDialog = new OpenFileDialog();
            var folder = $"{Config.Get().GameFolder}{Path.DirectorySeparatorChar}Binaries{Path.DirectorySeparatorChar}Win32";
            if (Directory.Exists(folder))
                fileDialog.Directory = folder;
            fileDialog.Filters = new List<FileDialogFilter> { new FileDialogFilter { Extensions = new List<string> { "exe" } } };

            var result = await fileDialog.ShowAsync(LauncherWindow);
            if (result != null)
            {
                // Hubok: Changed because FileName doesn't exist. Might break things.
                // http://reference.avaloniaui.net/api/Avalonia.Controls/OpenFileDialog/
                PatchTabGameFileInputTextBox.Text = fileDialog.InitialFileName;
            }
        }

        private void PatchTabASLROnlyCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var PatchTabNoProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabNoProxyInjectionCheckBox");
            var PatchTabASLROnlyCheckBox = this.Find<CheckBox>("PatchTabASLROnlyCheckBox");

            PatchTabNoProxyInjectionCheckBox.IsEnabled = !PatchTabASLROnlyCheckBox.IsChecked ?? false;
        }

        private async void PatchTabOpenGameOutputDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");
            var PatchTabGameFileOutputTextBox = this.Find<TextBox>("PatchTabGameFileOutputTextBox");

            var fileDialog = new SaveFileDialog();
            fileDialog.Directory = Directory.GetCurrentDirectory();
            fileDialog.InitialFileName = "FoxGame-win32-Shipping-Patched.exe";

            var result = await fileDialog.ShowAsync(LauncherWindow);
            if (result != null)
            {
                // http://reference.avaloniaui.net/api/Avalonia.Controls/SaveFileDialog/
                PatchTabGameFileOutputTextBox.Text = fileDialog.InitialFileName;
            }
        }
    }
}
