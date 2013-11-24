namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies how to send the form-data (which HTTP method to use). Only for type="submit"
    /// </summary>
    public enum FormMethod {
        /// <summary>
        ///     Appends the form-data to the URL: URL?name=value
        /// </summary>
        Get,
        /// <summary>
        ///     Sends the form-data as an HTTP post transaction
        /// </summary>
        Post
    }
}