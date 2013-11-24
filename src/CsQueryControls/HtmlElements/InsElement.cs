using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The ins tag defines a text that has been inserted into a document.
    /// </summary>
    public class InsElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies a URL to a document that explains the reason why the text was inserted/changed.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Cite { get { return Attr("cite"); } set { Attr("cite", value); } }
        /// <summary>
        ///     Specifies the date and time when the text was inserted/changed.
        /// </summary>
        /// <value>
        ///     YYYY-MM-DDThh:mm:ssTZD
        /// </value>
        public virtual string DateTime { get { return Attr("datetime"); } set { Attr("datetime", value); } }

        #endregion

        public InsElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Ins, parsingMode, parsingOptions, docType) {
        }
    }
}