using System;
using System.ComponentModel;
using System.Reflection;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CsQuery;
using CsQueryControls.HtmlAttributes;

namespace CsQueryControls.HtmlElements {
    public class CommonElement : CQ {
        private readonly HtmlTag _htmlTag;
        private readonly string _tagName;

        #region Property

        /// <summary>
        ///     Gets html tag of the element.
        /// </summary>
        /// <value>
        ///     Tag name.
        /// </value>
        public virtual HtmlTag HtmlTag {
            get { return _htmlTag; }
        }
        /// <summary>
        ///     Gets tag name of the element.
        /// </summary>
        /// <value>
        ///     Tag name.
        /// </value>
        public virtual string TagName {
            get { return _tagName; }
        }
        /// <summary>
        ///     Gets or sets the inner text.
        /// </summary>
        /// <value>
        ///     The inner text.
        /// </value>
        public virtual string InnerText {
            get { return Text(); }
            set { Text(value); }
        }
        /// <summary>
        ///     Gets or sets the inner HTML.
        /// </summary>
        /// <value>
        ///     The inner HTML.
        /// </value>
        public virtual string InnerHtml {
            get { return Html(); }
            set { Html(value); }
        }
        /// <summary>
        ///     Specifies a shortcut key to activate/focus an element.
        /// </summary>
        /// <value>
        ///     The access key.
        /// </value>
        public virtual char? AccessKey {
            get { return Attr<char?>("accesskey"); }
            set { Attr("accesskey", value); }
        }
        /// <summary>
        ///     Specifies one or more classnames for an element (refers to a class in a style sheet).
        /// </summary>
        /// <value>
        ///     The class.
        /// </value>
        public virtual string Class {
            get { return Attr("class"); }
            set { Attr("class", value); }
        }
        /// <summary>
        ///     Specifies whether the content of an element is editable or not.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [content editable]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool? ContentEditable {
            get { return Attr<bool?>("contenteditable"); }
            set { Attr("contenteditable", value); }
        }
        /// <summary>
        ///     Specifies a context menu for an element. The context menu appears when a user right-clicks on the element.
        /// </summary>
        /// <value>
        ///     The context menu.
        /// </value>
        public virtual string ContextMenu {
            get { return Attr("contextmenu"); }
            set { Attr("contextmenu", value); }
        }
        /// <summary>
        ///     Specifies the text direction for the content in an element.
        /// </summary>
        /// <value>
        ///     The dir.
        /// </value>
        public virtual Dir? Dir {
            get {
                Dir result;
                return Enum.TryParse(Attr("dir"), true, out result) ? result : (Dir?) null;
            }
            set { Attr("dir", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies whether an element is draggable or not.
        /// </summary>
        /// <value>
        ///     The draggable.
        /// </value>
        public virtual Draggable? Draggable {
            get {
                Draggable result;
                return Enum.TryParse(Attr("draggable"), true, out result) ? result : (Draggable?) null;
            }
            set { Attr("draggable", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies whether the dragged data is copied, moved, or linked, when dropped.
        /// </summary>
        /// <value>
        ///     The dropzone.
        /// </value>
        public virtual Dropzone? Dropzone {
            get {
                Dropzone result;
                return Enum.TryParse(Attr("dropzone"), true, out result) ? result : (Dropzone?) null;
            }
            set { Attr("dropzone", ToLowerString(value)); }
        }
        /// <summary>
        ///     Specifies that an element is not yet, or is no longer, relevant.
        /// </summary>
        /// <value>
        ///     <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Hidden {
            get { return HasAttr("hidden"); }
            set {
                if (value) {
                    Attr("hidden", "hidden");
                } else {
                    RemoveAttr("hidden");
                }
            }
        }
        /// <summary>
        ///     Specifies a unique id for an element.
        /// </summary>
        /// <value>
        ///     The ID.
        /// </value>
        public virtual string Id {
            get { return Attr("id"); }
            set { Attr("id", value); }
        }
        /// <summary>
        ///     Specifies the language of the element's content.
        /// </summary>
        /// <value>
        ///     The lang.
        /// </value>
        public virtual string Lang {
            get { return Attr("lang"); }
            set { Attr("lang", value); }
        }
        /// <summary>
        ///     Specifies whether the element is to have its spelling and grammar checked or not.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [spell check]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool? SpellCheck {
            get { return Attr<bool?>("spellcheck"); }
            set { Attr("spellcheck", value); }
        }
        /// <summary>
        ///     Specifies an inline CSS style for an element.
        /// </summary>
        /// <value>
        ///     The style.
        /// </value>
        public virtual string Style {
            get { return Attr("style"); }
            set { Attr("style", value); }
        }
        /// <summary>
        ///     Specifies the tabbing order of an element.
        /// </summary>
        /// <value>
        ///     The index of the tab.
        /// </value>
        public virtual int? TabIndex {
            get { return Attr<int?>("tabindex"); }
            set { Attr("tabindex", value); }
        }
        /// <summary>
        ///     Specifies extra information about an element.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public virtual string Title {
            get { return Attr("title"); }
            set { Attr("title", value); }
        }
        /// <summary>
        ///     Specifies whether the content of an element should be be translated or not.
        /// </summary>
        /// <value>
        ///     <c>true</c> if translate; otherwise, <c>false</c>.
        /// </value>
        public virtual bool? Translate {
            get {
                string result = Attr("translate");
                return !string.IsNullOrEmpty(result) ? result.ToLower() == "yes" : (bool?) null;
            }
            set { Attr("translate", value.HasValue ? (value.Value ? "yes" : "no") : null); }
        }

        #endregion

        #region Constructor

        public CommonElement(HtmlTag tag, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(ToHtmlString(tag), parsingMode, parsingOptions, docType) {
            _htmlTag = tag;
            _tagName = tag.ToString().ToLower();
        }
        public CommonElement(string tagName, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(ToHtmlString(tagName), parsingMode, parsingOptions, docType) {
            Enum.TryParse(tagName, true, out _htmlTag);
            _tagName = tagName;
        }
        public CommonElement(CQ cq)
            : base(cq.FirstElement()) {
            string tageName = cq.FirstElement().NodeName;
            Enum.TryParse(tageName, true, out _htmlTag);
            _tagName = tageName;
        }
        public CommonElement(IDomObject dom)
            : base(dom) {
            string tageName = dom.NodeName;
            Enum.TryParse(tageName, true, out _htmlTag);
            _tagName = tageName;
        }

        #endregion

        #region Indexer

        public new virtual CQ this[string selector] { get { return Find(selector); } }

        #endregion

        public new void Attr(string name, IConvertible value) {
            if (value == null) {
                RemoveAttr(name);
            } else {
                base.Attr(name, value);
            }
        }
        public new T Attr<T>(string name) {
            var result = Attr(name);
            return string.IsNullOrEmpty(result) ? default(T) : (T) TypeDescriptor.GetConverter(typeof (T)).ConvertFrom(result);
        }
        public IHtmlString RenderHtml() {
            return new HtmlString(Render());
        }

        public static CommonElement CreateElement(HtmlTag tag, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default,
            DocType docType = DocType.Default) {
            switch (tag) {
                case HtmlTag.A:
                    return new AElement(parsingMode, parsingOptions, docType);
                case HtmlTag.Area:
                    return new AreaElement(parsingMode, parsingOptions, docType);
                default:
                    return new CommonElement(tag, parsingMode, parsingOptions, docType);
            }
        }
        public static CommonElement CreateElement(CQ cq) {
            return cq is CommonElement ? (CommonElement) cq : new CommonElement(cq);
        }
        public static CommonElement CreateElement(IDomObject dom) {
            return new CommonElement(dom);
        }
        public static CommonElement CreateElement(WebControl control) {
            PropertyInfo property = control.GetType().GetProperty("TagName", BindingFlags.NonPublic);
            string tagName = property.GetValue(control).ToString();
            var element = new CommonElement(tagName);
            foreach (string key in control.Attributes.Keys) {
                string value = control.Attributes[key];
                element.Attr(key, value);
            }
            return element;
        }
        public static CommonElement CreateElement(HtmlControl control) {
            var element = new CommonElement(control.TagName);
            foreach (string key in control.Attributes.Keys) {
                string value = control.Attributes[key];
                element.Attr(key, value);
            }
            return element;
        }
        protected static string ToHtmlString(HtmlTag tag) {
            return ToHtmlString(tag.ToString());
        }
        protected static string ToHtmlString(string tagName) {
            return string.Format("<{0}>", tagName.ToLower());
        }
        protected static string ToLowerString(object obj) {
            return obj != null ? obj.ToString().ToLower() : string.Empty;
        }
    }
}