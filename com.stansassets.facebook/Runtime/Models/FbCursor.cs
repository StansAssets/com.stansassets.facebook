namespace StansAssets.Facebook
{
    /// <summary>
    /// The representation of Graph API paginated cursor.
    /// </summary>
    public class FbCursor
    {
        /// <summary>
        /// Cursor type.
        /// </summary>
        public FbCursorType Type { get; }

        /// <summary>
        /// Cursor value
        /// </summary>
        public string Value { get; }

        public FbCursor(FbCursorType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
