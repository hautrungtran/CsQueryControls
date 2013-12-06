using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The meter tag defines a scalar measurement within a known range, or a fractional value. This is also known as a gauge.
    /// </summary>
    public class MeterElement : CommonElement {
        #region Property

        /// <summary>
        /// Specifies one or more forms the meter element belongs to.
        /// </summary>
        /// <value>
        /// form_id
        /// </value>
        public virtual string Form {
            get { return Attr("form"); }
            set { Attr("form", value); }
        }
        /// <summary>
        /// Specifies the range that is considered to be a high value.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? High {
            get { return Attr<int?>("high"); }
            set { Attr("high", value); }
        }
        /// <summary>
        /// Specifies the range that is considered to be a low value.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Low {
            get { return Attr<int?>("low"); }
            set { Attr("low", value); }
        }
        /// <summary>
        /// Specifies the maximum value of the range.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Max {
            get { return Attr<int?>("max"); }
            set { Attr("max", value); }
        }
        /// <summary>
        /// Specifies the minimum value of the range.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Min {
            get { return Attr<int?>("min"); }
            set { Attr("min", value); }
        }
        /// <summary>
        /// Specifies what value is the optimal value for the gauge.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Optimum {
            get { return Attr<int?>("optimum"); }
            set { Attr("optimum", value); }
        }
        /// <summary>
        /// Required. Specifies the current value of the gauge.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int Value {
            get { return Attr<int>("value"); }
            set { Attr("value", value); }
        }

        #endregion

        public MeterElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Meter, parsingMode, parsingOptions, docType) {
        }
    }
}