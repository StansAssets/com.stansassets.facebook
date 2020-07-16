using System;
using System.Collections;
using Facebook.Unity;
using StansAssets.Foundation;

namespace StansAssets.Facebook
{
    public class FbGetProfileImageUrlResult : FbResult
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
