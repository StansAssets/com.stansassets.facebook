namespace StansAssets.Facebook
{
    /// <summary>
    /// Possible states of the facebook API result
    /// </summary>
    public enum FbResultState
    {
        /// <summary>
        /// Result is succeeded.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Fb returned `null` result.
        /// </summary>
        NullResult = 1,

        /// <summary>
        /// An operation was cancelled by user.
        /// </summary>
        UserCanceled = 2,

        /// <summary>
        /// Graph API error.
        /// </summary>
        ApiError = 3,

        /// <summary>
        /// Returned result is empty.
        /// </summary>
        EmptyRawResult = 4,

        /// <summary>
        /// Failed to parse the result from Facebook.
        /// </summary>
        ParsingFailed = 5,
    }
}