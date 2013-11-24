namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies where to display the response after submitting the form. Only for type="submit"
    /// </summary>
    public class FormTarget {
        /// <summary>
        ///     Loads the response in a new window/tab
        /// </summary>
        public static string Blank { get { return "_blank"; } }
        /// <summary>
        ///     Loads the response in the same frame (this is default)
        /// </summary>
        public static string Self { get { return "_self"; } }
        /// <summary>
        ///     Loads the response in the parent frame
        /// </summary>
        public static string Parent { get { return "_parent"; } }
        /// <summary>
        ///     Loads the response in the full body of the window
        /// </summary>
        public static string Top { get { return "_top"; } }
    }
}