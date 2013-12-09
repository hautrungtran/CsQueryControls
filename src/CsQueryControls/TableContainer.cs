using System.Collections.ObjectModel;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public abstract class TableContainer : CommonElement {
        private ObservableCollection<TableRow> _rows;
        public ObservableCollection<TableRow> Rows {
            get {
                return _rows ?? (_rows = new ObservableCollection<TableRow>());
            }
            set {
                _rows = value;
            }
        }
        protected TableContainer(HtmlTag tag, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(tag, parsingMode, parsingOptions, docType) {
            Rows.CollectionChanged += (sender, e) => Refresh();
        }
        public TableContainer Refresh() {
            Empty();
            foreach (var row in Rows) {
                Append(row.Refresh());
            }
            return this;
        }
    }
}