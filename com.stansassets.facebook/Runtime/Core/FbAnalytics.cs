using System.Collections.Generic;
using UnityEngine;

namespace StansAssets.Facebook
{
    public static class FbAnalytics
    {
        /// <summary>
        /// Publishes an App Event. App Events allow you to measure the effectiveness of your Facebook app ads and better understand
        /// the makeup of users engaging with your app. You can use one of 14 predefined events such as 'level achieved', or use custom
        /// events you define.
        ///
        /// Log events that could help you understand player behavior and measure engagement coming from your App Ads on Facebook.
        /// How often these events occur is reported in aggregate with through Facebook Analytics for Apps.
        /// <para> <see href="https://developers.facebook.com/docs/analytics"/> for information </para>
        ///
        /// Note: Users do not need to be logged in with Facebook in order for you to log App Events.
        /// Note: Predefined events in Facebook.Unity.AppEventName
        /// </summary>
        /// <param name="logEvent">The name of the event to log</param>
        /// <param name="valueToSum">A number representing a value to be summed when reported </param>
        /// <param name="parameters">Any parameters needed to describe the event </param>
        public static void LogAppEvent(string logEvent, float? valueToSum = null, Dictionary<string, object> parameters = null)
        {
            if (!Fb.IsInitialized)
            {
                Debug.LogError("SA_FB_Analytics: " + logEvent + " was skipped Facebook SDK not initialized. " +
                    "Make sure you initialized Facebook SDK on your application start.");
                return;
            }

            FbUnity.LogAppEvent(logEvent, valueToSum, parameters);
        }

        /// <summary>
        ///A convenience method has been provided to log real-money in-app purchases, which is the most common use of event logging.
        /// </summary>
        /// <param name="logPurchase">The name of the event to log</param>
        /// <param name="currency">ISO currency code e.g "USD" </param>
        /// <param name="parameters">Any parameters needed to describe the event </param>
        public static void LogPurchase(float logPurchase, string currency = null, Dictionary<string, object> parameters = null)
        {
            if (!Fb.IsInitialized)
            {
                Debug.LogError("SA_FB_Analytics: LogPurchase was skipped Facebook SDK not initialized. " +
                    "Make sure you initialized Facebook SDK on your application start.");
                return;
            }

            FbUnity.LogPurchase(logPurchase, currency, parameters);
        }
    }
}
