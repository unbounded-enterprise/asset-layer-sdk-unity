# Asset Layer SDK Unity

> Manage digital assets for your application with [Asset Layer](https://www.assetlayer.com). This Client SDK provides a turn-key solution for integrating your application with Asset Layer and a proxy server.

## Prerequisites

Logging in a user requires use of the Magic SDK. see more*

## Table of contents

- [Asset Layer SDK Unity](#asset-layer-sdk-unity)
  - [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Reference the SDK](#reference-the-sdk)
    - [Instantiate the SDK](#instantiate-the-sdk)
    - [Load an App](#load-an-app)
    - [Login a User](#login-a-user)

## Getting Started

These instructions will help getting started managing your digital assets with [Asset Layer](https://www.assetlayer.com).

## Installation

To install the package for Unity, use this GitHub link to add the package via UPM.

## Usage

### Reference the SDK

The SDK has one primary namespace:

```c#
using AssetLayer.SDK;
```

All the types you need for params and return values can be found in the relevant namespace:

```c#
using AssetLayer.SDK.Apps;
using AssetLayer.SDK.Assets;
using AssetLayer.SDK.Collections;
using AssetLayer.SDK.Currencies;
using AssetLayer.SDK.Equips;
using AssetLayer.SDK.Listings;
using AssetLayer.SDK.Slots;
using AssetLayer.SDK.Users;
```

### Instantiate the SDK

The Class must be initialized once by one of the following methods:

```c#
AssetLayerSDK.Initialize(config);
```

Or via an instance, which doesn't need to be directly used after construction:

```c#
AssetLayerSDK assetlayer = new AssetLayerSDK(config);
```

You can provide several props via the config class:

```c#
public class AssetLayerConfig
{
    public string baseUrl { get; set; } = AssetLayerSDK.APIURL;
    public string appSecret { get; set; }
    public string didToken { get; set; }
}
```

Note: The appSecret should not be set client-side in a live application.

### Load an App

Once the AssetLayerSDK class has been initialized, you can load an app:

```c#
App app = await AssetLayerSDK.Apps.Info(new AppInfoProps { appId = 'YOUR_APP_ID' });
```

By default, handlers return the payload and will throw Errors.
You can get the raw response by calling the raw handler as shown below:

```c#
AppInfoResponse response = await AssetLayerSDK.Apps.Raw.Info(props);
```

The raw handlers can be useful in situations where more data from the response is required.
However, it can still throw an error, to fix that we can call the safe handler:

```c#
BasicResult data = await AssetLayerSDK.Apps.Safe.Info(props);
if (data.error) Debug.Log("Error! " + data.error.message);
else return data.result;
```

Some endpoints may have different return types depending on the provided properties.
For this reason, there are more specific handlers available:

```c#
// App|App[] appOrApps = await AssetLayerSDK.Apps.Info(new AppInfoProps { appId = 'YOUR_APP_ID', appIds = ['APP_ID_1', 'APP_ID_2'] });
App app = await AssetLayerSDK.Apps.GetApp(new GetAppProps { appId = 'YOUR_APP_ID' });
App[] apps = await AssetLayerSDK.Apps.GetApps(new GetAppsProps { appIds = ['APP_ID_1', 'APP_ID_2'] });
```

These all call the same core endpoint (https://api-v2.assetlayer.com/api/v1/app/info),
but getApp & getApps offer stricter type security when passing props and returning values.
Typescript is highly recommended and the sdk includes extensive typings,
useful for referencing & importing, allowing for turn-key type-safe app development.


### Login a User

Logging in a user requires implementing the Magic SDK and generating a didtoken.
You can see examples of implementing magic for your project in our docs.
Once you have the didtoken, you can call the following method:

```c#
await AssetLayerSDK.InitializeUser(didToken);
```

This will register the user for your app and set the registered didtoken for use with the SDK. 

### Logout a User

```c#
AssetLayer.LogoutUser();
```
