using System;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to convert objects into XML string format.
    /// </summary>
    [PublicAPI]
    public static class ToXmlStringExtensions 
    {
        /// <summary>
        /// Returns the XML string representation of an XDocument.
        /// </summary>
        /// <param name="document">The XDocument to convert.</param>
        /// <returns>The indented XML string form of the XDocument.</returns>
        public static string ToXmlString(this XDocument document)
        {
            if (document.Declaration == null)
            {
                document = document.ToXDocument();
            }
            try
            {
                return document.Declaration + Environment.NewLine + document;
            }
            catch
            {
                foreach (XElement element in document.Root?.Elements().Elements() ?? new XElement[0])
                {
                    element.Value = string.Join(null, element.Value.Where(XmlConvert.IsXmlChar));
                }
                return document.Declaration + Environment.NewLine + document;
            }
        }

        /// <summary>
        /// Returns the XML string representation of an enumerable collection.
        /// </summary>
        /// <param name="elements">The enumerable collection to convert.</param>
        /// <returns>The indented XML string form of the enumerable collection.</returns>
        public static string ToXmlString(this IEnumerable elements)
        {
            return elements.ToXDocument().ToXmlString();
        }
    }
}
