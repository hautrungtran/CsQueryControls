using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CsQuery;
using CsQueryControls.HtmlElements;

namespace CsQueryControls {
    public class DropdownList : SelectElement {
        private ObservableCollection<ListItem> _items;
        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public ObservableCollection<ListItem> Items {
            get { return _items ?? (_items = new ObservableCollection<ListItem>()); }
            set {
                _items = value;
                Refresh();
            }
        }
        public DropdownList(HtmlParsingMode parsingMode = HtmlParsingMode.Auto, HtmlParsingOptions parsingOptions = HtmlParsingOptions.Default, DocType docType = DocType.Default)
            : base(parsingMode, parsingOptions, docType) {
            Items.CollectionChanged += (sender, e) => Refresh();
        }
        /// <summary>
        ///     Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        public DropdownList Refresh() {
            Empty();
            if (Items != null) {
                foreach (var item in Items) {
                    Append(item);
                }
            }
            return this;
        }
        /// <summary>
        ///     Binds the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDisplay">The type of the display.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="valueSelector">The value selector.</param>
        /// <param name="displaySelector">The display selector.</param>
        /// <param name="selectedValues">The selected values.</param>
        /// <returns></returns>
        public DropdownList Bind<T, TDisplay, TValue>(IEnumerable<T> items, Func<T, TValue> valueSelector, Func<T, TDisplay> displaySelector, params object[] selectedValues) {
            Items.Clear();
            foreach (T item in items) {
                TValue value = valueSelector(item);
                Items.Add(new ListItem {
                    Value = value.ToString(),
                    InnerText = displaySelector(item).ToString(),
                    Selected = selectedValues != null && selectedValues.Any(selected => selected.Equals(value))
                });
            }
            return this;
        }
    }
}