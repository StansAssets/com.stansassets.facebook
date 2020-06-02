using System;
using System.Collections;
using Facebook.Unity;
using UnityEngine.Assertions;

namespace SA.Facebook
{
    /// <summary>
    /// Abstract Graph API result class
    /// </summary>
    public abstract class FbGraphResult : FbResult
    {
        internal FbGraphResult(IGraphResult graphResult)
            : base(graphResult) { }

        protected void ParsePaginatedResult(IDictionary paginatedResult)
        {
            var paging = paginatedResult["paging"] as IDictionary;
            Assert.IsNotNull(paging);
            var cursors = paging["cursors"] as IDictionary;
            Assert.IsNotNull(cursors);

            if (paging.Contains("previous")) Previous = Convert.ToString(paging["previous"]);
            if (paging.Contains("next")) Next = Convert.ToString(paging["next"]);

            Before = Convert.ToString(cursors["before"]);
            After = Convert.ToString(cursors["after"]);
        }

        protected void ParseResultId(IDictionary rawDict)
        {
            Id = Convert.ToString(rawDict["id"]);
        }

        /// <summary>
        /// Request Id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Full request URL for a next page
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// True if request has next page of results
        /// </summary>
        public bool HasNext => !string.IsNullOrEmpty(Next);

        /// <summary>
        /// Full request URL for a previous page
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// True if request has previous page of results
        /// </summary>
        public bool HasPrevious => !string.IsNullOrEmpty(Previous);

        /// <summary>
        /// Request before page pointer
        /// </summary>
        public string Before { get; private set; }

        /// <summary>
        /// Request after page pointer
        /// </summary>
        public string After { get; private set; }

        /// <summary>
        /// Generated before cursor pointer
        /// </summary>
        public FbCursor BeforeFbCursorPointer => new FbCursor(FbCursorType.Before, Before);

        /// <summary>
        /// Generated after cursor pointer
        /// </summary>
        public FbCursor AfterFbCursorPointer => new FbCursor(FbCursorType.After, After);
    }
}
