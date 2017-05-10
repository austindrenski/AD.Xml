using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard
{
    /// <summary>
    /// Extension methods to convert objects to XElements.
    /// </summary> 
    [PublicAPI]
    public static class ToXElementExensions
    {
        /// <summary>
        /// Returns a single XElement named root whose content are the converted elements of the enumerable collection.
        /// </summary>
        /// <param name="enumerable">The enumerable collection that will become the elements of the root XElement.</param>
        /// <returns>An XElement named root that contains the enumerable as elements.</returns>
        public static XElement ToXElement(this IEnumerable enumerable)
        {
            IEnumerable<XElement> content;
            if (enumerable is IEnumerable<XElement>)
            {
                content = enumerable.Cast<XElement>();
            }
            else if (enumerable is IEnumerable<XStreamingElement>)
            {
                content = enumerable.Cast<XStreamingElement>()
                                    .Select(x => x.ToXElement());
            }
            else
            {
                content = enumerable.Cast<object>()
                                    .Select(x => x.ToXElement());
            }
            return new XElement("root", content); 
        }

        /// <summary>
        /// Returns a single XElement named root whose content are the converted elements of the enumerable collection.
        /// </summary>
        /// <param name="enumerable">The enumerable collection that will become the elements of the root XElement.</param>
        /// <returns>An XElement named root that contains the enumerable as elements.</returns>
        public static XElement ToXElement(this IQueryable enumerable)
        {
            IEnumerable<XElement> content;
            if (enumerable is IQueryable<XElement>)
            {
                content = enumerable.Cast<XElement>();
            }
            else if (enumerable is IQueryable<XStreamingElement>)
            {
                content = enumerable.Cast<XStreamingElement>()
                                    .Select(x => x.ToXElement());
            }
            else
            {
                content = enumerable.Cast<object>()
                                    .Select(x => x.ToXElement());
            }
            return new XElement("root", content);
        }

        /// <summary>
        /// Encapsulates the element in an XElement named record.
        /// </summary>
        /// <param name="element">The object to be encapsulated.</param>
        /// <returns>An XElement named record that contains the element.</returns>
        public static XElement ToXElement<T>(this T element)
        {
            if (element is XElement)
            {
                return element as XElement;
            }
            if (element is XStreamingElement)
            {
                return XElement.Parse(element.ToString());
            }
            if (element.GetType().GetTypeInfo().IsPrimitive)
            {
                return new XElement("record", element);
            }
            TypeInfo type = element.GetType().GetTypeInfo();
            IEnumerable<PropertyInfo> properties =
                !type.IsInterface
                    ? type.GetProperties()
                    : new TypeInfo[] { type }.Concat(type.GetInterfaces().Select(x => x.GetTypeInfo()))
                                             .SelectMany(i => i.GetProperties())
                                             .ToArray();
            XElement record = new XElement("record");
            foreach (PropertyInfo propertyInfo in properties)
            {
                XElement item = new XElement(propertyInfo.Name, propertyInfo.GetValue(element));

                item.SetAttributeValue(
                    "type",
                    propertyInfo.PropertyType.GetTypeInfo().IsGenericType
                        ? propertyInfo.PropertyType.Name + propertyInfo.PropertyType.GenericTypeArguments.FirstOrDefault()?.FullName
                        : propertyInfo.PropertyType.Name);

                record.Add(item);
            }
            return record;
        }

        /// <summary>
        /// Removes child elements from an enumerable collection of parent elements if a child element is null or zero in every parent element.
        /// </summary>
        /// <param name="elements">The enumerable collection of parent elements.</param>
        /// <returns>The enumerable collection without child elements that were null or zero in every parent element.</returns>
        public static IEnumerable<XElement> RemoveEmptyProperties(this IEnumerable<XElement> elements)
        {
            XElement[] elementsArray = elements as XElement[] ?? elements.ToArray();
            IEnumerable<XName> names = elementsArray.FirstOrDefault()?.Elements().Select(x => x.Name).ToArray() ?? new XName[0];
            foreach (XName name in names)
            {
                if (elementsArray.Descendants(name).All(x => x.Value == "0"))
                {
                    elementsArray.Descendants(name).Remove();
                }
                else if (elementsArray.Descendants(name).All(x => x.Value == ""))
                {
                    elementsArray.Descendants(name).Remove();
                }
            }
            return elementsArray;
        }
    }
}