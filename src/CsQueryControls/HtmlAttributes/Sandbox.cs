namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Enables a set of extra restrictions for the content in the iframe
    /// </summary>
    public class Sandbox {
        /// <summary>
        ///     Applies all restrictions.
        /// </summary>
        public static string All { get { return ""; } }
        /// <summary>
        ///     Allows form submission.
        /// </summary>
        public static string AllowForms { get { return "allow-forms"; } }
        /// <summary>
        ///     Allows the iframe content to be treated as being from the same origin as the containing document.
        /// </summary>
        public static string AllowSameOrigin { get { return "allow-same-origin"; } }
        /// <summary>
        ///     Allows script execution.
        /// </summary>
        public static string AllowScripts { get { return "allow-scripts"; } }
        /// <summary>
        ///     Allows the iframe content to navigate (load) content from the containing document.
        /// </summary>
        public static string AllowTopNavigation { get { return "allow-top-navigation"; } }
    }
}