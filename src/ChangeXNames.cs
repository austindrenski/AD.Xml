using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to change the names of XML elements.
    /// </summary>
    [PublicAPI]
    public static class ChangeXNamesExtensions
    {
        /// <summary>
        /// Changes the name of child elements with the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="oldName">The name of the child elements to be renamed.</param>
        /// <param name="newName">The name to which filtered child elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXNames(this XElement element, XName oldName, XName newName)
        {
            foreach (XElement item in element.Elements(oldName))
            {
                item.Name = newName;
            }
            return element;
        }

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        public static XElement ChangeXNames(this XElement element, Func<XElement, bool> predicate, XName name)
        {
            foreach (XElement item in element.Elements().Where(predicate))
            {
                item.Name = name;
            }
            return element;
        }

        /// <summary>
        /// Changes the name of child elements with the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="oldName">The name of the child elements to be renamed.</param>
        /// <param name="newName">The name to which filtered child elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXNames(this IEnumerable<XElement> elements, XName oldName, XName newName)
        {
            return elements.Select(x => x.ChangeXNames(oldName, newName));
        }

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static IEnumerable<XElement> ChangeXNames(this IEnumerable<XElement> elements, Func<XElement, bool> predicate, XName name)
        {
            return elements.Select(x => x.ChangeXNames(predicate, name));
        }

        /// <summary>
        /// Changes the name of child elements with the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="oldName">The name of the child elements to be renamed.</param>
        /// <param name="newName">The name to which filtered child elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXNames(this ParallelQuery<XElement> elements, XName oldName, XName newName)
        {
            return elements.Select(x => x.ChangeXNames(oldName, newName));
        }

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="IEnumerable{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        public static ParallelQuery<XElement> ChangeXNames(this ParallelQuery<XElement> elements, Func<XElement, bool> predicate, XName name)
        {
            return elements.Select(x => x.ChangeXNames(predicate, name));
        }
    }
}
