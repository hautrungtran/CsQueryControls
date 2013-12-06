using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The select element is used to create a drop-down list.
    ///     The option tags inside the select element define the available options in the list.
    /// </summary>
    public class SelectElement : CommonElement {
        #region Property

        /// <summary>
        ///     Specifies that the drop-down list should automatically get focus when the page loads.
        /// </summary>
        /// <value>
        ///     autofocus
        /// </value>
        public virtual bool AutoFocus {
            get { return HasAttr("autofocus"); }
            set {
                if (value) {
                    Attr("autofocus", "autofocus");
                } else {
                    RemoveAttr("autofocus");
                }
            }
        }
        /// <summary>
        ///     Specifies that a drop-down list should be disabled.
        /// </summary>
        /// <value>
        ///     disabled
        /// </value>
        public virtual bool Disabled {
            get { return HasAttr("disabled"); }
            set {
                if (value) {
                    Attr("disabled", "disabled");
                } else {
                    RemoveAttr("disabled");
                }
            }
        }
        /// <summary>
        ///     Defines one or more forms the select field belongs to.
        /// </summary>
        /// <value>
        ///     form_id
        /// </value>
        public virtual string Form { get { return Attr("form"); } set { Attr("form", value); } }
        /// <summary>
        ///     Specifies that multiple options can be selected at once.
        /// </summary>
        /// <value>
        ///     multiple
        /// </value>
        public virtual bool Multiple {
            get { return HasAttr("multiple"); }
            set {
                if (value) {
                    Attr("multiple", "multiple");
                } else {
                    RemoveAttr("multiple");
                }
            }
        }
        /// <summary>
        ///     Defines a name for the drop-down list.
        /// </summary>
        /// <value>
        ///     name
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }
        /// <summary>
        ///     Specifies that the user is required to select a value before submitting the form.
        /// </summary>
        /// <value>
        ///     required
        /// </value>
        public virtual bool Required {
            get { return HasAttr("required"); }
            set {
                if (value) {
                    Attr("required", "required");
                } else {
                    RemoveAttr("required");
                }
            }
        }
        /// <summary>
        ///     Defines the number of visible options in a drop-down list.
        /// </summary>
        /// <value>
        ///     number
        /// </value>
        public virtual int? Size { get { return Attr<int?>("size"); } set { Attr("size", value); } }

        #endregion

        public SelectElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Select, parsingMode, parsingOptions, docType) {
        }
    }
}