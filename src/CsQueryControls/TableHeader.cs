using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class TableHeader : TableContainer {
        public TableHeader(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Thead, parsingMode, parsingOptions, docType) {
        }
    }
}