using System;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Components {
    public class GridCommand : HyperLink {
        private readonly CommonElement _icon;
        public string Icon {
            get {
                return _icon.Class;
            }
            set {
                _icon.Class = value;
            }
        }
        public GridCommand(string href, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(href, parsingMode, parsingOptions, docType) {
            Attr("data-command-type", "default");
            _icon = new CommonElement(HtmlTag.I);
            Append(_icon);
        }
    }
    public class DialogCommand : GridCommand {
        public int? DialogWidth {
            get {
                return Attr<int?>("data-dialog-width");
            }
            set {
                Attr("data-dialog-width", value);
            }
        }
        public int? DialogHeight {
            get {
                return Attr<int?>("data-dialog-height");
            }
            set {
                Attr("data-dialog-height", value);
            }
        }
        public bool Refresh {
            get {
                return Attr<bool>("data-refresh");
            }
            set {
                Attr("data-refresh", ToLowerString(value));
            }
        }
        public DialogCommand(string href, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(href, parsingMode, parsingOptions, docType) {
            Attr("data-command-type", "dialog");
        }
    }
    public class AjaxCommand : GridCommand {
        public AjaxMethod AjaxMethod {
            get {
                return (AjaxMethod)Enum.Parse(typeof(AjaxMethod), Attr("data-ajax-method"));
            }
            set {
                Attr("data-ajax-method", ToLowerString(value));
            }
        }
        public string Confirm {
            get {
                return Attr("data-confirm");
            }
            set {
                Attr("data-confirm", value);
            }
        }
        public string Caption {
            get {
                return Attr("data-caption");
            }
            set {
                Attr("data-caption", value);
            }
        }
        public bool Refresh {
            get {
                return Attr<bool>("data-refresh");
            }
            set {
                Attr("data-refresh", ToLowerString(value));
            }
        }
        public string CallbackFunction {
            get {
                return Attr("data-callback");
            }
            set {
                Attr("data-callback", value);
            }
        }
        public AjaxCommand(string href, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(href, parsingMode, parsingOptions, docType) {
            Attr("data-command-type", "ajax");
        }
    }
    public enum AjaxMethod {
        Get,
        Post,
    }
}