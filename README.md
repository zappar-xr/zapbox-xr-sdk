Zapbox XR SDK for Unity
====================================
Copyright 2023 Zappar Ltd.

This package provides support for building Zapbox XR experiences in Unity.

How to enable the Zapbox provider for XR support:
1. Install the package
2. Open the XR Plug-in Management panel in the Project Settings window
3. Enable the "Zapbox" Plug-in Provider in the iOS tab (no other iOS providers should be enabled)

On the Unity side you can follow standard Unity documentation and tutorials about XR development.

Unity's XR interaction framework also works out-of-the-box with the Zapbox plugin.

A couple of other requirements on the Unity side:
- The app must include support for the portrait orientation, as this enables lower-latency compositing on iOS
- The only tracking origin mode supported is "Floor" (the world anchor with the Zapbox text on it is the origin of the space)

Join us over on the [Zapbox Discord Server](https://discord.gg/5nEC8FRjef) if you need any help or just want to chat about Zapbox!

## SDK Expiration Date: 01 October 2023

This is an early access build of the SDK so you can start building content.

We will be making signficant improvements to the quality of the experience and also addressing wider ecosystem questions (such as how third-party apps could integrate with a future "Zapbox Hub" app) which will require apps to update the version of their SDK for compatibility.

Therefore we have decided to introduce an expiry date for these early access SDKs to ensure users will get a consistent experience as we get closer to a full "consumer" release. We'll ensure the update process will be seemless for developers and will post updated SDKs well in advance of the expiration date.
