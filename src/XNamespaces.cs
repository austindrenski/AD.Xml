using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Common XML namespaces.
    /// </summary>
    [PublicAPI]
    public static class XNamespaces
    {
        /// <summary>
        /// Represents the 'w:' prefix seen in raw OpenXML documents.
        /// </summary>
        public const string OpenXmlWordprocessingmlMain = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        /// <summary>
        /// Represents the 'r:' prefix seen in the markup of document.xml.
        /// </summary>
        public const string OpenXmlOfficeDocumentRelationships = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

        /// <summary>
        /// Represents the 'r:' prefix seen in the markup of [Content_Types].xml
        /// </summary>
        public const string OpenXmlPackageRelationships = "http://schemas.openxmlformats.org/package/2006/relationships";

        /// <summary>
        /// The namespace declared on the [Content_Types].xml
        /// </summary>
        public const string OpenXmlPackageContentTypes = "http://schemas.openxmlformats.org/package/2006/content-types";

        /// <summary>
        /// Represents the 'wp:' prefix seen in the markup for 'drawing' elements.
        /// </summary>
        public const string OpenXmlDrawingmlWordprocessingDrawing = "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing";

        /// <summary>
        /// Represents the 'c:' prefix seen in the markup for chart[#].xml
        /// </summary>
        public const string OpenXmlDrawingmlChart = "http://schemas.openxmlformats.org/drawingml/2006/chart";

        /// <summary>
        /// Represents the 'a:' prefix seen in the markup for chart[#].xml
        /// </summary>
        public const string OpenXmlDrawingmlMain = "http://schemas.openxmlformats.org/drawingml/2006/main";

        /// <summary>
        /// The namespace delcared on docProps/app.xml
        /// </summary>
        public const string OpenXmlOfficeDocumentExtendedProperties = "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties";
    }
}
