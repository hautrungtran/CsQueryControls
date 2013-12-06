using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class Table : TableElement {
        private TableHeader _header;
        private TableBody _body;
        private TableFooter _footer;
        public TableHeader Header {
            get {
                return _header ?? (_header = new TableHeader());
            }
            set {
                _header = value;
            }
        }
        public TableBody Body {
            get {
                return _body ?? (_body = new TableBody());
            }
            set {
                _body = value;
            }
        }
        public TableFooter Footer {
            get {
                return _footer ?? (_footer = new TableFooter());
            }
            set {
                _footer = value;
            }
        }
        public Table(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
        }
        public void Refresh() {
            if (_header != null) {
                _header.Refresh();
            }
            if (_body != null) {
                _body.Refresh();
            }
            if (_footer != null) {
                _footer.Refresh();
            }
        }
    }
}