using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The table tag defines an HTML table.
    ///     An HTML table consists of the table element and one or more tr, th, and td elements.
    ///     The tr element defines a table row, the th element defines a table header, and the td element defines a table cell.
    ///     A more complex HTML table may also include caption, col, colgroup, thead, tfoot, and tbody elements.
    /// </summary>
    public class TableElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies the alignment of a table according to surrounding text.
        /// </summary>
        /// <value>
        ///     left|center|right
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Align { get { return Attr("align"); } set { Attr("align", value); } }
        /// <summary>
        ///     Specifies the background color for a table.
        /// </summary>
        /// <value>
        ///     rgb(x,x,x)|#xxxxxx|colorname
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string BgColor { get { return Attr("bgcolor"); } set { Attr("bgcolor", value); } }
        /// <summary>
        ///     Specifies whether the table cells should have borders or not.
        /// </summary>
        /// <value>
        ///     1|""
        /// </value>
        public virtual bool Border { get { return Attr("border") == "1"; } set { Attr("border", value ? "1" : string.Empty); } }
        /// <summary>
        ///     Specifies the space between the cell wall and the cell content.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? CellPadding { get { return Attr<int?>("cellpadding"); } set { Attr("cellpadding", value); } }
        /// <summary>
        ///     Specifies the space between cells.
        /// </summary>
        /// <value>
        ///     pixels
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? CellSpacing { get { return Attr<int?>("cellspacing"); } set { Attr("cellspacing", value); } }
        /// <summary>
        ///     Specifies which parts of the outside borders that should be visible.
        /// </summary>
        /// <value>
        ///     void|above|below|hsides|lhs|rhs|vsides|box|border
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Frame { get { return Attr("frame"); } set { Attr("frame", value); } }
        /// <summary>
        ///     Specifies which parts of the inside borders that should be visible.
        /// </summary>
        /// <value>
        ///     none|groups|rows|cols|all
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Rules { get { return Attr("rules"); } set { Attr("rules", value); } }
        /// <summary>
        ///     Specifies a summary of the content of a table.
        /// </summary>
        /// <value>
        ///     text
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Summary { get { return Attr("summary"); } set { Attr("summary", value); } }
        /// <summary>
        ///     Specifies the width of a table.
        /// </summary>
        /// <value>
        ///     pixels|%
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string InnerWidth { get { return Attr("width"); } set { Attr("width", value); } }

        #endregion

        public TableElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Table, parsingMode, parsingOptions, docType) {
        }
    }
}