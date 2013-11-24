using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The progress tag represents the progress of a task. 
    /// </summary>
    public class ProcessElement : ElementBase {
        #region Property

        /// <summary>
        /// Specifies how much work the task requires in total.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Max {
            get { return Attr<int?>("max"); }
            set { Attr("max", value); }
        }
        /// <summary>
        /// Specifies how much of the task has been completed.
        /// </summary>
        /// <value>
        /// number
        /// </value>
        public virtual int? Value {
            get { return Attr<int?>("value"); }
            set { Attr("value", value); }
        }

        #endregion

        public ProcessElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Progress, parsingMode, parsingOptions, docType) {
        }
    }
}