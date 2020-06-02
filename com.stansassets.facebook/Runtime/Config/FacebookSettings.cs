using System.Collections.Generic;
using Config;
using StansAssets.Plugins;

namespace SA.Facebook
{
    class FacebookSettings : PackageScriptableSettingsSingleton<FacebookSettings>
    {
        public List<string> Scopes = new List<string>();
        public override string PackageName => FbPackage.PackageName;
    }

    public static class FbSettings
    {
        /// <summary>
        /// When a person logs into your app via Facebook Login you can access a subset of that person's data stored on Facebook.
        /// Permissions or "Scopes" are how you ask someone if you can access that data.
        /// A person's privacy settings combined with what you ask for will determine what you can access.
        /// </summary>
        public static List<string> Scopes => FacebookSettings.Instance.Scopes;

        /// <summary>
        /// Set's the Facebook App Id, the same operation can be made using the editor settings
        /// </summary>
        /// <param name="appId"></param>
        public static void SetAppId(string appId)
        {
            FbUnity.SetAppId(appId);
        }
    }
}
