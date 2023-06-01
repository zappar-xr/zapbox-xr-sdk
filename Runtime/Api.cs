namespace Zappar.XR
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.InputSystem.Controls;

    /// <summary>
    /// Zapbox XR Plugin API.
    /// </summary>
    public static class Api
    {

        /// <summary>
        /// Open Zapbox Controller pairing UI upon gear icon press from in game
        /// </summary>
        public static void OpenControllerPairingActivity()
        {
#if UNITY_ANDROID || UNITY_IOS
            ZapboxUnity_LaunchSettingsUI();
#else
            Debug.LogError("Platform is not supported yet!");
#endif
        }

#if UNITY_ANDROID || UNITY_IOS
        [DllImport(ApiConstants.kPluginName)]
        private static extern void ZapboxUnity_LaunchSettingsUI();
#endif

    }
}
