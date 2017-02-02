using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// Extension methods to work with XML schemas.
    /// </summary>
    [PublicAPI]
    public static class XmlSchemaExtensions 
    {
        /// <summary>
        /// Creates an XML schema based on the first element of the root of the XDocument.
        /// </summary>
        /// <param name="document">The XDocument used to create the schema.</param>
        /// <param name="writer">The stream to which error information is written.</param>
        /// <returns>An XML schema representing the first element of the root of the XDocument.</returns>
        public static XmlSchema XmlSchema(this XDocument document, StreamWriter writer = null)
        {
            XmlSchema schema = new XmlSchema();

            schema.Items.Add(new XmlSchemaElement { Name = document.Elements().FirstOrDefault()?.Name.ToString() });

            foreach (XElement element in document.Root?.Elements().FirstOrDefault()?.Elements() ?? new XElement[0])
            {
                XmlSchemaElement schemaElement = new XmlSchemaElement
                {
                    Name = element.Name.ToString(),
                    SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
                };
                schema.Items.Add(schemaElement);
            }

            XmlSchemaElement poco = new XmlSchemaElement
            {
                Name = document.Elements().Elements().FirstOrDefault()?.Name.ToString()
            };

            schema.Items.Add(poco);

            XmlSchemaComplexType type = new XmlSchemaComplexType();

            poco.SchemaType = type;

            XmlSchemaSequence sequence = new XmlSchemaSequence();

            type.Particle = sequence;

            foreach (XElement element in document.Root?.Elements().FirstOrDefault()?.Elements() ?? new XElement[0])
            {
                XmlSchemaElement schemaElement = new XmlSchemaElement
                {
                    Name = element.Name.ToString(),
                    SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
                };
                sequence.Items.Add(schemaElement);
            }

            XmlSchemaSet set = new XmlSchemaSet();

            set.Add(schema);
            set.Compile();

            XmlSchema final = set.Schemas().Cast<XmlSchema>().FirstOrDefault();
            if (writer == null)
            {
                return document.Validate(final) ? final : null;
            }
            return document.Validate(final) ? final : null;
        } 

        /// <summary>
        /// Returns true if the XDocument is valid according to the schema.
        /// </summary>
        /// <param name="document">The document to validate.</param>
        /// <param name="schema">The schema for validation.</param>
        /// <returns>True if the document is valid according to the schema.</returns>
        public static bool Validate(this XDocument document, XmlSchema schema)
        { 
            bool valid = true;
            XmlSchemaSet set = new XmlSchemaSet();
            set.Add(schema);
            document.Validate(set, (s,e) => valid = false);
            return valid;
        }

        /// <summary>
        /// Returns true if the XDocument is valid according to the schema and writes error information to a stream.
        /// </summary>
        /// <param name="document">The document to validate.</param>
        /// <param name="schema">The schema for validation.</param>
        /// <param name="writer">The stream to which error information is written.</param>
        /// <returns>True if the document is valid according to the schema.</returns>
        public static bool Validate(this XDocument document, XmlSchema schema, StreamWriter writer)
        {
            bool valid = true;
            XmlSchemaSet set = new XmlSchemaSet();
            set.Add(schema);
            document.Validate(set, (s, e) =>
                                   {
                                       writer.WriteLine(e.Message);
                                       valid = false;
                                   });
            return valid;
        }
    }
}
