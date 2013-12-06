using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The details tag specifies additional details that the user can view or hide on demand.
    ///     The details tag can used to create an interactive widget that the user can open and close.
    ///     Any sort of content can be put inside the details tag.
    ///     The content of a details element should not be visible unless the open attribute is set.
    /// </summary>
    public class DetailsElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that the details should be visible (open) to the user.
        /// </summary>
        /// <value>
        ///     open
        /// </value>
        public virtual bool Open {
            get { return HasAttr("open"); }
            set {
                if (value) {
                    Attr("open", "open");
                } else {
                    RemoveAttr("open");
                }
            }
        }

        #endregion

        public DetailsElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Details, parsingMode, parsingOptions, docType) {
        }
    }
}