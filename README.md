Zapbox XR SDK for Unity
====================================
Copyright (c) 2023 Zappar Ltd.

This package provides support for building [Zapbox](https://zappar.com/zapbox) XR experiences in Unity.

On the Unity side you can follow standard Unity documentation and tutorials about XR development.

Unity's XR Interaction Toolkit also works out-of-the-box with the Zapbox plugin.

There's a simple sample project showing Interaction Toolkit "grab" interactions in a Mixed Realty scene available [here](https://github.com/zappar-xr/zapbox-xrit-demo).

How to enable the Zapbox provider for XR support in your own projects:
1. Add this package in the Unity Package Manager (+ -> Add package from git URL -> `https://github.com/zappar-xr/zapbox-xr-sdk.git`)
2. Open the XR Plug-in Management panel in the Project Settings window
3. Enable the "Zapbox" Plug-in Provider in the iOS tab (no other iOS providers should be enabled)

Join us over on the [Zapbox Discord Server](https://discord.gg/5nEC8FRjef) if you need any help or just want to chat about Zapbox!

## Current Status

- Currently iPhone only. Offers the best experience on iPhone 11 and later with the built-in ultrawide camera.
- The app must include support for the portrait orientation, as this enables lower-latency compositing on iOS.
- iOS devices without ultrawide camera will work with the main camera, however camera FoV for pass-through and controller tracking will be reduced. This version doesn't yet support using the ultrawide camera adapter that is included in the box.
- The only tracking origin mode supported is "Floor" (the world anchor with the "zapbox" text on it is the origin of the space)
- User tracking currently only uses the single orgin marker.
- Camera exposure is hardcoded to be short to improve controller tracking; bright indoor lighting will work best.
- Unity's frame workload will need to complete within 10ms or so to avoid tearing from the late-warp GPU work not happening in time. Simple content should be OK.

### Tips and tricks for the current version

- We recommend you just wake up one controller first when in the pairing UI so you can tell which is left and right.
- When the controllers are first connected (LED changes from flashing to constant low brightness state) then they should be left stationary on a stable surface for 5-10 seconds for the runtime to calibrate gyro bias.
- Kill the app (by swiping it up from the App Switcher) when you've finished to disconnect the controllers - the LEDs will return to flashing mode for 60 seconds, and then the controllers will enter deep sleep.

### Near-term roadmap (estimated to complete by end of June)

- Using mutliple world markers for user tracking to improve stabaility and tracking volume.
- Levaraging accelerometer data from the device to further reduce the perceived camera latency when moving and the positional jitter effect.
- Camera manual exposure UI.
- Moving the late warp process to a compute shader to remove tearing when content graphics work takes longer than a frame.
- Improving controller pairing flow, and automatic disconnection when the app is in the background.

### Future work

- Better simulation of stereo camera views by using more accurate world geometry for the reprojection.
- Hand tracking integration.
- Android support.

## SDK Expiration Date: 01 October 2023

This is an early access build of the SDK so you can start building content.

We will be making signficant improvements to the quality of the experience and also addressing wider ecosystem questions (such as how third-party apps could integrate with a future "Zapbox Hub" app) which will require apps to update the version of their SDK for compatibility.

Therefore we have decided to introduce an expiry date for these early access SDKs to ensure users will get a consistent experience as we get closer to a full "consumer" release. We'll ensure the update process will be seemless for developers and will post updated SDKs well in advance of the expiration date.
