namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies whether the dragged data is copied, moved, or linked, when dropped.
    /// </summary>
    public enum Dropzone {
        /// <summary>
        ///     Dropping the data will result in a copy of the dragged data
        /// </summary>
        Copy,
        /// <summary>
        ///     Dropping the data will result in that the dragged data is moved to the new location
        /// </summary>
        Move,
        /// <summary>
        ///     Dropping the data will result in a link to the original data
        /// </summary>
        Link
    }
}