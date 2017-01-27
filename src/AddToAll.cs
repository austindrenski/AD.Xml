using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
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
        public static XElement AddToAll(this XElement element, XName name, params object[] content)
        {
            foreach (XElement item in element.Elements())
            {
                item.Add(new XElement(name, content));
            }
            return element;
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
        public static XElement AddToAll(this XElement element, Func<XElement, bool> predicate, XName name, params object[] content)
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
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<XElement> AddToAll(this IEnumerable<XElement> elements, XName name, params object[] content)
        {
            return elements.Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }

        /// <summary>
        /// Adds an <see cref="XElement"/> with the given name and content to each child element of each element in the <see cref="IEnumerable{XElement}"/>.
        /// This method works on the existing enumerable, but returns a reference to the enumerable for a fluent syntax.
        /// </summary>
        /// <param name="elements">The <see cref="IEnumerable{XElement}"/> to search for child elements.</param>
        /// <param name="predicate">If satisfied, the <see cref="XElement"/> is added.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="XElement"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<XElement> AddToAll(this IEnumerable<XElement> elements, Func<XElement, bool> predicate, XName name, params object[] content)
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
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>
        public static ParallelQuery<XElement> AddToAll(this ParallelQuery<XElement> elements, XName name, params object[] content)
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
        /// <param name="predicate">If satisfied, the <see cref="XElement"/> is added.</param>
        /// <param name="name">The name of the <see cref="XElement"/> to be added.</param>
        /// <param name="content">The content of the <see cref="XElement"/> to be added.</param>
        /// <returns>A reference to the existing <see cref="ParallelQuery{XElement}"/>. This is returned for use with fluent syntax calls.</returns>
        /// <exception cref="AggregateException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="OperationCanceledException"/>   
        public static ParallelQuery<XElement> AddToAll(this ParallelQuery<XElement> elements, Func<XElement, bool> predicate, XName name, params object[] content)
        {
            return elements.Select(x =>
            {
                x.Add(new XElement(name, content));
                return x;
            });
        }
    }
}
