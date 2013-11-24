using System.Web;
using CsQuery;

namespace CsQueryControls.Components {
    public class Combobox : DropdownList {
        public Combobox(string name, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
            Attr("data-toggle", "select");
            Id = name;
            Name = name;
        }
        /// <summary>
        ///     Specifies that the user is required to select a value before submitting the form.
        /// </summary>
        /// <value>
        ///     required
        /// </value>
        public new bool? Required { get { return Attr<bool?>("data-required"); } set { Attr("data-required", ToLowerString(value)); } }
        /// <summary>
        ///     Gets or sets the minimum length of the input.
        /// </summary>
        /// <value>
        ///     The minimum length of the input.
        /// </value>
        public int? MinimumInputLength { get { return Attr<int?>("data-minimum-input-length"); } set { Attr("data-minimum-input-length", value); } }
        /// <summary>
        ///     Gets or sets the placeholder.
        /// </summary>
        /// <value>
        ///     The placeholder.
        /// </value>
        public string Placeholder { get { return Attr("data-placeholder"); } set { Attr("data-placeholder", value); } }
        /// <summary>
        ///     Renders the HTML.
        /// </summary>
        /// <returns></returns>
        public new IHtmlString RenderHtml() {
            if (!string.IsNullOrEmpty(Placeholder) && Required != true) {
                Append("<option>");
            }
            return base.RenderHtml();
        }
    }
}