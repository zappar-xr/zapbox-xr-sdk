//-----------------------------------------------------------------------
// <copyright file="ApiConstants.cs" company="Google LLC">
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
    internal static class ApiConstants
    {
#if UNITY_ANDROID
        public const string kPluginName = "GfxPluginZapbox";
#elif UNITY_IOS
        public const string kPluginName = "__Internal";
#else
        public const string kPluginName = "NOT_AVAILABLE";
#endif

        public const string kDeviceName = "Zapbox";

        // Display provider
        public const string kDisplayProviderId = "ZapboxDisplay";

        // Input provider
        public const string kInputProviderId = "ZapboxInput";
        public const short kDeviceIdZapboxHeadset = 0;
        public const short kDeviceIdControllerLeft = 1;
        public const short kDeviceIdControllerRight = 2;
    }
}
