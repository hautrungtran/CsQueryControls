namespace CsQueryControls.HtmlAttributes {
    /// <summary>
    /// Specifies the kind of text track
    /// </summary>
    public enum Kind {
        /// <summary>
        /// The track defines translation of dialogue and sound effects (suitable for deaf users)
        /// </summary>
        Captions,
        /// <summary>
        /// The track defines chapter titles (suitable for navigating the media resource)
        /// </summary>
        Chapters,
        /// <summary>
        /// The track defines a textual description of the video content (suitable for blind users)
        /// </summary>
        Descriptions,
        /// <summary>
        /// The track defines content used by scripts. Not visible for the user
        /// </summary>
        Metadata,
        /// <summary>
        /// The track defines subtitles, used to display subtitles in a video
        /// </summary>
        Subtitles,
    }
}