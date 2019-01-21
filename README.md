# Readme
This is an unoficial Windows Client for https://teampasswordmanager.com/.
Use at your own risk!

# Requirements
* Pro version to be able to access the API.
* Enabled API access to your team password manager.

# Features
* Search tree and list entries easily
* Autostart
* Ability to paste information using sendkeys (e.g. login as windows user in a teamviewer session)
* Library provides controls which can be implemented in other applications (even the full UI)
* Clipboard managemer which is able to copy username and password (replace username after first paste action)

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