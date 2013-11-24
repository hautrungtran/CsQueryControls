using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class Label : LabelElement {
        public Label(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
        }
    }
}