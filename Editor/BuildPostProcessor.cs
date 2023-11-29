//-----------------------------------------------------------------------
// <copyright file="BuildPostProcessor.cs" company="Google LLC">
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

#if UNITY_EDITOR && UNITY_IOS

namespace Zappar.XR.Editor
{
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEditor.Callbacks;
    using UnityEditor.iOS.Xcode;
    using UnityEngine;

    /// <summary>Processes the project files after the build is performed.</summary>
    public static class BuildPostProcessor
    {
        /// <summary>Unity callback to process after build.</summary>
        /// <param name="buildTarget">Target built.</param>
        /// <param name="path">Path to built project.</param>
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
        {
            if (buildTarget == BuildTarget.iOS)
            {
                // Note: SDK binaries no longer contain bitcode, as
                // <a https://developer.apple.com/documentation/Xcode-Release-Notes/xcode-14-release-notes>Apple has deprecated bitcode</a>.
                string projectPath = PBXProject.GetPBXProjectPath(buildPath);
                string projectConfig = File.ReadAllText(projectPath);
                projectConfig = projectConfig.Replace("ENABLE_BITCODE = YES",
                                                      "ENABLE_BITCODE = NO");
                File.WriteAllText(projectPath, projectConfig);

                // Load the plist to add the required privacy entries
                string plistPath = buildPath + "/Info.plist";
                PlistDocument plist = new PlistDocument();
                plist.ReadFromFile(plistPath);
                PlistElementDict root = plist.root;
                
                const string bluetoothUsage = "Zapbox controllers require Bluetooth";
                ensureKeyIsSet(root, "NSBluetoothAlwaysUsageDescription", bluetoothUsage); // From iOS 13
                ensureKeyIsSet(root, "NSBluetoothPeripheralUsageDescription", bluetoothUsage); // iOS 12 and earlier

                const string cameraUsage = "Zapbox requires camera access for Mixed Reality experiences";
                ensureKeyIsSet(root, "NSCameraUsageDescription", cameraUsage);

                const string networkUsage = "Zapbox requires local network access for spectator view captures";
                ensureKeyIsSet(root, "NSLocalNetworkUsageDescription", networkUsage);

                const string photoLibraryAddUsage = "Zapbox saves video captures to your Photos library";
                ensureKeyIsSet(root, "NSPhotoLibraryAddUsageDescription", photoLibraryAddUsage);

                //save plist values
                plist.WriteToFile(plistPath);
            }
        }

        private static void ensureKeyIsSet(PlistElementDict root, string key, string defaultValue)
        {
            if(root[key] != null) return;
            root.SetString(key, defaultValue);
        }
    }
}

#endif
