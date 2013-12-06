using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The label tag defines a label for an input element.
    ///     The label element does not render as anything special for the user.
    ///     However, it provides a usability improvement for mouse users, because if the user clicks on the text within the
    ///     label element, it toggles the control.
    ///     The for attribute of the label tag should be equal to the id attribute of the related element to bind them
    ///     together.
    /// </summary>
    public class LabelElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies which form element a label is bound to.
        /// </summary>
        /// <value>
        ///     element_id
        /// </value>
        public virtual string For { get { return Attr("for"); } set { Attr("for", value); } }
        /// <summary>
        ///     Specifies one or more forms the label belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }

        #endregion

        public LabelElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Label, parsingMode, parsingOptions, docType) {
        }
    }
}