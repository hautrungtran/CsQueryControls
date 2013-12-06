using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The input tag specifies an input field where the user can enter data.
    ///     input elements are used within a form element to declare input controls that allow users to input data.
    ///     An input field can vary in many ways, depending on the type attribute.
    /// </summary>
    public class InputElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the types of files that the server accepts (only for type="file").
        /// </summary>
        /// <value>
        ///     audio/*|video/*|image/*|MIME_type
        /// </value>
        public virtual string Accept { get { return Attr("accept"); } set { Attr("accept", value); } }
        /// <summary>
        ///     Specifies whether an input element should have autocomplete enabled.
        /// </summary>
        /// <value>
        ///     on|off
        /// </value>
        public virtual AutoComplete? Autocomplete {
            get {
                AutoComplete result;
                return Enum.TryParse(Attr("autocomplete"), true, out result) ? result : (AutoComplete?) null;
            }
            set { Attr("autocomplete", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies that an input element should automatically get focus when the page loads.
        /// </summary>
        /// <value>
        ///     autofocus
        /// </value>
        public virtual bool AutoFocus {
            get { return HasAttr("autofocus"); }
            set {
                if (value) {
                    Attr("autofocus", "autofocus");
                } else {
                    RemoveAttr("autofocus");
                }
            }
        }
        /// <summary>
        ///     Specifies that an input element should be disabled.
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
        ///     Specifies one or more forms the input element belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }
        /// <summary>
        ///     Defines that form elements should not be validated when submitted.
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
        ///     Refers to a datalist element that contains pre-defined options for an input element.
        /// </summary>
        /// <value>
        ///     datalist_id
        /// </value>
        public virtual string List { get { return Attr("list"); } set { Attr("list", value); } }
        /// <summary>
        ///     Specifies the maximum number of characters allowed in an input element.
        /// </summary>
        /// <value>
        ///     number
        /// </value>
        public virtual int? MaxLength { get { return Attr<int?>("maxlength"); } set { Attr("maxlength", value); } }
        /// <summary>
        ///     Specifies that a user can enter more than one value in an input element.
        /// </summary>
        /// <value>
        ///     multiple
        /// </value>
        public virtual bool Multiple {
            get { return HasAttr("multiple"); }
            set {
                if (value) {
                    Attr("multiple", "multiple");
                } else {
                    RemoveAttr("multiple");
                }
            }
        }
        /// <summary>
        ///     Specifies the name of an input element.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
        /// <summary>
        ///     Specifies a regular expression that an input element's value is checked against.
        /// </summary>
        /// <value>
        ///     regexp.
        /// </value>
        public virtual string Pattern { get { return Attr("pattern"); } set { Attr("pattern", value); } }
        /// <summary>
        ///     Specifies a short hint that describes the expected value of an input element.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Placeholder { get { return Attr("placeholder"); } set { Attr("placeholder", value); } }
        /// <summary>
        ///     Specifies that an input field is read-only.
        /// </summary>
        /// <value>
        ///     readonly
        /// </value>
        public virtual bool Readonly {
            get { return HasAttr("readonly"); }
            set {
                if (value) {
                    Attr("readonly", "readonly");
                } else {
                    RemoveAttr("readonly");
                }
            }
        }
        /// <summary>
        ///     Specifies that an input field must be filled out before submitting the form.
        /// </summary>
        /// <value>
        ///     required
        /// </value>
        public virtual bool Required {
            get { return HasAttr("required"); }
            set {
                if (value) {
                    Attr("required", "required");
                } else {
                    RemoveAttr("required");
                }
            }
        }
        /// <summary>
        ///     Specifies the width, in characters, of an input element.
        /// </summary>
        /// <value>
        ///     The size.
        /// </value>
        public virtual int? Size { get { return Attr<int?>("size"); } set { Attr("size", value); } }
        /// <summary>
        ///     Specifies the type input element to display.
        /// </summary>
        /// <value>
        ///     button|checkbox|color|date|datetime|datetime-local|email|file|hidden|image|month|number|password|radio|range|reset|search|submit|tel|text|time|url|week
        /// </value>
        public virtual InputType? Type {
            get {
                InputType result;
                return Enum.TryParse(Attr("type"), true, out result) ? result : (InputType?) null;
            }
            set { Attr("type", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies the value of an input element.
        /// </summary>
        /// <value>
        ///     text.
        /// </value>
        public virtual string Value { get { return Attr("value"); } set { Attr("value", value); } }

        #endregion

        public InputElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Input, parsingMode, parsingOptions, docType) {
        }
        public InputElement(InputType type, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Input, parsingMode, parsingOptions, docType) {
            Type = type;
        }
    }
}