using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The col tag specifies column properties for each column within a colgroup element.
    ///     The col tag is useful for applying styles to entire columns, instead of repeating the styles for each cell, for
    ///     each row.
    /// </summary>
    public class ColElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the alignment of the content related to a col element.
        /// </summary>
        /// <value>
        ///     left|right|center|justify|char
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Specifies the alignment of the content related to a col element to a character.
        /// </summary>
        /// <value>
        ///     character
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual char? Char { get { return Attr<char?>("char"); } set { Attr("char", value); } }
        /// <summary>
        ///     Specifies the number of characters the content will be aligned from the character specified by the char attribute.
        /// </summary>
        /// <value>
        ///     number.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? CharOff { get { return Attr<int?>("charoff"); } set { Attr("charoff", value); } }
        /// <summary>
        ///     Specifies the number of columns a col element should span.
        /// </summary>
        /// <value>
        ///     number
        /// </value>
        public virtual int? Span { get { return Attr<int?>("span"); } set { Attr("span", value); } }
        /// <summary>
        ///     Specifies the vertical alignment of the content related to a col element.
        /// </summary>
        /// <value>
        ///     top|middle|bottom|baseline
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string VAlign { get { return Attr("valign"); } set { Attr("valign", value); } }
        /// <summary>
        ///     Specifies the width of a col element.
        /// </summary>
        /// <value>
        ///     %|pixels|relative_length
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string InnerWidth { get { return Attr("width"); } set { Attr("width", value); } }

        #endregion

        public ColElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Col, parsingMode, parsingOptions, docType) {
        }
    }
}