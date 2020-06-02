using System.Collections;
using Facebook.Unity;

namespace SA.Facebook
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
