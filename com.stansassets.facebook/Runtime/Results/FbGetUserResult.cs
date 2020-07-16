using System.Collections;
using Facebook.Unity;

namespace StansAssets.Facebook
{
    public class FbGetUserResult : FbResult
    {
        public FbGetUserResult(IResult graphResult)
            : base(graphResult) { }

        public FbUser User { get; private set; }

        protected override void OnDataReady(IDictionary json)
        {
            User = new FbUser(json);
        }
    }
}
