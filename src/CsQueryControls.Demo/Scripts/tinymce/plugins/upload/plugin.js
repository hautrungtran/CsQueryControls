/**
 * plugin.js
 *
 * Copyright, ChanChungHao<chanchunghao@yahoo.com.vn>
 * Released under LGPL License.
 *
 * License: http://www.tinymce.com/license
 * Contributing: http://www.tinymce.com/contributing
 */

/*jshint unused:false */
/*global tinymce:true */

/**
 * Example plugin that adds a toolbar button and menu item.
 */
tinymce.PluginManager.add('upload', function (editor, url) {
    // Add a button that opens a window
    editor.addButton('upload', {
        title: 'Upload Files',
        icon: 'browse',
        onclick: function () {
            // Open window
            editor.windowManager.open({
                title: 'Upload Files',
                url: editor.settings.upload_url,
                width: 500,
                height: 400,
                onsubmit: function (e) {

                }
            });
        }
    });

    // Adds a menu item to the tools menu
    editor.addMenuItem('upload', {
        icon: 'browse',
        text: 'Upload files',
        context: 'insert',
        prependToContext: true,
        onclick: function () {
            // Open window with a specific url
            editor.windowManager.open({
                title: 'Upload Files',
                url: editor.settings.upload_url,
                width: 500,
                height: 400,
                onsubmit: function (e) {

                }
            });
        }
    });
});