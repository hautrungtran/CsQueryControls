using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CsQuery;
using CsQueryControls.Helper;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Components {
    public class GridView<T> : TableElement {
        private readonly DropdownList _pageSizes;
        private TableHeader _header;
        private TableBody _body;
        private TableFooter _footer;
        public string Key {
            get {
                return Attr("data-key");
            }
            set {
                Attr("data-key", value);
            }
        }
        public string Href {
            get {
                return Attr<string>("data-href");
            }
            set {
                Attr("data-href", value);
            }
        }
        public int PageIndex {
            get {
                return Attr<int>("data-page-index");
            }
            set {
                Attr("data-page-index", value);
            }
        }
        public bool Cache {
            get {
                return Attr<bool>("data-cache");
            }
            set {
                Attr("data-cache", ToLowerString(value));
            }
        }
        public string DefaultText {
            get {
                return Attr("data-default-text");
            }
            set {
                Attr("data-default-text", value);
            }
        }
        public bool AutoGenerateColumns { get; set; }
        public DropdownList PageSizes { get { return _pageSizes; } }
        public ObservableCollection<GridViewColumn> Columns { get; set; }
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
        public GridView(string name, string href, bool autoGenerateColumns = true, bool hasFooter = true, IEnumerable<int> pageSizes = null, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
            AddClass("table");
            Id = name;
            Href = href;
            Header = new TableHeader();
            Body = new TableBody();
            if (hasFooter) {
                Footer = new TableFooter();
            }
            AutoGenerateColumns = autoGenerateColumns;
            Columns = new ObservableCollection<GridViewColumn>();
            Columns.CollectionChanged += (sender, e) => {
                if (autoGenerateColumns) {
                    var rows = Header.Rows.Where(row => row.HasClass("columns"));
                    foreach (var row in rows) {
                        row.Empty();
                        foreach (var column in Columns) {
                            row.Append(column);
                        }
                    }
                }
            };
            if (autoGenerateColumns) {
                var row = new TableRow();
                row.AddClass("columns");
                Header.Rows.Add(row);
                if (hasFooter) {
                    Footer.Rows.Add(row);
                }
                var properties = typeof(T).GetProperties();
                foreach (var property in properties) {
                    var column = new GridViewColumn(parsingMode, parsingOptions, docType) {
                        Name = property.Name,
                        Sortable = true,
                        InnerText = ControlHelper.GetDisplayName(typeof(T), property.Name)
                    };
                    Columns.Add(column);
                }
            }
            DefaultText = "No data found.";
            if (pageSizes != null) {
                _pageSizes = new DropdownList {
                    Items = new ObservableCollection<ListItem>(pageSizes.Select(pageSize => new ListItem {
                        Value = pageSize.ToString(CultureInfo.InvariantCulture),
                        InnerText = pageSize.ToString(CultureInfo.InvariantCulture)
                    }))
                };
            } else {
                _pageSizes = new DropdownList {
                    Items = new ObservableCollection<ListItem> {
                        new ListItem { Value = "10", InnerText = "10"},
                        new ListItem { Value = "20", InnerText = "20"},
                        new ListItem { Value = "50", InnerText = "50"},
                    }
                };
            }
            var commandRow = new TableRow();
            var container = new CommonElement(HtmlTag.Span);
            container.Html(_pageSizes.Render());
            commandRow.Html(container.Render());
            Header.Rows.Add(commandRow);
            if (hasFooter) {
                Footer.Rows.Add(commandRow);
            }
        }
    }
}