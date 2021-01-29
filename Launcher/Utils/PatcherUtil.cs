using System;
using System.IO;
using Serilog;
using System.Collections.Generic;

namespace Utils
{
    public class Patcher
    {

        /// <summary>
        /// Create patched game file;
        /// </summary>
        /// <returns>wether patching suceeded</returns>
        public static bool PatchGameFile(string Input, string Output,
             bool ApplyPatches = true, bool injectProxy = false)
        {
            try
            {
                // we cant patch files that dont exist!
                if (!File.Exists(Input))
                {
                    Log.Error($"Cannot find game file ({Input})");
                    Environment.Exit(1);
                }

                // patching file
                File.Copy(Input, Output, true);
                FileStream patchedFile = new FileStream(Output, FileMode.Open);
                BinaryWriter Bin = new BinaryWriter(patchedFile);
                DisableASLR(Bin);
                if(ApplyPatches)
                    Patch(Bin);
                if(injectProxy)
                    InjectProxy(Bin, Path.GetDirectoryName(Output));
                Bin.Close();
                patchedFile.Close();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"Error while patching gamefiles: {ex.Message}");
                return false;
            }
        }

        public static bool InjectProxy(BinaryWriter Bin, string path)
        {
            if (!Directory.GetCurrentDirectory().Equals(path))
            {
                Dictionary<string, bool> deps = new Dictionary<string, bool>{
#if DEBUG
                    {"fmtd.dll", false},
#else
                    {"fmt.dll", false},
#endif
                    {"Proxy.dll", false}, { "BLRevive.json", true}
                };

                // ensure all dependencies for injection exist
                foreach(var dep in deps)
                {
                    if(!File.Exists(Path.Join(Directory.GetCurrentDirectory(), dep.Key)))
                    {
                        Log.Error($"{dep} was not found!");
                        return false;
                    }
                }

                // copy dependencies
                foreach(var dep in deps)
                {
                    if(dep.Value && File.Exists(Path.Join(path, dep.Key)))
                        continue;
                    File.Copy(Path.Join(Directory.GetCurrentDirectory(), dep.Key), Path.Join(path, dep.Key));
                }
            }

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

            return true;
        }

        /// <summary>
        /// Write the patches to the stream.
        /// </summary>
        /// <param name="fs">file stream to write in</param>
        /// <returns>wether patching succeeded</returns>
        protected static bool Patch(BinaryWriter Bin)
        {
            try
            {
                // patch crash issue (setemblem patch)
                byte[] patch = { 0x90, 0x90, 0x90, 0x90 };
                Bin.Seek(0xB38BA6, SeekOrigin.Begin);
                Bin.Write(patch);
            } catch(Exception ex)
            {
                Log.Error($"Applying patches failed: {ex.Message}");
                return false;
            }

            return true;            
        }
        
        protected static void DisableASLR(BinaryWriter Bin)
        {
            // disable aslr :)
            Bin.Seek(0x1FE, SeekOrigin.Begin);
            Bin.Write((byte)0x00);
        }
    }
}