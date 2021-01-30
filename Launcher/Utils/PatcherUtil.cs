using System;
using System.IO;
using Serilog;
using System.Collections.Generic;

namespace Launcher.Utils
{
    public class Patcher
    {

        /// <summary>
        /// Create patched game file;
        /// </summary>
        public static void PatchGameFile(string Input, string Output,
             bool ApplyPatches = true, bool injectProxy = false)
        {
            Log.Debug("Trying to patch {0} (ApplyPatches = {1}; InjectProxy = {2})", 
            Path.GetFileName(Input), ApplyPatches, injectProxy);

            FileStream patchedFile = null;
            BinaryWriter Bin = null;
            try 
            {
                // we cant patch files that dont exist!
                if (!File.Exists(Input))
                {
                    Log.Error($"Cannot find game file ({Input})");
                    throw new UserInputException("Input file not found", new FileNotFoundException("", Input));
                }

                // patching file
                File.Copy(Input, Output, true);
                patchedFile = new FileStream(Output, FileMode.Open);
                Bin = new BinaryWriter(patchedFile);

                DisableASLR(Bin);
                if(ApplyPatches)
                    Patch(Bin);
                if(injectProxy)
                    InjectProxy(Bin, Path.GetDirectoryName(Output));

                Log.Information("Succesfully patched and saved to {0}", Output);
            } catch(Exception ex) when(
                ex.GetType() == typeof(FileNotFoundException) ||
                ex.GetType() == typeof(AccessViolationException)
            )
            {
                Log.Debug(ex, "Patching failed due to missing file (rights)");
                throw new UserInputException("Patching failed: either game file or directory is not readable/writable", ex);
            } catch(Exception ex) when(
                ex.GetType() == typeof(IOException) ||
                ex.GetType() == typeof(ArgumentException)
            )
            {
                Log.Debug(ex, "Patching failed due to input binary missmatch");
                throw new UserInputException("Patching failed: The specified file does not provide valid offsets!", ex);
            }
            catch(Exception ex) when(ex.GetType() != typeof(UserInputException))
            {
                Log.Fatal(ex, "Unhandled exception occured while patching!");
                throw;
            } finally {
                if(Bin != null)
                    Bin.Close();
                if(patchedFile != null)
                    patchedFile.Close();
            }
        }

        /// <summary>
        /// Create a static trampoline inside game file to inject proxy.dll and copy dependencies to gamefolder.
        /// </summary>
        /// <param name="Bin">file to patch</param>
        /// <param name="path">gamefolder</param>
        public static void InjectProxy(BinaryWriter Bin, string path)
        {
            if (!Directory.GetCurrentDirectory().Equals(path))
            {
                Dictionary<string, bool> deps = new Dictionary<string, bool>{
#if DEBUG
                    {"fmtd.dll", false},
#else
                    {"fmt.dll", false},
#endif
                    {"Proxy.dll", false}, 
                    { "BLRevive.json", true}
                };

                // ensure all dependencies for injection exist
                foreach(var dep in deps)
                    if(!File.Exists(Path.Join(Directory.GetCurrentDirectory(), dep.Key)))
                        throw new UserInputException("Missing file for injecting proxy! Game file will still be patched but without proxy.", new FileNotFoundException("", dep.Key));

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
            
            Log.Debug("Succesfully injected Proxy detour.");
        }

        /// <summary>
        /// Write the patches to the stream.
        /// </summary>
        /// <param name="fs">file stream to write in</param>
        protected static void Patch(BinaryWriter Bin)
        {
            // patch crash issue (setemblem patch)
            byte[] patch = { 0x90, 0x90, 0x90, 0x90 };
            Bin.Seek(0xB38BA6, SeekOrigin.Begin);
            Bin.Write(patch);

            Log.Debug("Succesfully applied patches");
        }
        
        protected static void DisableASLR(BinaryWriter Bin)
        {

            // disable aslr :)
            Bin.Seek(0x1FE, SeekOrigin.Begin);
            Bin.Write((byte)0x00);
            Log.Debug("Disabled ASLR");
        }
    }
}