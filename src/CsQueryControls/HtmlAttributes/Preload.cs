namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies if and how the author thinks the audio should be loaded when the page loads
    /// </summary>
    public enum Preload {
        /// <summary>
        ///     The author thinks that the browser should NOT load the audio file when the page loads
        /// </summary>
        None,
        /// <summary>
        ///     The author thinks that the browser should load the entire audio file when the page loads
        /// </summary>
        Auto,
        /// <summary>
        ///     The author thinks that the browser should load only metadata when the page loads
        /// </summary>
        Metadata,
    }
}