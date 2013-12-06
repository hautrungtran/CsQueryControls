using System.Globalization;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Components {
    public class NumericTextbox : CommonElement {
        #region Property

        private readonly CommonElement _addon;
        private readonly Button _decreaseButton;
        private readonly CommonElement _decreaseIcon;
        private readonly TextBox _displayInput;
        private readonly Button _increaseButton;
        private readonly CommonElement _increaseIcon;
        private readonly HiddenField _valueInput;
        /// <summary>
        ///     Gets the target.
        /// </summary>
        /// <value>
        ///     The target.
        /// </value>
        public string Target {
            get { return Attr("data-target"); }
            private set { Attr("data-target", value); }
        }
        /// <summary>
        ///     Gets or sets the required.
        /// </summary>
        /// <value>
        ///     The required.
        /// </value>
        public bool? Required {
            get { return Attr<bool?>("data-required"); }
            set { Attr("data-required", ToLowerString(value)); }
        }
        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public decimal? Min {
            get { return Attr<decimal?>("data-min"); }
            set { Attr("data-min", value); }
        }
        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public decimal? Max {
            get { return Attr<decimal?>("data-max"); }
            set { Attr("data-max", value); }
        }
        /// <summary>
        ///     Gets or sets the round.
        /// </summary>
        /// <value>
        ///     The round.
        /// </value>
        public int? Round {
            get { return Attr<int?>("data-round"); }
            set { Attr("data-round", value); }
        }
        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        /// <value>
        ///     The language.
        /// </value>
        public CultureInfo Language {
            get {
                string key = Attr("data-language");
                return string.IsNullOrEmpty(key) ? null : new CultureInfo(key);
            }
            set {
                if (value == null || value.TwoLetterISOLanguageName == CultureInfo.InvariantCulture.TwoLetterISOLanguageName) {
                    RemoveAttr("data-language");
                } else {
                    Attr("data-language", value.TwoLetterISOLanguageName);
                }
            }
        }
        /// <summary>
        ///     Gets or sets the step.
        /// </summary>
        /// <value>
        ///     The step.
        /// </value>
        public decimal? Step {
            get { return Attr<decimal?>("data-step"); }
            set { Attr("data-step", value); }
        }

        /// <summary>
        ///     Gets the display input.
        /// </summary>
        /// <value>
        ///     The display input.
        /// </value>
        public TextBox DisplayInput {
            get { return _displayInput; }
        }

        /// <summary>
        ///     Gets the value input.
        /// </summary>
        /// <value>
        ///     The value input.
        /// </value>
        public HiddenField ValueInput {
            get { return _valueInput; }
        }

        /// <summary>
        ///     Gets the addon.
        /// </summary>
        /// <value>
        ///     The addon.
        /// </value>
        public CommonElement Addon {
            get { return _addon; }
        }

        /// <summary>
        ///     Gets the increase icon.
        /// </summary>
        /// <value>
        ///     The increase icon.
        /// </value>
        public CommonElement IncreaseIcon {
            get { return _increaseIcon; }
        }

        /// <summary>
        ///     Gets the increase button.
        /// </summary>
        /// <value>
        ///     The increase button.
        /// </value>
        public Button IncreaseButton {
            get { return _increaseButton; }
        }

        /// <summary>
        ///     Gets the decrease icon.
        /// </summary>
        /// <value>
        ///     The decrease icon.
        /// </value>
        public CommonElement DecreaseIcon {
            get { return _decreaseIcon; }
        }

        /// <summary>
        ///     Gets the decrease button.
        /// </summary>
        /// <value>
        ///     The decrease button.
        /// </value>
        public Button DecreaseButton {
            get { return _decreaseButton; }
        }

        #endregion

        public NumericTextbox(string name, NumericTheme theme = null, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default,
            DocType docType = DocType.Default)
            : base(HtmlTag.Div, parsingMode, parsingOptions, docType) {
            if (theme == null) {
                theme = DefaultTheme;
            }
            Target = name.StartsWith("#") ? name : "#" + name;
            Attr("data-toggle", "numeric");
            AddClass(theme.Wrapper);
            _displayInput = new TextBox();
            Append(_displayInput.AddClass(theme.Input));
            _valueInput = new HiddenField {Name = name, Id = name};
            Append(_valueInput);

            _increaseButton = new Button();
            _increaseIcon = new CommonElement(HtmlTag.I);
            _increaseButton.AddClass(theme.IncreaseButton).Append(_increaseIcon.AddClass(theme.IncreaseIcon));

            _decreaseButton = new Button();
            _decreaseIcon = new CommonElement(HtmlTag.I);
            _decreaseButton.AddClass(theme.DecreaseButton).Append(_decreaseIcon.AddClass(theme.DecreaseIcon));

            _addon = new CommonElement(HtmlTag.Span);
            _addon.AddClass(theme.Addon).Append(_increaseButton).Append(_decreaseButton);
            Append(_addon);
        }
        public static NumericTheme DefaultTheme {
            get {
                return new NumericTheme {
                    Input = "form-control",
                    IncreaseIcon = "glyphicon glyphicon-chevron-up",
                    IncreaseButton = "btn btn-default btn-increase",
                    DecreaseIcon = "glyphicon glyphicon-chevron-down",
                    DecreaseButton = "btn btn-default btn-decrease",
                    Addon = "input-group-btn",
                    Wrapper = "input-group numeric",
                };
            }
        }
    }

    public class NumericTheme {
        public string Input { get; set; }
        public string IncreaseIcon { get; set; }
        public string IncreaseButton { get; set; }
        public string DecreaseIcon { get; set; }
        public string DecreaseButton { get; set; }
        public string Addon { get; set; }
        public string Wrapper { get; set; }
    }
}