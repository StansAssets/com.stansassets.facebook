using System.Collections;
using System;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.Assertions;

namespace StansAssets.Facebook
{
    /// <summary>
    /// Friends request result.
    /// </summary>
    public class FbGraphFriendsListResult : FbGraphResult
    {
        internal FbGraphFriendsListResult(IGraphResult graphResult)
            : base(graphResult) { }

        /// <summary>
        /// Total Friends count.
        /// </summary>
        public int TotalFriendsCount { get; private set; }

        /// <summary>
        /// Received users in batch.
        /// </summary>
        public List<FbUser> Users { get; } = new List<FbUser>();

        protected override void OnDataReady(IDictionary json)
        {
            var friends = json["friends"] as IDictionary;
            Assert.IsNotNull(friends);

            var friendsList = friends["data"] as IList;
            Assert.IsNotNull(friendsList);

            foreach (var t in friendsList)
            {
                var user = new FbUser(t as IDictionary);
                Users.Add(user);
            }

            if (friends.Contains("summary"))
            {
                var summary = friends["summary"] as IDictionary;
                Assert.IsNotNull(summary);
                if (summary.Contains("total_count")) TotalFriendsCount = Convert.ToInt32(summary["total_count"]);
            }

            ParseResultId(json);
            ParsePaginatedResult(friends);
        }
    }
}
