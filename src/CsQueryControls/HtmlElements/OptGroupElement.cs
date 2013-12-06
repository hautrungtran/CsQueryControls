using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The optgroup is used to group related options in a drop-down list.
    /// If you have a long list of options, groups of related options are easier to handle for a user.
    /// </summary>
    public class OptGroupElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies that an option-group should be disabled.
        /// </summary>
        /// <value>
        /// disabled
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
        /// Specifies a label for an option-group.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        public virtual string Label {
            get { return Attr("label"); }
            set { Attr("label", value); }
        }

        #endregion

        public OptGroupElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Optgroup, parsingMode, parsingOptions, docType) {
        }
    }
}