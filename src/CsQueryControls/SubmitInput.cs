using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class SubmitInput : InputElement {
        #region Property

        /// <summary>
        ///     Specifies the URL of the file that will process the input control when the form is submitted (for type="submit" and
        ///     type="image").
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string FormAction { get { return Attr("formaction"); } set { Attr("formaction", value); } }
        /// <summary>
        ///     Specifies how the form-data should be encoded when submitting it to the server (for type="submit" and
        ///     type="image").
        /// </summary>
        /// <value>
        ///     application/x-www-form-urlencoded|multipart/form-data|text/plain
        /// </value>
        public virtual string FormEnctype { get { return Attr("formenctype"); } set { Attr("formenctype", value); } }
        /// <summary>
        ///     Defines the HTTP method for sending data to the action URL (for type="submit" and type="image").
        /// </summary>
        /// <value>
        ///     get|post
        /// </value>
        public virtual FormMethod? FormMethod {
            get {
                FormMethod result;
                return Enum.TryParse(Attr("formmethod"), true, out result) ? result : (FormMethod?) null;
            }
            set { Attr("formmethod", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies where to display the response that is received after submitting the form (for type="submit" and
        ///     type="image").
        /// </summary>
        /// <value>
        ///     _blank|_self|_parent|_top|framename
        /// </value>
        public virtual string FormTarget { get { return Attr("formtarget"); } set { Attr("formtarget", value); } }
        /// <summary>
        ///     Specifies the type input element to display.
        /// </summary>
        /// <value>
        ///     button|checkbox|color|date|datetime|datetime-local|email|file|hidden|image|month|number|password|radio|range|reset|search|submit|tel|text|time|url|week
        /// </value>
        public new InputType? Type { get { return base.Type; } }

        #endregion

        public SubmitInput(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(InputType.Submit, parsingMode, parsingOptions, docType) {
        }
        protected SubmitInput(InputType type, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(type, parsingMode, parsingOptions, docType) {
        }
    }
}