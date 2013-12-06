using System.Collections.ObjectModel;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class TableRow : CommonElement {
        private ObservableCollection<TableCell> _cells;
        public ObservableCollection<TableCell> Cells {
            get {
                return _cells ?? (_cells = new ObservableCollection<TableCell>());
            }
            set {
                _cells = value;
            }
        }
        
        public TableRow(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Tr, parsingMode, parsingOptions, docType) {
            Cells.CollectionChanged += (sender, e) => Refresh();
        }
        public TableRow Refresh() {
            Empty();
            foreach (var cell in Cells) {
                Append(cell);
            }
            return this;
        }
    }
}