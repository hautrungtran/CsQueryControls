using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CsQuery;
using CsQueryControls.Helper;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Components {
    public class GridView<T> : TableElement {
        private IEnumerable<int> _pageSizes;
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
        public string PageDisplay { get; set; }
        public bool AutoGenerateColumns { get; set; }
        public ObservableCollection<GridColumn> Columns { get; private set; }
        public TableHeader Header {
            get {
                return _header;
            }
            set {
                if (_header != null) {
                    _header.Remove();
                }
                _header = value;
                Append(value);
            }
        }
        public TableBody Body {
            get {
                return _body;
            }
            set {
                if (_body != null) {
                    _body.Remove();
                }
                _body = value;
                Append(value);
            }
        }
        public TableFooter Footer {
            get {
                return _footer;
            }
            set {
                if (_footer != null) {
                    _footer.Remove();
                }
                _footer = value;
                Append(value);
            }
        }
        public GridTheme Theme { get; set; }
        public GridView(string name, string href, bool autoGenerateColumns = true, bool hasFooter = true,
            IEnumerable<int> pageSizes = null, GridTheme theme = null,
            HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
            Initialize(name, href, autoGenerateColumns, hasFooter, pageSizes, theme);
        }
        private void Initialize(string name, string href, bool autoGenerateColumns, bool hasFooter,
            IEnumerable<int> pageSizes, GridTheme theme) {
            if (theme == null) {
                theme = DefaulTheme;
            }
            Theme = theme;
            Class = Theme.Table;
            Id = name;
            Href = href;
            AutoGenerateColumns = autoGenerateColumns;
            Header = new TableHeader();
            Body = new TableBody();
            if (hasFooter) {
                Footer = new TableFooter();
            }
            DefaultText = "No data found.";
            PageDisplay = "page {0} of {1}";
            if (pageSizes == null) {
                pageSizes = new List<int> { 10, 20, 50 };
            }
            _pageSizes = pageSizes;
            InitColumns();
            InitCommands();
        }
        private void InitColumns() {
            if (Columns != null) return;
            Columns = new ObservableCollection<GridColumn>();
            Columns.CollectionChanged += (sender, e) => {
                if (!AutoGenerateColumns) return;
                var rows = Header.Rows.Where(row => row.HasClass(Theme.Columns));
                if (Footer != null) {
                    rows = rows.Concat(Footer.Rows.Where(row => row.HasClass(Theme.Columns)));
                }
                foreach (var row in rows) {
                    row.Empty();
                    foreach (var column in Columns) {
                        row.Cells.Add(column);
                    }
                }
            };
            if (AutoGenerateColumns) {
                Header.Rows.Add(new TableRow {
                    Class = Theme.Columns
                });
                if (Footer != null) {
                    Footer.Rows.Insert(0, new TableRow {
                        Class = Theme.Columns
                    });
                }
                var properties = typeof(T).GetProperties();
                foreach (var property in properties) {
                    var column = new GridColumn {
                        Name = property.Name,
                        Sortable = true,
                        InnerText = ControlHelper.GetDisplayName(typeof(T), property.Name)
                    };
                    Columns.Add(column);
                }
            }
        }
        private void InitCommands() {
            var commandContainer = Find(ToSelector(Theme.CommandContainer));
            if (commandContainer.Any()) return;
            var row = new TableRow();
            commandContainer = new TableCell {
                Class = Theme.CommandContainer,
                ColSpan = Columns.Count
            };
            row.Cells.Add((TableCell)commandContainer);
            Columns.CollectionChanged += (sender, e) => ((TableCell)commandContainer).ColSpan = Columns.Count;
            Header.Rows.Insert(0, row);
            if (Footer != null) {
                Footer.Rows.Add(row);
            }
            InitPagerCommands();

        }
        private void InitPagerCommands() {
            var commandContainer = Find(ToSelector(Theme.CommandContainer));
            var pagerContainer = commandContainer.Find(ToSelector(Theme.PagerContainer));
            if (pagerContainer.Any()) return;
            pagerContainer = new CommonElement(HtmlTag.Span) {
                Class = Theme.PagerContainer
            };
            var firstButton = new Button {
                Class = Theme.FirstButton,
                InnerHtml = new CommonElement(HtmlTag.I) { Class = Theme.FirstIcon }.RenderHtml().ToHtmlString()
            };
            var previousButton = new Button {
                Class = Theme.PreviousButton,
                InnerHtml = new CommonElement(HtmlTag.I) { Class = Theme.PreviousIcon }.RenderHtml().ToHtmlString()
            };
            var pageIndex = new TextBox {
                Class = Theme.PageIndex,
                Value = 1.ToString(CultureInfo.InvariantCulture)
            };
            var total = new CommonElement(HtmlTag.Span) {
                Class = Theme.Total,
                InnerText = 1.ToString(CultureInfo.InvariantCulture)
            };
            var pageDisplay = new CommonElement(HtmlTag.Span) {
                InnerHtml = string.Format(PageDisplay, pageIndex.RenderHtml(), total.RenderHtml())
            };
            var nextButton = new Button {
                Class = Theme.NextButton,
                InnerHtml = new CommonElement(HtmlTag.I) { Class = Theme.NextIcon }.RenderHtml().ToHtmlString()
            };
            var lastButton = new Button {
                Class = Theme.LastButton,
                InnerHtml = new CommonElement(HtmlTag.I) { Class = Theme.LastIcon }.RenderHtml().ToHtmlString()
            };
            var pageSizes = new DropdownList {
                Class = Theme.PageSizes,
                Items = new ObservableCollection<ListItem>(_pageSizes.Select(item => new ListItem {
                    Value = item.ToString(CultureInfo.InvariantCulture),
                    InnerText = item.ToString(CultureInfo.InvariantCulture)
                }))
            };
            pagerContainer.Append(firstButton).Append(previousButton).Append(pageDisplay).Append(nextButton).Append(lastButton).Append(pageSizes);
            commandContainer.Append(pagerContainer);
        }
        private string ToSelector(string classes) {
            return string.Join(string.Empty, classes.Split(' ').Select(s => "." + s));
        }
        public static GridTheme DefaulTheme {
            get {
                return new GridTheme {
                    Table = "grid table table-bordered table-hover table-striped",
                    Columns = "columns",
                    CommandContainer = "command-container",
                    TableCommandContainer = "table-command-container",
                    TableCommandButton = "table-command btn btn-primary btn-sm",
                    PagerContainer = "pager-container pull-right form-inline",
                    FirstButton = "first-button btn btn-default btn-sm",
                    FirstIcon = "glyphicon glyphicon-step-backward",
                    PreviousButton = "prev-button btn btn-default btn-sm",
                    PreviousIcon = "glyphicon glyphicon-arrow-left",
                    PageIndex = "page-index form-control input-sm",
                    Total = "total",
                    NextButton = "next-button btn btn-default btn-sm",
                    NextIcon = "glyphicon glyphicon-arrow-right",
                    LastButton = "last-button btn btn-default btn-sm",
                    LastIcon = "glyphicon glyphicon-step-forward",
                    PageSizes = "page-sizes form-control input-sm",
                    RowCommand = "row-command",
                };
            }
        }
    }
    public class GridTheme {
        public string Table { get; set; }
        public string Columns { get; set; }
        public string CommandContainer { get; set; }
        public string TableCommandContainer { get; set; }
        public string TableCommandButton { get; set; }
        public string PagerContainer { get; set; }
        public string FirstButton { get; set; }
        public string FirstIcon { get; set; }
        public string PreviousButton { get; set; }
        public string PreviousIcon { get; set; }
        public string PageIndex { get; set; }
        public string Total { get; set; }
        public string NextButton { get; set; }
        public string NextIcon { get; set; }
        public string LastButton { get; set; }
        public string LastIcon { get; set; }
        public string PageSizes { get; set; }
        public string RowCommand { get; set; }
    }
}