using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The source tag is used to specify multiple media resources for media elements, such as video and audio.
    /// The source tag allows you to specify alternative video/audio files which the browser may choose from, based on its media type or codec support.
    /// </summary>
    public class SourceElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies the type of media resource.
        /// </summary>
        /// <value>
        /// media_query
        /// </value>
        public virtual string Media {
            get {
                return Attr("media");
            }
            set {
                Attr("media", value);
            }
        }
        /// <summary>
        /// Specifies the URL of the media file.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string Src {
            get {
                return Attr("src");
            }
            set {
                Attr("src", value);
            }
        }
        /// <summary>
        /// Specifies the MIME type of the media resource.
        /// </summary>
        /// <value>
        /// MIME_type
        /// </value>
        public virtual string Type {
            get {
                return Attr("type");
            }
            set {
                Attr("type", value);
            }
        }

        #endregion

        public SourceElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Source, parsingMode, parsingOptions, docType) {
        }
    }
}