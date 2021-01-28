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
            var PatchTabProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabProxyInjectionCheckBox");

            GameLauncher.LaunchPatcher(PatchTabGameFileInputTextBox.Text, PatchTabGameFileOutputTextBox.Text,
                PatchTabASLROnlyCheckBox.IsChecked ?? false, PatchTabNoEmblemPatchCheckBox.IsChecked ?? false, PatchTabProxyInjectionCheckBox.IsChecked ?? true);

            string binPath = Path.Join(Config.App.GameFolder, "Binaries", "Win32");
            if (!Directory.GetCurrentDirectory().Contains(Path.Join("Binaries", "Win32")))
            {
                string fmtdll = null;
#if DEBUG
                fmtdll = "fmtd.dll";
#else
                fmtdll = "fmt.dll";
#endif
                File.Copy(Path.Join(Directory.GetCurrentDirectory(), fmtdll), Path.Join(binPath, fmtdll), true);
                File.Copy(Path.Join(Directory.GetCurrentDirectory(), "Proxy.dll"), Path.Join(binPath, "Proxy.dll"), true);
                if(!File.Exists(Path.Join(Directory.GetCurrentDirectory(), "BLRevive.json")))
                    File.Copy(Path.Join(Directory.GetCurrentDirectory(), "BLRevive.json"), Path.Join(binPath, "BLRevive.json"), true);
            }
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
            var PatchTabProxyInjectionCheckBox = this.Find<CheckBox>("PatchTabProxyInjectionCheckBox");
            var PatchTabASLROnlyCheckBox = this.Find<CheckBox>("PatchTabASLROnlyCheckBox");

            PatchTabProxyInjectionCheckBox.IsEnabled = !PatchTabASLROnlyCheckBox.IsChecked ?? false;
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
