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

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IIdentifier identifier
            )
        {
            base._Write
                (
                xmlWriter,
                "identifier",
                Configuration.XCRICAP11NamespaceUri,
                identifier.Value,
                identifier.RenderRaw,
                identifier.XsiTypeValue,
                identifier.XsiTypeValueNamespace,
                identifier.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ITitle title
            )
        {
            base._Write
                (
                xmlWriter,
                "title",
                Configuration.XCRICAP11NamespaceUri,
                title.Value,
                title.RenderRaw,
                title.XsiTypeValue,
                title.XsiTypeValueNamespace,
                title.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IDescription description
            )
        {
            this._WriteStartElement(xmlWriter, "description", Configuration.XCRICAP11NamespaceUri);
            this._WriteXsiTypeAttribute
                (
                xmlWriter, 
                description.XsiTypeValue,
                description.XsiTypeValueNamespace
                );
            this._WriteXmlLanguageAttribute
                (
                xmlWriter,
                description.XmlLanguage
                );
            this._WriteStartElement(xmlWriter, "div", Configuration.XHTMLNamespaceUri);
            if (String.IsNullOrEmpty(description.Value))
                return;
            if (description.RenderRaw)
                xmlWriter.WriteRaw
                    (
                    description.Value
                    );
            else
                xmlWriter.WriteValue
                    (
                    description.Value
                    );
            this._WriteEndElement(xmlWriter);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ISubject subject
            )
        {
            base._Write
                (
                xmlWriter,
                "subject",
                Configuration.XCRICAP11NamespaceUri,
                subject.Value,
                subject.RenderRaw,
                subject.XsiTypeValue,
                subject.XsiTypeValueNamespace,
                subject.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationLevel qualLevel
            )
        {
            base._Write
                (
                xmlWriter,
                "level",
                Configuration.XCRICAP11NamespaceUri,
                qualLevel.Value,
                qualLevel.RenderRaw,
                qualLevel.XsiTypeValue,
                qualLevel.XsiTypeValueNamespace,
                qualLevel.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationType qualType
            )
        {
            base._Write
                (
                xmlWriter,
                "type",
                Configuration.XCRICAP11NamespaceUri,
                qualType.Value,
                qualType.RenderRaw,
                qualType.XsiTypeValue,
                qualType.XsiTypeValueNamespace,
                qualType.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAwardedBy awardedBy
            )
        {
            base._Write
                (
                xmlWriter,
                "awardedBy",
                Configuration.XCRICAP11NamespaceUri,
                awardedBy.Value,
                awardedBy.RenderRaw,
                awardedBy.XsiTypeValue,
                awardedBy.XsiTypeValueNamespace,
                awardedBy.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy
            )
        {
            base._Write
                (
                xmlWriter,
                "awaaccreditedByrdedBy",
                Configuration.XCRICAP11NamespaceUri,
                accreditedBy.Value,
                accreditedBy.RenderRaw,
                accreditedBy.XsiTypeValue,
                accreditedBy.XsiTypeValueNamespace,
                accreditedBy.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            )
        {
            this._WriteStartElement(xmlWriter, "qualification", Configuration.XCRICAP11NamespaceUri);
            if (qualification.ResourceStatus != ResourceStatus.Unknown)
            {
                this._Write(xmlWriter, qualification.ResourceStatus);
            }
            this._WriteXsiTypeAttribute(xmlWriter, qualification.XsiTypeValue, qualification.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, qualification.XmlLanguage);
            foreach (XCRI.Interfaces.IIdentifier identifier in qualification.Identifiers)
                this.Write(xmlWriter, identifier);
            foreach (XCRI.Interfaces.ITitle title in qualification.Titles)
                this.Write(xmlWriter, title);
            foreach (XCRI.Interfaces.IDescription description in qualification.Descriptions)
                this.Write(xmlWriter, description);
            if (qualification.Url != null)
                this.Write(xmlWriter, qualification.Url);
            if (qualification.Image != null)
                this.Write(xmlWriter, qualification.Image);
            if (qualification.Level != null)
                this.Write(xmlWriter, qualification.Level);
            if (qualification.Type != null)
                this.Write(xmlWriter, qualification.Type);
            foreach (XCRI.Interfaces.IQualificationAwardedBy awardedBy in qualification.AwardedBy)
                this.Write(xmlWriter, awardedBy);
            foreach (XCRI.Interfaces.IQualificationAccreditedBy accreditedBy in qualification.AccreditedBy)
                this.Write(xmlWriter, accreditedBy);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            )
        {
            this._WriteStartElement(xmlWriter, "presentation", Configuration.XCRICAP11NamespaceUri);
            if (presentation.ResourceStatus != ResourceStatus.Unknown)
            {
                this._Write(xmlWriter, presentation.ResourceStatus);
            }
            this._WriteXsiTypeAttribute(xmlWriter, presentation.XsiTypeValue, presentation.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, presentation.XmlLanguage);
            foreach (Identifier identifier in presentation.Identifiers)
                this.Write(xmlWriter, identifier);
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
                this.Write(xmlWriter, venue);
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

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
            )
        {
            foreach (Identifier identifier in venue.Identifiers)
            {
                if (identifier != null)
                    this.Write(xmlWriter, identifier);
            }
            if (String.IsNullOrEmpty(venue.Title))
                xmlWriter.WriteElementString("title", venue.Title);
            this.Write(xmlWriter, venue as XCRI.Interfaces.IAddress);
            this.Write(xmlWriter, venue.Uri);
            if (venue.Image != null)
                this.Write(xmlWriter, venue.Image);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            )
        {
            this.Write(xmlWriter, uri, Configuration.XCRICAP11NamespaceUri);
        }

        public override void Write
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

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            )
        {
            this.WriteLatitudeLongitude
                (
                xmlWriter,
                address.Latitude,
                address.Longitude
                );
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

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            )
        {
            this._WriteStartElement(xmlWriter, "course", Configuration.XCRICAP11NamespaceUri);
            this._Write(xmlWriter, course.ResourceStatus);
            this._WriteXsiTypeAttribute(xmlWriter, course.XsiTypeValue, course.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, course.XmlLanguage);
            foreach (Identifier identifier in course.Identifiers)
            {
                if (identifier != null)
                    this.Write(xmlWriter, identifier);
            }
            foreach (XCRI.Interfaces.ITitle title in course.Titles)
                this.Write(xmlWriter, title);
            foreach (XCRI.Interfaces.ISubject subject in course.Subjects)
                this.Write(xmlWriter, subject);
            foreach (XCRI.Interfaces.DescriptionTypes type in course.Descriptions.Keys)
            {
                Description description = new Description();
                description.XsiTypeValue = type.ToString();
                description.XsiTypeValueNamespace = Configuration.XCRICAP11TermsNamespaceUri;
                description.Value = course.Descriptions[type].Data;
                description.RenderRaw = course.Descriptions[type].IsXHtmlEncoded;
                this.Write(xmlWriter, description);
            }
            xmlWriter.WriteElementString
                (
                "url",
                Configuration.XCRICAP11NamespaceUri,
                course.Uri.ToString()
                );
            foreach (XCRI.Interfaces.IQualification qualification in course.Qualifications)
                this.Write(xmlWriter, qualification);
            foreach (XCRI.Interfaces.IPresentation presentation in course.Presentations)
            {
                this.Write(xmlWriter, presentation);
            }
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IImage image
            )
        {
            if (image == null)
                return;
            if (image.Source == null)
                return;
            this._WriteStartElement(xmlWriter, "image", Configuration.XCRICAP11NamespaceUri);
            if (image.ResourceStatus != ResourceStatus.Unknown)
                this._Write(xmlWriter, image.ResourceStatus);
            this._WriteXsiTypeAttribute(xmlWriter, image.XsiTypeValue, image.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, image.XmlLanguage);
            xmlWriter.WriteAttributeString("src", image.Source.ToString());
            if (String.IsNullOrEmpty(image.Title) == false)
                xmlWriter.WriteAttributeString("title", image.Title);
            if (String.IsNullOrEmpty(image.Alt) == false)
                xmlWriter.WriteAttributeString("title", image.Alt);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter, 
            XCRI.Interfaces.IProvider provider
            )
        {
            this._WriteStartElement(xmlWriter, "provider", Configuration.XCRICAP11NamespaceUri);
            if (provider.ResourceStatus != ResourceStatus.Unknown)
                this._Write(xmlWriter, provider.ResourceStatus);
            this._WriteXsiTypeAttribute(xmlWriter, provider.XsiTypeValue, provider.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, provider.XmlLanguage);
            bool outputIdentifier = false;
            foreach (Identifier identifier in provider.Identifiers)
            {
                if (identifier == null)
                    continue;
                outputIdentifier = true;
                this.Write(xmlWriter, identifier);
            }
            if (outputIdentifier == false)
            {
                Identifier ident = new Identifier()
                {
                    Value = provider.WebAddress.ToString()
                };
                this.Write(xmlWriter, ident);
            }
            if (provider.ReferenceNumber.HasValue)
            {
                Identifier ident = new Identifier()
                {
                    Value = provider.ReferenceNumber.Value.ToString()
                };
                ident.XsiTypeValue = "ukprn";
                ident.XsiTypeValueNamespace = @"http://www.ukrlp.co.uk";
                this.Write(xmlWriter, ident);
            }
            foreach (XCRI.Interfaces.ITitle el in provider.Titles)
            {
                if (el != null)
                    this.Write(xmlWriter, el);
            }
            foreach (XCRI.Interfaces.IDescription el in provider.Descriptions)
            {
                if (el != null)
                    this.Write(xmlWriter, el);
            }
            if (provider.WebAddress != null)
            {
                xmlWriter.WriteElementString("url", Configuration.XCRICAP11NamespaceUri, provider.WebAddress.ToString());
            }
            if (provider.Image != null)
            {
                this.Write(xmlWriter, provider.Image);
            }
            if (provider.Address != null)
            {
                this.Write(xmlWriter, provider.Address);
            }
            // Load courses and generate
            foreach (XCRI.Interfaces.ICourse course in provider.Courses)
            {
                this.Write(xmlWriter, course);
            }
            this._WriteEndElement(xmlWriter);
        }

        #endregion

        #region Public virtual

        public virtual void WriteLatitudeLongitude
            (
            System.Xml.XmlWriter xmlWriter,
            decimal? latitude,
            decimal? longitude
            )
        {
            if (latitude.HasValue)
            {
                this._WriteStartElement
                    (
                    xmlWriter,
                    "address",
                    Configuration.XCRICAP11NamespaceUri
                    );
                this._WriteAttribute
                    (
                    xmlWriter,
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    "lat",
                    Configuration.GeolocationNamespaceUri
                    );
                xmlWriter.WriteValue(longitude.Value);
                this._WriteEndElement(xmlWriter);
            }
            if (longitude.HasValue)
            {
                this._WriteStartElement
                    (
                    xmlWriter,
                    "address",
                    Configuration.XCRICAP11NamespaceUri
                    );
                this._WriteAttribute
                    (
                    xmlWriter,
                    "type",
                    Configuration.XMLSchemaInstanceNamespaceUri,
                    "long",
                    Configuration.GeolocationNamespaceUri
                    );
                xmlWriter.WriteValue(longitude.Value);
                this._WriteEndElement(xmlWriter);
            }
        }

        #endregion

        #endregion

    }
}
