A wrapper for the Unreal Engine inside BL:R. Currently used for debugging/ error fixing purposes.



## features

- logging of all UE3 events processed with `ProcessEvent`
- access to an SDK which allows direct communication with UE3 native functions



## usage

Use the patcher to apply the static injection to a BL:R gamefile.

After starting the client/server the Proxy will generate log outputs at `<BLR>\FoxGame\Logs`.



### enable/disable event logging

> WARNING: Enabling the event logging will produce ~10Mb log data in 15 seconds!
> 					Only enable this options for error/debugging purposes!

- open `<BLR>\Binaries\Win32\BLRevive.json`
- change `LogProcessEventCalls: false` to `LogProcessEventCalls: true`
- **don't forget to reset it to `false` after work!**

