using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The link tag defines the relationship between a document and an external resource.
    ///     The link tag is most used to link to style sheets.
    /// </summary>
    public class LinkElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies the character encoding of the linked document.
        /// </summary>
        /// <value>
        ///     char_encoding
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Charset { get { return Attr("charset"); } set { Attr("charset", value); } }
        /// <summary>
        ///     Specifies the location of the linked document.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Href { get { return Attr("href"); } set { Attr("href", value); } }
        /// <summary>
        ///     Specifies the language of the text in the linked document.
        /// </summary>
        /// <value>
        ///     language_code
        /// </value>
        public virtual string HrefLang { get { return Attr("hreflang"); } set { Attr("hreflang", value); } }
        /// <summary>
        ///     Specifies on what device the linked document will be displayed.
        /// </summary>
        /// <value>
        ///     media_query
        /// </value>
        public virtual string Media { get { return Attr("media"); } set { Attr("media", value); } }
        /// <summary>
        ///     Required. Specifies the relationship between the current document and the linked document.
        /// </summary>
        /// <value>
        ///     alternate|archives|author|bookmark|external|first|help|icon|last|license|next|nofollow|noreferrer|pingback|prefetch|prev|search|sidebar|stylesheet|tag|up
        /// </value>
        public virtual string Rel { get { return Attr("rel"); } set { Attr("rel", value); } }
        /// <summary>
        ///     Specifies the relationship between the linked document and the current document.
        /// </summary>
        /// <value>
        ///     reversed relationship
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Rev { get { return Attr("rev"); } set { Attr("rev", value); } }
        /// <summary>
        ///     Specifies the size of the linked resource. Only for rel="icon".
        /// </summary>
        /// <value>
        ///     HeightxWidth|any
        /// </value>
        public virtual string Sizes { get { return Attr("sizes"); } set { Attr("sizes", value); } }
        /// <summary>
        ///     Specifies where the linked document is to be loaded.
        /// </summary>
        /// <value>
        ///     _blank|_self|_top|_parent|frame_name
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Target { get { return Attr("target"); } set { Attr("target", value); } }
        /// <summary>
        ///     Specifies the MIME type of the linked document.
        /// </summary>
        /// <value>
        ///     MIME_type
        /// </value>
        public virtual string Type { get { return Attr("type"); } set { Attr("type", value); } }

        #endregion

        public LinkElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Link, parsingMode, parsingOptions, docType) {
        }
    }
}