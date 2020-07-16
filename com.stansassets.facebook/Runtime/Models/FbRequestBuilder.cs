using System.Text;

namespace StansAssets.Facebook
{
    /// <summary>
    /// Facebook Graph API request builder.
    /// </summary>
    public class FbRequestBuilder
    {
        readonly StringBuilder m_Request;

        public FbRequestBuilder(string request)
        {
            m_Request = new StringBuilder(request);
        }

        /// <summary>
        /// Adds facebook Graph API command to a current request.
        /// </summary>
        public void AddCommand(string command, params object[] args)
        {
            m_Request.Append(".");
            m_Request.Append(command);
            m_Request.Append("(");

            for (var i = 0; i < args.Length; i++)
            {
                m_Request.Append(args[i]);
                if (i != args.Length - 1) m_Request.Append(",");
            }

            m_Request.Append(")");
        }

        /// <summary>
        /// Adds a limit command.
        /// </summary>
        public void AddLimit(int limit)
        {
            AddCommand("limit", limit);
        }

        /// <summary>
        /// Add pagination cursor.
        /// </summary>
        public void AddCursor(FbCursor fbCursor)
        {
            if (fbCursor != null) AddCommand(fbCursor.Type.ToString(), fbCursor.Value);
        }

        /// <summary>
        /// Returns built request string.
        /// </summary>
        public string RequestString => m_Request.ToString();
    }
}
