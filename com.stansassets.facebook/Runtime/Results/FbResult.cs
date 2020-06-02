using System;
using System.Collections;
using Facebook.Unity;
using StansAssets.Foundation;

namespace SA.Facebook
{
    /// <summary>
    /// Facebook API callback result representation.
    /// </summary>
    public abstract class FbResult
    {
        /// <summary>
        /// The result state.
        /// </summary>
        public FbResultState State { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this result is succeeded.
        /// </summary>
        /// <value><c>true</c> if is succeeded; otherwise, <c>false</c>.</value>
        public bool IsSucceeded => State == FbResultState.Success;

        /// <summary>
        /// Gets a value indicating whether this result is failed.
        /// </summary>
        /// <value><c>true</c> if is failed; otherwise, <c>false</c>.</value>
        public bool IsFailed => !IsSucceeded;

        /// <summary>
        /// Gets the raw result string.
        /// </summary>
        public string RawResult { get; }

        /// <summary>
        /// Error message. Only available when <see cref="State"/> is <see cref="FbResultState.ApiError"/>
        /// </summary>
        public string Error { get; internal set; }

        internal FbResult(IResult graphResult)
        {
            State = GetResultState(graphResult);
            if (State == FbResultState.ApiError)
            {
                Error = graphResult.Error;
            }

            RawResult = graphResult.RawResult;
            if (State == FbResultState.Success)
            {
                try
                {
                    var json  = Json.Deserialize(RawResult) as IDictionary;
                    OnDataReady(json);
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    State = FbResultState.ParsingFailed;
                }
            }
        }

        protected abstract void OnDataReady(IDictionary json);

        FbResultState GetResultState(IResult graphResult)
        {
            if (graphResult == null) return FbResultState.NullResult;
            if (graphResult.Cancelled) return FbResultState.UserCanceled;
            if (!string.IsNullOrEmpty(graphResult.Error)) return FbResultState.ApiError;
            if (string.IsNullOrEmpty(graphResult.RawResult)) return FbResultState.EmptyRawResult;

            return FbResultState.Success;
        }
    }
}
