# Extended Facebook SDK 
Power up your Unity project with our Extended Facebook SDK. This library is a free open source product that contains extended access to Facebook API. We want to make life a little bit easier for all of our fellow developers. Facebook already provides [Facebook Unity SDK](https://developers.facebook.com/docs/unity/) but it only covers basic functionality. And if you would like to use [Graph API](https://developers.facebook.com/docs/graph-api/) you will have to do all the parsing yourself. And this is the exact part where we would like to help.

[![NPM Package](https://img.shields.io/npm/v/com.stansassets.facebook)](https://www.npmjs.com/package/com.stansassets.facebook)
[![openupm](https://img.shields.io/npm/v/com.stansassets.facebook?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.stansassets.facebook/)
[![Licence](https://img.shields.io/npm/l/com.stansassets.facebook)](https://github.com/StansAssets/com.stansassets.facebook/blob/master/LICENSE)
[![Issues](https://img.shields.io/github/issues/StansAssets/com.stansassets.facebook)](https://github.com/StansAssets/com.stansassets.facebook/issues)

[API Reference](https://api.stansassets.com/facebook/) | [Wiki](https://github.com/StansAssets/com.stansassets.facebook/wiki)

## Explore the library:
* [Initialization](https://github.com/StansAssets/com.stansassets.facebook/wiki/Initialization) Initializes all platform-specific data structures and behaviors.
* [GetFriends](https://github.com/StansAssets/com.stansassets.facebook/wiki/GetFriends) Represents users friends list.
* [GetProfileUrl](https://github.com/StansAssets/com.stansassets.facebook/wiki/GetProfileUrl) Gets user's profile url.
* [GetLoggedInUserInfo](https://github.com/StansAssets/com.stansassets.facebook/wiki/GetLoggedInUserInfo) Retrieves current logger user info.

## Contributing
This is open-source free software with a simple goal to save a bit of time to developers who need to add advanced Facebook SDK integration into the project. Therefore we 100% open to your contributions. Please read [CONTRIBUTING.md](https://github.com/StansAssets/com.stansassets.facebook/blob/master/CONTRIBUTING.md) for more details on how to contribute. 

### Install from NPM
* Navigate to the `Packages` directory of your project.
* Adjust the [project manifest file](https://docs.unity3d.com/Manual/upm-manifestPrj.html) `manifest.json` in a text editor.
* Ensure `https://registry.npmjs.org/` is part of `scopedRegistries`.
  * Ensure `com.stansassets` is part of `scopes`.
  * Add `com.stansassets.facebook` to the `dependencies`, stating the latest version.

A minimal example ends up looking like this. Please note that the version `X.Y.Z` stated here is to be replaced with [the latest released version](https://www.npmjs.com/package/com.stansassets.facebook) which is currently [![NPM Package](https://img.shields.io/npm/v/com.stansassets.facebook)](https://www.npmjs.com/package/com.stansassets.facebook).
  ```json
  {
    "scopedRegistries": [
      {
        "name": "npmjs",
        "url": "https://registry.npmjs.org/",
        "scopes": [
          "com.stansassets"
        ]
      }
    ],
    "dependencies": {
      "com.stansassets.facebook": "X.Y.Z",
      ...
    }
  }
  ```
* Switch back to the Unity software and wait for it to finish importing the added package.

### Install from OpenUPM
* Install openupm-cli `npm install -g openupm-cli` or `yarn global add openupm-cli`
* Enter your unity project folder `cd <YOUR_UNITY_PROJECT_FOLDER>`
* Install package `openupm add com.stansassets.facebook`



## About Us
We are committed to developing high quality and engaging entertainment software. Our mission has been to bring a reliable and high-quality Unity Development service to companies and individuals around the globe. 
At Stan's Assets, we make Plugins, SDKs, Games, VR & AR Applications. Do not hesitate do get in touch, whether you have a question, want to build something, or just to say hi :) [Let's Talk!](mailto:stan@stansassets.com)

[Website](https://stansassets.com/) | [LinkedIn](https://www.linkedin.com/in/lacost/) | [Youtube](https://www.youtube.com/user/stansassets/videos) | [Github](https://github.com/StansAssets) | [AssetStore](https://assetstore.unity.com/publishers/2256)
