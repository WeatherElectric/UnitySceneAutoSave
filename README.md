# UnitySceneAutoSave

Why does Unity not already do this? I don't know.

Automatically saves the currently open scene after a configured amount of time.

# Instructions

You can install this in 3 ways.

### 1) Package Manager
1. Copy this link: `https://github.com/WeatherElectric/UnitySceneAutoSave.git`
2. Open Package Manager in Unity
3. Click on the plus and hit "Add from Git"
4. Enter the URL and wait for it to install
### 2) Manual - Package
1. Import the `.unitypackage` in the latest release.
### 3) Manual - Direct
1. Download the repo as a .zip
2. Drag the "Editor" folder into your Unity project.

### Config
After it is installed, a scriptable object will be created in the assets folder. Adjust the settings within the scriptable asset to your liking.

You can then put that asset anywhere in your project.

If there is more than one, it'll load the first one it finds and delete the extras.