using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    public class ColGroupElement : ElementBase {
        #region Property

        /// <summary>
        ///     Aligns the content in a column group.
        /// </summary>
        /// <value>
        ///     left|right|center|justify|char
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Aligns the content in a column group to a character.
        /// </summary>
        /// <value>
        ///     character
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual char? Char { get { return Attr<char?>("char"); } set { Attr("char", value); } }
        /// <summary>
        ///     Sets the number of characters the content will be aligned from the character specified by the char attribute.
        /// </summary>
        /// <value>
        ///     number.
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? CharOff { get { return Attr<int?>("charoff"); } set { Attr("charoff", value); } }
        /// <summary>
        ///     Specifies the number of columns a column group should span.
        /// </summary>
        /// <value>
        ///     number
        /// </value>
        public virtual int? Span { get { return Attr<int?>("span"); } set { Attr("span", value); } }
        /// <summary>
        ///     Vertical aligns the content in a column group.
        /// </summary>
        /// <value>
        ///     top|middle|bottom|baseline
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string VAlign { get { return Attr("valign"); } set { Attr("valign", value); } }
        /// <summary>
        ///     Specifies the width of a column group.
        /// </summary>
        /// <value>
        ///     %|pixels|relative_length
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string InnerWidth { get { return Attr("width"); } set { Attr("width", value); } }

        #endregion

        public ColGroupElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Colgroup, parsingMode, parsingOptions, docType) {
        }
    }
}