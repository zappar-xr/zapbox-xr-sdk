Zapbox XR SDK for Unity
====================================
Copyright (c) 2025 Zappar Ltd.

This package provides support for building [Zapbox](https://zappar.com/zapbox) XR experiences in Unity.

On the Unity side you can follow standard Unity documentation and tutorials about XR development.

Unity's XR Interaction Toolkit also works out-of-the-box with the Zapbox plugin.

There's a simple sample project showing Interaction Toolkit "grab" interactions in a Mixed Realty scene available [here](https://github.com/zappar-xr/zapbox-xrit-demo).

How to enable the Zapbox provider for XR support in your own projects:
1. Add this package in the Unity Package Manager (+ -> Add package from git URL -> `https://github.com/zappar-xr/zapbox-xr-sdk.git`)
2. Open the XR Plug-in Management panel in the Project Settings window
3. Enable the "Zapbox" Plug-in Provider in the iOS tab (no other iOS providers should be enabled)

Join us over on the [Zapbox Discord Server](https://discord.gg/5nEC8FRjef) if you need any help or just want to chat about Zapbox!

## What's new in 0.4.0

- Added automatic range calibration for analog trigger.
- Automatically calibrate thumbstick centre during "motion sensor calibration" phase of the controller pairing flow. NB: Ensure thumbstick is centred when the UI is in this mode - the easiest way to do this is just to place the controllers on a flat surface without touching them during the controller pairing.
- Update thumbstick scale factors to ensure the full -1 to +1 range is available on all controllers.
- Use a neck model to provide somewhat more realistic position updates when no markers are in view.

## What's (somewhat less) new

- Improved support for recording experiences, including a "spectator" view from another iPhone.
- Improving controller pairing flow.
- Better app lifecycle management, including disconnecting from controllers when the app is in the background.

## Video capture support

The SDK now offers two modes for recording your Zapbox experiences.

### First-person view

First-person captures can be made with the same device running your app with the Zapbox SDK. To start and stop the first-person recording, double-tap near the top of the device screen (in landscape), just to the right of the center line separating the views. At the end of the recording you'll find it in your Photos app on the device.

This mode records the full 1440x1080 camera feed and overlays a new view from Unity that should align exactly with the camera. During recording Unity will be rendering the scene 3 times, so there may be an impact on performance.

### Third-person view / Spectator Mode

The Zapbox SDK now also supports capturing video with a third-person view so you can see both the person wearing Zapbox and the content they are interacting with.

This mode requires another iPhone (that supports ARKit) for capturing the spectator video, and the dedicated "Zapbox Recorder" app running on that device for video capture. We are preparing that app for the App Store / Test Flight now and will have more information on how to use it shortly.

## Current Status

- Currently iPhone only. Offers the best experience on iPhone 11 and later with the built-in ultrawide camera.
- The app must include support for the portrait orientation, as this enables lower-latency compositing on iOS.
- iOS devices without ultrawide camera will work with the main camera, however camera FoV for pass-through and controller tracking will be reduced. This version doesn't yet support using the ultrawide camera adapter that is included in the box.
- The only tracking origin mode supported is "Floor" (the world anchor with the "zapbox" text on it is the origin of the space)
- This build supports multiple world markers to increase the tracking volume. The origin and orientation of the tracking space comes from the world anchor with the zapbox text.
- Camera exposure is hardcoded to be short to improve controller tracking; bright indoor lighting will work best.
- Unity's frame workload will need to complete within 10ms or so to avoid tearing from the late-warp GPU work not happening in time. Simple content should be OK.

### Near-term roadmap

- Improving tracking stability with multiple markers.
- Levaraging accelerometer data from the device to further reduce the perceived camera latency when moving and the positional jitter effect.
- Camera manual exposure UI.
- Moving the late warp process to a compute shader to remove tearing when content graphics work takes longer than a frame.

### Future work

- Better simulation of stereo camera views by using more accurate world geometry for the reprojection.
- Hand tracking integration.
- Android support.

## SDK Expiration Date: 01 April 2026

This is an early access build of the SDK so you can start building content.

We will be making signficant improvements to the quality of the experience and also addressing wider ecosystem questions (such as how third-party apps could integrate with a future "Zapbox Hub" app) which will require apps to update the version of their SDK for compatibility.

Therefore we have decided to introduce an expiry date for these early access SDKs to ensure users will get a consistent experience as we continue to grow the number of new users coming to Zapbox. We'll ensure the update process will be seemless for developers and will post updated SDKs well in advance of the expiration date.
