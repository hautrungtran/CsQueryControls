using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The param tag is used to define parameters for plugins embedded with an object element.
    /// </summary>
    public class ParamElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies the name of a parameter.
        /// </summary>
        /// <value>
        /// name
        /// </value>
        public virtual string Name {
            get { return Attr("name"); }
            set { Attr("name", value); }
        }
        /// <summary>
        /// Specifies the MIME type of the parameter.
        /// </summary>
        /// <value>
        /// MIME_type
        /// </value>
        public virtual string Type {
            get { return Attr("type"); }
            set { Attr("type", value); }
        }
        /// <summary>
        /// Specifies the value of the parameter.
        /// </summary>
        /// <value>
        /// value
        /// </value>
        public virtual string Value {
            get { return Attr("value"); }
            set { Attr("value", value); }
        }
        /// <summary>
        /// Specifies the type of the value.
        /// </summary>
        /// <value>
        /// data|ref|object
        /// </value>
        public virtual string ValueType {
            get { return Attr("valuetype"); }
            set { Attr("valuetype", value); }
        }

        #endregion

        public ParamElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Param, parsingMode, parsingOptions, docType) {
        }
    }
}