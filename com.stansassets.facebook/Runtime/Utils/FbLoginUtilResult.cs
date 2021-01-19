using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

namespace StansAssets.Facebook
{
    public class FbLoginUtilResult : IGraphResult
    {
        internal FbLoginUtilResult(bool isSucceeded)
        {
            IsSucceeded = isSucceeded;
            if (!IsSucceeded) Error = "Operation is requires active session, make sure user is logged in";
        }

        public bool IsSucceeded { get; } = false;

        public string Error { get; } = string.Empty;

        public IDictionary<string, string> ErrorDictionary => new Dictionary<string, string>();

        public IDictionary<string, object> ResultDictionary => new Dictionary<string, object>();

        public string RawResult => string.Empty;

        public bool Cancelled => false;

        public IList<object> ResultList => new List<object>();

        public Texture2D Texture => null;
    }
}
