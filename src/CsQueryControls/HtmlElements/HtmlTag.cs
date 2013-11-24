using System;

namespace CsQueryControls.HtmlElements {
    public enum HtmlTag {
        /// <summary>
        ///     The generic tag
        /// </summary>
        Generic,
        /// <summary>Defines a hyperlink</summary>
        A,
        /// <summary>Defines an abbreviation</summary>
        Abbr,
        /// <summary>Defines an acronym</summary>
        [Obsolete("Not supported in HTML5.")] Acronym,
        /// <summary>Defines contact information for the author/owner of a document</summary>
        Address,
        /// <summary>Deprecated in HTML 4.01. Defines an embedded applet</summary>
        [Obsolete("Not supported in HTML5.")] Applet,
        /// <summary>Defines an area inside an image-map</summary>
        Area,
        /// <summary>New Defines an article</summary>
        Article,
        /// <summary>New Defines content aside from the page content</summary>
        Aside,
        /// <summary>New Defines sound content</summary>
        Audio,
        /// <summary>Defines bold text</summary>
        B,
        /// <summary>Specifies the base URL/target for all relative URLs in a document</summary>
        Base,
        /// <summary>Deprecated in HTML 4.01. Specifies a default color, size, and font for all text in a document</summary>
        [Obsolete("Not supported in HTML5.")] Basefont,
        /// <summary>New Isolates a part of text that might be formatted in a different direction from other text outside it</summary>
        Bdi,
        /// <summary>Overrides the current text direction</summary>
        Bdo,
        /// <summary>Defines big text</summary>
        [Obsolete("Not supported in HTML5.")] Big,
        /// <summary>Defines a section that is quoted from another source</summary>
        Blockquote,
        /// <summary>Defines the document's body</summary>
        Body,
        /// <summary>Defines a single line break</summary>
        Br,
        /// <summary>Defines a clickable button</summary>
        Button,
        /// <summary>New Used to draw graphics, on the fly, via scripting (usually JavaScript)</summary>
        Canvas,
        /// <summary>Defines a table caption</summary>
        Caption,
        /// <summary>Deprecated in HTML 4.01. Defines centered text</summary>
        [Obsolete("Not supported in HTML5.")] Center,
        /// <summary>Defines the title of a work</summary>
        Cite,
        /// <summary>Defines a piece of computer code</summary>
        Code,
        /// <summary>Specifies column properties for each column within a colgroup element</summary>
        Col,
        /// <summary>Specifies a group of one or more columns in a table for formatting</summary>
        Colgroup,
        /// <summary>New Defines a command button that a user can invoke</summary>
        Command,
        /// <summary>New Specifies a list of pre-defined options for input controls</summary>
        Datalist,
        /// <summary>Defines a description/value of a term in a description list</summary>
        Dd,
        /// <summary>Defines text that has been deleted from a document</summary>
        Del,
        /// <summary>New Defines additional details that the user can view or hide</summary>
        Details,
        /// <summary>Defines a definition term</summary>
        Dfn,
        /// <summary>New Defines a dialog box or window</summary>
        Dialog,
        /// <summary>Deprecated in HTML 4.01. Defines a directory list</summary>
        [Obsolete("Not supported in HTML5.")] Dir,
        /// <summary>Defines a section in a document</summary>
        Div,
        /// <summary>Defines a description list</summary>
        Dl,
        /// <summary>Defines a term/name in a description list</summary>
        Dt,
        /// <summary>Defines emphasized text</summary>
        Em,
        /// <summary>New Defines a container for an external (non-HTML) application</summary>
        Embed,
        /// <summary>Groups related elements in a form</summary>
        Fieldset,
        /// <summary>New Defines a caption for a figure element</summary>
        Figcaption,
        /// <summary>New Specifies self-contained content</summary>
        Figure,
        /// <summary>Deprecated in HTML 4.01. Defines font, color, and size for text</summary>
        [Obsolete("Not supported in HTML5.")] Font,
        /// <summary>New Defines a footer for a document or section</summary>
        Footer,
        /// <summary>Defines an HTML form for user input</summary>
        Form,
        /// <summary>Defines a window (a frame) in a frameset</summary>
        [Obsolete("Not supported in HTML5.")] Frame,
        /// <summary>Defines a set of frames</summary>
        [Obsolete("Not supported in HTML5.")] Frameset,
        /// <summary>Defines HTML headings </summary>
        H1,
        /// <summary>Defines HTML headings </summary>
        H2,
        /// <summary>Defines HTML headings </summary>
        H3,
        /// <summary>Defines HTML headings </summary>
        H4,
        /// <summary>Defines HTML headings </summary>
        H5,
        /// <summary>Defines HTML headings </summary>
        H6,
        /// <summary>Defines information about the document</summary>
        Head,
        /// <summary>New Defines a header for a document or section</summary>
        Header,
        /// <summary>Defines a thematic change in the content</summary>
        Hr,
        /// <summary>Defines the root of an HTML document</summary>
        Html,
        /// <summary>Defines a part of text in an alternate voice or mood</summary>
        I,
        /// <summary>Defines an inline frame</summary>
        Iframe,
        /// <summary>Defines an image</summary>
        Img,
        /// <summary>Defines an input control</summary>
        Input,
        /// <summary>Defines a text that has been inserted into a document</summary>
        Ins,
        /// <summary>Defines keyboard input</summary>
        Kbd,
        /// <summary>New Defines a key-pair generator field (for forms)</summary>
        Keygen,
        /// <summary>Defines a label for an input element</summary>
        Label,
        /// <summary>Defines a caption for a fieldset element</summary>
        Legend,
        /// <summary>Defines a list item</summary>
        Li,
        /// <summary>Defines the relationship between a document and an external resource (most used to link to style sheets)</summary>
        Link,
        /// <summary>Defines a client-side image-map</summary>
        Map,
        /// <summary>New Defines marked/highlighted text</summary>
        Mark,
        /// <summary>Defines a list/menu of commands</summary>
        Menu,
        /// <summary>Defines metadata about an HTML document</summary>
        Meta,
        /// <summary>New Defines a scalar measurement within a known range (a gauge)</summary>
        Meter,
        /// <summary>New Defines navigation links</summary>
        Nav,
        /// <summary>Defines an alternate content for users that do not support frames</summary>
        [Obsolete("Not supported in HTML5.")] Noframes,
        /// <summary>Defines an alternate content for users that do not support client-side scripts</summary>
        Noscript,
        /// <summary>Defines an embedded object</summary>
        Object,
        /// <summary>Defines an ordered list</summary>
        Ol,
        /// <summary>Defines a group of related options in a drop-down list</summary>
        Optgroup,
        /// <summary>Defines an option in a drop-down list</summary>
        Option,
        /// <summary>New Defines the result of a calculation</summary>
        Output,
        /// <summary>Defines a paragraph</summary>
        P,
        /// <summary>Defines a parameter for an object</summary>
        Param,
        /// <summary>Defines preformatted text</summary>
        Pre,
        /// <summary>New Represents the progress of a task</summary>
        Progress,
        /// <summary>Defines a short quotation</summary>
        Q,
        /// <summary>New Defines what to show in browsers that do not support ruby annotations</summary>
        Rp,
        /// <summary>New Defines an explanation/pronunciation of characters (for East Asian typography)</summary>
        Rt,
        /// <summary>New Defines a ruby annotation (for East Asian typography)</summary>
        Ruby,
        /// <summary>Defines text that is no longer correct</summary>
        S,
        /// <summary>Defines sample output from a computer program</summary>
        Samp,
        /// <summary>Defines a client-side script</summary>
        Script,
        /// <summary>New Defines a section in a document</summary>
        Section,
        /// <summary>Defines a drop-down list</summary>
        Select,
        /// <summary>Defines smaller text</summary>
        Small,
        /// <summary>New Defines multiple media resources for media elements (video and audio)</summary>
        Source,
        /// <summary>Defines a section in a document</summary>
        Span,
        /// <summary>Deprecated in HTML 4.01. Defines strikethrough text</summary>
        [Obsolete("Not supported in HTML5.")] Strike,
        /// <summary>Defines important text</summary>
        Strong,
        /// <summary>Defines style information for a document</summary>
        Style,
        /// <summary>Defines subscripted text</summary>
        Sub,
        /// <summary>New Defines a visible heading for a details element</summary>
        Summary,
        /// <summary>Defines superscripted text</summary>
        Sup,
        /// <summary>Defines a table</summary>
        Table,
        /// <summary>Groups the body content in a table</summary>
        Tbody,
        /// <summary>Defines a cell in a table</summary>
        Td,
        /// <summary>Defines a multiline input control (text area)</summary>
        Textarea,
        /// <summary>Groups the footer content in a table</summary>
        Tfoot,
        /// <summary>Defines a header cell in a table</summary>
        Th,
        /// <summary>Groups the header content in a table</summary>
        Thead,
        /// <summary>New Defines a date/time</summary>
        Time,
        /// <summary>Defines a title for the document</summary>
        Title,
        /// <summary>Defines a row in a table</summary>
        Tr,
        /// <summary>New Defines text tracks for media elements (video and audio)</summary>
        Track,
        /// <summary>Defines teletype text</summary>
        [Obsolete("Not supported in HTML5.")] Tt,
        /// <summary>Defines text that should be stylistically different from normal text</summary>
        U,
        /// <summary>Defines an unordered list</summary>
        Ul,
        /// <summary>Defines a variable</summary>
        Var,
        /// <summary>New Defines a video or movie</summary>
        Video,
        /// <summary>New Defines a possible line-break</summary>
        Wbr
    }
}