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

        #region Protected override

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            )
        {
            this._WriteStartElement(xmlWriter, qualification);
            foreach (XCRI.Interfaces.IIdentifier identifier in qualification.Identifiers)
                this._Write(xmlWriter, identifier);
            foreach (XCRI.Interfaces.ITitle title in qualification.Titles)
                this._Write(xmlWriter, title);
            foreach (XCRI.Interfaces.IDescription description in qualification.Descriptions)
                this._Write(xmlWriter, description);
            if (qualification.Url != null)
                this._Write(xmlWriter, qualification.Url);
            if (qualification.Image != null)
                this._Write(xmlWriter, qualification.Image);
            if (qualification.Level != null)
                this._Write(xmlWriter, qualification.Level);
            if (qualification.Type != null)
                this._Write(xmlWriter, qualification.Type);
            foreach (XCRI.Interfaces.IQualificationAwardedBy awardedBy in qualification.AwardedBy)
                this._Write(xmlWriter, awardedBy);
            foreach (XCRI.Interfaces.IQualificationAccreditedBy accreditedBy in qualification.AccreditedBy)
                this._Write(xmlWriter, accreditedBy);
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            )
        {
            this._WriteStartElement(xmlWriter, presentation);
            foreach (Identifier identifier in presentation.Identifiers)
                this._Write(xmlWriter, identifier);
            if (presentation.Start.HasValue)
                xmlWriter.WriteElementString("start", Configuration.XCRICAP11NamespaceUri, presentation.Start.Value.ToXCRIString());
            if (presentation.End.HasValue)
                xmlWriter.WriteElementString("end", Configuration.XCRICAP11NamespaceUri, presentation.End.Value.ToXCRIString());
            if (String.IsNullOrEmpty(presentation.Duration) == false)
                xmlWriter.WriteElementString("duration", Configuration.XCRICAP11NamespaceUri, presentation.Duration);
            if (presentation.StudyMode != XCRI.Interfaces.StudyModes.Unknown)
            {
                xmlWriter.WriteStartElement("studyMode", Configuration.XCRICAP11NamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:studyModeType", xmlWriter.LookupPrefix(Configuration.XCRICAP11TermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.StudyMode.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            if (presentation.AttendanceMode != XCRI.Interfaces.AttendanceModes.Unknown)
            {
                xmlWriter.WriteStartElement("attendanceMode", Configuration.XCRICAP11NamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:attendanceModeType", xmlWriter.LookupPrefix(Configuration.XCRICAP11TermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.AttendanceMode.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            foreach (XCRI.Interfaces.IVenue venue in presentation.Venues)
            {
                this._Write(xmlWriter, venue);
            }
            if (presentation.AttendancePattern != XCRI.Interfaces.AttendancePatterns.Unknown)
            {
                xmlWriter.WriteStartElement("attendancePattern", Configuration.XCRICAP11NamespaceUri);
                xmlWriter.WriteAttributeString
                    (
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    String.Format("{0}:attendancePatternType", xmlWriter.LookupPrefix(Configuration.XCRICAP11TermsNamespaceUri))
                    );
                xmlWriter.WriteValue(presentation.AttendancePattern.ToXCRIString());
                xmlWriter.WriteEndElement();
            }
            if (String.IsNullOrEmpty(presentation.ApplyTo) == false)
                xmlWriter.WriteElementString("applyTo", Configuration.XCRICAP11NamespaceUri, presentation.ApplyTo);
            if (String.IsNullOrEmpty(presentation.EnquireTo) == false)
                xmlWriter.WriteElementString("enquireTo", Configuration.XCRICAP11NamespaceUri, presentation.EnquireTo);
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
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
            this._Write(xmlWriter, venue.Uri);
            if (venue.Image != null)
                this._Write(xmlWriter, venue.Image);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            )
        {
            this._Write(xmlWriter, uri, Configuration.XCRICAP11NamespaceUri);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri,
            string Namespace
            )
        {
            xmlWriter.WriteElementString
                (
                "url",
                Namespace,
                uri.ToString()
                );
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            )
        {
            if (address.Latitude.HasValue)
            {
                XmlBaseClasses.ElementWithSingleValue<decimal> latitude
                    = new XmlBaseClasses.ElementWithSingleValue<decimal>("address", Configuration.XCRICAP11NamespaceUri);
                latitude.XsiType.Value = "lat";
                latitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                latitude.Value = address.Latitude.Value;
                this._Write(xmlWriter, latitude);
            }
            if (address.Longitude.HasValue)
            {
                XmlBaseClasses.ElementWithSingleValue<decimal> longitude
                    = new XmlBaseClasses.ElementWithSingleValue<decimal>("address", Configuration.XCRICAP11NamespaceUri);
                longitude.XsiType.Value = "long";
                longitude.XsiType.AttributeValueNamespace = @"http://www.w3.org/2003/01/geo/wgs84_pos";
                longitude.Value = address.Longitude.Value;
                this._Write(xmlWriter, longitude);
            }
            if (String.IsNullOrEmpty(address.Street) == false)
                xmlWriter.WriteElementString("street", Configuration.XCRICAP11NamespaceUri, address.Street);
            if (String.IsNullOrEmpty(address.Town) == false)
                xmlWriter.WriteElementString("town", Configuration.XCRICAP11NamespaceUri, address.Town);
            if (String.IsNullOrEmpty(address.Postcode) == false)
                xmlWriter.WriteElementString("postcode", Configuration.XCRICAP11NamespaceUri, address.Postcode);
            if (String.IsNullOrEmpty(address.PhoneNumber) == false)
                xmlWriter.WriteElementString("phone", Configuration.XCRICAP11NamespaceUri, address.PhoneNumber);
            if (String.IsNullOrEmpty(address.FaxNumber) == false)
                xmlWriter.WriteElementString("fax", Configuration.XCRICAP11NamespaceUri, address.FaxNumber);
            if (String.IsNullOrEmpty(address.EmailAddress) == false)
                xmlWriter.WriteElementString("email", Configuration.XCRICAP11NamespaceUri, address.EmailAddress);
        }

        protected override void _Write
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
            foreach (XCRI.Interfaces.ITitle title in course.Titles)
                this._Write(xmlWriter, title);
            foreach (XCRI.Interfaces.ISubject subject in course.Subjects)
                this._Write(xmlWriter, subject);
            foreach (XCRI.Interfaces.DescriptionTypes type in course.Descriptions.Keys)
            {
                XmlBaseClasses.ElementWithChildElements description 
                    = new XmlBaseClasses.ElementWithChildElements("description", Configuration.XCRICAP11NamespaceUri);
                description.XsiType.AttributeValueNamespace = Configuration.XCRICAP11TermsNamespaceUri;
                description.XsiType.Value = type.ToString();
                XmlBaseClasses.ElementWithSingleValue<string> htmlDiv
                    = new XmlBaseClasses.ElementWithSingleValue<string>("div", @"http://www.w3.org/1999/xhtml");
                htmlDiv.Value = course.Descriptions[type].Data;
                htmlDiv.RenderRaw = course.Descriptions[type].IsXHtmlEncoded;
                description.ChildElements.Add(htmlDiv);
                this._Write(xmlWriter, description);
            }
            xmlWriter.WriteElementString
                (
                "url",
                Configuration.XCRICAP11NamespaceUri,
                course.Uri.ToString()
                );
            foreach (XCRI.Interfaces.IQualification qualification in course.Qualifications)
                this._Write(xmlWriter, qualification);
            foreach (XCRI.Interfaces.IPresentation presentation in course.Presentations)
            {
                this._Write(xmlWriter, presentation);
            }
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IImage image
            )
        {
            if (image == null)
                return;
            if (image.Source == null)
                return;
            this._WriteStartElement(xmlWriter, image);
            xmlWriter.WriteAttributeString("src", image.Source.ToString());
            if (String.IsNullOrEmpty(image.Title) == false)
                xmlWriter.WriteAttributeString("title", image.Title);
            if (String.IsNullOrEmpty(image.Alt) == false)
                xmlWriter.WriteAttributeString("title", image.Alt);
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElement element
            )
        {
            if (element == null)
                return;
            if (element is XCRI.Interfaces.IXmlElementWithSingleValue)
                this._Write(xmlWriter, element as XCRI.Interfaces.IXmlElementWithSingleValue);
            else if (element is XmlBaseClasses.ElementWithIdentifiers)
                this._Write(xmlWriter, element as XmlBaseClasses.ElementWithIdentifiers);
            else if (element is XCRI.Interfaces.IXmlElementWithChildElements)
                this._Write(xmlWriter, element as XCRI.Interfaces.IXmlElementWithChildElements);
            else
                throw new Exception("unexpected element type encountered.");
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElementWithChildElements element
            )
        {
            this._WriteStartElement(xmlWriter, element);
            foreach (XmlBaseClasses.Element childElement in element.ChildElements)
            {
                this._Write(xmlWriter, childElement);
            }
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElementWithSingleValue element
            )
        {
            this._WriteStartElement(xmlWriter, element);
            if (element.Value == null)
                return;
            if (element.RenderRaw)
                xmlWriter.WriteRaw
                    (
                    element.Value.ToString()
                    );
            else
                xmlWriter.WriteValue
                    (
                    element.Value.ToString()
                    );
            this._WriteEndElement(xmlWriter);
        }

        protected override void _Write
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
            foreach (XCRI.Interfaces.ITitle el in provider.Titles)
            {
                if (el != null)
                    this._Write(xmlWriter, el);
            }
            foreach (XCRI.Interfaces.IDescription el in provider.Descriptions)
            {
                if (el != null)
                    this._Write(xmlWriter, el);
            }
            if (provider.WebAddress != null)
            {
                XmlBaseClasses.ElementWithSingleValue<string> element = new XmlBaseClasses.ElementWithSingleValue<string>("url", Configuration.XCRICAP11NamespaceUri)
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
