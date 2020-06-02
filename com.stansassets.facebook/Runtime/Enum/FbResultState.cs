namespace SA.Facebook
{
    /// <summary>
    /// Possible states of the facebook API result
    /// </summary>
    public enum FbResultState
    {
        Success = 0,
        NullResult = 1,
        UserCanceled = 2,
        ApiError = 3,
        EmptyRawResult = 4,
        ParsingFailed = 5,
    }
}
