using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class Table : TableElement {
        public Table(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
        }
    }
}