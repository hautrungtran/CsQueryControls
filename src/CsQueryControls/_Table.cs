//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Web.Mvc;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using CsQuery.HtmlParser;
//using CsQuery.Implementation;

//namespace CsQueryControls {
//    public class Table<T> : DomElement {
//        #region Property

//        public string Key { get; set; }
//        public int PageIndex { get; set; }
//        public SelectList PageSizes { get; set; }
//        public int Total { get; set; }
//        public int PageSize {
//            get {
//                if (PageSizes.SelectedValue != null) {
//                    return Convert.ToInt32(PageSizes.SelectedValue);
//                }
//                if (PageSizes.Any()) {
//                    return Convert.ToInt32(PageSizes.ElementAt(0).Value);
//                }
//                return 0;
//            }
//        }
//        public int PagesCount {
//            get {
//                return GetPagesCount(Total, PageSize);
//            }
//        }
//        public IList<T> Items { get; set; }
//        public bool Cache { get; set; }
//        public bool Paging { get; set; }
//        public bool HasFooter { get; set; }
//        public bool Responsive { get; set; }
//        public string AjaxUrl { get; set; }
//        public IList<TableHeader> Headers { get; set; }
//        public IList<TableCommand> TableCommands { get; set; }
//        public IList<TableCommand> RowCommands { get; set; }
//        public ITableTheme Theme { get; set; }
//        public CultureInfo Cultue { get; set; }
//        public string PageIndexInputText { get; set; }
//        public string EmptyText { get; set; }
//        /// <summary>
//        /// Gets or sets the page display text. 
//        /// {0}: Start index of page
//        /// {1}: End index of page
//        /// {2}: Total records
//        /// {3}: Page index
//        /// {4}: Total pages
//        /// </summary>
//        /// <value>
//        /// The page display text.
//        /// </value>
//        public string PageDisplayText { get; set; }

//        #endregion

//        #region Constructor

//        public Table(string id, string ajaxUrl, int total, bool cache = true)
//            : base(HtmlData.tagTABLE) {
//            Initialize(id, 0, total, new List<T>(), ajaxUrl, cache);
//        }
//        public Table(string id, string ajaxUrl, bool cache = true)
//            : base(HtmlData.tagTABLE) {
//            Initialize(id, 0, 0, new List<T>(), ajaxUrl, cache);
//        }
//        public Table(string id, IList<T> items)
//            : base(HtmlData.tagTABLE) {
//            Initialize(id, 0, items.Count, items, String.Empty, true);
//        }

//        #endregion

//        #region Method

//        public Table<T> SetSelectedPageSize(int pageSize) {
//            PageSizes = new SelectList(PageSizes.Items, pageSize);
//            return this;
//        }
//        public Table<T> AddAllColumns() {
//            const BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;
//            var properties = typeof(T).GetProperties(publicAttributes).Where(property => property.CanRead);
//            foreach (var property in properties) {
//                var name = property.Name;
//                var text = ControlsHelper.GetDisplayName(typeof(T), property.Name);
//                var format = ControlsHelper.GetDisplayFormat(typeof(T), property.Name);
//                var columnType = TableColumnType.Text;
//                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(long) ||
//                    property.PropertyType == typeof(double) || property.PropertyType == typeof(decimal)) {
//                    columnType = TableColumnType.Number;
//                }
//                if (property.PropertyType == typeof(DateTime)) {
//                    columnType = TableColumnType.DateTime;
//                }
//                var column = new TableHeader(name) {
//                    Text = string.IsNullOrEmpty(text) ? property.Name : text,
//                    Format = format,
//                    ColumnType = columnType
//                };
//                AddColumn(column);
//            }
//            return this;
//        }
//        public Table<T> AddColumn(TableHeader header) {
//            Headers.Add(header);
//            return this;
//        }
//        public Table<T> AddColumn(string name, string text, TableColumnType columnType = TableColumnType.Text, string format = null, int width = 0) {
//            AddColumn(new TableHeader(name) { Text = text, Format = format, Width = width, ColumnType = columnType });
//            return this;
//        }
//        public Table<T> AddColumns(IEnumerable<TableHeader> headers) {
//            foreach (var column in headers) {
//                AddColumn(column);
//            }
//            return this;
//        }
//        public Table<T> AddColumnFor<TProperty>(Expression<Func<T, TProperty>> expression, TableColumnType columnType = TableColumnType.Text, string text = null, string format = null) {
//            var name = ExpressionHelper.GetExpressionText(expression);
//            if (string.IsNullOrEmpty(text)) {
//                var displayName = ControlsHelper.GetDisplayName(expression);
//                text = string.IsNullOrEmpty(displayName) ? name : displayName;
//            }
//            if (string.IsNullOrEmpty(format)) {
//                format = ControlsHelper.GetDisplayFormat(expression);
//            }
//            AddColumn(name, text, columnType, format);
//            return this;
//        }
//        public Table<T> ExcludeColumn(TableHeader header) {
//            Headers.Remove(header);
//            return this;
//        }
//        public Table<T> ExcludeColumn(string name) {
//            //Columns.Remove(tmp => tmp.Name == name);
//            return this;
//        }
//        public Table<T> ExcludeColumns(IEnumerable<TableHeader> headers) {
//            foreach (var column in headers) {
//                ExcludeColumn(column);
//            }
//            return this;
//        }
//        public Table<T> ExcludeColumnsFor<TProperty>(Expression<Func<T, TProperty>> expression) {
//            var name = ExpressionHelper.GetExpressionText(expression);
//            ExcludeColumn(name);
//            return this;
//        }
//        public Table<T> SetKey<TProperty>(Expression<Func<T, TProperty>> expression) {
//            Key = ExpressionHelper.GetExpressionText(expression);
//            return this;
//        }
//        public Table<T> AddRowsCommand(TableCommand command) {
//            RowCommands.Add(command);
//            return this;
//        }
//        public Table<T> AddTableCommand(TableCommand command) {
//            TableCommands.Add(command);
//            return this;
//        }

//        #endregion

//        #region Utilities

//        private static int GetPagesCount(int total, int pageSize) {
//            return pageSize > 0 ? (total + pageSize - 1) / pageSize : 0;
//        }
//        private void Clone<TControl>(TControl src, TControl dest) where TControl : WebControl {
//            var properties = typeof(TControl).GetProperties().Where(x => x.CanRead && x.CanWrite);
//            foreach (var property in properties) {
//                property.SetValue(dest, property.GetValue(src));
//            }
//            foreach (string key in src.Attributes.Keys) {
//                dest.Attributes[key] = src.Attributes[key];
//            }
//        }
//        private void Initialize(string id, int pageIndex, int total, IList<T> items, string ajaxUrl, bool cache) {
//            Id = id;
//            Cache = cache;
//            Items = items;
//            if (total < items.Count) {
//                total = items.Count;
//            }
//            Total = total;
//            PageIndex = pageIndex;
//            AjaxUrl = ajaxUrl;
//            PageSizes = new SelectList(new List<int> { 10, 20, 30, 40, 50 }, 20);
//            Headers = new List<TableHeader>();
//            TableCommands = new List<TableCommand>();
//            RowCommands = new List<TableCommand>();
//            Theme = new BootstrapTheme();
//            PageIndexInputText = "Go to page";
//            EmptyText = "No data found.";
//            PageDisplayText = "{0} - {1} / {2}";
//            Cultue = CultureInfo.InvariantCulture;
//            HasFooter = true;
//            Responsive = true;
//        }
//        private void RenderHeader(DomElement table) {
//            var thead = new WebControl(HtmlTextWriterTag.Thead);
//            RenderHeaderCommands(thead);
//            RenderHeaderText(thead);
//            table.Controls.Add(thead);
//        }
//        private void RenderFooter(DomElement table) {
//            var tfoot = new WebControl(HtmlTextWriterTag.Tfoot);
//            if (HasFooter) {
//                RenderHeaderText(tfoot);
//                RenderHeaderCommands(tfoot);
//            } else {
//                var cell = new TableCell {
//                    ColumnSpan = Headers.Count + (RowCommands.Count > 0 ? 1 : 0)
//                };
//                tfoot.Controls.Add(cell);
//            }
//            table.Controls.Add(tfoot);
//        }
//        private void RenderBody(DomElement table) {
//            var tbody = new WebControl(HtmlTextWriterTag.Tbody);
//            var properties = typeof(T).GetProperties();
//            if (Items.Count > 0) {
//                foreach (var item in Items) {
//                    var row = new TableRow();
//                    var keyProperty = properties.FirstOrDefault(tmp => tmp.Name == Key);
//                    if (keyProperty != null) {
//                        var value = keyProperty.GetValue(item, null) ?? string.Empty;
//                        row.Attributes.Add("data-key-value", value.ToString());
//                    }
//                    foreach (var column in Headers) {
//                        var property = properties.FirstOrDefault(tmp => tmp.Name == column.Name);
//                        if (property != null) {
//                            var value = property.GetValue(item, null) ?? string.Empty;
//                            Control control = null;
//                            switch (column.ColumnType) {
//                                case TableColumnType.Checkbox:
//                                    control = new CheckBox { Checked = Convert.ToBoolean(value) };
//                                    break;
//                                case TableColumnType.Image:
//                                    control = new Image {
//                                        ImageUrl = value.ToString(),
//                                        AlternateText = value.ToString()
//                                    };
//                                    break;
//                                //default:
//                                //    if (value.IsNumber()) {
//                                //        value = Convert.ToDecimal(value).ToString(column.Format);
//                                //    } else if (value is DateTime) {
//                                //        value = Convert.ToDateTime(value).ToString(column.Format);
//                                //    }
//                                //    break;
//                            }
//                            var cell = new TableCell();
//                            if (control == null) {
//                                cell.Text = value.ToString();
//                            } else {
//                                cell.Controls.Add(control);
//                            }
//                            row.Controls.Add(cell);
//                        }
//                    }
//                    if (RowCommands.Count > 0) {
//                        var cell = new TableHeaderCell().AddClass(Theme.RowCommandContainer);
//                        foreach (var command in RowCommands) {
//                            var link = new HyperLink();
//                            Clone(command, link);
//                            link.AddClass(Theme.RowCommand);
//                            var ajaxCommand = command as AjaxCommand;
//                            if (ajaxCommand != null) {
//                                link.Attributes.Add("data-command-type", "ajax");
//                                link.Attributes.Add("data-ajax-method", ajaxCommand.Method.ToString().ToUpper());
//                                link.Attributes.Add("data-confirm", ajaxCommand.Confirm);
//                                link.Attributes.Add("data-caption", ajaxCommand.Caption);
//                                link.Attributes.Add("data-refresh", ajaxCommand.Refresh.ToString().ToLower());
//                                link.Attributes.Add("data-callback", ajaxCommand.CallbackName);
//                            } else {
//                                var dialogCommand = command as DialogCommand;
//                                if (dialogCommand != null) {
//                                    link.Attributes.Add("data-command-type", "dialog");
//                                    link.Attributes.Add("data-dialog-width", (dialogCommand.DialogWidth ?? 800).ToString(string.Empty));
//                                    link.Attributes.Add("data-dialog-height", (dialogCommand.DialogHeight ?? 600).ToString(string.Empty));
//                                    link.Attributes.Add("data-refresh", dialogCommand.Refresh.ToString().ToLower());
//                                }
//                            }
//                            if (!string.IsNullOrEmpty(command.Icon)) {
//                                var icon = new WebControl(HtmlTextWriterTag.I).AddClass(command.Icon);
//                                link.Controls.Add(icon);
//                            }
//                            cell.Controls.Add(link);
//                        }
//                        row.Controls.Add(cell);
//                    }
//                    tbody.Controls.Add(row);
//                }
//            } else {
//                var emptyRow = new TableRow();
//                emptyRow.Controls.Add(new TableCell {
//                    Text = EmptyText,
//                    ColumnSpan = Headers.Count + (RowCommands.Count > 0 ? 1 : 0)
//                });
//                tbody.Controls.Add(emptyRow);
//            }
//            table.Controls.Add(tbody);
//        }
//        private void RenderHeaderCommands(DomElement thead) {
//            var row = new TableRow();
//            var cell = new TableHeaderCell {
//                ColumnSpan = Headers.Count + (RowCommands.Count > 0 ? 1 : 0),
//            };
//            cell.AddClass(Theme.HeaderCommandRow);
//            if (TableCommands.Count > 0) {
//                var commandsContainer = new Label().AddClass(Theme.TableCommandContainer);
//                var commands = new List<TableCommand>(TableCommands);
//                foreach (var command in commands) {
//                    var link = new HyperLink();
//                    Clone(command, link);
//                    link.AddClass(Theme.TableCommand);
//                    AddCommandAttributes(link, command);
//                    if (!string.IsNullOrEmpty(command.Icon)) {
//                        var icon = new WebControl(HtmlTextWriterTag.I).AddClass(command.Icon);
//                        link.Controls.Add(icon);
//                        var text = new Literal { Text = " " + command.Text };
//                        link.Controls.Add(text);
//                    }
//                    commandsContainer.Controls.Add(link);
//                }
//                cell.Controls.Add(commandsContainer);
//            }
//            var pager = new Label().AddClass(Theme.Pager);

//            var firstIcon = new WebControl(HtmlTextWriterTag.I).AddClass(Theme.FirstButtonIcon);
//            var firstButton = new WebControl(HtmlTextWriterTag.Button).AddClass(Theme.FirstButton);
//            firstButton.Controls.Add(firstIcon);
//            pager.Controls.Add(firstButton);

//            var prevIcon = new WebControl(HtmlTextWriterTag.I).AddClass(Theme.PrevButtonIcon);
//            var prevButton = new WebControl(HtmlTextWriterTag.Button).AddClass(Theme.PrevButton);
//            prevButton.Controls.Add(prevIcon);
//            pager.Controls.Add(prevButton);

//            var pageDisplay = new Label();
//            pageDisplay.AddClass(Theme.PageDisplay);
//            pageDisplay.Text = string.Format(PageDisplayText,
//                Items.Count > 0 ? PageIndex * PageSize + 1 : 0, Math.Min(PageIndex * PageSize + PageSize, Total), Total,
//                Math.Min(PageIndex + 1, GetPagesCount(Total, PageSize)), GetPagesCount(Total, PageSize));
//            pager.Controls.Add(pageDisplay);

//            var nextIcon = new WebControl(HtmlTextWriterTag.I).AddClass(Theme.NextButtonIcon);
//            var nextButton = new WebControl(HtmlTextWriterTag.Button).AddClass(Theme.NextButton);
//            nextButton.Controls.Add(nextIcon);
//            pager.Controls.Add(nextButton);

//            var lastIcon = new WebControl(HtmlTextWriterTag.I).AddClass(Theme.LastButtonIcon);
//            var lastButton = new WebControl(HtmlTextWriterTag.Button).AddClass(Theme.LastButton);
//            lastButton.Controls.Add(lastIcon);
//            pager.Controls.Add(lastButton);

//            var pageSizeSelect = new DropDownList();
//            pageSizeSelect.AddClass(Theme.PageSize);
//            pageSizeSelect.Items.AddRange(PageSizes.Select(pageSize => new ListItem(pageSize.Text, pageSize.Value) {
//                Selected = pageSize.Selected
//            }).ToArray());
//            pager.Controls.Add(pageSizeSelect);

//            var pageIndexContainer = new Label().AddClass(Theme.PageIndexContainer);
//            var pageIndexWrapper = new Label().AddClass(Theme.PageIndexWrapper);
//            var pageIndexInput = new TextBox().AddClass(Theme.PageIndexInput);
//            pageIndexInput.Attributes["placeholder"] = PageIndexInputText;
//            pageIndexWrapper.Controls.Add(pageIndexInput);

//            var pageIndexAddon = new Label().AddClass(Theme.PageIndexAddon);
//            var pageIndexButtonIcon = new WebControl(HtmlTextWriterTag.I).AddClass(Theme.PageIndexButtonIcon);
//            var pageIndexButton = new WebControl(HtmlTextWriterTag.Button).AddClass(Theme.PageIndexButton);
//            pageIndexButton.Controls.Add(pageIndexButtonIcon);
//            pageIndexAddon.Controls.Add(pageIndexButton);

//            pageIndexWrapper.Controls.Add(pageIndexAddon);
//            pageIndexContainer.Controls.Add(pageIndexWrapper);
//            pager.Controls.Add(pageIndexContainer);
//            cell.Controls.Add(pager);
//            row.Controls.Add(cell);
//            thead.Controls.Add(row);
//        }
//        private void RenderHeaderText(DomElement thead) {
//            var row = new TableRow().AddClass(Theme.HeaderTextRow);
//            var headers = Headers;
//            foreach (var header in headers) {
//                var cell = new TableHeaderCell();
//                Clone(header, cell);
//                cell.Attributes.Add("data-property", header.Name);
//                cell.Attributes.Add("data-format", header.Format);
//                cell.Attributes.Add("data-column-type", header.ColumnType.ToString().ToLower());
//                if (string.IsNullOrEmpty(header.Text) && header.Controls.Count == 0) {
//                    cell.Text = header.Name;
//                }
//                row.Controls.Add(cell);
//            }
//            if (RowCommands.Count > 0) {
//                var cell = new TableHeaderCell().AddClass(Theme.RowCommandContainer);
//                foreach (var command in RowCommands) {
//                    var link = new HyperLink();
//                    Clone(command, link);
//                    link.AddClass(Theme.RowCommand);
//                    AddCommandAttributes(link, command);
//                    if (!string.IsNullOrEmpty(command.Icon)) {
//                        var icon = new WebControl(HtmlTextWriterTag.I).AddClass(command.Icon);
//                        link.Controls.Add(icon);
//                    }
//                    cell.Controls.Add(link);
//                }
//                row.Controls.Add(cell);
//            }
//            thead.Controls.Add(row);
//        }
//        private void AddCommandAttributes(DomElement control, TableCommand command) {
//            var ajaxCommand = command as AjaxCommand;
//            if (ajaxCommand != null) {
//                control.Attributes.Add("data-command-type", "ajax");
//                control.Attributes.Add("data-ajax-method", ajaxCommand.Method.ToString().ToUpper());
//                control.Attributes.Add("data-confirm", ajaxCommand.Confirm);
//                control.Attributes.Add("data-caption", ajaxCommand.Caption);
//                control.Attributes.Add("data-refresh", ajaxCommand.Refresh.ToString().ToLower());
//                control.Attributes.Add("data-callback", ajaxCommand.CallbackName);
//            } else {
//                var dialogCommand = command as DialogCommand;
//                if (dialogCommand != null) {
//                    control.Attributes.Add("data-command-type", "dialog");
//                    control.Attributes.Add("data-dialog-width", (dialogCommand.DialogWidth ?? 800).ToString(string.Empty));
//                    control.Attributes.Add("data-dialog-height", (dialogCommand.DialogHeight ?? 600).ToString(string.Empty));
//                    control.Attributes.Add("data-refresh", dialogCommand.Refresh.ToString().ToLower());
//                }
//            }
//        }

//        #endregion

//        #region Overrides of HtmlControl

//        public override string Render() {
//            if (Headers.Count == 0) {
//                AddAllColumns();
//            }
//            if (string.IsNullOrEmpty(Key)) {
//                Key = Headers[0].Name;
//            }
//            if (Items.Count > 0 && Total < Items.Count) {
//                Total = Items.Count;
//            }
//            AddClass(Theme.Table);
//            Attributes["data-toggle"] = "table";
//            Attributes["data-page-index"] = PageIndex.ToString(string.Empty);
//            Attributes["data-page-size"] = PageSize.ToString(string.Empty);
//            Attributes["data-total"] = Total.ToString(string.Empty);
//            Attributes["data-cache"] = Cache.ToString().ToLower();
//            Attributes["data-ajax-url"] = AjaxUrl;
//            Attributes["data-key"] = Key;
//            Attributes["data-empty-text"] = EmptyText;
//            Attributes["data-page-display-text"] = PageDisplayText;
//            Attributes["data-language"] = Cultue.TwoLetterISOLanguageName == "iv" ? "default" : Cultue.TwoLetterISOLanguageName;
//            RenderHeader(this);
//            RenderFooter(this);
//            RenderBody(this);
//            if (Responsive) {
//                var wrapper = ControlsHelper.CreateElement(HtmlTag.Div).AddClass(Theme.ReponsiveWrapper).Append(this);
//                return wrapper.Render();
//            }
//            return base.Render();
//        }

//        #endregion
//    }
//    public enum TableColumnType {
//        Text,
//        Number,
//        DateTime,
//        Html,
//        Image,
//        Checkbox
//    }
//    public enum AjaxMethod {
//        Get,
//        Post,
//    }
//    public class TableHeader : TableHeaderCell {
//        public string Name { get; set; }
//        public string Format { get; set; }
//        public TableColumnType ColumnType { get; set; }
//        public TableHeader(string name) {
//            Name = name;
//        }
//    }
//    public class TableCommand : HyperLink {
//        public string Icon { get; set; }
//    }
//    public class AjaxCommand : TableCommand {
//        public AjaxMethod Method { get; set; }
//        public string Confirm { get; set; }
//        public string Caption { get; set; }
//        public bool Refresh { get; set; }
//        public string CallbackName { get; set; }
//    }
//    public class DialogCommand : TableCommand {
//        public int? DialogWidth { get; set; }
//        public int? DialogHeight { get; set; }
//        public bool Refresh { get; set; }
//    }
//    public interface ITableTheme {
//        string Table { get; set; }
//        string HeaderCommandRow { get; set; }
//        string HeaderTextRow { get; set; }
//        string TableCommandContainer { get; set; }
//        string TableCommand { get; set; }
//        string RowCommandContainer { get; set; }
//        string RowCommand { get; set; }
//        string Pager { get; set; }
//        string FirstButton { get; set; }
//        string FirstButtonIcon { get; set; }
//        string PrevButton { get; set; }
//        string PrevButtonIcon { get; set; }
//        string PageDisplay { get; set; }
//        string NextButton { get; set; }
//        string NextButtonIcon { get; set; }
//        string LastButton { get; set; }
//        string LastButtonIcon { get; set; }
//        string PageSize { get; set; }
//        string PageIndexContainer { get; set; }
//        string PageIndexWrapper { get; set; }
//        string PageIndexAddon { get; set; }
//        string PageIndexInput { get; set; }
//        string PageIndexButton { get; set; }
//        string PageIndexButtonIcon { get; set; }
//        string EmptyRow { get; set; }
//        string ReponsiveWrapper { get; set; }
//    }
//    public class BootstrapTheme : ITableTheme {
//        #region Implementation of ITableTheme

//        public string Table { get; set; }
//        public string HeaderCommandRow { get; set; }
//        public string HeaderTextRow { get; set; }
//        public string TableCommandContainer { get; set; }
//        public string TableCommand { get; set; }
//        public string RowCommandContainer { get; set; }
//        public string RowCommand { get; set; }
//        public string Pager { get; set; }
//        public string FirstButton { get; set; }
//        public string FirstButtonIcon { get; set; }
//        public string PrevButton { get; set; }
//        public string PrevButtonIcon { get; set; }
//        public string PageDisplay { get; set; }
//        public string NextButton { get; set; }
//        public string NextButtonIcon { get; set; }
//        public string LastButton { get; set; }
//        public string LastButtonIcon { get; set; }
//        public string PageSize { get; set; }
//        public string PageIndexContainer { get; set; }
//        public string PageIndexWrapper { get; set; }
//        public string PageIndexAddon { get; set; }
//        public string PageIndexInput { get; set; }
//        public string PageIndexButton { get; set; }
//        public string PageIndexButtonIcon { get; set; }
//        public string EmptyRow { get; set; }
//        public string ReponsiveWrapper { get; set; }

//        #endregion
//        public BootstrapTheme() {
//            Table = "custom-table table table-bordered table-hover table-striped";
//            HeaderCommandRow = "table-header-commands";
//            HeaderTextRow = "table-header-text";
//            TableCommandContainer = "table-command-container pull-left";
//            TableCommand = "table-command btn btn-default btn-sm";
//            RowCommandContainer = "row-command-container";
//            RowCommand = "row-command";
//            Pager = "pager pull-right form-inline";
//            FirstButton = "first-button btn btn-default btn-sm";
//            FirstButtonIcon = "glyphicon glyphicon-step-backward";
//            PrevButton = "prev-button btn btn-default btn-sm";
//            PrevButtonIcon = "glyphicon glyphicon-arrow-left";
//            PageDisplay = "page-display";
//            NextButton = "next-button btn btn-default btn-sm";
//            NextButtonIcon = "glyphicon glyphicon-arrow-right";
//            LastButton = "last-button btn btn-default btn-sm";
//            LastButtonIcon = "glyphicon glyphicon-step-forward";
//            PageSize = "page-sizes form-control input-sm";
//            PageIndexContainer = "page-index-container form-group";
//            PageIndexWrapper = "input-group";
//            PageIndexInput = "page-index-input form-control input-sm";
//            PageIndexAddon = "input-group-btn";
//            PageIndexButton = "page-index-button btn btn-default btn-sm";
//            PageIndexButtonIcon = "glyphicon glyphicon-search";
//            ReponsiveWrapper = "table-responsive";
//        }
//    }
//}
