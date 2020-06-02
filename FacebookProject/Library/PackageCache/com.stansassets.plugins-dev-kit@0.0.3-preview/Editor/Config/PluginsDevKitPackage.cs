using StansAssets.Foundation.Editor;
using UnityEditor.PackageManager;

namespace StansAssets.Plugins.Editor
{
    static class PluginsDevKitPackage
    {
        public const string Name = "com.stansassets.plugins-dev-kit";
        public static readonly string RootPath = PackageManagerUtility.GetPackageRootPath(Name);
        public static readonly string UIPath = $"{RootPath}/Editor/UI";

        /// <summary>
        ///  Foundation package info.
        /// </summary>
        public static PackageInfo GetPackageInfo()
        {
            return PackageManagerUtility.GetPackageInfo(Name);
        }
    }
}
