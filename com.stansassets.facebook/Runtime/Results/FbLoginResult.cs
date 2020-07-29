using System.Collections;
using Facebook.Unity;

namespace StansAssets.Facebook
{
    /// <summary>
    /// Login reasult.
    /// </summary>
    public class FbLoginResult : FbResult
    {
        internal FbLoginResult(ILoginResult result)
            : base(result)
        {
            if (State == FbResultState.Success)
            {
                UserId = result.AccessToken.UserId;
                AccessToken = result.AccessToken;
            }
        }

        /// <summary>
        /// Logged User Id.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// User AccessToken.
        /// </summary>
        public AccessToken AccessToken { get; }

        protected override void OnDataReady(IDictionary json)
        {

        }
    }
}
