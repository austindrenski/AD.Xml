using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public static class RemoveNamespacesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [NotNull]
        public static XElement RemoveNamespaces([NotNull] this XElement element)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            return new XElement(
                element.Name.LocalName,
                element.Attributes()
                       .Where(x => !x.IsNamespaceDeclaration)
                       .Select(x => new XAttribute(x.Name.LocalName, x.Value)),
                element.HasElements ? element.Elements().Select(x => x.RemoveNamespaces()) : element.Value as object);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<XElement> RemoveNamespaces([NotNull] this IEnumerable<XElement> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            return elements.Select(x => x.RemoveNamespaces());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        [NotNull]
        public static ParallelQuery<XElement> RemoveNamespaces([NotNull] this ParallelQuery<XElement> elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            return elements.Select(x => x.RemoveNamespaces());
        }
    }
}