using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to remove XML elements.
    /// </summary>
    [PublicAPI]
    public static class RemoveByExtensions
    {
        /// <summary>
        /// Removes elements from the <see cref="XElement"/> that have the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="name">The name of the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement RemoveBy(this XElement element, XName name)
        {
            element.Elements(name).Remove();
            return element;
        }

        /// <summary>
        /// Removes elements from the <see cref="XElement"/> that satisify the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> to search for children with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from the <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement RemoveBy(this XElement element, Func<XElement, bool> predicate)
        {
            element.Elements().Where(predicate).Remove();
            return element;
        }

        /// <summary>
        /// Removes elements from the <see cref="IEnumerable{XElement}"/> that have the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="name">The name of the child elements to be removed from the <see cref="IEnumerable{XElement}"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> RemoveBy(this IEnumerable<XElement> elements, XName name)
        {
            return elements.Select(x => x.RemoveBy(name));
        }

        /// <summary>
        /// Removes elements from the <see cref="IEnumerable{XElement}"/> that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from each <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> RemoveBy(this IEnumerable<XElement> elements, Func<XElement, bool> predicate)
        {
            return elements.Select(x => x.RemoveBy(predicate));
        }

        /// <summary>
        /// Removes elements from the <see cref="ParallelQuery{XElement}"/> that have the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="name">The name of the child elements to be removed from the <see cref="ParallelQuery{XElement}"/>.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> RemoveBy(this ParallelQuery<XElement> elements, XName name)
        {
            return elements.Select(x => x.RemoveBy(name));
        }

        /// <summary>
        /// Removes elements from the <see cref="ParallelQuery{XElement}"/> that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="ParallelQuery{XElement}"/> to search for child elements with the given name.</param>
        /// <param name="predicate">The predicate that is satisfied by the elements to be removed from each <see cref="XElement"/>.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> RemoveBy(this ParallelQuery<XElement> elements, Func<XElement, bool> predicate)
        {
            return elements.Select(x => x.RemoveBy(predicate));
        }
    }
}
