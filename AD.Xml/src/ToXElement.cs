using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to convert objects to XElements.
    /// </summary> 
    [PublicAPI]
    public static class ToXElementExensions
    {
        /// <summary>
        /// Fields that should be flagged in XDocuments consumed by Getdata applications.
        /// </summary>
        internal static readonly IList<string> SpecialFields = new string[] { "HTS10", "HTS8", "HTS6", "HTS4", "HTS2", "HS6", "HS4", "HS2", "GTAP", "NAICS", "Year" };

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
                content = enumerable.Cast<XElement>()
                                    .RemoveEmptyProperties();
            }
            else if (enumerable is IEnumerable<XStreamingElement>)
            {
                content = enumerable.Cast<XStreamingElement>()
                                    .Select(x => x.ToXElement())
                                    .RemoveEmptyProperties();
            }
            else
            {
                content = enumerable.Cast<object>()
                                    .Select(x => x.ToXElement())
                                    .RemoveEmptyProperties();
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
            if (element.GetType().IsPrimitive)
            {
                return new XElement("record", element);
            }
            Type type = element.GetType();
            IEnumerable<PropertyInfo> properties = 
                !type.IsInterface ? type.GetProperties()
                                  : new Type[] { type }.Concat(type.GetInterfaces())
                                                       .SelectMany(i => i.GetProperties())
                                                       .ToArray();
        XElement record = new XElement("record");
            foreach (PropertyInfo propertyInfo in properties)
            {
                XElement item = new XElement(propertyInfo.Name, propertyInfo.GetValue(element));
                item.SetAttributeValue("type", propertyInfo.PropertyType.Name);
                if (SpecialFields.Contains(propertyInfo.Name.ToUpper()))
                {
                    item.SetAttributeValue("type", propertyInfo.Name.ToUpper());
                }
                record.Add(item);
            }
            return record;
        }

        /// <summary>
        /// Removes child elements from an enumerable collection of parent elements if a child element is null or zero in every parent element.
        /// </summary>
        /// <param name="elements">The enumerable collection of parent elements.</param>
        /// <returns>The enumerable collection without child elements that were null or zero in every parent element.</returns>
        private static IEnumerable<XElement> RemoveEmptyProperties(this IEnumerable<XElement> elements)
        {
            XElement[] elementsArray = elements as XElement[] ?? elements.ToArray();
            IList<XName> names = elementsArray.FirstOrDefault()?.Elements().Select(x => x.Name).ToArray() ?? new XName[0];
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
