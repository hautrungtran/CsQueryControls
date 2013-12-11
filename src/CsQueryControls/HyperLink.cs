using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class HyperLink : AElement {
        public HyperLink(string href, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
            Href = href;
        }
    }
}