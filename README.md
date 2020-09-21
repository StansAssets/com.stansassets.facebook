# Extended Facebook SDK 
Power up your Unity games with our Facebook Unity SDKs.
The goal of StansAssets is to make life easier for any developer. That is why we are introducing the Extended Facebook SDK. This library is a free open source product that contains extended access to Facebook API.

[![NPM Package](https://img.shields.io/npm/v/com.stansassets.facebook)](https://www.npmjs.com/package/com.stansassets.facebook)
[![openupm](https://img.shields.io/npm/v/com.stansassets.facebook?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.stansassets.facebook/)
[![Licence](https://img.shields.io/npm/l/com.stansassets.facebook)](https://github.com/StansAssets/com.stansassets.facebook/blob/master/LICENSE)
[![Issues](https://img.shields.io/github/issues/StansAssets/com.stansassets.facebook)](https://github.com/StansAssets/com.stansassets.facebook/issues)

## Detailed articles to explore the library:
* [Utilities.](https://api.stansassets.com/foundation/StansAssets.Foundation.html) The collection of various utility methods.
* [Editor Utilities.](https://api.stansassets.com/foundation/StansAssets.Foundation.Editor.html)The collection of utility methods for the Unity Editor.
* [Extensions.](https://api.stansassets.com/foundation/StansAssets.Foundation.Extensions.html) Extension methods for default C# and Unity Objects.
* [Patterns.](https://api.stansassets.com/foundation/StansAssets.Foundation.Patterns.html) Implementation of well-known design patterns like Singleton, Factory, Pool, etc.
* [UI Toolkit.](https://api.stansassets.com/foundation/StansAssets.Foundation.UIElements.html) Helper methods, extensions, utilities for the new Unity [UI Toolkit framework](https://docs.unity3d.com/Manual/UIElements.html).

[API Reference](https://myapi) | [Forum](https://myforum) | [Wiki](https://github.com/StansAssets/com.stansassets.facebook/wiki)

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
