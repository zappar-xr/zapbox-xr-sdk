#if XR_MGMT_GTE_320

namespace Zappar.XR.Editor
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.XR.Management.Metadata;
    using UnityEngine;

    /// <summary>
    /// XR Metadata for Zapbox XR Plugin.
    /// Required by XR Management package.
    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@4.2/manual/Provider.html
    /// </summary>
    public class ZapboxPackage : IXRPackage
    {
        /// <summary>
        /// Package metadata instance.
        /// </summary>
        public IXRPackageMetadata metadata => new PackageMetadata();

        /// <summary>
        /// Populates package settings instance.
        /// </summary>
        ///
        /// <param name="obj">
        /// Settings object.
        /// </param>
        /// <returns>Settings analysis result. Given that nothing is done, returns true.</returns>
        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            return true;
        }

        private class LoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "Zapbox";

            public string loaderType => typeof(Zappar.XR.ZapboxLoader).FullName;

            public List<BuildTargetGroup> supportedBuildTargets => new List<BuildTargetGroup>()
            {
                BuildTargetGroup.iOS
            };
        }

        private class PackageMetadata : IXRPackageMetadata
        {
            public string packageName => "Zapbox XR Plugin";

            public string packageId => "com.zappar.xr.zapbox";

            public string settingsType => typeof(Zappar.XR.ZapboxSettings).FullName;

            public List<IXRLoaderMetadata> loaderMetadata => new List<IXRLoaderMetadata>()
            {
                new LoaderMetadata()
            };
        }
    }
}

#endif // XR_MGMT_GTE_320
