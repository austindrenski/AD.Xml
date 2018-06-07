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
        [NotNull] public const string OpenXmlWordprocessingmlMain = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        /// <summary>
        /// Represents the 'r:' prefix seen in the markup of document.xml.
        /// </summary>
        [NotNull] public const string OpenXmlOfficeDocumentRelationships = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

        /// <summary>
        /// Represents the 'r:' prefix seen in the markup of [Content_Types].xml
        /// </summary>
        [NotNull] public const string OpenXmlPackageRelationships = "http://schemas.openxmlformats.org/package/2006/relationships";

        /// <summary>
        /// The namespace declared on the [Content_Types].xml
        /// </summary>
        [NotNull] public const string OpenXmlPackageContentTypes = "http://schemas.openxmlformats.org/package/2006/content-types";

        /// <summary>
        /// Represents the 'c:' prefix seen in the markup for chart[#].xml
        /// </summary>
        [NotNull] public const string OpenXmlDrawingmlChart = "http://schemas.openxmlformats.org/drawingml/2006/chart";

        /// <summary>
        /// Represents the 'dgm:' prefix seen in the markup for 'drawing' elements.
        /// </summary>
        [NotNull] public const string OpenXmlDrawingmlDiagram = "http://schemas.openxmlformats.org/drawingml/2006/diagram";

        /// <summary>
        /// Represents the 'a:' prefix seen in the markup for chart[#].xml
        /// </summary>
        [NotNull] public const string OpenXmlDrawingmlMain = "http://schemas.openxmlformats.org/drawingml/2006/main";

        /// <summary>
        /// Represents the 'pic:' prefix seen in the markup for 'drawing' elements.
        /// </summary>
        [NotNull] public const string OpenXmlDrawingmlPicture = "http://schemas.openxmlformats.org/drawingml/2006/picture";

        /// <summary>
        /// Represents the 'wp:' prefix seen in the markup for 'drawing' elements.
        /// </summary>
        [NotNull] public const string OpenXmlDrawingmlWordprocessingDrawing = "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing";

        /// <summary>
        /// The namespace delcared on docProps/app.xml
        /// </summary>
        [NotNull] public const string OpenXmlOfficeDocumentExtendedProperties = "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties";

        /// <summary>
        /// Represents the 'm:' prefix seen in the markup for math elements.
        /// </summary>
        [NotNull] public const string OpenXmlMath = "http://schemas.openxmlformats.org/officeDocument/2006/math";

        /// <summary>
        /// Represents the 'wps:' prefix seen in the markup for 'wsp' elements.
        /// </summary>
        [NotNull] public const string OpenXmlWordprocessingShape = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape";
    }
}