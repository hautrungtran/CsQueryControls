using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The blockquote tag specifies a section that is quoted from another source.
    /// </summary>
    public class BlockQuoteElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies the source of the quotation.
        /// </summary>
        /// <value>
        ///     URL.
        /// </value>
        public virtual string Cite { get { return Attr("cite"); } set { Attr("cite", value); } }

        #endregion

        public BlockQuoteElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Blockquote, parsingMode, parsingOptions, docType) {
        }
    }
}