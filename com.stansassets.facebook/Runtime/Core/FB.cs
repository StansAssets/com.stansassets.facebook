using System;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.Assertions;

namespace StansAssets.Facebook
{
    // ReSharper disable once InconsistentNaming
    public static class Fb
    {
        static readonly FbGraphAPI s_FbGraphApi = new FbGraphAPI();
        static bool s_IsInitializing;
        static InitDelegate s_InitCallback = delegate { };

        /// <summary>
        /// Sets the state of the Facebook SDK, and initializes all platform-specific data structures and behaviors.
        /// This function can only be called once during the lifetime of the object; later calls lead to undefined behavior.
        /// Relies on properties that are set in the Unity Editor using the Facebook | Edit settings menu option,
        ///
        /// Also <see cref="ActivateApp()"/> method will be called automatically when initialization is completed
        /// </summary>
        /// <param name="onInitComplete">A function that will be called once all data structures in the SDK are initialized; any code that should synchronize with the player's Facebook session should be in onInitComplete().</param>
        /// <param name="onHideUnity">A function that will be called when Facebook tries to display HTML content within the boundaries of the Canvas. When called with its sole argument set to false, your game should pause and prepare to lose focus. If it's called with its argument set to true, your game should prepare to regain focus and resume play. Your game should check whether it is in fullscreen mode when it resumes, and offer the player a chance to go to fullscreen mode if appropriate.</param>
        /// <param name="authResponse">effective in Web Player only, rarely used A Facebook auth_response you have cached to preserve a session, represented in JSON. If an auth_response is provided, FB will initialize itself using the data from that session, with no additional checks.</param>
        public static void Init(InitDelegate onInitComplete = null, HideUnityDelegate onHideUnity = null, string authResponse = null)
        {
            if (s_IsInitializing)
            {
                if (onInitComplete != null) s_InitCallback += onInitComplete;
                return;
            }

            s_IsInitializing = true;
            FbUnity.Init(() =>
            {
                FbUnity.ActivateApp();
                s_InitCallback += onInitComplete;
                s_InitCallback.Invoke();
            }, onHideUnity, authResponse);
        }

        /// <summary>
        /// Sets the state of the Facebook SDK, and initializes all platform-specific data structures and behaviors.
        /// This function can only be called once during the lifetime of the object; later calls lead to undefined behavior.
        ///
        /// Also <see cref="ActivateApp()"/> method will be called automatically when initialization is completed
        /// </summary>
        /// <param name="appId">The Facebook application ID of the initializing app. </param>
        /// <param name="clientToken">Client Token</param>
        /// <param name="cookie">Sets a cookie which your server-side code can use to validate a user's Facebook session</param>
        /// <param name="logging">If true, outputs a verbose log to the Javascript console to facilitate debugging. Effective on Web only.</param>
        /// <param name="status">If true, attempts to initialize the Facebook object with valid session data.*</param>
        /// <param name="xfbml">If true, Facebook will immediately parse any XFBML elements on the Facebook Canvas page hosting the app, like the page plugin. Effective on Web only.</param>
        /// <param name="frictionlessRequests">Frictionless Requests</param>
        /// <param name="authResponse">effective in Web Player only, rarely used A Facebook auth_response you have cached to preserve a session, represented in JSON. If an auth_response is provided, FB will initialize itself using the data from that session, with no additional checks.</param>
        /// <param name="javascriptSDKLocale">javascript SDK Locale</param>
        /// <param name="onHideUnity">A function that will be called when Facebook tries to display HTML content within the boundaries of the Canvas. When called with its sole argument set to false, your game should pause and prepare to lose focus. If it's called with its argument set to true, your game should prepare to regain focus and resume play. Your game should check whether it is in fullscreen mode when it resumes, and offer the player a chance to go to fullscreen mode if appropriate.</param>
        /// <param name="onInitComplete">A function that will be called once all data structures in the SDK are initialized; any code that should synchronize with the player's Facebook session should be in onInitComplete().</param>
        // ReSharper disable once IdentifierTypo
        public static void Init(string appId, string clientToken = null, bool cookie = true, bool logging = true, bool status = true, bool xfbml = false, bool frictionlessRequests = true, string authResponse = null, string javascriptSDKLocale = "en_US", HideUnityDelegate onHideUnity = null, InitDelegate onInitComplete = null)
        {
            FbUnity.Init(appId, clientToken, cookie, logging, status, xfbml, frictionlessRequests, authResponse, javascriptSDKLocale, onHideUnity, () =>
            {
                FbUnity.ActivateApp();
                onInitComplete?.Invoke();
            });
        }

        /// <summary>
        /// Prompts the user to authorize your application for publish permissions using the Login Dialog appropriate to the platform.
        /// If the user is already logged in and has authorized your application,
        /// checks whether all permissions in the permissions parameter have been granted, and if not, prompts the user for any that are newly requested.
        ///
        /// People are sensitive about granting publish permissions,
        /// so you should only ask for publish permissions once a person is ready to post something from your app and not during the initial login.
        ///
        /// In the Unity Editor, a stub function is called, which will prompt you to provide an access token from the Access Token Tool.
        /// Please note that this token will not necessarily contain the permissions you specified in FB.Login. To change this token's permissions,
        /// please use the [Graph API Explorer](https://developers.facebook.com/tools/explorer).
        /// </summary>
        /// <param name="callback">A delegate that will be called with the result of the Login Dialog.</param>
        public static void LogInWithPublishPermissions(Action<FbLoginResult> callback)
        {
            Login(FbSettings.PermissionsStringsList, true, callback);
        }

        /// <summary>
        /// Prompts the user to authorize your application for publish permissions using the Login Dialog appropriate to the platform.
        /// If the user is already logged in and has authorized your application,
        /// checks whether all permissions in the permissions parameter have been granted, and if not, prompts the user for any that are newly requested.
        ///
        /// People are sensitive about granting publish permissions,
        /// so you should only ask for publish permissions once a person is ready to post something from your app and not during the initial login.
        ///
        /// In the Unity Editor, a stub function is called, which will prompt you to provide an access token from the Access Token Tool.
        /// Please note that this token will not necessarily contain the permissions you specified in FB.Login. To change this token's permissions,
        /// please use the [Graph API Explorer](https://developers.facebook.com/tools/explorer).
        /// </summary>
        /// <param name="callback">A delegate that will be called with the result of the Login Dialog.</param>
        /// <param name="permissions">A list of Facebook permissions requested from the user</param>
        public static void LogInWithPublishPermissions(IEnumerable<string> permissions, Action<FbLoginResult> callback)
        {
            Login(permissions, true, callback);
        }

        /// <summary>
        /// Prompts the user to authorize your application using the Login Dialog appropriate to the platform.
        /// If the user is already logged in and has authorized your application,
        /// checks whether all permissions in the permissions parameter have been granted, and if not,
        /// prompts the user for any that are newly requested.
        ///
        /// In the Unity Editor, a stub function is called, which will prompt you to provide an access token from the Access Token Tool.
        /// Please note that this token will not necessarily contain the permissions you specified in FB.Login. To change this token's permissions,
        /// please use the [Graph API Explorer](https://developers.facebook.com/tools/explorer).
        /// </summary>
        /// <param name="callback">A delegate that will be called with the result of the Login Dialog.</param>
        public static void LogInWithReadPermissions(Action<FbLoginResult> callback)
        {
            Login(FbSettings.PermissionsStringsList, true, callback);
        }

        /// <summary>
        /// Prompts the user to authorize your application using the Login Dialog appropriate to the platform.
        /// If the user is already logged in and has authorized your application,
        /// checks whether all permissions in the permissions parameter have been granted, and if not,
        /// prompts the user for any that are newly requested.
        ///
        /// In the Unity Editor, a stub function is called, which will prompt you to provide an access token from the Access Token Tool.
        /// Please note that this token will not necessarily contain the permissions you specified in FB.Login. To change this token's permissions,
        /// please use the [Graph API Explorer](https://developers.facebook.com/tools/explorer).
        /// </summary>
        /// <param name="callback">A delegate that will be called with the result of the Login Dialog.</param>
        /// <param name="permissions">A list of Facebook permissions requested from the user</param>
        public static void LogInWithReadPermissions(IEnumerable<string> permissions, Action<FbLoginResult> callback)
        {
            Login(permissions, true, callback);
        }

        internal static void Login(bool requestPublishPermissions, Action<FbLoginResult> callback)
        {
            Login(FbSettings.PermissionsStringsList, requestPublishPermissions, callback);
        }

        static void Login(IEnumerable<string> permissions, bool requestPublishPermissions, Action<FbLoginResult> callback)
        {
            if (!requestPublishPermissions)
                FbUnity.LogInWithReadPermissions(permissions, (loginResult) =>
                {
                    var result = new FbLoginResult(loginResult);
                    callback.Invoke(result);
                });
            else
                FbUnity.LogInWithPublishPermissions(permissions, (loginResult) =>
                {
                    var result = new FbLoginResult(loginResult);
                    callback.Invoke(result);
                });
        }

        public static void GetLoggedInUserInfo(Action<FbGetUserResult> callback)
        {
            FbGraphApi.GetLoggedInUserInfo(callback);
        }

        /// <summary>
        /// On Web, this method will log the user out of both your site and Facebook.
        /// On iOS and Android, it will log the user out of your Application.
        /// On all the platforms it will also invalidate any access token that you have for the user that was issued before the logout.
        ///
        /// On Web, you almost certainly should not use this function, which is provided primarily for completeness.
        /// Having a logout control inside a game that executes a Facebook-wide logout will violate users' expectations.
        /// Instead, allow users to control their logged-in status on Facebook itself.
        /// </summary>
        public static void LogOut()
        {
            FbUnity.LogOut();
        }

        /// <summary>
        /// Makes a call to the Graph API to get data, or take action on a user's behalf.
        /// This will always be used once a user is logged in, and an access token has been granted;
        /// the permissions encoded by the access token determine which Graph API calls will be available.
        ///
        /// This method will automatically check user active session, and if user isn't logged in,
        /// SDK Init & User Login attempt would be made using the editor SDK settings
        /// </summary>
        /// <param name="query">The Graph API endpoint to call. e.g. /me/scores </param>
        /// <param name="method">The HTTP method to use in the call </param>
        /// <param name="callback">A delegate which will receive the result of the call </param>
        /// <param name="formData">The key/value pairs to be passed to the endpoint as arguments. </param>
        // ReSharper disable once InconsistentNaming
        public static void API(string query, HttpMethod method, FacebookDelegate<IGraphResult> callback = null, IDictionary<string, string> formData = null)
        {
            Assert.IsTrue(IsLoggedIn);
            FbUnity.Api(query, method, callback, formData);
        }

        /// <summary>
        /// By logging app activation events, you can observe how frequently users activate your app,
        /// how much time they spend using it, and view other demographic information through Facebook Analytics for Apps.
        /// </summary>
        public static void ActivateApp() => FbUnity.ActivateApp();

        /// <summary>
        /// Check whether a user is currently logged in and has authorized your app
        /// </summary>
        public static bool IsLoggedIn => FbUnity.IsLoggedIn;

        /// <summary>
        /// Check whether the Unity SDK has been initialized. `false` if the SDK has not been initialized.
        /// </summary>
        public static bool IsInitialized => FbUnity.IsInitialized;

        /// <summary>
        /// Object that contain methods to communicate with facebook graph API.
        /// </summary>
        public static FbGraphAPI FbGraphApi => s_FbGraphApi;

        /// <summary>
        /// Saved user AccessToken from last login result
        /// Can be null if there wa no success during current session
        /// </summary>
        public static AccessToken AccessToken => AccessToken.CurrentAccessToken;

        /// <summary>
        /// Saved user AccessToken string from last login result
        /// <see cref="string.Empty"/> if there wa no success during current session
        /// </summary>
        public static string AccessTokenString => AccessToken.CurrentAccessToken != null ? AccessToken.CurrentAccessToken.TokenString : string.Empty;

        /// <summary>
        /// Gets the app client token. ClientToken might be different from FBSettings.ClientToken
        /// if using the programmatic version of SA_FB.Init().
        /// </summary>
        public static string ClientToken => FbUnity.ClientToken;
    }
}
