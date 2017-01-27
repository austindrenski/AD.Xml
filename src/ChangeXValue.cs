using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to modify the values of XML elements.
    /// </summary>
    [PublicAPI]
    public static class ChangeXValuesExtensions
    {
        /// <summary>
        /// Sets the value of child elements that have a specified name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXValues(this XElement element, XName name, string value)
        {
            IEnumerable<XElement> items = element.Elements(name).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value;
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="newValue">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXValues(this XElement element, XName name, Func<XElement, bool> predicate, string newValue)
        {
            IEnumerable<XElement> items = element.Elements(name).Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = newValue;
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXValues(this XElement element, Func<XElement, bool> predicate, string value)
        {
            IEnumerable<XElement> items = element.Elements().Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value;
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXValues(this XElement element, XName name, Func<XElement, bool> predicate, Func<XElement, string> value)
        {
            IEnumerable<XElement> items = element.Elements(name).Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value(item);
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXValues(this IEnumerable<XElement> elements, XName name, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, value));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="newValue">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXValues(this IEnumerable<XElement> elements, XName name, Func<XElement, bool> predicate, string newValue)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, newValue));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXValues(this IEnumerable<XElement> elements, Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXValues(this IEnumerable<XElement> elements, XName name, Func<XElement, bool> predicate, Func<XElement, string> value)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXValues(this ParallelQuery<XElement> elements, XName name, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, value));
        }


        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="newValue">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXValues(this ParallelQuery<XElement> elements, XName name, Func<XElement, bool> predicate, string newValue)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, newValue));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXValues(this ParallelQuery<XElement> elements, Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXValues(this ParallelQuery<XElement> elements, XName name, Func<XElement, bool> predicate, Func<XElement, string> value)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, value));
        }
    }
}
