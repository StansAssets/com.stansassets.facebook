using System.Collections;
using Facebook.Unity;

namespace StansAssets.Facebook
{
    public class FbLoginResult : FbResult
    {
        public FbLoginResult(ILoginResult result)
            : base(result)
        {
            if (State == FbResultState.Success)
            {
                UserId = result.AccessToken.UserId;
                AccessToken = result.AccessToken;
            }
        }

        public string UserId { get; }

        public AccessToken AccessToken { get; }

        protected override void OnDataReady(IDictionary json)
        {

        }
    }
}
