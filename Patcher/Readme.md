A CLI tool which takes a Blacklight: Retribution gamefile (`FoxGame-win32-Shipping.exe`) and generates an output with several binary changes.



## usage

Synopsis: `Patcher.exe <input> <options>`

### options

- `--output=<file>` save patched file to a custom path (defaults to `FoxGame-win32-Shipping-Patched.exe`)
- `--no-emblem-patch` disables patching of the as_SetEmblem crash issue
- `--no-proxy` disables static injection of Proxy.dll
- `--aslr-only` only disable aslr





## development



### prerequisites

- Visual Studio 2019
- C#
- .NET Framework 4+



### setup environment

- clone BLRevive: `git clone --recursive git@gitlab.com:blrevive/blrevive`
- open solution with VS2019
- set Patcher as solution build target



#  patches explaination

The tool will apply three patches by default:

- *Emblem Patch*: fixes an issue that was preventing BL:R clients from connecting to server
- *Proxy Injection*: places a static code cave into BL:R which loads the Proxy.dll at startup
- *ASLR*: disable aslr for static code cave & easier analysis