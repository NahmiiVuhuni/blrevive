using System;
using System.IO;
using System.Collections.Generic;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Utils;
using Configuration;

namespace Launcher
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

            string binPath = Path.Join(Config.App.GameFolder, "Binaries", "Win32");
            if (!Directory.GetCurrentDirectory().Contains(Path.Join("Binaries", "Win32")))
            {
                string fmtdll = null;
#if DEBUG
                fmtdll = "fmtd.dll";
#else
                fmtdll = "fmt.dll";
#endif
                File.Copy(Path.Join(Directory.GetCurrentDirectory(), fmtdll), Path.Join(binPath, fmtdll));
                File.Copy(Path.Join(Directory.GetCurrentDirectory(), "Proxy.dll"), Path.Join(binPath, "Proxy.dll"));
                File.Copy(Path.Join(Directory.GetCurrentDirectory(), "BLRevive.json"), Path.Join(binPath, "BLRevive.json"));
            }

            File.Copy($"{PatchTabGameFileOutputTextBox.Text}", Path.Join(binPath, GameLauncher.ServerExe));
        }

        private async void PatchTabOpenGameInputDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var LauncherWindow = this.Find<Window>("LauncherWindow");
            var PatchTabGameFileInputTextBox = this.Find<TextBox>("PatchTabGameFileInputTextBox");

            var fileDialog = new OpenFileDialog();
            var folder = Path.Join(Config.App.GameFolder, "Binaries", "Win32");
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
