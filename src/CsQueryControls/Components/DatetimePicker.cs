using System;
using System.Globalization;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Components {
    public class DatetimePicker : ElementBase {
        #region Property

        private readonly ElementBase _addon;
        private readonly Button _button;
        private readonly TextBox _displayInput;
        private readonly ElementBase _icon;
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
        ///     Gets or sets the format.
        /// </summary>
        /// <value>
        ///     The format.
        /// </value>
        public string Format {
            get { return Attr("data-format"); }
            set {
                DateTime? startDate = StartDate;
                DateTime? endDate = EndDate;
                Attr("data-format", value);
                StartDate = startDate;
                EndDate = endDate;
            }
        }
        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        public DateTime? StartDate {
            get {
                string result = Attr("data-start-date");
                return string.IsNullOrEmpty(result) ? (DateTime?) null : DateTime.ParseExact(result, Format, Language);
            }
            set { Attr("data-start-date", value.HasValue ? value.Value.ToString(Format) : ToLowerString(false)); }
        }
        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>
        ///     The end date.
        /// </value>
        public DateTime? EndDate {
            get {
                string result = Attr("data-end-date");
                return string.IsNullOrEmpty(result) ? (DateTime?) null : DateTime.ParseExact(result, Format, Language);
            }
            set { Attr("data-end-date", value.HasValue ? value.Value.ToString(Format) : ToLowerString(false)); }
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
        ///     Gets or sets the mode.
        /// </summary>
        /// <value>
        ///     The mode.
        /// </value>
        public DateTimePickerMode? Mode {
            get {
                var pickDate = Attr<bool?>("data-pick-date");
                var pickTime = Attr<bool?>("data-pick-time");
                if (pickDate == true && pickTime == true) {
                    return DateTimePickerMode.DateTime;
                }
                if (pickDate == true) {
                    return DateTimePickerMode.Date;
                }
                if (pickTime == true) {
                    return DateTimePickerMode.Time;
                }
                return null;
            }
            set {
                switch (value) {
                    case DateTimePickerMode.DateTime:
                        Attr("data-pick-date", "true");
                        Attr("data-pick-time", "true");
                        break;
                    case DateTimePickerMode.Date:
                        Attr("data-pick-date", "true");
                        Attr("data-pick-time", "false");
                        break;
                    case DateTimePickerMode.Time:
                        Attr("data-pick-date", "false");
                        Attr("data-pick-time", "true");
                        break;
                    default:
                        RemoveAttr("data-pick-date");
                        RemoveAttr("data-pick-time");
                        break;
                }
            }
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
        public ElementBase Addon {
            get { return _addon; }
        }

        /// <summary>
        ///     Gets the icon.
        /// </summary>
        /// <value>
        ///     The icon.
        /// </value>
        public ElementBase Icon {
            get { return _icon; }
        }

        /// <summary>
        ///     Gets the button.
        /// </summary>
        /// <value>
        ///     The button.
        /// </value>
        public Button Button {
            get { return _button; }
        }

        #endregion

        public DatetimePicker(string name, DatetimePickerTheme theme = null, HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default,
            DocType docType = DocType.Default)
            : base(HtmlTag.Div, parsingMode, parsingOptions, docType) {
            if (theme == null) {
                theme = DefaultTheme;
            }
            Target = name.StartsWith("#") ? name : "#" + name;
            Attr("data-toggle", "datetime");
            AddClass(theme.Wrapper);
            _displayInput = new TextBox();
            Append(_displayInput.AddClass(theme.Input));
            _valueInput = new HiddenField {Name = name, Id = name};
            Append(_valueInput);

            _button = new Button();
            _icon = new ElementBase(HtmlTag.I);
            _button.AddClass(theme.Button).Append(_icon.AddClass(theme.Icon));

            _addon = new ElementBase(HtmlTag.Span);
            _addon.AddClass(theme.Addon).Append(_button);
            Append(_addon);
        }
        public static DatetimePickerTheme DefaultTheme {
            get {
                return new DatetimePickerTheme {
                    Input = "form-control",
                    Icon = "glyphicon glyphicon-calendar",
                    Button = "btn btn-default",
                    Addon = "input-group-btn",
                    Wrapper = "input-group date",
                };
            }
        }
    }

    public class DatetimePickerTheme {
        public string Input { get; set; }
        public string Icon { get; set; }
        public string Button { get; set; }
        public string Addon { get; set; }
        public string Wrapper { get; set; }
    }

    public enum DateTimePickerMode {
        DateTime,
        Date,
        Time
    }
}