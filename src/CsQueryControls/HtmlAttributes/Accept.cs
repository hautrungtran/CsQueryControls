namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies the types of files that the server accepts (only for type="file")
    /// </summary>
    public static class Accept {
        /// <summary>
        ///     audio/*: All sound files are accepted
        /// </summary>
        public static string Audio { get { return "audio/*"; } }
        /// <summary>
        ///     video/*: All video files are accepted
        /// </summary>
        public static string Video { get { return "video/*"; } }
        /// <summary>
        ///     image/*: All image files are accepted
        /// </summary>
        public static string Image { get { return "image/*"; } }
    }
}