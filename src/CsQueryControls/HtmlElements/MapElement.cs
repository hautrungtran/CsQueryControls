using CsQuery;

namespace CsQueryControls.HtmlElements {
    /// <summary>
    ///     The map tag is used to define a client-side image-map.
    ///     An image-map is an image with clickable areas.
    ///     The required name attribute of the map element is associated with the img's usemap attribute and creates a
    ///     relationship between the image and the map.
    ///     The map element contains a number of area elements, that defines the clickable areas in the image map.
    /// </summary>
    public class MapElement : ElementBase {
        #region Property

        /// <summary>
        ///     Required. Specifies the name of an image-map.
        /// </summary>
        /// <value>
        ///     mapname
        /// </value>
        public virtual string Name { get { return Attr("name"); } set { Attr("name", value); } }

        #endregion

        public MapElement(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(HtmlTag.Map, parsingMode, parsingOptions, docType) {
        }
    }
}