(function ($, undefined) {
    var doc = document;

    var idx = 0, columnType = {
        'static': 'static',
        text: 'text',
        link: 'link',
        html: 'html',
        image: 'image',
        checkbox: 'checkbox',
    };
    var DataGrid = function (element, options) {
        this.id = idx++;
        this.init(element, options);
    };
    DataGrid.prototype = {
        constructor: DataGrid,
        init: function (element, options) {
            this.element = $(element);
            this.header = this.element.find('thead');
            this.footer = this.element.find('tfoot');
            this.body = this.element.find('tbody');

            this.options = options;
            this.selector = $.extend($.fn.datagrid.defaults.selector, options.selector);
            this.gridCommands = this.element.find(this.selector.gridCommands);
            this.rowCommands = this.element.find(this.selector.rowCommands);
            this.firstButton = this.element.find(this.selector.firstButton);
            this.previousButton = this.element.find(this.selector.previousButton);
            this.nextButton = this.element.find(this.selector.nextButton);
            this.lastButton = this.element.find(this.selector.lastButton);
            this.pageIndexInput = this.element.find(this.selector.pageIndexInput);
            this.totalDisplay = this.element.find(this.selector.totalDisplay);
            this.pageSizeSelect = this.element.find(this.selector.pageSizeSelect);

            this.pageSize = this.pageSizeSelect.val();
            this.cache = options.cache === false ? options.cache : $.fn.datagrid.defaults.cache;
            this.defaultText = options.defaultText != undefined ? options.defaultText : $.fn.datagrid.defaults.defaultText;
            this.multiselect = options.multiselect === true ? options.multiselect : $.fn.datagrid.defaults.multiselect;
            this.key = options.key;
            this.href = options.href;
            var columns = [];
            if (!$.isArray(options.columns)) {
                (this.header.find(this.selector.columns) || this.footer.find(this.selector.columns)).each(function () {
                    var $this = $(this);
                    columns.push({
                        name: $this.data('columnName'),
                        type: $this.data('columnType'),
                        sortable: $this.data('sortable'),
                        html: $this.html()
                    });
                });
            } else {
                columns = options.columns;
            }
            this.columns = columns;
            this.pages = {};

            this.process = options.process || this.process;
            this.attachEventHandler();
            this.changePage(0);
        },
        changePage: function (pageIndex) {
            if (pageIndex == this.pageIndex || !$.isNumeric(pageIndex)) return;
            var grid = this;
            if (this.pages[pageIndex]) {
                process(this.pages[pageIndex]);
                grid.pageIndex = pageIndex;
                this.notifyChange();
            } else {
                $.ajax({
                    type: 'GET',
                    url: grid.href,
                    data: {
                        pageIndex: pageIndex,
                        pageSize: grid.pageSize
                    },
                    beforeSend: function () {

                    },
                    success: function (response) {
                        grid.body.empty();
                        grid.total = response.total;
                        grid.pageIndex = pageIndex;
                        grid.process(response.items);
                        grid.notifyChange();
                    },
                    complete: function () {

                    }
                });
            }
        },
        process: function (items) {
            if (items && items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    var item = items[i];
                    var row = $.createElement('tr').appendTo(this.body);
                    for (var j = 0; j < this.columns.length; j++) {
                        var column = this.columns[j];
                        var value = item[column.name];
                        var cell = $.createElement('td').appendTo(row);
                        switch (column.type) {
                            case columnType.static:
                                cell.html(column.html);
                                break;
                            case columnType.html:
                                cell.html(value);
                                break;
                            case columnType.link:
                                cell.append($.createElement('a').attr('href', value).text(value));
                                break;
                            case columnType.image:
                                cell.append($.createElement('img').attr('src', value));
                                break;
                            case columnType.checkbox:
                                var checkbox = $.createElement('input').attr('type', 'checkbox').attr('onclick', 'return false');
                                if (value == true || value == 'true') {
                                    checkbox.attr('checked', 'checked');
                                }
                                cell.append(checkbox);
                                break;
                            default:
                                cell.text(value);
                        }
                    }
                }
            } else {
                $.createElement('tr').appendTo(this.body).append($.createElement('td').attr('colspan', this.columns.length).text(this.defaultText));
            }
        },
        clearCache: function (index) {
            if ($.isNumeric(index)) {
                this.pages[index] = [];
            } else {
                this.pages = {};
            }
        },
        attachEventHandler: function () {
            var grid = this;
            this.firstButton.click(function () {
                grid.changePage(0);
            });
            this.previousButton.click(function () {
                grid.changePage(grid.pageIndex - 1);
            });
            this.lastButton.click(function () {
                grid.changePage(grid.total - 1);
            });
            this.nextButton.click(function () {
                grid.changePage(grid.pageIndex + 1);
            });
            this.pageSizeSelect.change(function () {
                grid.pageSize = grid.pageSizeSelect.val();
                grid.pageIndex = -1;
                grid.clearCache();
                grid.changePage(0);
            });
            this.pageIndexInput.change(function () {
                var $this = $(this);
                var value = $this.val();
                if ($.isNumeric(value)) {
                    value = value * 1;
                    if (value <= 0) {
                        value = 0;
                    }
                    if (value >= grid.total) {
                        value = grid.total - 1;
                    }
                    grid.changePage(value - 1);
                } else {
                    $this.val(grid.pageIndex + 1);
                }
            });
        },
        notifyChange: function () {
            this.pageIndexInput.val(this.pageIndex + 1);
            this.totalDisplay.text(this.total);
            if (this.pageIndex == 0) {
                this.firstButton.disable();
                this.previousButton.disable();
            } else {
                this.firstButton.enable();
                this.previousButton.enable();
            }
            if (this.pageIndex == this.total - 1) {
                this.nextButton.disable();
                this.lastButton.disable();
            } else {
                this.nextButton.enable();
                this.lastButton.enable();
            }
        }
    };
    $.fn.datagrid = function (options, val) {
        return this.each(function () {
            var $this = $(this),
            data = $this.data('datagrid'),
            opt = typeof options === 'object' && options,
            dataset = $this.data();
            if (!data) {
                $this.data('datagrid', (data = new DataGrid(this, $.extend({}, $.fn.datagrid.defaults, dataset, opt))));
            }
            if (typeof options === 'string') data[options](val);
        });
    };
    $.fn.datagrid.defaults = {
        cache: true,
        defaultText: 'No data found.',
        multiselect: false,
        selector: {
            gridCommands: '.grid-command',
            rowCommands: '.row-command',
            firstButton: '.first-button',
            previousButton: '.prev-button',
            nextButton: '.next-button',
            lastButton: '.last-button',
            pageIndexInput: '.page-index',
            totalDisplay: '.total',
            pageSizeSelect: '.page-sizes',
            columns: '.columns th'
        }
    };
    $.fn.disable = function () {
        return this.attr('disabled', 'disabled');
    };
    $.fn.enable = function () {
        return this.removeAttr('disabled');
    };
    $.createElement = function (tagName) {
        return $(doc.createElement(tagName));
    };
}(jQuery));