using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The audio tag defines sound, such as music or other audio streams.
    /// </summary>
    public class AudioElement : ElementBase {
        #region Property

        /// <summary>
        ///     Specifies that the audio will start playing as soon as it is ready.
        /// </summary>
        /// <value>
        ///     autoplay
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
        ///     Specifies that audio controls should be displayed (such as a play/pause button etc).
        /// </summary>
        /// <value>
        ///     controls
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
        ///     Specifies that the audio will start over again, every time it is finished.
        /// </summary>
        /// <value>
        ///     loop.
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
        ///     Specifies that the audio output should be muted.
        /// </summary>
        /// <value>
        ///     muted.
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
        ///     Specifies if and how the author thinks the audio should be loaded when the page loads.
        /// </summary>
        /// <value>
        ///     auto|metadata|none.
        /// </value>
        public virtual Preload? Preload {
            get {
                Preload result;
                return Enum.TryParse(Attr("preload"), true, out result) ? result : (Preload?) null;
            }
            set { Attr("preload", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies the URL of the audio file.
        /// </summary>
        /// <value>
        ///     URL.
        /// </value>
        public virtual string Src { get { return Attr("src"); } set { Attr("src", value); } }

        #endregion

        public AudioElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Audio, parsingMode, parsingOptions, docType) {
        }
    }
}