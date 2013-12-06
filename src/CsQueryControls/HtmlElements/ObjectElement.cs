using System;
using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    /// The object tag defines an embedded object within an HTML document.
    /// Use this element to embed multimedia (like audio, video, Java applets, ActiveX, PDF, and Flash) in your web pages.
    /// You can also use the object tag to embed another webpage into your HTML document.
    /// You can use the param tag to pass parameters to plugins that have been embedded with the object tag.
    /// </summary>
    public class ObjectElement : CommonElement {
        #region Property

        /// <summary>
        ///  Specifies the alignment of the object element according to surrounding elements.
        /// </summary>
        /// <value>
        /// top|bottom|middle|left|right
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public virtual string Align {
            get { return Attr("align"); }
            set { Attr("align", value); }
        }
        /// <summary>
        /// A space separated list of URL's to archives. The archives contains resources relevant to the object.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Archive {
            get { return Attr("archive"); }
            set { Attr("archive", value); }
        }
        /// <summary>
        /// Specifies the width of the border around an object.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public virtual int? Border {
            get { return Attr<int?>("border"); }
            set { Attr("border", value); }
        }
        /// <summary>
        /// Defines a class ID value as set in the Windows Registry or a URL.
        /// </summary>
        /// <value>
        /// class_ID
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string ClassId {
            get { return Attr("classid"); }
            set { Attr("classid", value); }
        }
        /// <summary>
        /// Defines where to find the code for the object.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string CodeBase {
            get { return Attr("codebase"); }
            set { Attr("codebase", value); }
        }
        /// <summary>
        /// The internet media type of the code referred to by the classid attribute.
        /// </summary>
        /// <value>
        /// MIME_type
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string CodeType {
            get { return Attr("codetype"); }
            set { Attr("codetype", value); }
        }
        /// <summary>
        /// Specifies the URL of the resource to be used by the object.
        /// </summary>
        /// <value>
        /// URL
        /// </value>
        public virtual string InnerData {
            get { return Attr("data"); }
            set { Attr("data", value); }
        }
        /// <summary>
        /// Defines that the object should only be declared, not created or instantiated until needed.
        /// </summary>
        /// <value>
        /// declare
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Declare {
            get { return Attr("declare"); }
            set { Attr("declare", value); }
        }
        /// <summary>
        /// Specifies one or more forms the object belongs to.
        /// </summary>
        /// <value>
        /// form_id
        /// </value>
        public virtual string Form {
            get { return Attr("form"); }
            set { Attr("form", value); }
        }
        /// <summary>
        /// Specifies the height of the object.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        public virtual int? InnerHeight {
            get { return Attr<int?>("height"); }
            set { Attr("height", value); }
        }
        /// <summary>
        /// Specifies the whitespace on left and right side of an object.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public virtual int? HSpace {
            get { return Attr<int?>("hspace"); }
            set { Attr("hspace", value); }
        }
        
        /// <summary>
        /// Specifies a name for the object.
        /// </summary>
        /// <value>
        /// name
        /// </value>
        public virtual string Name {
            get { return Attr("name"); }
            set { Attr("name", value); }
        }
        /// <summary>
        /// Defines a text to display while the object is loading.
        /// </summary>
        /// <value>
        /// text
        /// </value>
        [Obsolete("Not supported in HTML5.")]
        public virtual string Standby {
            get { return Attr("standby"); }
            set { Attr("standby", value); }
        }
        /// <summary>
        /// Specifies the MIME type of data specified in the data attribute.
        /// </summary>
        /// <value>
        /// MIME_type
        /// </value>
        public virtual string Type {
            get { return Attr("type"); }
            set { Attr("type", value); }
        }
        /// <summary>
        /// Specifies the name of a client-side image map to be used with the object.
        /// </summary>
        /// <value>
        /// #mapname
        /// </value>
        public virtual string Usemap {
            get { return Attr("usemap"); }
            set { Attr("usemap", value); }
        }
        /// <summary>
        /// Specifies the whitespace on top and bottom of an object.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        [Obsolete("Not supported in HTML5. Deprecated in HTML 4.01.")]
        public virtual int? VSpace {
            get { return Attr<int?>("vspace"); }
            set { Attr("vspace", value); }
        }
        /// <summary>
        /// Specifies the width of the object.
        /// </summary>
        /// <value>
        /// pixels
        /// </value>
        public virtual int? InnerWidth {
            get { return Attr<int?>("width"); }
            set { Attr("width", value); }
        }

        #endregion

        public ObjectElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Audio, parsingMode, parsingOptions, docType) {
        }
    }
}