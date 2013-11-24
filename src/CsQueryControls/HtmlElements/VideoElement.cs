using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The video tag specifies video, such as a movie clip or other video streams.
    /// Currently, there are 3 supported video formats for the video element: MP4, WebM, and Ogg
    /// </summary>
    public class VideoElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies that the video will start playing as soon as it is ready.
        /// </summary>
        /// <value>
        /// autoplay
        /// </value>
        public virtual bool Autoplay {
            get { return HasAttr("autoplay"); }
            set {
                if (value) {
                    Attr("autoplay", "autoplay");
                } else {
                    RemoveAttr("autoplay");
                }
            }
        }
        /// <summary>
        /// Specifies that video controls should be displayed (such as a play/pause button etc).
        /// </summary>
        /// <value>
        /// controls
        /// </value>
        public virtual bool Controls {
            get { return HasAttr("controls"); }
            set {
                if (value) {
                    Attr("controls", "controls");
                } else {
                    RemoveAttr("controls");
                }
            }
        }
        /// <summary>
        /// Sets the height of the video player.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        public virtual int? InnerHeight {
            get { return Attr<int?>("height"); }
            set { Attr("height", value); }
        }
        /// <summary>
        /// Specifies that the video will start over again, every time it is finished.
        /// </summary>
        /// <value>
        /// loop
        /// </value>
        public virtual bool Loop {
            get { return HasAttr("loop"); }
            set {
                if (value) {
                    Attr("loop", "loop");
                } else {
                    RemoveAttr("loop");
                }
            }
        }
        /// <summary>
        /// Specifies that the audio output of the video should be muted.
        /// </summary>
        /// <value>
        /// muted
        /// </value>
        public virtual bool Muted {
            get { return HasAttr("muted"); }
            set {
                if (value) {
                    Attr("muted", "muted");
                } else {
                    RemoveAttr("muted");
                }
            }
        }
        /// <summary>
        /// Specifies an image to be shown while the video is downloading, or until the user hits the play button.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string Poster {
            get { return Attr("poster"); }
            set { Attr("poster", value); }
        }
        /// <summary>
        /// Specifies if and how the author thinks the video should be loaded when the page loads.
        /// </summary>
        /// <value>
        /// auto|metadata|none
        /// </value>
        public virtual Preload? Preload {
            get {
                Preload result;
                return Enum.TryParse(Attr("preload"), true, out result) ? result : (Preload?)null;
            }
            set { Attr("preload", ToLowerString(value)); }
        }
        /// <summary>
        /// Specifies the URL of the video file.
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
        /// Sets the width of the video player.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        public virtual int? InnerWidth {
            get { return Attr<int?>("width"); }
            set { Attr("width", value); }
        }

        #endregion

        public VideoElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Video, parsingMode, parsingOptions, docType) {
        }
    }
}