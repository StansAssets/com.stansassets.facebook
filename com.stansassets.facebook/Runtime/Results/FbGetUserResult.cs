using System.Collections;
using Facebook.Unity;

namespace StansAssets.Facebook
{
    /// <summary>
    /// User request result.
    /// </summary>
    public class FbGetUserResult : FbResult
    {
        internal FbGetUserResult(IResult graphResult)
            : base(graphResult) { }

        public FbUser User { get; private set; }

        protected override void OnDataReady(IDictionary json)
        {
            User = new FbUser(json);
        }
    }
}
