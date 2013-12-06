using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The canvas tag is used to draw graphics, on the fly, via scripting (usually JavaScript).
    ///     The canvas tag is only a container for graphics, you must use a script to actually draw the graphics.
    /// </summary>
    public class CanvasElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the height of the canvas.
        /// </summary>
        /// <value>
        ///     pixels.
        /// </value>
        public virtual int? InnerHeight { get { return Attr<int?>("height"); } set { Attr("height", value); } }
        /// <summary>
        ///     Specifies the width of the canvas.
        /// </summary>
        /// <value>
        ///     pixels.
        /// </value>
        public virtual int? InnerWidth { get { return Attr<int?>("width"); } set { Attr("width", value); } }

        #endregion

        public CanvasElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Canvas, parsingMode, parsingOptions, docType) {
        }
    }
}