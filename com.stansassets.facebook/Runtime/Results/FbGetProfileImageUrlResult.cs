using System.Collections;
using Facebook.Unity;

namespace StansAssets.Facebook
{
    class FbGetProfileImageUrlResult : FbResult
    {
        public FbGetProfileImageUrlResult(IResult graphResult)
            : base(graphResult) { }

        public string Url { get; private set; }

        protected override void OnDataReady(IDictionary json)
        {
            var user = new FbUser(json);
            Url = user.PictureUrl;
        }
    }
}
