using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Extension methods to add an <see cref="XElement"/> to each child element.
    /// </summary>
    [PublicAPI]
    public static class AddToAllXElementExtensions
    {
        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element.
        /// This method works on the existing <see cref="XElement"/> and returns a reference to it for a fluent syntax.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for child elements.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement AddToAll([NotNull] this XElement element, [NotNull] XName name, params object[] content)
        {
            foreach (XElement item in element.Elements())
            {
                item.Add(new XElement(name, content));
            }
            return element;
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element of each element in the <see cref="IEnumerable{XElement}"/>.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> AddToAll([NotNull] this IEnumerable<XElement> elements, [NotNull] XName name, params object[] content)
        {
            return elements.Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element of each element in the <see cref="ParallelQuery{XElement}"/>.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> AddToAll([NotNull] this ParallelQuery<XElement> elements, [NotNull] XName name, params object[] content)
        {
            return elements.Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to child elements that satisfy the predicate.
        /// This method works on the existing <see cref="XElement"/> and returns a reference to it for a fluent syntax.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for child elements.</param>
        /// <param name="predicate">If satisfied, the <see cref="XElement"/> is added.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="ArgumentNullException"/>
        [NotNull]
        public static XElement AddToAll([NotNull] this XElement element, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name, params object[] content)
        {
            foreach (XElement item in element.Elements().Where(predicate))
            {
                item.Add(new XElement(name, content));
            }
            return element;
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element of each element in the <see cref="IEnumerable{XElement}"/>.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements.</param>
        /// <param name="predicate">If satisfied, the <see cref="XElement"/> is added.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> AddToAll([NotNull] this IEnumerable<XElement> elements, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name, params object[] content)
        {
            return elements.Where(predicate).Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element of each element in the <see cref="ParallelQuery{XElement}"/>.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements.</param>
        /// <param name="predicate">If satisfied, the <see cref="XElement"/> is added.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>   
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> AddToAll([NotNull] this ParallelQuery<XElement> elements, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name, params object[] content)
        {
            return elements.Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }
    }
}
