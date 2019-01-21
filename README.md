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

# Application .config
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

# Screenshot
![](https://github.com/MyUncleSam/TeamPasswordManager.Viewer/blob/master/Screenshot1.png)
