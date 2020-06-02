using System;
using System.Collections.Generic;

namespace SA.Facebook
{
    public static class FbLoginUtil
    {
        static readonly List<Action<FbLoginUtilResult>> s_Callbacks = new List<Action<FbLoginUtilResult>>();
        static bool s_WaitingLoginResult;

        public static void ConfirmLoginStatus(Action<FbLoginUtilResult> callback)
        {
            s_Callbacks.Add(callback);

            if (FB.IsLoggedIn)
            {
                DispatchLoginSucceeded();
                return;
            }

            if (s_WaitingLoginResult) return;

            s_WaitingLoginResult = true;

            if (FB.IsInitialized)
                OnInitCompleted();
            else
                FB.Init(() =>
                {
                    if (FB.IsInitialized)
                        OnInitCompleted();
                    else
                        DispatchLoginFailed();
                });
        }

        static void OnInitCompleted()
        {
            if (FB.IsLoggedIn)
                DispatchLoginSucceeded();
            else
                FB.Login(result =>
                {
                    if (result.IsSucceeded)
                        DispatchLoginSucceeded();
                    else
                        DispatchLoginFailed();
                });
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
