using System;
using CsQuery;

namespace CsQueryControls.Components {
    public class GridColumn : TableCell {
        public string Name {
            get {
                return Attr("data-column-name");
            }
            set {
                Attr("data-column-name", value);
            }
        }
        public bool Sortable {
            get {
                return Attr<bool>("data-sortable");
            }
            set {
                Attr("data-sortable", ToLowerString(value));
            }
        }
        public ColumnType Type {
            get {
                return (ColumnType)Enum.Parse(typeof(ColumnType), Attr("data-column-type"));
            }
            set {
                Attr("data-column-type", ToLowerString(value));
            }
        }
        public GridColumn(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(true, parsingMode, parsingOptions, docType) {
            Sortable = true;
        }
    }
    public enum ColumnType {
        Text,
        Html,
        Link,
        Image,
        Checkbox,
        Dropdown
    }
}