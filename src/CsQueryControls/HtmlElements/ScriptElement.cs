using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The script tag is used to define a client-side script, such as a JavaScript.
    /// The script element either contains scripting statements, or it points to an external script file through the src attribute.
    /// Common uses for JavaScript are image manipulation, form validation, and dynamic changes of content.
    /// </summary>
    public class ScriptElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies that the script is executed asynchronously (only for external scripts).
        /// </summary>
        /// <value>
        /// async
        /// </value>
        public virtual bool Async {
            get { return HasAttr("async"); }
            set {
                if (value) {
                    Attr("async", "async");
                } else {
                    RemoveAttr("async");
                }
            }
        }
        /// <summary>
        /// Specifies the character encoding used in an external script file.
        /// </summary>
        /// <value>
        /// charset
        /// </value>
        public virtual string Charset {
            get { return Attr("charset"); }
            set { Attr("charset", value); }
        }
        /// <summary>
        /// Specifies that the script is executed when the page has finished parsing (only for external scripts).
        /// </summary>
        /// <value>
        /// defer
        /// </value>
        public virtual bool Defer {
            get { return HasAttr("defer"); }
            set {
                if (value) {
                    Attr("defer", "defer");
                } else {
                    RemoveAttr("defer");
                }
            }
        }
        /// <summary>
        /// Specifies the URL of an external script file.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string Src {
            get { return Attr("src"); }
            set { Attr("src", value); }
        }
        /// <summary>
        /// Specifies the MIME type of the script.
        /// </summary>
        /// <value>
        /// MIME-type
        /// </value>
        public virtual string Type {
            get { return Attr("type"); }
            set { Attr("type", value); }
        }

        #endregion

        public ScriptElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Script, parsingMode, parsingOptions, docType) {
        }
    }
}