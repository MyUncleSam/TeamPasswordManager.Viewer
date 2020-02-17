# Readme
This is an unoficial Windows Client for https://teampasswordmanager.com/ (TPM).
Use at your own risk!

# Requirements
* Pro version of TPM to be able to access the API.
* Enabled TPM API access to your team password manager.

# Features
* Search tree and list entries easily
* Different list styles selectable
* Autostart possible (using windows task scheduler logon option)
* Google 2FA support using custom fields
* Portable
* Working API Access to basic functions needed for UI
* Full access to UI controls (use it in your own application if you want to)
* Possibility to enable clipboard posting using sendkeys (to avoid copy/paste limitations)
* Directly send a password to a selected application
* Clipboard management which is able to handle multiple paste operations (like first paste is username, second is password, ...)

# GoodToKnow
This project is still in beta phase and there are some things missing like:
* Icons
* License
* Settings

# TeamPassword.Viewer.exe.config
## User
* ActivateSendKeys (enable sendkeys features)
* NeedsUpgrade (needed to determinate if the config file needs an update)
* Password
* SendKeysKey (hotkey to send clipboard using sendkeys)
* Url
* Username
* ViewStyle (style of your password list)
## Application
* HidePasswordsAfterSeconds (if password is revealed in the UI it is hidden after these amount of seconds - or not if 0)

# TeamPassword.Library.dll.config
## User
* WindowChooserUsage (list of recently used programs in send keys feature - sorted after last used)
* WindowChooserIgnoreProgramNames (list of program names which are going to be not shown in window chooser)
## Application
* SendDelay (each key is delayed for these amount of milliseconds if send keys/send to application is used)
* SendDelayInitial (waits these amounts of milliseconds before starting to send the first key (must be bigger than SendDelay) - needed e.g. for slow teamivewer connections)
* SendWait (uses the default send keys feature to wait till application accepted the key)
* WindowChooserLastUsedEntries (number of entries to show in window chooser - keep in mind that 3 can be viewed in default format)

# Screenshot
## Main Window
![](https://github.com/MyUncleSam/TeamPasswordManager.Viewer/blob/master/Screenshot1.png)
## Window Chooser (for send keys)
![](https://github.com/MyUncleSam/TeamPasswordManager.Viewer/blob/master/Screenshot2.png)
## Tray icon
![](https://github.com/MyUncleSam/TeamPasswordManager.Viewer/blob/master/Screenshot3.png)
## Google 2FA
![](https://github.com/MyUncleSam/TeamPasswordManager.Viewer/blob/master/Screenshot4.gif)
