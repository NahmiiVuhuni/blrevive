[![Discord](https://img.shields.io/discord/791187711184338954?label=Discord&style=flat-square)](https://discord.gg/2zGhBGED)

A user-friendly game patcher for Blacklight: Retribution. The long-term goal is to make the latest Steam release playable without limitations.



> Currently this project is still in alpha and get tested concurrently. If you want a stable version I recommend to check this page weekly or join one of our communities linked below.



## Installation

- Download the latest Blacklight: Retribution Client (version 3.02) from Steam. 

  > If you don't have BL:R in your Steam library you can get a copy here: [Old Wiki Downloads](https://gitlab.com/blrevive/docs/-/wikis/Resources).

- Download the [latest BLRevive]() release.



## Setup

This will enable local and online play for your client.

1. Download the [latest Client (v3.02)](https://gitlab.com/blrevive/docs/-/wikis/Resources)
2. Download the [latest BLRevive]() release.
3. Extract  `BLRevive.zip` and copy the contents of `BLRevive` into the base directory of your BL:R client (eg. `C:\\Program Files(x86)\\Steam\\steamapps\\common\\blacklightretribution`)
4. Verify that the `Binaries\Win32` subdirectory contains a `BLRevive.exe`



## Usage

1. Open `BLRevive.exe`
2. Choose your NetMode
3. Follow the instructions below for your selected NetMode



### NetMode

#### Local

Open the client and launch an offline botgame.

#### Online

Open the client a connect to a [MasterServer]().

#### Server

Run the [MasterServer]().



## How does it work ?

In simple words we're patching the original game file (`FoxGame-win32-Shipping.exe`) to prevent the client from crashing and adding debugging features.

1. `BLRevive.exe`: 
   - **Local** | **Online**: will start an instance of `FoxGame-win32-Shipping.exe` and inject the `BLRevive.dll` at startup. 
   - **Server**: will start the master server.
2. `BLRevive.dll`: as soon as this library gets injected into `FoxGame-win32-Shipping.exe` it does the following:
   1. Initialize a log system for BL:R which enables easier debugging
   2. Apply code fixes to prevent BL:R from crashing



>  For more details on the technical stuff read the [Wiki]().



## Legal/Copyright Notes

This whole project is GPL-licensed so you are free to use, share and fork it. Only commercial use is forbidden.
