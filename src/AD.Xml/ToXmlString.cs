using System;
using System.Collections;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
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
        [CanBeNull]
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
                    // XmlConvert.IsXmlChar should return in .NET Standard 2.0
                    try
                    {
                        element.Value = string.Join(null, XmlConvert.VerifyXmlChars((string) element));
                    }
                    catch
                    {
                        element.Value = "XmlConvert.VerifyXmlChars could not verify this value.";
                    }
                }
                return document.Declaration + Environment.NewLine + document;
            }
        }

        /// <summary>
        /// Returns the XML string representation of an enumerable collection.
        /// </summary>
        /// <param name="elements">The enumerable collection to convert.</param>
        /// <returns>The indented XML string form of the enumerable collection.</returns>
        [CanBeNull]
        public static string ToXmlString(this IEnumerable elements) => elements.ToXDocument().ToXmlString();

        /// <summary>
        /// Returns the XML string representation of an immutable array.
        /// </summary>
        /// <param name="records">The immutable collection to convert.</param>
        /// <param name="indent">The indent string applied during serialization.</param>
        /// <param name="line">The delimiting string applied between nodes.</param>
        /// <returns>The indented XML string form of the immutable collection.</returns>
        [CanBeNull]
        public static string ToXmlString(this IImmutableList<object> records, string indent = "  ", string line = "\r\n")
        {
            PropertyInfo[] properties =
                records.FirstOrDefault()?
                       .GetType()
                       .GetTypeInfo()
                       .GetProperties()
                ?? new PropertyInfo[0];

            return
                string.Join(
                    line,
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>",
                    "<root>",
                    string.Join(
                        line,
                        records.Select(
                            x =>
                                string.Join(
                                    line,
                                    $"{indent}<record>",
                                    string.Join(
                                        line,
                                        properties.Select(y => $"{indent}{indent}<{y.Name}>{y.GetValue(x)}</{y.Name}>")),
                                    $"{indent}</record>"))),
                    "</root>");
        }
    }
}
