using System.Collections.Generic;
using StansAssets.Plugins;

namespace StansAssets.Facebook
{
    class FacebookAdditiveSettings : PackageScriptableSettingsSingleton<FacebookAdditiveSettings>
    {
        public List<FbPermissions> Permissions = new List<FbPermissions>();
        public override string PackageName => FbPackage.PackageName;
    }
}
