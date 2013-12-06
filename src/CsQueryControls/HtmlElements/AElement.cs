using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     Defines a hyperlink, which is used to link from one page to another.
    /// </summary>
    public class AElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the character-set of a linked document.
        /// </summary>
        /// <value>
        ///     char_encoding.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual char? Charset { get { return Attr<char?>("charset"); } set { Attr("charset", value); } }
        /// <summary>
        ///     Specifies the coordinates of a link.
        /// </summary>
        /// <value>
        ///     coordinates.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
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
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
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
        ///     Specifies the relationship between the linked document and the current document.
        /// </summary>
        /// <value>
        ///     text.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual Rev? Rev {
            get {
                Rev result;
                return Enum.TryParse(Attr("rev"), true, out result) ? result : (Rev?) null;
            }
            set { Attr("rev", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies the shape of a link.
        /// </summary>
        /// <value>
        ///     default|rect|circle|poly.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
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

        public AElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.A, parsingMode, parsingOptions, docType) {
        }
    }
}