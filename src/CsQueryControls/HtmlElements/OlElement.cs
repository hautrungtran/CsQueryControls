using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The ol tag defines an ordered list. An ordered list can be numerical or alphabetical.
    ///     Use the li tag to define list items.
    /// </summary>
    public class OlElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that the list order should be descending (9,8,7...).
        /// </summary>
        /// <value>
        ///     reversed
        /// </value>
        public virtual bool Reversed {
            get { return HasAttr("reversed"); }
            set {
                if (value) {
                    Attr("reversed", "reversed");
                } else {
                    RemoveAttr("reversed");
                }
            }
        }
        /// <summary>
        ///     Specifies the start value of an ordered list.
        /// </summary>
        /// <value>
        ///     number
        /// </value>
        public virtual int? Start { get { return Attr<int?>("start"); } set { Attr("start", value); } }
        /// <summary>
        ///     Specifies the kind of marker to use in the list.
        /// </summary>
        /// <value>
        ///     1|A|a|I|i
        /// </value>
        public virtual char? Type { get { return Attr<char?>("type"); } set { Attr("type", value); } }

        #endregion

        public OlElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Ol, parsingMode, parsingOptions, docType) {
        }
    }
}