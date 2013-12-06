using System;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class TableCell : CommonElement {
        #region Property

        /// <summary>
        /// Specifies an abbreviated version of the content in a cell.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public string Abbr {
            get { return Attr("abbr"); }
            set { Attr("abbr", value); }
        }
        /// <summary>
        /// Aligns the content in a cell.
        /// </summary>
        /// <value>
        /// left|right|center|justify|char
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public string Align {
            get { return Attr("align"); }
            set { Attr("align", value); }
        }
        /// <summary>
        /// Categorizes cells.
        /// </summary>
        /// <value>
        /// category_name
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public string Axis {
            get { return Attr("axis"); }
            set { Attr("axis", value); }
        }
        /// <summary>
        /// Specifies the background color of a cell.
        /// </summary>
        /// <value>
        /// rgb(x,x,x)|#xxxxxx|colorname
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public string BgColor {
            get { return Attr("bgcolor"); }
            set { Attr("bgcolor", value); }
        }
        /// <summary>
        /// Aligns the content in a cell to a character.
        /// </summary>
        /// <value>
        /// character
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual char? Char {
            get { return Attr<char?>("char"); }
            set { Attr("char", value); }
        }
        /// <summary>
        /// Sets the number of characters the content will be aligned from the character specified by the char attribute.
        /// </summary>
        /// <value>
        /// number 
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual int? CharOff {
            get { return Attr<int?>("charoff"); }
            set { Attr("charoff", value); }
        }
        /// <summary>
        /// Specifies the number of columns a cell should span.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? ColSpan {
            get { return Attr<int?>("colspan"); }
            set { Attr("colspan", value); }
        }
        /// <summary>
        /// Specifies one or more header cells a cell is related to.
        /// </summary>
        /// <value>
        /// header_id
        /// </value>
        public string Headers {
            get { return Attr("headers"); }
            set { Attr("headers", value); }
        }
        /// <summary>
        /// Sets the height of a cell.
        /// </summary>
        /// <value>
        /// pixels|%
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public string InnerHeight {
            get { return Attr("height"); }
            set { Attr("height", value); }
        }
        /// <summary>
        /// Specifies that the content inside a cell should not wrap.
        /// </summary>
        /// <value>
        /// nowrap
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public virtual bool NoWrap {
            get { return HasAttr("nowrap"); }
            set {
                if (value) {
                    Attr("nowrap", "nowrap");
                } else {
                    RemoveAttr("nowrap");
                }
            }
        }
        /// <summary>
        /// Sets the number of rows a cell should span.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? RowSpan {
            get { return Attr<int?>("rowspan"); }
            set { Attr("rowspan", value); }
        }
        /// <summary>
        /// Defines a way to associate header cells and data cells in a table.
        /// </summary>
        /// <value>
        /// col|colgroup|row|rowgroup
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public string Scope {
            get { return Attr("scope"); }
            set { Attr("scope", value); }
        }
        /// <summary>
        /// Vertical aligns the content in a cell.
        /// </summary>
        /// <value>
        /// top|middle|bottom|baseline
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public string VAlign {
            get { return Attr("valign"); }
            set { Attr("valign", value); }
        }
        /// <summary>
        /// Specifies the width of a cell.
        /// </summary>
        /// <value>
        /// pixels|%
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public string InnerWidth {
            get { return Attr("width"); }
            set { Attr("width", value); }
        }

        #endregion

        public TableCell(bool isHeaderCell = false, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(isHeaderCell ? HtmlTag.Th : HtmlTag.Td, parsingMode, parsingOptions, docType) {
        }
    }
}