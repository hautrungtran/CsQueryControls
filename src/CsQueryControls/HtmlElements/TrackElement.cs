using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The track tag specifies text tracks for media elements (audio and video).
    /// This element is used to specify subtitles, caption files or other files containing text, that should be visible when the media is playing.
    /// </summary>
    public class TrackElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies that the track is to be enabled if the user's preferences do not indicate that another track would be more appropriate.
        /// </summary>
        /// <value>
        /// default
        /// </value>
        public virtual bool Default {
            get { return HasAttr("default"); }
            set {
                if (value) {
                    Attr("default", "default");
                } else {
                    RemoveAttr("default");
                }
            }
        }
        /// <summary>
        /// Specifies the kind of text track.
        /// </summary>
        /// <value>
        /// captions|chapters|descriptions|metadata|subtitles
        /// </value>
        public virtual Kind? Kind {
            get {
                Kind result;
                return Enum.TryParse(Attr("kind"), true, out result) ? result : (Kind?)null;
            }
            set { Attr("kind", ToLowerString(value)); }
        }
        /// <summary>
        /// Specifies the title of the text track.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        public virtual string Label {
            get { return Attr("label"); }
            set { Attr("label", value); }
        }
        /// <summary>
        /// Required. Specifies the URL of the track file.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string Src {
            get { return Attr("src"); }
            set { Attr("src", value); }
        }
        /// <summary>
        /// Specifies the language of the track text data (required if kind="subtitles").
        /// </summary>
        /// <value>
        /// language_code
        /// </value>
        public virtual string SrcLang {
            get { return Attr("srclang"); }
            set { Attr("srclang", value); }
        }

        #endregion

        public TrackElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Track, parsingMode, parsingOptions, docType) {
        }
    }
}