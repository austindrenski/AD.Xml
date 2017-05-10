using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml.Standard 
{
    /// <summary>
    /// Extension methods to convert enumerable collections into XDocuments. 
    /// </summary>
    public static class ToXDocumentExtensions
    {
        /// <summary>
        /// The standard declaration for a well-formed XDocument.
        /// </summary>
        private static readonly XDeclaration XDeclarationStandard = new XDeclaration("1.0", "UTF-8", "yes");

        /// <summary>
        /// Converts an enumerable collection into an XDocument.
        /// </summary>
        /// <param name="elements">The enumerable collection that will be the content of the root element of the XDocument.</param>
        /// <returns>A well-formed XDocument with a root element whose children are the XElement representations of the elements in the enumerable collection.</returns>
        public static XDocument ToXDocument(this IEnumerable elements)
        {
            return elements is IEnumerable<XElement> ? new XDocument(XDeclarationStandard, new XElement("root", elements))
                                                     : new XDocument(XDeclarationStandard, elements.ToXElement());
        }

        /// <summary>
        /// Ensures the XDocument is well-formed. If the XDocument is not well-formed, alterations are made.
        /// </summary>
        /// <param name="document">The XDocument to check.</param>
        /// <returns>A well-formed XDocument.</returns>
        public static XDocument ToXDocument(this XDocument document)
        {
            document.Declaration = document.Declaration ?? XDeclarationStandard;
            return document;
        }
    }
}
