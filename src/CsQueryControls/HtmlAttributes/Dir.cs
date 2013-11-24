namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies the text direction for the content in an element.
    /// </summary>
    public enum Dir {
        /// <summary>
        ///     Default. Left-to-right text direction
        /// </summary>
        Ltr,
        /// <summary>
        ///     Right-to-left text direction
        /// </summary>
        Rtl,
        /// <summary>
        ///     Let the browser figure out the text direction, based on the content (only recommended if the text direction is
        ///     unknown)
        /// </summary>
        Auto,
    }
}