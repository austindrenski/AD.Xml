using System;
using System.Collections;
using System.Linq;
using System.Text;
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
        /// <returns>
        /// The indented XML string form of the XDocument.
        /// </returns>
        [CanBeNull]
        public static string ToXmlString([NotNull] this XDocument document)
        {
            if (document is null)
                throw new ArgumentNullException(nameof(document));

            if (document.Declaration == null)
                document = document.ToXDocument();

            try
            {
                return document.Declaration + Environment.NewLine + document;
            }
            catch
            {
                foreach (XElement element in document.Root?.Elements().Elements() ?? new XElement[0])
                {
                    if (element.Value.All(XmlConvert.IsXmlChar))
                        continue;

                    element.Value = string.Join(null, element.Value.Where(XmlConvert.IsXmlChar));
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(document.Declaration.ToString());
                sb.Append(document);

                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns the XML string representation of an enumerable collection.
        /// </summary>
        /// <param name="elements">The enumerable collection to convert.</param>
        /// <returns>
        /// The indented XML string form of the enumerable collection.
        /// </returns>
        [CanBeNull]
        public static string ToXmlString([NotNull] this IEnumerable elements)
        {
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            return elements.ToXDocument().ToXmlString();
        }
    }
}