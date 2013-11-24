using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The q tag defines a short quotation.
    /// Browsers normally insert quotation marks around the quotation.
    /// </summary>
    public class QElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies the source URL of the quote.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string Cite { get { return Attr("cite"); } set { Attr("cite", value); } }

        #endregion

        public QElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Q, parsingMode, parsingOptions, docType) {
        }
    }
}