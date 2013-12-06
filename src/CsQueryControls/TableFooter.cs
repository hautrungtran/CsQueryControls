using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class TableFooter : TableContainer {
        public TableFooter(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Tfoot, parsingMode, parsingOptions, docType) {
        }
    }
}