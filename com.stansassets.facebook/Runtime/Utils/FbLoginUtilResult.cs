using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

namespace SA.Facebook
{
    public class FbLoginUtilResult : IGraphResult
    {
        readonly string m_Error = string.Empty;
        readonly bool m_IsSucceeded = false;

        public FbLoginUtilResult(bool isSucceeded)
        {
            m_IsSucceeded = isSucceeded;
            if (!m_IsSucceeded) m_Error = "Operation is requires active session, make sure user is logged in";
        }

        public bool IsSucceeded => m_IsSucceeded;

        public string Error => m_Error;

        public IDictionary<string, object> ResultDictionary => new Dictionary<string, object>();

        public string RawResult => string.Empty;

        public bool Cancelled => false;

        public IList<object> ResultList => new List<object>();

        public Texture2D Texture => null;
    }
}
