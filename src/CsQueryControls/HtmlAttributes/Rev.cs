using System;

namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    ///     Specifies the relationship between the linked document and the current document
    /// </summary>
    [Obsolete("Not supported in HTML5.")]
    public enum Rev {
        /// <summary>
        ///     An alternate version of the document (i.e. print page, translated or mirror)
        /// </summary>
        Alternate,
        /// <summary>
        ///     An external style sheet for the document
        /// </summary>
        StyleSheet,
        /// <summary>
        ///     The first document in a selection
        /// </summary>
        Start,
        /// <summary>
        ///     The next document in a selection
        /// </summary>
        Next,
        /// <summary>
        ///     The previous document in a selection
        /// </summary>
        Prev,
        /// <summary>
        ///     A table of contents for the document
        /// </summary>
        Contents,
        /// <summary>
        ///     An index for the document
        /// </summary>
        Index,
        /// <summary>
        ///     A glossary (explanation) of words used in the document
        /// </summary>
        Glossary,
        /// <summary>
        ///     A document containing copyright information
        /// </summary>
        Copyright,
        /// <summary>
        ///     A chapter of the document
        /// </summary>
        Chapter,
        /// <summary>
        ///     A section of the document
        /// </summary>
        Section,
        /// <summary>
        ///     A subsection of the document
        /// </summary>
        SubSection,
        /// <summary>
        ///     An appendix for the document
        /// </summary>
        Appendix,
        /// <summary>
        ///     A help document
        /// </summary>
        Help,
        /// <summary>
        ///     A related document
        /// </summary>
        Bookmark,
        /// <summary>
        ///     "nofollow" is used by Google, to specify that the Google search spider should not follow that link (mostly used for
        ///     paid links)
        /// </summary>
        Nofollow,
        /// <summary>
        ///     The licence
        /// </summary>
        Licence,
        /// <summary>
        ///     The tag
        /// </summary>
        Tag,
        /// <summary>
        ///     The friend
        /// </summary>
        Friend
    }
}