using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The fieldset tag is used to group related elements in a form.
    ///     The fieldset tag draws a box around the related elements.
    /// </summary>
    public class FieldsetElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies that a group of related form elements should be disabled.
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
        ///     Specifies one or more forms the fieldset belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }
        /// <summary>
        ///     Specifies a name for the fieldset.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }

        #endregion

        public FieldsetElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Fieldset, parsingMode, parsingOptions, docType) {
        }
    }
}