using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class Table : TableElement {
        private TableHeader _header;
        private TableBody _body;
        private TableFooter _footer;
        public TableHeader Header {
            get {
                return _header;
            }
            set {
                if (_header == null) {
                    Append(value);
                }
                _header = value;
            }
        }
        public TableBody Body {
            get {
                return _body;
            }
            set {
                if (_body == null) {
                    Append(value);
                }
                _body = value;
            }
        }
        public TableFooter Footer {
            get {
                return _footer;
            }
            set {
                if (_footer == null) {
                    Append(value);
                }
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