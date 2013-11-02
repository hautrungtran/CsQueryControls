(function ($, undefined) {
    var string = String, number = Number, math = Math, doc = document;
    string.EMPTY = '';
    number.MAX_LENGTH = 16;
    number.MAX = 9007199254740992;
    number.MIN = -9007199254740992;
    $.message = function (message, caption, callbacks) {
        var modal = $(doc.createElement('div')).addClass('message-box');
        var header = $(doc.createElement('header')).addClass('modal-header');
        var closeIcon = $(doc.createElement('div')).addClass('close')
            .text('x').click(function () {
                $.fancybox.close(modal);
            });
        header.append(closeIcon);
        if (caption) {
            var headerCaption = $(doc.createElement('h4')).html(caption);
            header.append(headerCaption);
        }
        modal.append(header);
        var body = $(doc.createElement('div')).addClass('modal-body').html(message);
        modal.append(body);
        var footer = $(doc.createElement('footer')).addClass('modal-footer');
        var closeButton = $(doc.createElement('button')).addClass('btn')
            .text('Close').click(function () {
                $.fancybox.close(modal);
            });
        footer.append(closeButton);
        modal.append(footer);
        $.fancybox(modal, { padding: 3, closeBtn: false, afterClose: callbacks });
    };
    $.confirm = function (message, caption, callbacks) {
        var modal = $(doc.createElement('div')).addClass('message-box');
        var header = $(doc.createElement('header')).addClass('modal-header');
        var closeIcon = $(doc.createElement('div')).addClass('close')
            .text('x').click(function () {
                callbacks(false);
                $.fancybox.close(modal);
            });
        header.append(closeIcon);
        if (caption) {
            var headerCaption = $(doc.createElement('h4')).html(caption);
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
        var closeButton = $(doc.createElement('button')).addClass('btn')
            .text('Close').click(function () {
                callbacks(false);
                $.fancybox.close(modal);
            });
        footer.append(closeButton);
        modal.append(footer);
        $.fancybox(modal, { padding: 3, closeBtn: false, afterClose: function () { modal.remove(); } });
    };
    $.mask = function ($element) {
        if ($element.data('mask')) {
            return;
        }
        var container = $(doc.createElement('div')).addClass('mask');
        var backdrop = $(doc.createElement('div')).addClass('mask-backdrop');
        var icon = $(doc.createElement('span')).addClass('mask-icon');
        container.insertBefore($element);
        container.append($element, backdrop, icon);
        $element.data('mask', container);
    };
    $.unmask = function ($element) {
        var container = $element.data('mask');
        if (container) {
            $element.insertBefore(container);
            container.remove();
            $element.removeData('mask');
        }
    };
}(jQuery));