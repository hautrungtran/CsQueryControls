(function ($, undefined) {
    var DOCUMENT = document, MATH = Math;
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
    var idx = 0, COLUMNTYPE = {
        STATIC: 'static',
        TEXT: 'text',
        HTML: 'html',
        CHECKBOX: 'checkbox',
    }, COMMANDTYPE = {
        DEFAULT: 'default',
        DIALOG: 'dialog',
        AJAX: 'ajax'
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
                var headers = this.header.find(this.selector.header);
                if (headers.length == 0) {
                    headers = this.footer.find(this.selector.header);
                }
                headers.each(function () {
                    var $this = $(this);
                    var sortable = $this.data('sortable');
                    var html = $this.html();
                    if (sortable) {
                        $this.empty();
                        $this.append($.createElement('a').addClass('sortable').attr('href', '#').html(html));
                    }
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
            this._attachEventHandler();
            this.changePage(0);
        },
        changePage: function (pageIndex) {
            if (!$.isNumeric(pageIndex)) return;
            var grid = this;
            if (this.pages[pageIndex]) {
                this._process(this.pages[pageIndex], pageIndex, this.total);
            } else {
                $.ajax({
                    type: 'GET',
                    url: grid.href,
                    data: {
                        pageIndex: pageIndex,
                        pageSize: grid.pageSize
                    },
                    beforeSend: function () {
                        grid.toggle('loading');
                    },
                    success: function (response) {
                        grid._process(response.items, pageIndex, response.total || grid.total);
                        if (grid.cache) {
                            grid.pages[pageIndex] = response.items;
                        }
                    },
                    complete: function () {
                        grid.toggle('complete');
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
                            case COLUMNTYPE.STATIC:
                                cell.html(column.html);
                                break;
                            case COLUMNTYPE.HTML:
                                cell.html(value);
                                break;
                            case COLUMNTYPE.CHECKBOX:
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
        toggle: function (status) {
            switch (status) {
                case 'loading':
                    this.element.block({ message: '' });
                    break;
                case 'complete':
                    this.element.unblock();
                    break;
            }
        },
        _process: function (items, pageIndex, total) {
            this.body.empty();
            this.process(items);
            this._attachRowEventHandler();
            this.total = total;
            this.pageIndex = pageIndex;
            this.notifyChange();
        },
        _attachEventHandler: function () {
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
                    value = MATH.round(value);
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
            this._attachCommandEventHandler(this.element.find(this.selector.gridCommands));
        },
        _attachRowEventHandler: function () {
            var grid = this;
            this.element.find(this.selector.rowCommands).each(function () {
                var $this = $(this);
                var key = $this.parents('tr').data('key');
                var url = addOrUpdateParameter('id', key, $this.attr('href'));
                $this.attr('href', url);
                grid._attachCommandEventHandler($this);
            });
        },
        _attachCommandEventHandler: function (commands) {
            var grid = this;
            commands.click(function (e) {
                var $this = $(this);
                var url = $this.attr('href');
                switch ($this.data('commandType')) {
                    case COMMANDTYPE.DIALOG:
                        e.preventDefault();
                        grid._showDialog($this, url);
                        break;
                    case COMMANDTYPE.AJAX:
                        e.preventDefault();
                        var confirm = $this.data('confirm');
                        if (confirm) {
                            $.confirm(confirm, $this.data('caption'), function (cancel) {
                                if (!cancel) {
                                    grid._requestAjax($this, url);
                                }
                            });
                        } else {
                            grid._requestAjax($this, url);
                        }
                        break;
                }
            });
        },
        _showDialog: function (command, url) {
            var grid = this;
            $.showDialog(url, command.data('dialogWidth'), command.data('dialogHeight'), function () {
                if (command.data('refresh')) {
                    grid.clearCache();
                    grid.changePage(grid.pageIndex);
                }
            });
        },
        _requestAjax: function (command, url) {
            var grid = this;
            if (url) {
                $.ajax({
                    type: command.data('ajaxMethod') || 'GET',
                    url: url,
                    beforeSend: function () {
                        grid.toggle('loading');
                    },
                    success: function (response) {
                        grid.callbacks[command.data('callback') || 'default'](response);
                        if (command.data('refresh')) {
                            grid.clearCache();
                            grid.changePage(grid.pageIndex);
                        }
                    },
                    complete: function () {
                        grid.toggle('complete');
                    }
                });
            } else {
                grid.clearCache();
                grid.changePage(0);
            }
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
            header: '.header'
        },
        callbacks: {
            'default': function (response) {
                var message = response;
                if (response.message) {
                    message = response.message;
                }
                $.showMessage(message);
            }
        }
    };
    $.fn.disable = function () {
        return this.attr('disabled', 'disabled');
    };
    $.fn.enable = function () {
        return this.removeAttr('disabled');
    };
    $.createElement = function (tagName) {
        return $(DOCUMENT.createElement(tagName));
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
    $.showMessage = function (message, caption, callback) {
        var modal = $.createElement('div').addClass('message-box');
        var header = $.createElement('header').addClass('modal-header');
        var closeIcon = $.createElement('button').addClass('close')
            .text('x').click(function () {
                $.fancybox.close(modal);
            });
        header.append(closeIcon);
        if (caption) {
            var headerCaption = $.createElement('h4').html(caption).addClass("modal-title");
            header.append(headerCaption);
        }
        modal.append(header);
        var body = $.createElement('div').addClass('modal-body').html(message);
        modal.append(body);
        $.fancybox(modal, { padding: 3, closeBtn: false, afterClose: callback });
    };
    $.confirm = function (message, caption, callback) {
        var modal = $.createElement('div').addClass('message-box');
        var header = $.createElement('header').addClass('modal-header');
        var cancel = false;
        if (caption) {
            var headerCaption = $.createElement('h4').html(caption).addClass("modal-title");
            header.append(headerCaption);
        }
        modal.append(header);
        var body = $.createElement('div').addClass('modal-body').html(message);
        modal.append(body);
        var footer = $.createElement('footer').addClass('modal-footer');
        var okButton = $.createElement('button').addClass('btn btn-primary')
            .text('OK').click(function () {
                $.fancybox.close(modal);
            });
        footer.append(okButton);
        var closeButton = $.createElement('button').addClass('btn btn-default')
            .text('Cancel').click(function () {
                cancel = true;
                $.fancybox.close(modal);
            });
        footer.append(closeButton);
        modal.append(footer);
        $.fancybox(modal, {
            padding: 3, closeBtn: false, afterClose: function () {
                if (callback) {
                    callback(cancel);
                }
            }
        });
    };
}(jQuery));