namespace StansAssets.Facebook
{
    /// <summary>
    /// Type of the Graph API paginated cursor.
    /// </summary>
    public enum FbCursorType
    {
        /// <summary>
        /// This is the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        After,

        /// <summary>
        /// This is the cursor that points to the start of the page of data that has been returned.
        /// </summary>
        Before,
    }
}
