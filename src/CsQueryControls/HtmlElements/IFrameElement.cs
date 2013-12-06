using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    public class IframeElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the alignment of an iframe according to surrounding elements.
        /// </summary>
        /// <value>
        ///     left|right|top|middle|bottom
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Specifies whether or not to display a border around an iframe.
        /// </summary>
        /// <value>
        ///     1|0
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual bool? FrameBorder {
            get {
                string result = Attr("frameborder");
                return !string.IsNullOrEmpty(result) ? result.ToLower() == "1" : (bool?) null;
            }
            set { Attr("frameborder", value.HasValue ? (value.Value ? "1" : "0") : null); }
        }
        /// <summary>
        ///     Specifies the height of an iframe.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerHeight { get { return Attr<int?>("height"); } set { Attr("height", value); } }
        /// <summary>
        ///     Specifies a page that contains a long description of the content of an iframe.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string LongDesc { get { return Attr("longdesc"); } set { Attr("longdesc", value); } }
        /// <summary>
        ///     Specifies the top and bottom margins of the content of an iframe.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? MarginHeight { get { return Attr<int?>("marginheight"); } set { Attr("marginheight", value); } }
        /// <summary>
        ///     Specifies the left and right margins of the content of an iframe.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? MarginWidth { get { return Attr<int?>("marginwidth"); } set { Attr("marginwidth", value); } }
        /// <summary>
        ///     Specifies the name of an iframe.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
        /// <summary>
        ///     Enables a set of extra restrictions for the content in the iframe.
        /// </summary>
        /// <value>
        ///     ""|allow-forms|allow-same-origin|allow-scripts|allow-top-navigation
        /// </value>
        public virtual string Sandbox { get { return Attr("sandbox"); } set { Attr("sandbox", value); } }
        /// <summary>
        ///     Specifies whether or not to display scrollbars in an iframe.
        /// </summary>
        /// <value>
        ///     yes|no|auto
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual Scrolling? Scrolling {
            get {
                Scrolling result;
                return Enum.TryParse(Attr("scrolling"), true, out result) ? result : (Scrolling?) null;
            }
            set { Attr("scrolling", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies that the iframe should look like it is a part of the containing document.
        /// </summary>
        /// <value>
        ///     seamless
        /// </value>
        public virtual bool Seamless {
            get { return HasAttr("seamless"); }
            set {
                if (value) {
                    Attr("seamless", "seamless");
                } else {
                    RemoveAttr("seamless");
                }
            }
        }
        /// <summary>
        ///     Specifies the address of the document to embed in the iframe.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Src { get { return Attr("src"); } set { Attr("src", value); } }
        /// <summary>
        ///     Specifies the HTML content of the page to show in the iframe.
        /// </summary>
        /// <value>
        ///     HTML_code
        /// </value>
        public virtual string SrcDoc { get { return Attr("srcdoc"); } set { Attr("srcdoc", value); } }
        /// <summary>
        ///     Specifies the width of an iframe.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerWidth { get { return Attr<int?>("width"); } set { Attr("width", value); } }

        #endregion

        public IframeElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Iframe, parsingMode, parsingOptions, docType) {
        }
    }
}