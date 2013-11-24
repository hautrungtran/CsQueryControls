using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The option tag defines an option in a select list.
    ///     option elements go inside a select or datalist element.
    /// </summary>
    public class OptionElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies that an option should be disabled.
        /// </summary>
        /// <value>
        ///     disabled
        /// </value>
        public virtual bool Disabled {
            get { return HasAttr("disabled"); }
            set {
                if (value) {
                    Attr("disabled", "disabled");
                } else {
                    RemoveAttr("disabled");
                }
            }
        }
        /// <summary>
        ///     Specifies a shorter label for an option.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Label { get { return Attr("label"); } set { Attr("label", value); } }
        /// <summary>
        ///     Specifies that an option should be pre-selected when the page loads.
        /// </summary>
        /// <value>
        ///     selected
        /// </value>
        public virtual bool Selected {
            get { return HasAttr("selected"); }
            set {
                if (value) {
                    Attr("selected", "selected");
                } else {
                    RemoveAttr("selected");
                }
            }
        }
        /// <summary>
        ///     Specifies the value to be sent to a server.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Value { get { return Attr("value"); } set { Attr("value", value); } }

        #endregion

        public OptionElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Option, parsingMode, parsingOptions, docType) {
        }
    }
}