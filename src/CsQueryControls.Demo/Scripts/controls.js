(function ($, undefined) {
    $(document).ready(function () {
        function addOrUpdateParameter(paramName, paramValue) {
            var url = window.location.href;
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
        var doc = document;
        $('div[data-toggle=numeric], input[data-toggle=numeric]').each(function () {
            var $this = $(this);
            var input = $($this.data('target'));
            $this.numeric().on('changeValue', function (e) {
                input.val(e.value);
            });
        });
        $('div[data-toggle=datetime], input[data-toggle=datetime]').each(function () {
            var $this = $(this);
            var input = $($this.data('target'));
            $this.datetimepicker().on('changeDate', function (e) {
                input.val(e.localDate ? e.localDate.toLocaleString() : '');
            });
        });
        $('div[data-toggle=color], input[data-toggle=color]').each(function () {
            var $this = $(this);
            var input = $($this.data('target'));
            $this.colorpicker().on('changeColor', function () {
                input.val($this.find('input:first').val());
            });
        });
        $('input[data-toggle=select], select[data-toggle=select]').each(function () {
            var $this = $(this);
            if ($this.is('select') && $this.data('required') !== true) {
                $this.prepend(doc.createElement('option'));
            }
            $this.select2({
                placeholder: $this.data('placeholder'),
                allowClear: !($this.data('required') === true),
                minimumInputLength: $this.data('minimumInputLength'),
                formatResult: function (item) {
                    return item.text;
                },
                formatSelection: function (item) {
                    return item.text;
                }
            });
            $this.select2('val', $this.data('selectedValue'));
        });
        $('textarea[data-toggle=editor], input[data-toggle=editor]').each(function () {
            var $this = $(this);
            tinymce.init({
                selector: '#' + this.id,
                width: $this.data('editorWidth'),
                height: $this.data('editorHeight'),
                theme: "modern",
                plugins: [$this.data('plugins')],
                toolbar: $this.data('toolbar'),
                image_advtab: true,
                relative_urls: false,
                convert_urls: false,
                contextmenu: $this.data('contextMenu'),
                upload_url: $this.data('uploadUrl')
            });
        });
        $('div[data-toggle=fileUpload]').each(function () {
            var $this = $(this);
            var input = $($this.data('target'));
            $this.find('.btn-upload').click(function () {
                input.click();
            });
            input.change(function () {
                $this.find('input:first').val(input.val());
            });
        });
        $('table[data-toggle=table]').each(function () {
            $(this).table();
        });
        $('ul[data-toggle=tabs]').each(function () {
            var $this = $(this);
            var tabContent = $.createElement('div').addClass('tab-content');
            $this.children().each(function () {
                var link = $(this).find('a:first');
                var id = link.attr('href');
                link.click(function () {
                    var selectedTab = { selectedTab: id };
                    history.replaceState(selectedTab, '', addOrUpdateParameter('selectedTab', id.substring(1)));
                });
                $(id).addClass('tab-pane').appendTo(tabContent);
            });
            tabContent.insertAfter($this);
            $this.children().eq($this.data('selected') || 0).find('a:first').tab('show');
        });
    });
}(jQuery));
