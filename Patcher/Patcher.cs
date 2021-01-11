using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLRevive.Patcher
{
    /// <summary>
    /// Provides logic for patching BL:R game files.
    /// </summary>
    public class Patcher
    {
        public static string GameFolder;
        public static string BinariesFolder;
        public static string OriginalGameFile;
        public static string PatchedGameFile;
        public static bool ApplyEmblemPatch = true;
        public static bool InjectProxy = true;

        /// <summary>
        /// Are patched game file present ?
        /// </summary>
        public static bool IsPatched { get { return File.Exists(PatchedGameFile); } }

        /// <summary>
        /// Create patched game file;
        /// </summary>
        /// <returns>wether patching suceeded</returns>
        public static bool PatchGameFile()
        {
            try
            {
                // we cant patch files that dont exist!
                if (!File.Exists(OriginalGameFile))
                {
                    Console.WriteLine($"Cannot find game file ({OriginalGameFile})");
                    Environment.Exit(1);
                }

                // make sure server & client files are repatched
                if (File.Exists(PatchedGameFile))
                    File.Delete(PatchedGameFile);

                // patching file
                File.Copy(OriginalGameFile, PatchedGameFile);
                FileStream patchedFile = new FileStream(PatchedGameFile, FileMode.Open);
                ApplyPatches(patchedFile);
                patchedFile.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while patching gamefiles: {ex.Message}");
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
                if(ApplyEmblemPatch)
                {
                    byte[] patch = { 0x90, 0x90, 0x90, 0x90 };
                    Bin.Seek(0xB38BA6, SeekOrigin.Begin);
                    Bin.Write(patch);
                }

                // calling loadlib from engine init
                if (InjectProxy)
                {

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
                }

                Bin.Close();
            } catch(Exception ex)
            {
                Console.WriteLine($"Applying patches failed: {ex.Message}");
                return false;
            }

            return true;            
        }
    }
}
