using System;
using System.Collections.Generic;

namespace StansAssets.Facebook
{
    /// <summary>
    /// Login Utilities methods.
    /// </summary>
    public static class FbLoginUtil
    {
        static readonly List<Action<FbLoginUtilResult>> s_Callbacks = new List<Action<FbLoginUtilResult>>();
        static bool s_WaitingLoginResult;
        static bool s_RequestPublishPermissions;

        /// <summary>
        /// This is conflict free method
        /// (it can be executed from several places in the code and will only result in on facebook login request but all parties will get the result).
        ///
        /// The method will call combination of Init and Login methods.
        /// </summary>
        /// <param name="requestPublishPermissions">Use `true` if login request should be with publish permissions.</param>
        /// <param name="callback">Operation callback.</param>
        ///
        public static void ConfirmLoginStatus(bool requestPublishPermissions, Action<FbLoginUtilResult> callback)
        {
            s_Callbacks.Add(callback);
            if (Fb.IsLoggedIn)
            {
                if (!requestPublishPermissions || s_RequestPublishPermissions)
                {
                    DispatchLoginSucceeded();
                    return;
                }
            }

            if (s_WaitingLoginResult) return;

            s_WaitingLoginResult = true;
            s_RequestPublishPermissions = requestPublishPermissions;
            if (Fb.IsInitialized)
                OnInitCompleted();
            else
                Fb.Init(() =>
                {
                    if (Fb.IsInitialized)
                        OnInitCompleted();
                    else
                        DispatchLoginFailed();
                });
        }

        static void OnInitCompleted()
        {
            if (Fb.IsLoggedIn)
                DispatchLoginSucceeded();
            else
            {
                if (s_RequestPublishPermissions)
                {
                    Fb.Login(s_RequestPublishPermissions, result =>
                    {
                        if (result.IsSucceeded)
                            DispatchLoginSucceeded();
                        else
                            DispatchLoginFailed();
                    });
                }
            }

        }

        static void DispatchLoginFailed()
        {
            DispatchLoginStatus(false);
        }

        static void DispatchLoginSucceeded()
        {
            DispatchLoginStatus(true);
        }

        static void DispatchLoginStatus(bool status)
        {
            var callbacks = new List<Action<FbLoginUtilResult>>(s_Callbacks);
            foreach (var callback in callbacks) callback.Invoke(new FbLoginUtilResult(status));

            s_Callbacks.Clear();
            s_WaitingLoginResult = false;
        }
    }
}
