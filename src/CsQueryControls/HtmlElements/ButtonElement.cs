using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The button tag defines a clickable button.
    ///     Inside a button element you can put content, like text or images.
    ///     This is the difference between this element and buttons created with the input element.
    /// </summary>
    public class ButtonElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that a button should automatically get focus when the page loads.
        /// </summary>
        /// <value>
        ///     autofocus
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
        ///     Specifies that a button should be disabled.
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
        ///     Specifies one or more forms the button belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }
        /// <summary>
        ///     Specifies a name for the button.
        /// </summary>
        /// <value>
        ///     name
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
        /// <summary>
        ///     Specifies the type of button.
        /// </summary>
        /// <value>
        ///     button|reset|submit
        /// </value>
        public virtual ButtonType? Type {
            get {
                ButtonType result;
                return Enum.TryParse(Attr("type"), true, out result) ? result : (ButtonType?) null;
            }
            set { Attr("type", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies an initial value for the button.
        /// </summary>
        /// <value>
        ///     text.
        /// </value>
        public virtual string Value { get { return Attr("value"); } set { Attr("value", value); } }

        #endregion

        public ButtonElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Button, parsingMode, parsingOptions, docType) {
        }
        public ButtonElement(ButtonType type, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Button, parsingMode, parsingOptions, docType) {
            Type = type;
        }
    }
}