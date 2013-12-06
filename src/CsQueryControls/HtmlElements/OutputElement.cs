using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The output tag represents the result of a calculation (like one performed by a script).
    /// </summary>
    public class OutputElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies the relationship between the result of the calculation, and the elements used in the calculation.
        /// </summary>
        /// <value>
        /// element_id  
        /// </value>
        public virtual string For {
            get { return Attr("for"); }
            set { Attr("for", value); }
        }
        /// <summary>
        /// Specifies one or more forms the output element belongs to.
        /// </summary>
        /// <value>
        /// form_id
        /// </value>
        public virtual string Form {
            get { return Attr("form"); }
            set { Attr("form", value); }
        }
        /// <summary>
        /// Specifies a name for the output element.
        /// </summary>
        /// <value>
        /// name
        /// </value>
        public virtual string Name {
            get { return Attr("name"); }
            set { Attr("name", value); }
        }

        #endregion

        public OutputElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Output, parsingMode, parsingOptions, docType) {
        }
    }
}