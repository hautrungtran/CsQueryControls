using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The form tag is used to create an HTML form for user input.
    ///     The form element can contain one or more of the following form elements: input, textarea, button, select, option,
    ///     optgroup, fieldset, label
    /// </summary>
    public class FormElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the types of files that the server accepts (that can be submitted through a file upload).
        /// </summary>
        /// <value>
        ///     MIME_type
        /// </value>
        public virtual string Accept { get { return Attr("accept"); } set { Attr("accept", value); } }
        /// <summary>
        ///     Specifies the character encodings that are to be used for the form submission.
        /// </summary>
        /// <value>
        ///     character_set
        /// </value>
        public virtual string AcceptCharset { get { return Attr("accept-charset"); } set { Attr("accept-charset", value); } }
        /// <summary>
        ///     Specifies where to send the form-data when a form is submitted.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Action { get { return Attr("action"); } set { Attr("action", value); } }
        /// <summary>
        ///     Specifies whether a form should have autocomplete on or off.
        /// </summary>
        /// <value>
        ///     on|off
        /// </value>
        public virtual AutoComplete? AutoComplete {
            get {
                AutoComplete result;
                return Enum.TryParse(Attr("autocomplete"), true, out result) ? result : (AutoComplete?) null;
            }
            set { Attr("autocomplete", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies how the form-data should be encoded when submitting it to the server (only for method="post").
        /// </summary>
        /// <value>
        ///     application/x-www-form-urlencoded|multipart/form-data|text/plain
        /// </value>
        public virtual string Enctype { get { return Attr("enctype"); } set { Attr("enctype", value); } }
        /// <summary>
        ///     Specifies the HTTP method to use when sending form-data.
        /// </summary>
        /// <value>
        ///     get|post
        /// </value>
        public virtual FormMethod? Method {
            get {
                FormMethod result;
                return Enum.TryParse(Attr("method"), true, out result) ? result : (FormMethod?) null;
            }
            set { Attr("method", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies the name of a form.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
        /// <summary>
        ///     Specifies that the form should not be validated when submitted.
        /// </summary>
        /// <value>
        ///     novalidate
        /// </value>
        public virtual bool NoValidate {
            get { return HasAttr("novalidate"); }
            set {
                if (value) {
                    Attr("novalidate", "novalidate");
                } else {
                    RemoveAttr("novalidate");
                }
            }
        }
        /// <summary>
        ///     Specifies where to display the response that is received after submitting the form.
        /// </summary>
        /// <value>
        ///     _blank|_self|_parent|_top
        /// </value>
        public virtual string Target { get { return Attr("target"); } set { Attr("target", value); } }

        #endregion

        public FormElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Form, parsingMode, parsingOptions, docType) {
        }
    }
}