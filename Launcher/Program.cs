using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLRevive.Launcher
{
    static class Program
    {
        /// <summary>
        /// Main thread.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // initialize app
            Logging.Initialize();
            Config.Get();

            // run gui
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherUI());
        }
    }
}
