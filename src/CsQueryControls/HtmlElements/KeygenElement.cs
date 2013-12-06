using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The keygen tag specifies a key-pair generator field used for forms.
    ///     When the form is submitted, the private key is stored locally, and the public key is sent to the server.
    /// </summary>
    public class KeygenElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that a keygen element should automatically get focus when the page loads.
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
        ///     Specifies that the value of the keygen element should be challenged when submitted.
        /// </summary>
        /// <value>
        ///     challenge
        /// </value>
        public virtual bool Challenge {
            get { return HasAttr("challenge"); }
            set {
                if (value) {
                    Attr("challenge", "challenge");
                } else {
                    RemoveAttr("challenge");
                }
            }
        }
        /// <summary>
        ///     Specifies that a keygen element should be disabled.
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
        ///     Specifies one or more forms the keygen element belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }
        /// <summary>
        ///     Specifies the security algorithm of the key.
        /// </summary>
        /// <value>
        ///     rsa|dsa|ec
        /// </value>
        public virtual KeygenType? KeyType {
            get {
                KeygenType result;
                return Enum.TryParse(Attr("keytype"), true, out result) ? result : (KeygenType?) null;
            }
            set { Attr("keytype", ToLowerString(value)); }
        }
        /// <summary>
        ///     Defines a name for the keygen element.
        /// </summary>
        /// <value>
        ///     name
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }

        #endregion

        public KeygenElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Keygen, parsingMode, parsingOptions, docType) {
        }
    }
}