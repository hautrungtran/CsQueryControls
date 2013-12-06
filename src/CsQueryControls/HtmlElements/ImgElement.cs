using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The img tag defines an image in an HTML page.
    ///     The img tag has two required attributes: src and alt.
    /// </summary>
    public class ImgElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the alignment of an image according to surrounding elements.
        /// </summary>
        /// <value>
        ///     top|bottom|middle|left|right
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Specifies an alternate text for an image.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Alt { get { return Attr("alt"); } set { Attr("alt", value); } }
        /// <summary>
        ///     Specifies the width of the border around an image.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? Border { get { return Attr<int?>("border"); } set { Attr("border", value); } }
        /// <summary>
        ///     Allow images from third-party sites that allow cross-origin access to be used with canvas.
        /// </summary>
        /// <value>
        ///     anonymous|use-credentials
        /// </value>
        public virtual string CrossOrigin { get { return Attr("crossorigin"); } set { Attr("crossorigin", value); } }
        /// <summary>
        ///     Specifies the height of an image.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerHeight { get { return Attr<int?>("height"); } set { Attr("height", value); } }
        /// <summary>
        ///     Specifies the whitespace on left and right side of an image.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? HSpace { get { return Attr<int?>("hspace"); } set { Attr("hspace", value); } }
        /// <summary>
        ///     Specifies an image as a server-side image-map.
        /// </summary>
        /// <value>
        ///     ismap
        /// </value>
        public virtual bool IsMap {
            get { return HasAttr("ismap"); }
            set {
                if (value) {
                    Attr("ismap", "ismap");
                } else {
                    RemoveAttr("ismap");
                }
            }
        }
        /// <summary>
        ///     Specifies the URL to a document that contains a long description of an image.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string LongDesc { get { return Attr("longdesc"); } set { Attr("longdesc", value); } }
        /// <summary>
        ///     Specifies the URL of an image.
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Src { get { return Attr("src"); } set { Attr("src", value); } }
        /// <summary>
        ///     Specifies an image as a client-side image-map.
        /// </summary>
        /// <value>
        ///     #mapname
        /// </value>
        public virtual string UseMap { get { return Attr("usemap"); } set { Attr("usemap", value); } }
        /// <summary>
        ///     Specifies the whitespace on top and bottom of an image.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? VSpace { get { return Attr<int?>("vspace"); } set { Attr("vspace", value); } }
        /// <summary>
        ///     Specifies the width of an image.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerWidth { get { return Attr<int?>("width"); } set { Attr("width", value); } }

        #endregion

        public ImgElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Img, parsingMode, parsingOptions, docType) {
        }
    }
}