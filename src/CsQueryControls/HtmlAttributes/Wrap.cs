namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    /// Specifies how the text in a text area is to be wrapped when submitted in a form
    /// </summary>
    public enum Wrap {
        /// <summary>
        /// The text in the textarea is not wrapped when submitted in a form. This is default
        /// </summary>
        Hard,
        /// <summary>
        /// The text in the textarea is wrapped (contains newlines) when submitted in a form. When "hard" is used, the cols attribute must be specified
        /// </summary>
        Soft
    }
}