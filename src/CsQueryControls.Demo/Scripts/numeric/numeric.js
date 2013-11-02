(function ($, undefined) {
    var string = String, number = Number, math = Math;
    string.EMPTY = '';
    number.MAX_LENGTH = 16;
    number.MAX = 9007199254740992;
    number.MIN = -9007199254740992;
    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }
    function toNumber(n) {
        if (isNumber(n)) {
            return number(n);
        } else {
            return undefined;
        }
    }
    function format(n, step, comma, decimal) {
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
    function removeFormat(s, decimal) {
        if (isNumber(s)) {
            return s;
        }
        s += string.EMPTY;
        var rgx = /^\d+$/;
        var out = string.EMPTY;
        for (var i = 0; i < s.length; i++) {
            if (rgx.test(s.charAt(i)) || (out === string.EMPTY && s.charAt(i) === '-')
                || (s.charAt(i) === decimal && out.indexOf('.') === -1)) {
                out += s.charAt(i) !== decimal ? s.charAt(i) : '.';
            }
        }
        if (out !== string.EMPTY && out !== '-') {
            return out;
        }
        return string.EMPTY;
    };
    var idx = 0;
    var Numeric = function (element, options) {
        this.id = idx++;
        this.init(element, options);
    };
    Numeric.prototype = {
        constructor: Numeric,
        init: function (element, options) {
            this.options = options;
            this.$element = $(element);
            var $input = this.$element.is('input') ? this.$element : this.$element.find('input[type=text]');;
            this.$input = $input.attr('maxlength', number.MAX_LENGTH);
            this.$increaseButton = this.$element.find(options.increaseButton);
            this.$decreaseButton = this.$element.find(options.decreaseButton);
            this.required = options.required == true;
            var min = isNumber(options.min) ? toNumber(options.min) : $.fn.numeric.defaults.min;
            var max = isNumber(options.max) ? toNumber(options.max) : $.fn.numeric.defaults.max;
            if (min > max) {
                var tmp = min;
                min = max;
                max = tmp;
            }
            this.min = min;
            this.max = max;
            var defaultValue = toNumber(options.defaultValue) || $.fn.numeric.defaults.defaultValue;
            if (defaultValue < this.min) {
                defaultValue = this.min;
            } else if (defaultValue > max) {
                defaultValue = this.max;
            }
            this.defaultValue = defaultValue;
            var round = toNumber(options.round) || $.fn.numeric.defaults.round;
            if (round > 10) {
                round = 10;
            } else if (round < 0) {
                round = 0;
            }
            this.round = round;
            var step = toNumber(options.step) || $.fn.numeric.defaults.step;
            if (this.max === this.min) {
                step = 0;
            } else if (step > (this.max - this.min)) {
                step = this.max - this.min;
            } else if (step < 1) {
                step = 1;
            }
            this.step = step;
            this.language = options.language || 'default';
            var formatInfo = options.format || $.fn.numeric.formats[this.language] || $.fn.numeric.formats['default'];
            formatInfo.step = toNumber(formatInfo.step) || $.fn.numeric.formats['default'].step;
            if (formatInfo.step < 0) {
                formatInfo.step = 0;
            }
            this.format = formatInfo;
            this.setValue(this.$input.val());
            this._attachEvents();
        },
        setValue: function (value) {
            value += string.EMPTY;
            if (!isNumber(value)) {
                value = removeFormat(value, this.format.decimal);
            }
            if (value.length > number.MAX_LENGTH) {
                value = value.indexOf('-') === 0 ? this.min : this.max;
            }
            value = toNumber(value) || string.EMPTY;
            if (value !== string.EMPTY) {
                if (value > this.max) {
                    value = this.max;
                }
                if (value < this.min) {
                    value = this.min;
                }
                value = value.toFixed(this.round).substring(0, number.MAX_LENGTH);
                value = format(value, this.format.step, this.format.comma, this.format.decimal);
            } else if (this.required) {
                value = math.max(0, this.min).toFixed(this.round);
            }
            this.$input.val(value);
            this.notifyChange();
        },
        getValue: function (required) {
            var value = this.$input.val();
            value = toNumber(removeFormat(value, this.format.decimal));
            if (required && !value) {
                value = math.max(0, this.min);
            }
            return value;
        },
        increase: function () {
            if (this.step === 0) { return; }
            var value = this.getValue(true);
            if (value === this.max) { return; }
            if ((this.max - value) < this.step) {
                value = this.max;
            } else {
                value = value + this.step;
            }
            this.setValue(value);
        },
        decrease: function () {
            if (this.step === 0) { return; }
            var value = this.getValue(true);
            if (value === this.min) { return; }
            if ((value - this.min) < this.step) {
                value = this.min;
            } else {
                value = value - this.step;
            }
            this.setValue(value);
        },
        notifyChange: function () {
            var val = this.getValue(true);
            if (val === this.max) {
                this.$increaseButton.addClass('disabled');
            } else {
                this.$increaseButton.removeClass('disabled');
            }
            if (val === this.min) {
                this.$decreaseButton.addClass('disabled');
            } else {
                this.$decreaseButton.removeClass('disabled');
            }
            this.$input.trigger({
                type: 'changeValue',
                value: this.getValue(this.required)
            });
        },
        destroy: function () {
            this._detachEvents();
            this.$input.removeAttr('maxlength');
            this.$element.removeData('numeric');
        },
        _attachEvents: function () {
            this.$input.on('blur', $.proxy(this._blur, this));
            this.$input.on('change', $.proxy(this._change, this));
            this.$input.on('focus', $.proxy(this._focus, this));
            if (this.step > 0) {
                this.$increaseButton.on('click', $.proxy(this.increase, this));
                this.$decreaseButton.on('click', $.proxy(this.decrease, this));
            }
        },
        _detachEvents: function () {
            this.$input.off('blur', this._blur);
            this.$input.off('change', this._change);
            this.$input.off('focus', this._focus);
            if (this.step > 0) {
                this.$increaseButton.off('click', this.increase);
                this.$decreaseButton.on('click', this.decrease);
            }
        },
        _blur: function (e) {
            this.setValue($(e.target).val());
        },
        _change: function (e) {
            this.setValue($(e.target).val());
        },
        _focus: function (e) {
            $(e.target).val(this.getValue());
        }
    };
    $.fn.numeric = function (options, val) {
        return this.each(function () {
            var $this = $(this),
            data = $this.data('numeric'),
            opt = typeof options === 'object' && options,
            dataset = $.getDataset(this);
            if (!data) {
                $this.data('numeric', (data = new Numeric(
                  this, $.extend({}, $.fn.numeric.defaults, dataset, opt))));
            }
            if (typeof options === 'string') data[options](val);
        });
    };
    $.fn.numeric.defaults = {
        required: false,
        min: 0,
        max: number.MAX,
        round: 0,
        defaultValue: 0,
        step: 1,
        language: 'default',
        increaseButton: '.btn-increase',
        decreaseButton: '.btn-decrease',
        hiddenInput: true
    };
    $.fn.numeric.formats = {
        'default': {
            step: 0,
            comma: '',
            decimal: '.'
        },
        en: {
            step: 3,
            comma: ',',
            decimal: '.'
        }
    };
}(jQuery));
