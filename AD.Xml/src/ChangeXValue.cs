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
        [NotNull]
        public static XElement ChangeXValues([NotNull] this XElement element, [NotNull] XName name, string value)
        {
            IEnumerable<XElement> items = element.Elements(name).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value;
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
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>        
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, value));
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, value));
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
        [NotNull]
        public static XElement ChangeXValues([NotNull] this XElement element, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, string value)
        {
            IEnumerable<XElement> items = element.Elements(name).Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value;
            }
            return element;
        }
        
        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>        
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXValues([NotNull] this XElement element, [NotNull] Func<XElement, bool> predicate, string value)
        {
            IEnumerable<XElement> items = element.Elements().Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = value;
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>        
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(predicate, value));
        }

        /// <summary>
        /// Sets the value of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="value">The value to which filtered elements should be set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] Func<XElement, bool> predicate, string value)
        {
            return elements.Select(x => x.ChangeXValues(predicate, value));
        }
        
        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="valuePredicate">The value to which filtered elements should be set.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXValues([NotNull] this XElement element, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, [NotNull] Func<XElement, string> valuePredicate)
        {
            IEnumerable<XElement> items = element.Elements(name).Where(predicate).ToArray();
            foreach (XElement item in items)
            {
                item.Value = valuePredicate(item);
            }
            return element;
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="valuePredicate">The value to which filtered elements should be set.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>        
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXValues([NotNull][ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, Func<XElement, string> valuePredicate)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, valuePredicate));
        }

        /// <summary>
        /// Sets the value of child elements that have a specified name and satisfies the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The elements to search for child elements.</param>
        /// <param name="name">The name of the child elements to set equal to the value.</param>
        /// <param name="predicate">A predicate with which to test elements.</param>
        /// <param name="valuePredicate">The value to which filtered elements should be set.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXValues([NotNull][ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, [NotNull] Func<XElement, bool> predicate, Func<XElement, string> valuePredicate)
        {
            return elements.Select(x => x.ChangeXValues(name, predicate, valuePredicate));
        }
    }
}
