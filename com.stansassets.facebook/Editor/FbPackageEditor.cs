using StansAssets.Foundation.Editor;

namespace StansAssets.Facebook.Editor
{
    static class FbPackageEditor
    {
        public static readonly string RootPath = PackageManagerUtility.GetPackageRootPath(FbPackage.PackageName);
        public static readonly string SamplesPath = $"{RootPath}/Samples";
        public static readonly string IconsPath = $"{RootPath}/Editor/Art/Icons";
    }
}
