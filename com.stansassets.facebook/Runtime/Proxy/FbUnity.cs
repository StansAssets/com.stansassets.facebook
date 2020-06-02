using System.Collections.Generic;
using FacebookUnity = Facebook.Unity;

namespace SA.Facebook
{
    static class FbUnity
    {
        public static void Init(FacebookUnity.InitDelegate onInitComplete = null, FacebookUnity.HideUnityDelegate onHideUnity = null, string authResponse = null)
        {
            FacebookUnity.FB.Init(() =>
                {
                    onInitComplete?.Invoke();
                }, (isUnityShown) =>
                {
                    onHideUnity?.Invoke(isUnityShown);
                },
            authResponse);
        }

        public static void SetAppId(string appId)
        {
            var appIds = new List<string> { appId };
            FacebookUnity.Settings.FacebookSettings.AppIds = appIds;
        }

        public static void Api(string query, FacebookUnity.HttpMethod method, FacebookUnity.FacebookDelegate<FacebookUnity.IGraphResult> callback = null, IDictionary<string, string> formData = null)
        {
            FacebookUnity.FB.API(query, (FacebookUnity.HttpMethod)method, callback, formData);
        }

        public static void Init(string appId, string clientToken = null, bool cookie = true, bool logging = true, bool status = true, bool xfbml = false, bool frictionlessRequests = true, string authResponse = null, string javascriptSDKLocale = "en_US", FacebookUnity.HideUnityDelegate onHideUnity = null, FacebookUnity.InitDelegate onInitComplete = null)
        {
            FacebookUnity.FB.Init(appId,
                clientToken,
                cookie,
                logging,
                status,
                xfbml,
                frictionlessRequests,
                authResponse,
                javascriptSDKLocale,
                (isUnityShown) =>
                {
                    onHideUnity?.Invoke(isUnityShown);
                },
                () =>
                {
                    onInitComplete?.Invoke();
                });
        }

        public static void LogInWithReadPermissions(IEnumerable<string> permissions = null, FacebookUnity.FacebookDelegate<FacebookUnity.ILoginResult> callback = null)
        {
            FacebookUnity.FB.LogInWithReadPermissions(permissions, callback);
        }

        public static void LogInWithPublishPermissions(IEnumerable<string> permissions = null, FacebookUnity.FacebookDelegate<FacebookUnity.ILoginResult> callback = null)
        {
            FacebookUnity.FB.LogInWithPublishPermissions(permissions, callback);
        }

        public static void LogOut()
        {
            FacebookUnity.FB.LogOut();
        }

        public static void ActivateApp()
        {
            FacebookUnity.FB.ActivateApp();
        }

        public static void LogAppEvent(string logEvent, float? valueToSum = null, Dictionary<string, object> parameters = null)
        {
            FacebookUnity.FB.LogAppEvent(logEvent, valueToSum, parameters);
        }

        public static void LogPurchase(float logPurchase, string currency = null, Dictionary<string, object> parameters = null)
        {
            FacebookUnity.FB.LogPurchase(logPurchase, currency, parameters);
        }

        public static bool IsInitialized => FacebookUnity.FB.IsInitialized;
        public static bool IsLoggedIn => FacebookUnity.FB.IsLoggedIn;
        public static string GraphApiVersion => FacebookUnity.FB.GraphApiVersion;
        public static string ClientToken => FacebookUnity.FB.ClientToken;
        public static string AppId => FacebookUnity.FB.AppId;
    }
}
