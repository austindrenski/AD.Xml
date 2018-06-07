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
        [NotNull]
        public static XElement ChangeXNames([NotNull] this XElement element, [NotNull] XName oldName, [NotNull] XName newName)
        {
            XElement[] children = element.Elements(oldName).ToArray();

            for (int i = 0; i < children.Length; i++)
            {
                children[i].Name = newName;
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
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXNames([NotNull] [ItemNotNull] this IEnumerable<XElement> elements, [NotNull] XName oldName, [NotNull] XName newName)
            => elements.Select(x => x.ChangeXNames(oldName, newName));

        /// <summary>
        /// Changes the name of child elements with the given name.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="oldName">The name of the child elements to be renamed.</param>
        /// <param name="newName">The name to which filtered child elements should be renamed.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXNames([NotNull] [ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] XName oldName, [NotNull] XName newName)
            => elements.Select(x => x.ChangeXNames(oldName, newName));

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="element">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        [NotNull]
        public static XElement ChangeXNames([NotNull] this XElement element, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name)
        {
            XElement[] children = element.Elements().Where(predicate).ToArray();

            for (int i = 0; i < children.Length; i++)
            {
                children[i].Name = name;
            }

            return element;
        }

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>An <see cref="IEnumerable{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static IEnumerable<XElement> ChangeXNames([NotNull] [ItemNotNull] this IEnumerable<XElement> elements, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name)
            => elements.Select(x => x.ChangeXNames(predicate, name));

        /// <summary>
        /// Changes the name of child elements that satisfy the predicate.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The element to search for child elements.</param>
        /// <param name="predicate">A filtering expression to find child elements in the <see cref="XElement"/>.</param>
        /// <param name="name">The name to which filtered elements should be renamed.</param>
        /// <returns>A <see cref="ParallelQuery{XElement}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        [ItemNotNull]
        [NotNull]
        [Pure]
        public static ParallelQuery<XElement> ChangeXNames([NotNull] [ItemNotNull] this ParallelQuery<XElement> elements, [NotNull] Func<XElement, bool> predicate, [NotNull] XName name)
            => elements.Select(x => x.ChangeXNames(predicate, name));
    }
}