A cross-platform GUI for guidance through setting up BL:R clients with our patches & proxy.

## usage

For detailed usage instructions look at our Wiki: [Installing & Using BLRevive](https://gitlab.com/blrevive/blrevive/-/wikis/Installing-&-Using-BLRevive).

## development

### linux

#### prerequisites

- Git
- .NET5 SDK
- (recommended) Visual Studio Code

#### setup environment

- clone repository
- open repo in VS Code (`code .` inside repo)

#### debugging

Debugging is provided with the `.vscode/<settings>.json` so you can use the menu in any IDE which detects those files.

- select `Launcher (Debug)` from run tasks in vs code

### windows

#### prerequisites

- Git
- .NET5 SDK
- (recommended) Visual Studio

### building

- for linux builds: `dotnet build -c <Config> -p:Platform=Linux`
- for windows builds: `dotnet build -c <Config> -p:Platform=Windows`

### publish

- for linux: `dotnet publish -c Release -p:Platform=Linux`
- for windows: `dotnet publish -c Release -p:Platform=Windows`