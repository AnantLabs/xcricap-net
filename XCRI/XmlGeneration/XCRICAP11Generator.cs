using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration
{
    public class XCRICAP11Generator : XmlGeneratorBase
    {

        #region Constructors

        #region Internal

        internal XCRICAP11Generator()
            : base()
        {
        }

        #endregion

        #endregion

        #region Methods

        #region Public override

        public override void Generate
            (
            System.Xml.XmlWriter xmlWriter, 
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement("catalog", Configuration.XCRINamespaceUri);
            if (namespaceList != null)
            {
                StringBuilder schemaLocation = new StringBuilder();
                foreach (NamespaceData ns in namespaceList)
                {
                    if (String.IsNullOrEmpty(ns.NamespaceUri) == true)
                        continue;
                    if (String.IsNullOrEmpty(ns.Prefix) == false)
                        xmlWriter.WriteAttributeString("xmlns", ns.Prefix, null, ns.NamespaceUri);
                    if (String.IsNullOrEmpty(ns.XSDLocation) == false)
                        schemaLocation.AppendFormat("{0} {1} ", ns.NamespaceUri, ns.XSDLocation);
                }
                xmlWriter.WriteAttributeString("xsi", "schemaLocation", null, schemaLocation.ToString().Trim());
            }
            xmlWriter.WriteAttributeString("generated", DateTime.Now.ToXCRIString());
            foreach (XCRI.Interfaces.IProvider provider in Providers)
            {
                this._Write(xmlWriter, provider);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
        }

        #endregion

        #region Protected virtual

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            )
        {
            throw new NotImplementedException();
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            )
        {
            this._WriteStartElement(xmlWriter, presentation);
            foreach (Identifier identifier in presentation.Identifiers)
            {
                if (identifier != null)
                    this._Write(xmlWriter, identifier);
            }
            if (presentation.Start.HasValue)
                xmlWriter.WriteElementString("start", Configuration.XCRINamespaceUri, presentation.Start.Value.ToXCRIString());
            if (presentation.End.HasValue)
                xmlWriter.WriteElementString("end", Configuration.XCRINamespaceUri, presentation.End.Value.ToXCRIString());
            if (String.IsNullOrEmpty(presentation.Duration) == false)
                xmlWriter.WriteElementString("duration", Configuration.XCRINamespaceUri, presentation.Duration);
            if (presentation.StudyMode != XCRI.Interfaces.StudyModes.Unknown)
            {
                xmlWriter.WriteStartElement("studyMode", Configuration.XCRINamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:studyModeType", xmlWriter.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.StudyMode.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            if (presentation.AttendanceMode != XCRI.Interfaces.AttendanceModes.Unknown)
            {
                xmlWriter.WriteStartElement("attendanceMode", Configuration.XCRINamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:attendanceModeType", xmlWriter.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.AttendanceMode.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            foreach (Venue venue in presentation.Venues)
            {
                this._Write(xmlWriter, venue);
            }
            if (presentation.AttendancePattern != XCRI.Interfaces.AttendancePatterns.Unknown)
            {
                xmlWriter.WriteStartElement("attendancePattern", Configuration.XCRINamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:attendancePatternType", xmlWriter.LookupPrefix(Configuration.XCRITermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.AttendancePattern.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            if (String.IsNullOrEmpty(presentation.ApplyTo) == false)
                xmlWriter.WriteElementString("applyTo", Configuration.XCRINamespaceUri, presentation.ApplyTo);
            if (String.IsNullOrEmpty(presentation.EnquireTo) == false)
                xmlWriter.WriteElementString("enquireTo", Configuration.XCRINamespaceUri, presentation.EnquireTo);
            this._WriteEndElement(xmlWriter);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            Venue venue
            )
        {
            foreach (Identifier identifier in venue.Identifiers)
            {
                if (identifier != null)
                    this._Write(xmlWriter, identifier);
            }
            if (String.IsNullOrEmpty(venue.Title))
                xmlWriter.WriteElementString("title", venue.Title);
            this._Write(xmlWriter, venue as XCRI.Interfaces.IAddress);
            if (venue.Uri != null)
                xmlWriter.WriteElementString("url", venue.Uri.ToString());
            if (venue.Image != null)
                this._Write(xmlWriter, venue.Image);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            )
        {
            if (address.Latitude.HasValue)
            {
                XmlBaseClasses.ElementWithStringValue latitude
                    = new XmlBaseClasses.ElementWithStringValue("address", Configuration.XCRINamespaceUri);
                latitude.XsiType.Value = "lat";
                latitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                latitude.Value = address.Latitude.Value.ToString();
                this._Write(xmlWriter, latitude);
            }
            if (address.Longitude.HasValue)
            {
                XmlBaseClasses.ElementWithStringValue longitude
                    = new XmlBaseClasses.ElementWithStringValue("address", Configuration.XCRINamespaceUri);
                longitude.XsiType.Value = "long";
                longitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                longitude.Value = address.Longitude.Value.ToString();
                this._Write(xmlWriter, longitude);
            }
            if (String.IsNullOrEmpty(address.Street) == false)
                xmlWriter.WriteElementString("street", Configuration.XCRINamespaceUri, address.Street);
            if (String.IsNullOrEmpty(address.Town) == false)
                xmlWriter.WriteElementString("town", Configuration.XCRINamespaceUri, address.Town);
            if (String.IsNullOrEmpty(address.Postcode) == false)
                xmlWriter.WriteElementString("postcode", Configuration.XCRINamespaceUri, address.Postcode);
            if (String.IsNullOrEmpty(address.PhoneNumber) == false)
                xmlWriter.WriteElementString("phone", Configuration.XCRINamespaceUri, address.PhoneNumber);
            if (String.IsNullOrEmpty(address.FaxNumber) == false)
                xmlWriter.WriteElementString("fax", Configuration.XCRINamespaceUri, address.FaxNumber);
            if (String.IsNullOrEmpty(address.EmailAddress) == false)
                xmlWriter.WriteElementString("email", Configuration.XCRINamespaceUri, address.EmailAddress);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            )
        {
            this._WriteStartElement(xmlWriter, course);
            foreach (Identifier identifier in course.Identifiers)
            {
                if (identifier != null)
                    this._Write(xmlWriter, identifier);
            }
            if (String.IsNullOrEmpty(course.Title) == false)
                xmlWriter.WriteElementString
                    (
                    "title", 
                    Configuration.XCRINamespaceUri,
                    course.Title
                    );
            foreach (string subject in course.Subjects)
            {
                if (String.IsNullOrEmpty(subject))
                    continue;
                xmlWriter.WriteElementString
                    (
                    "subject", 
                    Configuration.XCRINamespaceUri, 
                    subject
                    );
            }
            foreach (XCRI.Interfaces.DescriptionTypes type in course.Descriptions.Keys)
            {
                XmlBaseClasses.ElementWithChildElements description 
                    = new XmlBaseClasses.ElementWithChildElements("description", Configuration.XCRINamespaceUri);
                description.XsiType.AttributeValueNamespace = Configuration.XCRITermsNamespaceUri;
                description.XsiType.Value = type.ToString();
                XmlBaseClasses.ElementWithStringValue htmlDiv
                    = new XmlBaseClasses.ElementWithStringValue("div", @"http://www.w3.org/1999/xhtml");
                htmlDiv.Value = course.Descriptions[type].Data;
                htmlDiv.RenderRaw = course.Descriptions[type].IsXHtmlEncoded;
                description.ChildElements.Add(htmlDiv);
                this._Write(xmlWriter, description);
            }
            xmlWriter.WriteElementString
                (
                "url",
                Configuration.XCRINamespaceUri,
                course.Uri.ToString()
                );
            if (course.Qualification != null)
                this._Write(xmlWriter, course.Qualification);
            foreach (XCRI.Interfaces.IPresentation presentation in course.Presentations)
            {
                this._Write(xmlWriter, presentation);
            }
            this._WriteEndElement(xmlWriter);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            Image image
            )
        {
            this._WriteStartElement(xmlWriter, image);
            xmlWriter.WriteAttributeString("src", image.Source.ToString());
            xmlWriter.WriteAttributeString("title", image.Title);
            this._WriteEndElement(xmlWriter);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XmlBaseClasses.Element element
            )
        {
            if (element == null)
                return;
            if (element is XmlBaseClasses.ElementWithStringValue)
                this._Write(xmlWriter, element as XmlBaseClasses.ElementWithStringValue);
            else if (element is XmlBaseClasses.ElementWithIdentifiers)
                this._Write(xmlWriter, element as XmlBaseClasses.ElementWithIdentifiers);
            else if (element is XmlBaseClasses.ElementWithChildElements)
                this._Write(xmlWriter, element as XmlBaseClasses.ElementWithChildElements);
            else
                throw new Exception("unexpected element type encountered.");
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XmlBaseClasses.ElementWithChildElements element
            )
        {
            this._WriteStartElement(xmlWriter, element);
            foreach (XmlBaseClasses.Element childElement in element.ChildElements)
            {
                this._Write(xmlWriter, childElement);
            }
            this._WriteEndElement(xmlWriter);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XmlBaseClasses.ElementWithStringValue element
            )
        {
            this._WriteStartElement(xmlWriter, element);
            if (String.IsNullOrEmpty(element.Value))
                return;
            if (element.RenderRaw)
                xmlWriter.WriteRaw
                    (
                    element.Value
                    );
            else
                xmlWriter.WriteValue
                    (
                    element.Value
                    );
            this._WriteEndElement(xmlWriter);
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter, 
            XCRI.Interfaces.IProvider provider
            )
        {
            this._WriteStartElement(xmlWriter, provider);
            bool outputIdentifier = false;
            foreach (Identifier identifier in provider.Identifiers)
            {
                if (identifier == null)
                    continue;
                outputIdentifier = true;
                this._Write(xmlWriter, identifier);
            }
            if (outputIdentifier == false)
            {
                Identifier ident = new Identifier()
                {
                    Value = provider.WebAddress.ToString()
                };
                this._Write(xmlWriter, ident);
            }
            if (provider.ReferenceNumber.HasValue)
            {
                Identifier ident = new Identifier()
                {
                    Value = provider.ReferenceNumber.Value.ToString()
                };
                ident.XsiType.AttributeValueNamespace = @"http://www.ukrlp.co.uk";
                ident.XsiType.Value = "ukprn";
                this._Write(xmlWriter, ident);
            }
            foreach (XmlBaseClasses.ElementWithStringValue el in provider.Titles)
            {
                if (el != null)
                    this._Write(xmlWriter, el);
            }
            foreach (XmlBaseClasses.Element el in provider.Descriptions)
            {
                if (el != null)
                    this._Write(xmlWriter, el);
            }
            if (provider.WebAddress != null)
            {
                XmlBaseClasses.ElementWithStringValue element = new XmlBaseClasses.ElementWithStringValue("url", Configuration.XCRINamespaceUri)
                {
                    Value = provider.WebAddress.ToString()
                };
                this._Write(xmlWriter, element);
            }
            if (provider.Image != null)
            {
                this._Write(xmlWriter, provider.Image);
            }
            if (provider.Address != null)
            {
                this._Write(xmlWriter, provider.Address);
            }
            // Load courses and generate
            foreach (XCRI.Interfaces.ICourse course in provider.Courses)
            {
                this._Write(xmlWriter, course);
            }
            this._WriteEndElement(xmlWriter);
        }

        #endregion

        #endregion

    }
}
