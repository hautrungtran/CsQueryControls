namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies where to open the linked document
    /// </summary>
    public static class Target {
        /// <summary>
        ///     Opens the linked document in a new window or tab
        /// </summary>
        public static string Blank { get { return "_blank"; } }
        /// <summary>
        ///     Opens the linked document in the same frame as it was clicked (this is default)
        /// </summary>
        public static string Self { get { return "_self"; } }
        /// <summary>
        ///     Opens the linked document in the parent frame
        /// </summary>
        public static string Parent { get { return "_parent"; } }
        /// <summary>
        ///     Opens the linked document in the full body of the window
        /// </summary>
        public static string Top { get { return "_top"; } }
    }
}