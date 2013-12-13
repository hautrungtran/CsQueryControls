(function ($, undefined) {
    var doc = document, math = Math;
    function addOrUpdateParameter(paramName, paramValue, url) {
        if (!url) {
            url = window.location.href;
        }
        if (url.indexOf(paramName + "=") >= 0) {
            var prefix = url.substring(0, url.indexOf(paramName));
            var suffix = url.substring(url.indexOf(paramName)).substring(url.indexOf("=") + 1);
            suffix = (suffix.indexOf("&") >= 0) ? suffix.substring(suffix.indexOf("&")) : "";
            url = prefix + paramName + "=" + paramValue + suffix;
        }
        else {
            if (url.indexOf("?") < 0)
                url += "?" + paramName + "=" + paramValue;
            else
                url += "&" + paramName + "=" + paramValue;
        }
        return url;
    }
    var idx = 0, columnType = {
        'static': 'static',
        text: 'text',
        html: 'html',
        checkbox: 'checkbox',
    }, commandType = {
        'default': 'default',
        dialog: 'dialog',
        ajax: 'ajax'
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
            this.callbacks = $.extend($.fn.datagrid.defaults.callbacks, options.callbacks);
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
            this.cache = options.cache == false ? options.cache : $.fn.datagrid.defaults.cache;
            this.defaultText = options.defaultText != undefined ? options.defaultText : $.fn.datagrid.defaults.defaultText;
            this.multiselect = options.multiselect == true ? options.multiselect : $.fn.datagrid.defaults.multiselect;
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
            if (!$.isNumeric(pageIndex)) return;
            var grid = this;
            if (this.pages[pageIndex]) {
                this.body.empty();
                this.process(this.pages[pageIndex]);
                this.attachRowEventHandler();
                this.pageIndex = pageIndex;
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
                        grid.element.block({ message: '' });
                    },
                    success: function (response) {
                        grid.total = response.total;
                        grid.pageIndex = pageIndex;
                        grid.body.empty();
                        grid.process(response.items);
                        grid.attachRowEventHandler();
                        grid.notifyChange();
                        if (grid.cache) {
                            grid.pages[pageIndex] = response.items;
                        }
                    },
                    complete: function () {
                        grid.element.unblock();
                    }
                });
            }
        },
        process: function (items) {
            if (items && items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    var item = items[i];
                    var row = $.createElement('tr').attr('data-key', item[this.key]).appendTo(this.body);
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
                grid.clearCache();
                grid.changePage(0);
            });
            this.pageIndexInput.change(function () {
                var $this = $(this);
                var value = $this.val();
                if ($.isNumeric(value)) {
                    value = math.round(value);
                    if (value < 1) {
                        value = 1;
                    }
                    if (value >= grid.total) {
                        value = grid.total;
                    }
                    grid.changePage(value - 1);
                } else {
                    $this.val(grid.pageIndex + 1);
                }
            });
            this.element.find(this.selector.gridCommands).click(function (e) {
                var $this = $(this);
                var url = $this.attr('href');
                switch ($this.data('commandType')) {
                    case commandType.dialog:
                        e.preventDefault();
                        $.showDialog(url, $this.data('dialogWidth'), $this.data('dialogHeight'), function () {
                            if ($this.data('refresh')) {
                                grid.clearCache();
                                grid.changePage(grid.pageIndex);
                            }
                        });
                        break;
                    case commandType.ajax:
                        e.preventDefault();
                        if (url) {
                            $.ajax({
                                type: $this.data('ajaxMethod') || 'GET',
                                url: url,
                                beforeSend: function () {
                                    grid.element.block({ message: '' });
                                },
                                success: function (response) {
                                    grid.callbacks[$this.data('callback') || 'default'](response);
                                    if ($this.data('refresh')) {
                                        grid.clearCache();
                                        grid.changePage(grid.pageIndex);
                                    }
                                },
                                complete: function () {
                                    grid.element.unblock();
                                }
                            });
                        } else {
                            grid.changePage(0);
                        }
                        break;
                }
            });
        },
        attachRowEventHandler: function () {
            var grid = this;
            this.element.find(this.selector.rowCommands).each(function () {
                var $this = $(this);
                var key = $this.parents('tr').data('key');
                var url = addOrUpdateParameter('id', key, $this.attr('href'));
                $this.attr('href', url);
                $this.click(function (e) {
                    switch ($this.data('commandType')) {
                        case commandType.dialog:
                            e.preventDefault();
                            $.showDialog(url, $this.data('dialogWidth'), $this.data('dialogHeight'), function () {
                                if ($this.data('refresh')) {
                                    grid.clearCache();
                                    grid.changePage(grid.pageIndex);
                                }
                            });
                            break;
                        case commandType.ajax:
                            e.preventDefault();
                            if (url) {
                                $.ajax({
                                    type: $this.data('ajaxMethod') || 'GET',
                                    url: url,
                                    beforeSend: function () {
                                        grid.element.block({ message: '' });
                                    },
                                    success: function (response) {
                                        grid.callbacks[$this.data('callback') || 'default'](response);
                                        if ($this.data('refresh')) {
                                            grid.clearCache();
                                            grid.changePage(grid.pageIndex);
                                        }
                                    },
                                    complete: function () {
                                        grid.element.unblock();
                                    }
                                });
                            } else {
                                grid.changePage(0);
                            }
                            break;
                    }
                });
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
        },
        callbacks: {
            'default': function (response) {
                $.showMessage(response);
            }
        }
    };
    $.fn.disable = function () {
        return this.attr('disabled', 'disabled');
    };
    $.fn.enable = function () {
        return this.removeAttr('disabled');
    };
    $.showDialog = function (href, width, height, callback) {
        $.fancybox.open({
            href: href,
            padding: 3,
            closeBtn: false,
            type: 'iframe',
            iframe: { preload: false },
            width: width,
            height: height,
            wrapCSS: 'table-dialog',
            afterClose: callback
        });
    };
    $.showMessage = function (message) {
        $.fancybox({ content: message });
    };
    $.createElement = function (tagName) {
        return $(doc.createElement(tagName));
    };
}(jQuery));