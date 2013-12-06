using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The time tag defines either a time (24 hour clock), or a date in the Gregorian calendar, optionally with a time and a time-zone offset.
    /// This element can be used as a way to encode dates and times in a machine-readable way so that, for example, user agents can offer to add birthday reminders or scheduled events to the user's calendar, and search engines can produce smarter search results.
    /// </summary>
    public class TimeElement : CommonElement {
        #region Property

        /// <summary>
        /// Gives the date/time being specified. Otherwise, the date/time is given by the element's contents.
        /// </summary>
        /// <value>
        /// datetime
        /// </value>
        public virtual string DateTime { get { return Attr("datetime"); } set { Attr("datetime", value); } }

        #endregion

        public TimeElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Time, parsingMode, parsingOptions, docType) {
        }
    }
}