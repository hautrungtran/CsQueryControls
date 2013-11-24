using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The embed tag defines a container for an external application or interactive content (a plug-in).
    /// </summary>
    public class EmbedElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies the height of the embedded content.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerHeight { get { return Attr<int?>("height"); } set { Attr("height", value); } }
        /// <summary>
        ///     Specifies the address of the external file to embed.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Src { get { return Attr("src"); } set { Attr("src", value); } }
        /// <summary>
        ///     Specifies the MIME type of the embedded content.
        /// </summary>
        /// <value>
        ///     MIME_type
        /// </value>
        public virtual string Type { get { return Attr("type"); } set { Attr("type", value); } }
        /// <summary>
        ///     Specifies the width of the embedded content.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerWidth { get { return Attr<int?>("width"); } set { Attr("width", value); } }

        #endregion

        public EmbedElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Embed, parsingMode, parsingOptions, docType) {
        }
    }
}