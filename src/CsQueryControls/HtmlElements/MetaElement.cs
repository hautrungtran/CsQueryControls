using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// Metadata is data (information) about data.
    /// The meta tag provides metadata about the HTML document.
    /// Metadata will not be displayed on the page, but will be machine parsable.
    /// Meta elements are typically used to specify page description, keywords, author of the document, last modified, and other metadata.
    /// The metadata can be used by browsers (how to display content or reload page), search engines (keywords), or other web services.
    /// </summary>
    public class MetaElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies the character encoding for the HTML document.
        /// </summary>
        /// <value>
        /// character_set
        /// </value>
        public virtual string Charset {
            get { return Attr("charset"); }
            set { Attr("charset", value); }
        }
        /// <summary>
        /// Gives the value associated with the http-equiv or name attribute.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        public virtual string Content {
            get { return Attr("content"); }
            set { Attr("content", value); }
        }
        /// <summary>
        /// Provides an HTTP header for the information/value of the content attribute.
        /// </summary>
        /// <value>
        /// content-type|default-style|refresh
        /// </value>
        public virtual string HttpEquiv {
            get { return Attr("http-equiv"); }
            set { Attr("http-equiv", value); }
        }
        /// <summary>
        /// Specifies a name for the metadata.
        /// </summary>
        /// <value>
        /// application-name|author|description|generator|keywords
        /// </value>
        public virtual string Name {
            get { return Attr("name"); }
            set { Attr("name", value); }
        }
        /// <summary>
        /// Specifies a scheme to be used to interpret the value of the content attribute.
        /// </summary>
        /// <value>
        /// format/URI
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Scheme {
            get { return Attr("scheme"); }
            set { Attr("scheme", value); }
        }

        #endregion

        public MetaElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Meta, parsingMode, parsingOptions, docType) {
        }
    }
}