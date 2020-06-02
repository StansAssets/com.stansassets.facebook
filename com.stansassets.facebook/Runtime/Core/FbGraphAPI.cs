using System;
using Facebook.Unity;

namespace SA.Facebook
{
    // ReSharper disable once InconsistentNaming
    public class FbGraphAPI
    {
        /// <summary>
        /// This edge allows you to:
        /// get the User's friends who have installed the app making the query
        /// get the User's total number of friends (including those who have not installed the app making the query)
        /// <para>Requires  <b>"user_friends" </b> permission
        /// <see href="https://developers.facebook.com/docs/graph-api/reference/user/friends"/> for information </para>
        /// </summary>
        /// <param name="limit">Result limit </param>
        /// <param name="callback">Request callback </param>
        /// <param name="fbCursor">Pagination cursor pointer </param>
        public void GetFriends(int limit, Action<FbGraphFriendsListResult> callback, FbCursor fbCursor = null)
        {
            var request = new FbRequestBuilder("/me?fields=friends");
            request.AddLimit(limit);
            request.AddCommand("fields", "first_name,id,last_name,name,link,locale,picture");
            request.AddCursor(fbCursor);

            FB.API(request.RequestString, HttpMethod.GET,
                graphResult =>
                {
                    var result = new FbGraphFriendsListResult(graphResult);
                    callback.Invoke(result);
                });
        }

        internal void GetLoggedInUserInfo(Action<FbGetUserResult> callback)
        {
            var request = new FbRequestBuilder("/me?fields=id,name,first_name,last_name,email,gender,birthday,age_range,location,picture");
            FB.API(request.RequestString, HttpMethod.GET,
                graphResult =>
                {
                    var result = new FbGetUserResult(graphResult);
                    callback.Invoke(result);
                });
        }

        internal void ResolveProfileImageUrl(string id, FbProfileImageSize size, Action<string> callback)
        {
            var request = new FbRequestBuilder($"/{id}?fields=picture.type({size.ToString().ToLower()})");
            FB.API(request.RequestString, HttpMethod.GET,
                graphResult =>
                {
                    var result = new FbGetProfileImageUrlResult(graphResult);
                    callback.Invoke(result.Url);
                });
        }
    }
}
