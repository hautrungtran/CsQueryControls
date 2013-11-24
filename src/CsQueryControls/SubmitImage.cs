using System;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls {
    public class SubmitImage : SubmitInput {
        #region Property

        /// <summary>
        ///     Specifies the alignment of an image input (only for type="image").
        /// </summary>
        /// <value>
        ///     left|right|top|middle|bottom
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Specifies an alternate text for images (only for type="image").
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        public virtual string Alt { get { return Attr("alt"); } set { Attr("alt", value); } }
        /// <summary>
        ///     Specifies the height of an input element (only for type="image").
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerHeight { get { return Attr<int?>("height"); } set { Attr("height", value); } }
        /// <summary>
        ///     Specifies the URL of the image to use as a submit button (only for type="image").
        /// </summary>
        /// <value>
        ///     URL
        /// </value>
        public virtual string Src { get { return Attr("src"); } set { Attr("src", value); } }
        /// <summary>
        ///     Specifies the width of an input element (only for type="image").
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        public virtual int? InnerWidth { get { return Attr<int?>("width"); } set { Attr("width", value); } }

        #endregion

        public SubmitImage(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(InputType.Image, parsingMode, parsingOptions, docType) {
        }
    }
}