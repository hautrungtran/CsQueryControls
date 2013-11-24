using System;

namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies whether or not to display scrollbars in an iframe
    /// </summary>
    [Obsolete("Not supported in HTML5.")]
    public enum Scrolling {
        /// <summary>
        ///     Scrollbars appear if needed (this is default)
        /// </summary>
        Auto,
        /// <summary>
        ///     Scrollbars are always shown (even if they are not needed)
        /// </summary>
        Yes,
        /// <summary>
        ///     Scrollbars are never shown (even if they are needed)
        /// </summary>
        No,
    }
}