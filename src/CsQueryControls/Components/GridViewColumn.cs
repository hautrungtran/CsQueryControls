using CsQuery;

namespace CsQueryControls.Components {
    public class GridViewColumn : TableCell {
        public string Name {
            get {
                return Attr("data-name");
            }
            set {
                Attr("data-name", value);
            }
        }
        public bool Sortable {
            get {
                return Attr<bool>("data-sortable");
            }
            set {
                Attr("data-sortable", ToLowerString(value));
            }
        }
        public GridViewColumn(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(true, parsingMode, parsingOptions, docType) {
            Sortable = true;
        }
    }
}