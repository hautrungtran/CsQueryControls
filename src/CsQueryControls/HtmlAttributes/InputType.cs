namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies the type input element to display
    /// </summary>
    public enum InputType {
        /// <summary>
        ///     Default. Defines a single-line text field (default width is 20 characters)
        /// </summary>
        Text,
        /// <summary>
        ///     Defines a clickable button (mostly used with a JavaScript to activate a script)
        /// </summary>
        Button,
        /// <summary>
        ///     Defines a checkbox
        /// </summary>
        CheckBox,
        /// <summary>
        ///     Defines a color picker
        /// </summary>
        Color,
        /// <summary>
        ///     Defines a date control (year, month and day (no time))
        /// </summary>
        Date,
        /// <summary>
        ///     Defines a date and time control (year, month, day, hour, minute, second, and fraction of a second, based on UTC
        ///     time zone)
        /// </summary>
        DateTime,
        /// <summary>
        ///     Defines a field for an e-mail address
        /// </summary>
        Email,
        /// <summary>
        ///     Defines a file-select field and a "Browse..." button (for file uploads)
        /// </summary>
        File,
        /// <summary>
        ///     Defines a hidden input field
        /// </summary>
        Hidden,
        /// <summary>
        ///     Defines an image as the submit button
        /// </summary>
        Image,
        /// <summary>
        ///     Defines a month and year control (no time zone)
        /// </summary>
        Month,
        /// <summary>
        ///     Defines a field for entering a number
        /// </summary>
        Number,
        /// <summary>
        ///     Defines a password field (characters are masked)
        /// </summary>
        Password,
        /// <summary>
        ///     Defines a radio button
        /// </summary>
        Radio,
        /// <summary>
        ///     Defines a control for entering a number whose exact value is not important (like a slider control)
        /// </summary>
        Range,
        /// <summary>
        ///     Defines a reset button (resets all form values to default values)
        /// </summary>
        Reset,
        /// <summary>
        ///     Defines a text field for entering a search string
        /// </summary>
        Search,
        /// <summary>
        ///     Defines a submit button
        /// </summary>
        Submit,
        /// <summary>
        ///     Defines a field for entering a telephone number
        /// </summary>
        Tel,
        /// <summary>
        ///     Defines a control for entering a time (no time zone)
        /// </summary>
        Time,
        /// <summary>
        ///     Defines a field for entering a URL
        /// </summary>
        Url,
        /// <summary>
        ///     Defines a week and year control (no time zone)
        /// </summary>
        Week
    }
}