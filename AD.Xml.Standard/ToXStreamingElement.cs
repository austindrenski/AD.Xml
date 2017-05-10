using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Extension methods to convert objects to XStreamingElements.
    /// </summary>
    [PublicAPI]
    public static class ToXStreamingElementExtensions
    {
        /// <summary>
        /// Returns the source <see cref="XDocument"/> as an XStreamingElement.
        /// </summary>
        /// <param name="document">The source document to be returned as an XStreamingElement.</param>
        /// <returns>An XStreamingElement representing the source document.</returns>
        /// <exception cref="ArgumentException"/>
        public static XStreamingElement ToXStreamingElement(this XDocument document)
        {
            if (document.Root == null)
            {
                throw new ArgumentException("The root element of the source document cannot be null.");
            }
            return new XStreamingElement(document.Root.Name, document.Root.Elements());
        }

        /// <summary>
        /// Returns a single <see cref="XStreamingElement"/> named root whose content are the converted elements of the <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> that will become the elements of the root <see cref="XStreamingElement"/>.</param>
        /// <returns>An <see cref="XStreamingElement"/> named root that contains the source collection as an <see cref="XStreamingElement"/>.</returns>
        public static XStreamingElement ToXStreamingElement(this IEnumerable source)
        {
            IEnumerable<XStreamingElement> content;
            if (source is IEnumerable<XElement>)
            {
                content = source.Cast<XElement>()
                                .Select(x => x.ToXStreamingElement());
            }
            else
            {
                content = source.Cast<object>()
                                .Select(x => x.ToXStreamingElement());
            }
            return new XStreamingElement("root", content);
        }

        /// <summary>
        /// Encapsulates the element in an <see cref="XStreamingElement"/> named record.
        /// </summary>
        /// <param name="element">The object to be encapsulated.</param>
        /// <returns>An <see cref="XStreamingElement"/> named record that contains the element.</returns>
        public static XStreamingElement ToXStreamingElement<T>(this T element)
        {
            if (element is XElement)
            {
                XElement xElement = element as XElement;
                return xElement.HasElements ? new XStreamingElement(xElement.Name, xElement.Elements()) 
                                            : new XStreamingElement(xElement.Name, xElement.Value);
            }
            TypeInfo elementType = element.GetType().GetTypeInfo();
            if (elementType.IsPrimitive)
            {
                return new XStreamingElement("record", element);
            }
            TypeInfo type = element.GetType().GetTypeInfo();
            IEnumerable<PropertyInfo> properties =
                !type.IsInterface
                    ? type.GetProperties()
                    : new TypeInfo[] { type }.Concat(type.GetInterfaces().Select(x => x.GetTypeInfo()))
                                             .SelectMany(i => i.GetProperties())
                                             .ToArray();
            XStreamingElement record =
                new XStreamingElement("record", properties.Select(x =>
                {
                    XElement item = new XElement(x.Name, x.GetValue(element));
                    item.SetAttributeValue("type", x.PropertyType.Name);
                    return item;
                }));
            return record;
        }
    }
}