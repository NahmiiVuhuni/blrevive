using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Serilog;
using System.Windows.Forms;

namespace Bootstrapper
{
    /// <summary>
    /// Provides logic for patching BL:R game files.
    /// </summary>
    public class Patcher
    {
        /// <summary>
        /// Are patched game file present ?
        /// </summary>
        public static bool IsPatched { get { return File.Exists(GameLauncher.PatchedGameExe) && File.Exists(GameLauncher.ServerExe); } }

        /// <summary>
        /// Create patched files for client and server.
        /// </summary>
        /// <returns>wether patching suceeded</returns>
        public static bool PatchFiles()
        {
            try
            {
                // we cant patch files that dont exist!
                if (!File.Exists(GameLauncher.GameExe))
                {
                    MessageBox.Show("The original game file (FoxGame-win32-Shipping.exe) is missing!");
                    Log.Fatal("{0} is missing", GameLauncher.GameExe);
                    Environment.Exit(1);
                }

                // make sure server & client files are repatched
                if (File.Exists(GameLauncher.PatchedGameExe))
                    File.Delete(GameLauncher.PatchedGameExe);

                if (File.Exists(GameLauncher.ServerExe))
                    File.Delete(GameLauncher.ServerExe);

                // patching file
                File.Copy(GameLauncher.GameExe, GameLauncher.PatchedGameExe);
                FileStream patchedFile = new FileStream(GameLauncher.PatchedGameExe, FileMode.Open);
                ApplyPatches(patchedFile);
                patchedFile.Close();

                // create copy for server because 2 instances of Proxy accessing the same log file will crash
                // ref: https://gitlab.com/blrevive/blrevive/-/issues/13
                File.Copy(GameLauncher.PatchedGameExe, GameLauncher.ServerExe);

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal("Error while cheking game files!");
                Log.Debug(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Write the patches to the stream.
        /// </summary>
        /// <param name="fs">file stream to write in</param>
        /// <returns>wether patching succeeded</returns>
        protected static bool ApplyPatches(FileStream fs)
        {
            BinaryWriter Bin = new BinaryWriter(fs);

            try
            {
                // disable aslr :)
                Bin.Seek(0x1FE, SeekOrigin.Begin);
                Bin.Write((byte)0x00);

                // patch crash issue (setemblem patch)
                byte[] patch = { 0x90, 0x90, 0x90, 0x90 };
                Bin.Seek(0xB38BA6, SeekOrigin.Begin);
                Bin.Write(patch);

                // calling loadlib from engine init
                Bin.Seek(0x27C199, SeekOrigin.Begin);
                byte[] payload =
                    {
                    // pushad (save all registers on stack)
                    0x60,
                    // push 0x014c94d0 ("Proxy")
                    0x68, 0xD0, 0x94, 0x4c, 0x01,
                    // call loadlibrary
                    0xff, 0x15, 0x64, 0xe2, 0x49, 0x01,
                    0x61,
                    // restore original code
                    0x5F, 0x5E, 0x8B, 0xE5, 0x5D, 0xC2, 0x0C, 0x00
                };
                Bin.Write(payload);

                Bin.Close();
            } catch(Exception ex)
            {
                Log.Error("Couldn't apply patches!");
                Log.Debug(ex.Message);
                return false;
            }

            return true;            
        }
    }
}
