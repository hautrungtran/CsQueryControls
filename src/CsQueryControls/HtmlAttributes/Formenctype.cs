namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies how form-data should be encoded before sending it to a server. Only for type="submit"
    /// </summary>
    public static class Formenctype {
        /// <summary>
        ///     application/x-www-form-urlencoded: Default. All characters will be encoded before sent
        /// </summary>
        public static string Application { get { return "application/x-www-form-urlencoded"; } }
        /// <summary>
        ///     multipart/form-data: No characters are encoded (use this when you are using forms that have a file upload control)
        /// </summary>
        public static string Multipart { get { return "multipart/form-data"; } }
        /// <summary>
        ///     text/plain: Spaces are converted to "+" symbols, but no characters are encoded
        /// </summary>
        public static string Text { get { return "text/plain"; } }
    }
}