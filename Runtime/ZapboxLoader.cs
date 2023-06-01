//-----------------------------------------------------------------------
// <copyright file="XRLoader.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Zappar.XR
{
    using System.Collections.Generic;
    using UnityEngine.XR;
    using UnityEngine.XR.Management;
    using UnityEngine.InputSystem;
    using UnityEngine.InputSystem.Layouts;
    using UnityEngine.InputSystem.XR;

#if UNITY_EDITOR
    using UnityEditor;
#endif

#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    static class InputLayoutLoader
    {
        static InputLayoutLoader()
        {
            RegisterInputLayouts();
        }

        public static void RegisterInputLayouts()
        {
            InputSystem.RegisterLayout<ZapboxControllerProfile.ZapboxController>("ZapboxController", matches: new InputDeviceMatcher()
                .WithInterface(XRUtilities.InterfaceMatchAnyVersion)
                .WithProduct(@"^(Zapbox Controller)")
                );
        }
    }

    /// <summary>
    /// XR Loader for Zapbox XR Plugin.
    /// Loads Display and Input Subsystems.
    /// </summary>
    public class ZapboxLoader : XRLoaderHelper
    {
        private static List<XRDisplaySubsystemDescriptor> _displaySubsystemDescriptors =
            new List<XRDisplaySubsystemDescriptor>();

        private static List<XRInputSubsystemDescriptor> _inputSubsystemDescriptors =
            new List<XRInputSubsystemDescriptor>();

        /// <summary>
        /// Gets a value indicating whether the subsystems are initialized or not.
        /// </summary>
        ///
        /// <returns>
        /// True after a successful call to Initialize() without a posterior call to
        /// Deinitialize().
        /// </returns>
        internal static bool _isInitialized { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the subsystems are started or not.
        /// </summary>
        ///
        /// <returns>
        /// True after a successful call to Start() without a posterior call to Stop().
        /// </returns>
        internal static bool _isStarted { get; private set; }

        /// <summary>
        /// Initialize the loader. This should initialize all subsystems to support the desired
        /// runtime setup this loader represents.
        /// </summary>
        ///
        /// <returns>Whether or not initialization succeeded.</returns>
        public override bool Initialize()
        {
#if !UNITY_EDITOR
            InputLayoutLoader.RegisterInputLayouts();
#endif
            CardboardSDKInitialize();
            CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(
                _displaySubsystemDescriptors, ApiConstants.kDisplayProviderId);
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(
                _inputSubsystemDescriptors, ApiConstants.kInputProviderId);
            _isInitialized = true;
            return true;
        }

        /// <summary>
        /// Ask loader to start all initialized subsystems.
        /// </summary>
        ///
        /// <returns>Whether or not all subsystems were successfully started.</returns>
        public override bool Start()
        {
            StartSubsystem<XRDisplaySubsystem>();
            StartSubsystem<XRInputSubsystem>();
            _isStarted = true;
            return true;
        }

        /// <summary>
        /// Ask loader to stop all initialized subsystems.
        /// </summary>
        ///
        /// <returns>Whether or not all subsystems were successfully stopped.</returns>
        public override bool Stop()
        {
            StopSubsystem<XRDisplaySubsystem>();
            StopSubsystem<XRInputSubsystem>();
            _isStarted = false;
            return true;
        }

        /// <summary>
        /// Ask loader to deinitialize all initialized subsystems.
        /// </summary>
        ///
        /// <returns>Whether or not deinitialization succeeded.</returns>
        public override bool Deinitialize()
        {
            DestroySubsystem<XRDisplaySubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            CardboardSDKDeinitialize();
            _isInitialized = false;
            return true;
        }

#if UNITY_ANDROID
        [DllImport(ApiConstants.kPluginName)]
        private static extern void CardboardUnity_initializeAndroid(IntPtr context);
        [DllImport(ApiConstants.kPluginName)]
        private static extern void ZapboxUnity_deInitializeAndroid(IntPtr context);
#endif

        /// <summary>
        /// For Android, initializes JavaVM and Android activity context.
        /// Then, for both Android and iOS, it sets the screen size in pixels.
        /// </summary>
        private void CardboardSDKInitialize()
        {
#if UNITY_ANDROID
            // TODO(b/169797155): Move this to UnityPluginLoad().
            // Gets Unity context (Main Activity).
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            var context = activity.Call<AndroidJavaObject>("getApplicationContext");

            // Initializes Cardboard SDK.
            CardboardUnity_initializeAndroid(activity.GetRawObject());
#endif
        }

        /// <summary>
        /// Widget textures are preserved until the XR provider is deinitialized.
        /// </summary>
        private void CardboardSDKDeinitialize()
        {
#if UNITY_ANDROID
            // Get Unity context (Main Activity).
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            var context = activity.Call<AndroidJavaObject>("getApplicationContext");

            // clears any cached jni global resources
            ZapboxUnity_deInitializeAndroid(activity.GetRawObject());
#endif
        }
    }
}
