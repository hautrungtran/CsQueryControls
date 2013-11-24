using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class Image : ImgElement {
        public Image(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) { }
    }
}