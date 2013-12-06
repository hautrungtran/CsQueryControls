using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The textarea tag defines a multi-line text input control.
    /// A text area can hold an unlimited number of characters, and the text renders in a fixed-width font (usually Courier).
    /// The size of a text area can be specified by the cols and rows attributes, or even better; through CSS' height and width properties.
    /// </summary>
    public class TextAreaElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies that a text area should automatically get focus when the page loads.
        /// </summary>
        /// <value>
        /// autofocus
        /// </value>
        public virtual bool Autofocus {
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
        /// Specifies the visible width of a text area.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Cols {
            get { return Attr<int?>("cols"); }
            set { Attr("cols", value); }
        }
        /// <summary>
        /// Specifies that a text area should be disabled.
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
        /// Specifies one or more forms the text area belongs to.
        /// </summary>
        /// <value>
        /// form_id
        /// </value>
        public virtual string Form {
            get { return Attr("form"); }
            set { Attr("form", value); }
        }
        /// <summary>
        /// Specifies the maximum number of characters allowed in the text area.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? MaxLength {
            get { return Attr<int?>("maxlength"); }
            set { Attr("maxlength", value); }
        }
        /// <summary>
        /// Specifies a name for a text area.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        public virtual string Name {
            get { return Attr("name"); }
            set { Attr("name", value); }
        }
        /// <summary>
        /// Specifies a short hint that describes the expected value of a text area.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        public virtual string Placeholder {
            get { return Attr("placeholder"); }
            set { Attr("placeholder", value); }
        }
        /// <summary>
        /// Specifies that a text area should be read-only.
        /// </summary>
        /// <value>
        /// readonly
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
        /// Specifies that a text area is required/must be filled out.
        /// </summary>
        /// <value>
        /// required
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
        /// Specifies the visible number of lines in a text area.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Rows {
            get { return Attr<int?>("rows"); }
            set { Attr("rows", value); }
        }
        /// <summary>
        /// Specifies how the text in a text area is to be wrapped when submitted in a form.
        /// </summary>
        /// <value>
        /// hard|soft
        /// </value>
        public virtual Wrap? Wrap {
            get {
                Wrap result;
                return Enum.TryParse(Attr("wrap"), true, out result) ? result : (Wrap?)null;
            }
            set { Attr("wrap", ToLowerString(value)); }
        }

        #endregion

        public TextAreaElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Textarea, parsingMode, parsingOptions, docType) {
        }
    }
}