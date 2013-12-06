using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class TableBody : TableContainer {
        public TableBody(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Tbody, parsingMode, parsingOptions, docType) {
        }
    }
}