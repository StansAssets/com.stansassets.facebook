using System.Collections.Generic;
using System.Linq;

namespace StansAssets.Facebook
{
    public static class FbSettings
    {
        /// <summary>
        /// When a person logs into your app via Facebook Login you can access a subset of that person's data stored on Facebook.
        /// Permissions or "Scopes" are how you ask someone if you can access that data.
        /// A person's privacy settings combined with what you ask for will determine what you can access.
        /// </summary>
        public static List<FbPermissions> Permissions => FacebookAdditiveSettings.Instance.Permissions;

        /// <summary>
        /// The <see cref="Permissions"/> list repressed with strings.
        /// </summary>
        public static List<string> PermissionsStringsList => Permissions.Select(perm => perm.ToString()).ToList();

        /// <summary>
        /// Set's the Facebook App Id, the same operation can be made using the editor settings
        /// </summary>
        /// <param name="appId"></param>
        public static void SetAppId(string appId)
        {
           /* FbUnity.SetAppId(appId);*/
        }

        /// <summary>
        /// Scene settings changes.
        /// </summary>
        public static void Save() => FacebookAdditiveSettings.Save();
    }
}
