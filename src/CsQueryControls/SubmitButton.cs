using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class SubmitButton : ButtonElement {
        #region Property

        /// <summary>
        ///     Specifies where to send the form-data when a form is submitted.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Formaction { get { return Attr("formaction"); } set { Attr("formaction", value); } }
        /// <summary>
        ///     Specifies how form-data should be encoded before sending it to a server.
        /// </summary>
        /// <value>
        ///     application/x-www-form-urlencoded|multipart/form-data|text/plain
        /// </value>
        public virtual string Formenctype { get { return Attr("formenctype"); } set { Attr("formenctype", value); } }
        /// <summary>
        ///     Specifies how to send the form-data (which HTTP method to use).
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
        ///     Specifies that the form-data should not be validated on submission.
        /// </summary>
        /// <value>
        ///     formnovalidate
        /// </value>
        public virtual bool FormNoValidate {
            get { return HasAttr("formnovalidate"); }
            set {
                if (value) {
                    Attr("formnovalidate", "formnovalidate");
                } else {
                    RemoveAttr("formnovalidate");
                }
            }
        }
        /// <summary>
        ///     Specifies where to display the response after submitting the form.
        /// </summary>
        /// <value>
        ///     _blank|_self|_parent|_top|framename
        /// </value>
        public virtual string FormTarget { get { return Attr("formtarget"); } set { Attr("formtarget", value); } }
        /// <summary>
        ///     Specifies the type of button.
        /// </summary>
        /// <value>
        ///     button|reset|submit
        /// </value>
        public new ButtonType? Type { get { return base.Type; } }

        #endregion

        public SubmitButton(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(ButtonType.Submit, parsingMode, parsingOptions, docType) {
        }
    }
}