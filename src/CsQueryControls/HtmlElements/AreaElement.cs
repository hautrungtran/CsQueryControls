using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The area tag defines an area inside an image-map (an image-map is an image with clickable areas).
    ///     The area element is always nested inside a map tag.
    /// </summary>
    public class AreaElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies an alternate text for the area. Required if the href attribute is present.
        /// </summary>
        /// <value>
        ///     text.
        /// </value>
        public virtual string Alt { get { return Attr("alt"); } set { Attr("alt", value); } }
        /// <summary>
        ///     Specifies the coordinates of a link.
        /// </summary>
        /// <value>
        ///     coordinates.
        /// </value>
        public virtual string Coords { get { return Attr("coords"); } set { Attr("coords", value); } }
        /// <summary>
        ///     Specifies the hyperlink target to be downloaded.
        /// </summary>
        /// <value>
        ///     filename.
        /// </value>
        public virtual string Download { get { return Attr("download"); } set { Attr("download", value); } }
        /// <summary>
        ///     Specifies the URL of the page the link goes to.
        /// </summary>
        /// <value>
        ///     URL.
        /// </value>
        public virtual string Href { get { return Attr("href"); } set { Attr("href", value); } }
        /// <summary>
        ///     Specifies the language of the linked document.
        /// </summary>
        /// <value>
        ///     language_code.
        /// </value>
        public virtual string HrefLang { get { return Attr("hreflang"); } set { Attr("hreflang", value); } }
        /// <summary>
        ///     Specifies what media/device the linked document is optimized for.
        /// </summary>
        /// <value>
        ///     media_query.
        /// </value>
        public virtual string Media { get { return Attr("media"); } set { Attr("media", value); } }
        /// <summary>
        ///     Specifies the name of an anchor.
        /// </summary>
        /// <value>
        ///     section_name.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual bool NoHref {
            get { return HasAttr("nohref"); }
            set {
                if (value) {
                    Attr("nohref", "nohref");
                } else {
                    RemoveAttr("nohref");
                }
            }
        }
        /// <summary>
        ///     Specifies the name of an anchor.
        /// </summary>
        /// <value>
        ///     alternate|author|bookmark|help|license|next|nofollow|noreferrer|prefetch|prev|search|tag.
        /// </value>
        public virtual Rel? Rel {
            get {
                Rel result;
                return Enum.TryParse(Attr("rel"), true, out result) ? result : (Rel?) null;
            }
            set { Attr("rel", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies the shape of a link.
        /// </summary>
        /// <value>
        ///     default|rect|circle|poly.
        /// </value>
        public virtual Shape? Shape {
            get {
                Shape result;
                return Enum.TryParse(Attr("shape"), true, out result) ? result : (Shape?) null;
            }
            set { Attr("shape", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies where to open the linked document.
        /// </summary>
        /// <value>
        ///     _blank|_parent|_self|_top|framename.
        /// </value>
        public virtual string Target { get { return Attr("target"); } set { Attr("target", value); } }
        /// <summary>
        ///     Specifies the MIME type of the linked document.
        /// </summary>
        /// <value>
        ///     MIME_type.
        /// </value>
        public virtual string Type { get { return Attr("type"); } set { Attr("type", value); } }

        #endregion

        public AreaElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Area, parsingMode, parsingOptions, docType) {
        }
    }
}