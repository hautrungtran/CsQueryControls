(function ($, undefined) {
    var string = String, number = Number, math = Math, doc = document;
    string.EMPTY = '';
    number.MAX_LENGTH = 16;
    number.MAX = 9007199254740992;
    number.MIN = -9007199254740992;
    var keys = [];
    var dateFormatComponents = {
        dd: { property: 'UTCDate', getPattern: function () { return '(0?[1-9]|[1-2][0-9]|3[0-1])\\b'; } },
        MM: { property: 'UTCMonth', getPattern: function () { return '(0?[1-9]|1[0-2])\\b'; } },
        yy: { property: 'UTCYear', getPattern: function () { return '(\\d{2})\\b'; } },
        yyyy: { property: 'UTCFullYear', getPattern: function () { return '(\\d{4})\\b'; } },
        hh: { property: 'UTCHours', getPattern: function () { return '(0?[0-9]|1[0-9]|2[0-3])\\b'; } },
        mm: { property: 'UTCMinutes', getPattern: function () { return '(0?[0-9]|[1-5][0-9])\\b'; } },
        ss: { property: 'UTCSeconds', getPattern: function () { return '(0?[0-9]|[1-5][0-9])\\b'; } },
        ms: { property: 'UTCMilliseconds', getPattern: function () { return '([0-9]{1,3})\\b'; } },
        HH: { property: 'Hours12', getPattern: function () { return '(0?[1-9]|1[0-2])\\b'; } },
        PP: { property: 'Period12', getPattern: function () { return '(AM|PM|am|pm|Am|aM|Pm|pM)\\b'; } }
    };
    for (var k in dateFormatComponents) keys.push(k);
    keys[keys.length - 1] += '\\b';
    keys.push('.');

    keys.pop();
    var formatReplacer = new RegExp(keys.join('\\b|'), 'g');
    function padLeft(s, l, c) {
        if (l < s.length) return s;
        else return Array(l - s.length + 1).join(c || ' ') + s;
    }
    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }
    function isEmpty(obj) {
        return obj === undefined || obj === null || obj.length === 0;
    }
    function toNumber(n) {
        if (isNumber(n)) {
            return number(n);
        } else {
            return undefined;
        }
    }
    function formatNumber(n, step, comma, decimal) {
        n += string.EMPTY;
        var x = n.split('.');
        var x1 = x[0];
        var x2 = x.length > 1 && x[1] ? decimal + x[1] : string.EMPTY;
        if (step > 0) {
            var rgx = new RegExp('(\\d+)(\\d{' + step + '})');
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + comma + '$2');
            }
        }
        return x1 + x2;
    };
    //function removeNumberFormat(s, decimal) {
    //    if (isNumber(s)) {
    //        return s;
    //    }
    //    s += string.EMPTY;
    //    var rgx = /^\d+$/;
    //    var out = string.EMPTY;
    //    for (var i = 0; i < s.length; i++) {
    //        if (rgx.test(s.charAt(i)) || (out === string.EMPTY && s.charAt(i) === '-')
    //            || (s.charAt(i) === decimal && out.indexOf('.') === -1)) {
    //            out += s.charAt(i) !== decimal ? s.charAt(i) : '.';
    //        }
    //    }
    //    if (out !== string.EMPTY && out !== '-') {
    //        return out;
    //    }
    //    return string.EMPTY;
    //};
    function formatDateTime(date, format) {
        if ($.type(date) === 'date') {
            var result = format.replace(formatReplacer, function (match) {
                var methodName, property, rv, len = match.length;
                if (match === 'ms')
                    len = 1;
                property = dateFormatComponents[match].property;
                if (property === 'Hours12') {
                    rv = date.getUTCHours();
                    if (rv === 0) rv = 12;
                    else if (rv !== 12) rv = rv % 12;
                } else if (property === 'Period12') {
                    if (date.getUTCHours() >= 12) return 'PM';
                    else return 'AM';
                } else {
                    methodName = 'get' + property;
                    rv = date[methodName]();
                }
                if (methodName === 'getUTCMonth') rv = rv + 1;
                if (methodName === 'getUTCYear') rv = rv + 1900 - 2000;
                return padLeft(rv.toString(), len, '0');
            });
            return result;
        }
        return string.EMPTY;
    };
    function formatString(s) {
        var args = arguments;
        return s.replace(/{(\d+)}/g, function (match, index) {
            index = index * 1 + 1;
            return typeof args[index] != 'undefined' ? args[index] : match;
        });
    };
    function insertParam(url, obj) {
        url += (url.indexOf('?') === -1 ? '?' : '&') + $.param(obj);
        return url;
    };

    var idx = 0;
    var Table = function (element, options) {
        this.id = idx++;
        this.init(element, options);
    };
    Table.prototype = {
        constructor: Table,
        init: function (element, options) {
            var table = this;
            this.options = options;
            this.selector = options.selector || $.fn.table.defaults.selector;
            this.$element = $(element);
            this.header = this.$element.find('thead');
            this.footer = this.$element.find('tfoot');
            this.body = this.$element.find('tbody');

            this.pagers = this.$element.find(this.selector.pagers);
            this.firstButtons = this.$element.find(this.selector.firstButton);
            this.prevButtons = this.$element.find(this.selector.previousButton);
            this.pageDisplay = this.$element.find(this.selector.pageDisplay);
            this.nextButtons = this.$element.find(this.selector.nextButton);
            this.lastButtons = this.$element.find(this.selector.lastButton);
            this.pageSizeSelects = this.$element.find(this.selector.pageSize);
            this.pageIndexInputs = this.$element.find(this.selector.pageIndex);

            this.commands = this.$element.find(this.selector.gridCommandContainer);
            this.pageIndex = toNumber(options.pageIndex) || $.fn.table.defaults.pageIndex;
            this.pageSize = toNumber(options.pageSize) || $.fn.table.defaults.pageSize;
            this.total = toNumber(options.total);
            if ($.isFunction(options.ajaxUrl)) {
                options.ajaxUrl = options.ajaxUrl(element);
            }
            if (!$.type(options.ajaxUrl) === "string") {
                options.ajaxUrl = $.fn.table.defaults.ajaxUrl;
            }
            this.ajaxUrl = options.ajaxUrl;
            this.key = options.key;
            this.cache = options.cache == true;
            this.items = false;
            if (!$.isFunction(options.processData)) {
                options.processData = $.fn.table.defaults.processData;
            }
            this.processData = options.processData;
            if (!$.isFunction(options.buildContent)) {
                options.buildContent = $.fn.table.defaults.buildContent;
            }
            this.buildContent = options.buildContent;
            if (!$.isFunction(options.getPageDisplayText)) {
                options.getPageDisplayText = $.fn.table.defaults.getPageDisplayText;
            }
            this.getPageDisplayText = options.getPageDisplayText;
            var headerTextRow = this.$element.find(this.selector.headerTextRow);
            var columns = [];
            if (!isEmpty(options.columns) && $.isArray(options.columns)) {
                columns = options.columns;
            } else if (!isEmpty(headerTextRow)) {
                var headers = headerTextRow.eq(0).children();
                headers.each(function () {
                    var $this = $(this);
                    if (!$this.hasClass(table.selector.rowCommandContainer.substring(1))) {
                        columns.push({
                            name: $this.data('property'),
                            format: $this.data('format'),
                            columnType: $this.data('columnType')
                        });
                    } else {
                        columns.push({
                            name: table.selector.rowCommandContainer.substring(1),
                            columnType: 'rowCommand',
                            html: $this.html()
                        });
                    }
                });
            }
            this.columns = columns;
            this.emptyText = options.emptyText;
            this.pageDisplayText = options.pageDisplayText;
            if (this.ajaxUrl) {
                this.changePage(0, true);
            }
            this._attachEvents();
        },
        changePage: function (pageIndex, refresh) {
            var table = this;
            if (pageIndex < 0) {
                pageIndex = 0;
            }
            if (this.pageSize < 1) {
                this.pageSize = 1;
            }
            if (this.state === 'loading' || (this.pageIndex == pageIndex && refresh === false)
                || (this.total > 0 && pageIndex > this._getTotalPages(this.total, this.pageSize) - 1)) {
                return;
            }
            if (this.ajaxUrl) {
                if (refresh === true || !this.cache) {
                    this.items = {};
                }
                if (refresh === 'limit') {
                    this.items[pageIndex] = [];
                }
                if (!this.items[pageIndex] || this.items[pageIndex].length === 0) {
                    this.toggle('loading');
                    var data = {};
                    if (this.criteria) {
                        var fields = $(this.criteria).serializeArray();
                        $.each(fields, function (i, field) {
                            data[field.name] = field.value;
                        });
                    }
                    data = $.extend(data, { pageIndex: pageIndex, pageSize: this.pageSize });
                    $.get(this.ajaxUrl, data).done(function (response) {
                        var items = table.processData(response);
                        table.items[pageIndex] = items;
                        table.buildContent(items);
                        table._attachRowCommandEvents();

                        table.pageIndex = pageIndex;
                        table.notifyChange();
                    }).always(function () {
                        table.toggle('complete');
                    });
                } else {
                    this.buildContent(table.items[pageIndex]);
                    table._attachRowCommandEvents();
                    this.pageIndex = pageIndex;
                    this.notifyChange();
                }
            } else {
                this.buildContent(false);
                this.pageIndex = pageIndex;
                this.notifyChange();
            }
        },
        notifyChange: function () {
            if (!isEmpty(this.pagers)) {
                if (this.pageIndex == 0) {
                    this.firstButtons.attr('disabled', 'disabled');
                    this.prevButtons.attr('disabled', 'disabled');
                } else {
                    this.firstButtons.removeAttr('disabled');
                    this.prevButtons.removeAttr('disabled');
                }
                if (this.pageIndex === (this._getTotalPages(this.total, this.pageSize) - 1)) {
                    this.lastButtons.attr('disabled', 'disabled');
                    this.nextButtons.attr('disabled', 'disabled');
                } else {
                    this.lastButtons.removeAttr('disabled');
                    this.nextButtons.removeAttr('disabled');
                }
            }
            this._updatePager();
        },
        toggle: function (target) {
            if (target === 'loading') {
                this.$element.block({ message: "please wait..." });
                this.loading = true;
            }
            if (target === 'complete') {
                this.$element.unblock();
                this.loading = false;
            }
            return this.state;
        },
        _getTotalPages: function (total, pageSize) {
            return math.floor((total + pageSize - 1) / pageSize);
        },
        _updatePager: function () {
            if (!isEmpty(this.pagers)) {
                this.pageDisplay.text(this.getPageDisplayText(this.pageIndex, this.pageSize, this.total));
                this.pageIndexInputs.val(this.pageIndex + 1);
            }
        },
        _attachEvents: function () {
            var table = this;
            this.firstButtons.click($.proxy(this.changePage, this, 0));
            this.lastButtons.click(function () {
                table.changePage(table._getTotalPages(table.total, table.pageSize) - 1);
            });
            this.prevButtons.click(function () {
                table.changePage(table.pageIndex - 1);
            });
            this.nextButtons.click(function () {
                table.changePage(table.pageIndex + 1);
            });
            this.pageSizeSelects.change(function () {
                table.pageSize = toNumber($(this).val());
                table.changePage(0, true);
                table.pageIndexInputs.val('');
                table.pageSizeSelects.val(table.pageSize);
            });
            this.pageIndexInputs.change(function () {
                var value = toNumber($(this).val());
                if (value || value === 0) {
                    var totalPages = table._getTotalPages(table.total, table.pageSize);
                    if (value > totalPages) {
                        value = totalPages;
                    }
                    if (value < 1) {
                        value = 1;
                    }
                }
                table.pageIndexInputs.val(value);
            });
            this.pageIndexInputs.keyup(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    table.changePage(((toNumber(table.pageIndexInputs.val()) - 1) || 0), 'limit');
                }
            });
            this.pageIndexButtons.click(function (e) {
                e.preventDefault();
                table.changePage(((toNumber(table.pageIndexInputs.val()) - 1) || 0), 'limit');
            });
            this.$element.find(this.selector.tableCommand).click(function (e) {
                var $this = $(this);

                var url = $this.attr('href');
                var commandType = $this.data('commandType');
                if (commandType === 'ajax') {
                    e.preventDefault();
                    if (url) {
                        if ($this.data('confirm')) {
                            $.confirm($this.data('confirm'), $this.data('caption') || 'Confirm', function (event) {
                                if (event) {
                                    table._requestAjax($this, url);
                                }
                            });
                        } else {
                            table._requestAjax($this, url);
                        }
                    } else {
                        table.changePage(table.pageIndex, true);
                    }
                } else if (commandType === 'dialog') {
                    e.preventDefault();
                    if (url) {
                        $.fancybox.open({
                            href: url,
                            padding: 3,
                            closeBtn: false,
                            type: 'iframe',
                            iframe: { preload: false },
                            width: $this.data('dialogWidth'),
                            height: $this.data('dialogHeight'),
                            wrapCSS: 'table-dialog',
                            afterClose: function () {
                                if ($this.data('refresh')) {
                                    table.state = 'complete';
                                    table.changePage(table.pageIndex, true);
                                }
                            }
                        });
                    }
                }
            });
        },
        _attachRowCommandEvents: function () {
            var table = this;
            this.body.find(this.selector.rowCommand).click(function (e) {
                e.preventDefault();
                var $this = $(this);

                var url = $this.attr('href');
                var commandType = $this.data('commandType');
                var key = $this.parents('tr').data('keyValue');

                if (commandType === 'ajax') {
                    e.preventDefault();
                    if (url) {
                        if ($this.data('confirm')) {
                            $.confirm($this.data('confirm'), $this.data('caption') || 'Confirm', function (event) {
                                if (event) {
                                    table._requestAjax($this, url, key);
                                }
                            });
                        } else {
                            table._requestAjax($this, url, key);
                        }
                    } else {
                        table.changePage(table.pageIndex, true);
                    }
                } else if (commandType === 'dialog') {
                    if (url) {
                        $.fancybox.open({
                            href: url,
                            padding: 3,
                            closeBtn: false,
                            type: 'iframe',
                            iframe: { preload: false },
                            width: $this.data('dialogWidth'),
                            height: $this.data('dialogHeight'),
                            wrapCSS: 'table-dialog',
                            afterClose: function () {
                                if ($this.data('refresh')) {
                                    table.state = 'complete';
                                    table.changePage(table.pageIndex, true);
                                }
                            }
                        });
                    }
                } else {
                    window.open(url, $this.attr('target'));
                    window.focus();
                }
            });
        },
        _requestAjax: function ($target, url) {
            this.toggle('loading');
            var table = this;
            $.ajax({
                type: $target.data('ajaxMethod') || 'POST',
                url: url
            }).done(function (response) {
                var process = $.fn.table.functions[$target.data('callback')] || $.fn.table.functions['default'];
                process(response, function () {
                    if ($target.data('refresh')) {
                        table.state = 'complete';
                        table.changePage(table.pageIndex, true);
                    }
                });
            }).always($.proxy(this.toggle, this, 'complete'));
        },
        _formatValue: function (cell, columnType, value, strFormat) {
            switch (columnType) {
                case 'html':
                    cell.html(value);
                    break;
                case 'image':
                    cell.html($.createElement('img').attr('src', value).addClass(this.theme.cellImageClasses));
                    break;
                case 'checkbox':
                    cell.html($.createElement('input').attr('type', 'checkbox').val(value));
                    break;
                case 'datetime':
                    value = value.replace(/[^0-9 +]/g, '');
                    value = new Date(parseInt(value));
                    cell.text(formatDateTime(value, strFormat || this.format.dateFormat));
                    break;
                case 'number':
                    cell.text(formatNumber(value, this.format.step, this.format.comma, this.format.decimal));
                    break;
                default:
                    cell.text(value);
            }
        }
    };
    $.fn.table = function (options, val) {
        return this.each(function () {
            var $this = $(this),
            data = $this.data('table'),
            opt = typeof options === 'object' && options,
            dataset = $.getDataset(this);
            if (!data) {
                $this.data('table', (data = new Table(
                  this, $.extend({}, $.fn.table.defaults, dataset, opt))));
            }
            if (typeof options === 'string') data[options](val);
        });
    };
    $.fn.table.defaults = {
        pageIndex: 0,
        pageSize: 20,
        cache: true,
        total: false,
        ajaxUrl: false,
        columns: false,
        key: false,
        criteria: false,
        emptyText: 'No data found.',
        pageDisplayText: '{0} - {1} / {2}',
        language: 'iv',
        selector: {
            columns: ".columns",
            commandContainer: ".command-container",
            gridCommandContainer: ".grid-command-container",
            gridCommandButton: ".grid-command",
            pagerContainer: ".pager-container",
            firstButton: ".first-button",
            previousButton: ".prev-button",
            pageIndex: ".page-index",
            total: ".total",
            nextButton: ".next-button",
            lastButton: ".last-button",
            pageSizes: ".page-sizes",
            rowCommand: ".row-command",
            rowCommandContainer: ".row-command-container",
        },
        processData: function (response) {
            var items;
            if (response instanceof Array) {
                items = response;
            } else {
                if (response.total && response.total !== this.total) {
                    this.total = toNumber(response.total);
                    this._updatePager();
                    this.items = [];
                }
                items = response.items;
            }
            return items;
        },
        buildContent: function (items) {
            if (this.ajaxUrl) {
                var body = this.body.empty();
                if (items.length > 0) {
                    for (var i = 0; i < items.length; i++) {
                        var item = items[i];
                        var row = $(doc.createElement('tr')).attr('data-key-value', item[this.key]);
                        for (var j = 0; j < this.columns.length; j++) {
                            var column = this.columns[j];
                            var cell = $(doc.createElement('td'));
                            if (column.columnType !== 'rowCommand') {
                                this._formatValue(cell, column.columnType, item[column.name], column.format);
                            } else {
                                cell.html(column.html);
                            }
                            row.append(cell);
                        }
                        body.append(row);
                    }
                    this.body.find(this.selector.rowCommand).each(function () {
                        var $this = $(this);
                        var key = $this.parents('tr').data('keyValue');
                        var url = insertParam($this.attr('href'), { id: key });
                        $this.attr('href', url);
                    });
                } else {
                    body.append($(doc.createElement('tr')).append($(doc.createElement('td')).attr('colspan', this.columns.length).html(this.emptyText)));
                }
            } else {

            }
        },
        getPageDisplayText: function (pageIndex, pageSize, total) {
            var start = formatNumber(math.min((pageIndex * pageSize + 1), total), this.format.step, this.format.comma, this.format.decimal);
            var end = formatNumber(math.min((pageIndex * pageSize + pageSize), this.total), this.format.step, this.format.comma, this.format.decimal);
            var totalString = formatNumber(total, this.format.step, this.format.comma, this.format.decimal);
            var pageIndexString = formatNumber(pageIndex + 1, this.format.step, this.format.comma, this.format.decimal);
            var totalPage = formatNumber(math.max(this._getTotalPages(total, pageSize), 1), this.format.step, this.format.comma, this.format.decimal);
            return formatString(this.pageDisplayText, start, end, totalString, pageIndexString, totalPage);
        }
    };
    $.fn.table.formats = {
        'default': {
            step: 0,
            comma: '',
            decimal: '.',
            dateFormat: 'MM/dd/yyyy'
        },
        en: {
            step: 3,
            comma: ',',
            decimal: '.',
            dateFormat: 'MM/dd/yyyy'
        }
    };
    $.fn.table.functions = {
        'default': function (response, callback) {
            var message = string.EMPTY;
            if (response.message) {
                message = response.message;
            }
            var caption = 'Message';
            if (response.caption) {
                message = response.caption;
            }
            if ($.type(response) === 'string') {
                message = response;
            }
            if (message) {
                $.message(message, caption, callback);
            } else {
                callback();
            }
        }
    };
    $.message = function (message, caption, callbacks) {
        var modal = $(doc.createElement('div')).addClass('message-box');
        var header = $(doc.createElement('header')).addClass('modal-header');
        var closeIcon = $(doc.createElement('button')).addClass('close')
            .text('x').click(function () {
                $.fancybox.close(modal);
            });
        header.append(closeIcon);
        if (caption) {
            var headerCaption = $(doc.createElement('h4')).html(caption).addClass("modal-title");
            header.append(headerCaption);
        }
        modal.append(header);
        var body = $(doc.createElement('div')).addClass('modal-body').html(message);
        modal.append(body);
        var footer = $(doc.createElement('footer')).addClass('modal-footer');
        modal.append(footer);
        $.fancybox(modal, { padding: 3, closeBtn: false, afterClose: callbacks, width: 400 });
    };
    $.confirm = function (message, caption, callbacks) {
        var modal = $(doc.createElement('div')).addClass('message-box');
        var header = $(doc.createElement('header')).addClass('modal-header');
        var closeIcon = $(doc.createElement('button')).addClass('close')
            .text('x').click(function () {
                callbacks(false);
                $.fancybox.close(modal);
            });
        header.append(closeIcon);
        if (caption) {
            var headerCaption = $(doc.createElement('h4')).html(caption).addClass("modal-title");
            header.append(headerCaption);
        }
        modal.append(header);
        var body = $(doc.createElement('div')).addClass('modal-body').html(message);
        modal.append(body);
        var footer = $(doc.createElement('footer')).addClass('modal-footer');
        var okButton = $(doc.createElement('button')).addClass('btn btn-primary')
            .text('OK').click(function () {
                if (callbacks) {
                    callbacks(true);
                }
                $.fancybox.close(modal);
            });
        footer.append(okButton);
        var closeButton = $(doc.createElement('button')).addClass('btn btn-default')
            .text('Cancel').click(function () {
                callbacks(false);
                $.fancybox.close(modal);
            });
        footer.append(closeButton);
        modal.append(footer);
        $.fancybox(modal, { padding: 3, closeBtn: false, width: 400, afterClose: function () { modal.remove(); } });
    };
}(jQuery));