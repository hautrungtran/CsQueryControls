using CsQuery;

namespace CsQueryControls.HtmlElements {
    public class DialogElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that the dialog element is active and that the user can interact with it.
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

        public DialogElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Dialog, parsingMode, parsingOptions, docType) {
        }
    }
}