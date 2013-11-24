using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The style tag is used to define style information for an HTML document.
    /// Inside the style element you specify how HTML elements should render in a browser.
    /// Each HTML document can contain multiple style tags.
    /// </summary>
    public class StyleElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies what media/device the media resource is optimized for.
        /// </summary>
        /// <value>
        /// media_query
        /// </value>
        public virtual string Media {
            get { return Attr("media"); }
            set { Attr("media", value); }
        }
        /// <summary>
        /// Specifies that the styles only apply to this element's parent element and that element's child elements.
        /// </summary>
        /// <value>
        /// scoped
        /// </value>
        public virtual bool Scoped {
            get { return HasAttr("scoped"); }
            set {
                if (value) {
                    Attr("scoped", "scoped");
                } else {
                    RemoveAttr("scoped");
                }
            }
        }
        /// <summary>
        /// Specifies the MIME type of the style sheet.
        /// </summary>
        /// <value>
        /// text/css
        /// </value>
        public virtual string Type {
            get { return Attr("type"); }
            set { Attr("type", value); }
        }

        #endregion

        public StyleElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Style, parsingMode, parsingOptions, docType) {
        }
    }
}