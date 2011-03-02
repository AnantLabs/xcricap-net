using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlGeneration;
using XCRI.XmlBaseClasses;
using XCRI.Interfaces;

namespace XCRI.XmlGeneration.XCRICAP11
{
    public class Generator : XmlGeneratorBase
    {

        #region Constructors

        #region Internal

        internal Generator()
            : base()
        {
            base._Namespaces = NamespaceList.GetNamespaces(NamespaceList.Namespaces.XCRICAP11_All);
        }

        #endregion

        #endregion

        #region Methods

        #region Protected virtual

        protected virtual void WriteXCRI11GenericItem
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP11.IGeneric genericItem
            )
        {
            this.Write(xmlWriter, genericItem.ResourceStatus);
            this._WriteXsiTypeAttribute(xmlWriter, genericItem.XsiTypeValue, genericItem.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, genericItem.XmlLanguage);
            foreach (XCRI.Interfaces.IIdentifier identifier in genericItem.Identifiers)
                this.Write(xmlWriter, identifier);
            foreach (XCRI.Interfaces.ITitle title in genericItem.Titles)
                this.Write(xmlWriter, title);
            foreach (XCRI.Interfaces.ISubject subject in genericItem.Subjects)
                this.Write(xmlWriter, subject);
            foreach (XCRI.Interfaces.IDescription description in genericItem.Descriptions)
                this.Write(xmlWriter, description);
            if (genericItem.Url != null)
                this.Write(xmlWriter, genericItem.Url);
            if (genericItem.Image != null)
                this.Write(xmlWriter, genericItem.Image);
        }

        public virtual void WriteXCRI11OrganisationItem
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP11.IOrganisation organisationItem
            )
        {
            this.WriteXCRI11GenericItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IGeneric)organisationItem);
            if(organisationItem.Address != null)
                this.WriteXCRI11Address(xmlWriter, (XCRI.Interfaces.XCRICAP11.IAddress)organisationItem.Address);
            if (String.IsNullOrEmpty(organisationItem.PhoneNumber) == false)
                xmlWriter.WriteElementString("phone", Configuration.Namespaces.XCRICAP11NamespaceUri, organisationItem.PhoneNumber);
            if (String.IsNullOrEmpty(organisationItem.FaxNumber) == false)
                xmlWriter.WriteElementString("fax", Configuration.Namespaces.XCRICAP11NamespaceUri, organisationItem.FaxNumber);
            if (String.IsNullOrEmpty(organisationItem.EmailAddress) == false)
                xmlWriter.WriteElementString("email", Configuration.Namespaces.XCRICAP11NamespaceUri, organisationItem.EmailAddress);
        }

        public virtual void WriteXCRI11Address
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP11.IAddress addressItem
            )
        {
            this.WriteLatitudeLongitude
                (
                xmlWriter,
                addressItem.Latitude,
                addressItem.Longitude
                );
            if (String.IsNullOrEmpty(addressItem.Street) == false)
                xmlWriter.WriteElementString("street", Configuration.Namespaces.XCRICAP11NamespaceUri, addressItem.Street);
            if (String.IsNullOrEmpty(addressItem.Town) == false)
                xmlWriter.WriteElementString("town", Configuration.Namespaces.XCRICAP11NamespaceUri, addressItem.Town);
            if (String.IsNullOrEmpty(addressItem.Postcode) == false)
                xmlWriter.WriteElementString("postcode", Configuration.Namespaces.XCRICAP11NamespaceUri, addressItem.Postcode);
        }

        #endregion

        #region Public override

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            ResourceStatus resourceStatus
            )
        {
            if (resourceStatus == ResourceStatus.Unknown)
                return;
            if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                xmlWriter.WriteAttributeString
                    (
                    "recstatus",
                    ((int)resourceStatus).ToString()
                    );
            else
                xmlWriter.WriteAttributeString
                    (
                    "recstatus",
                    Configuration.Namespaces.XCRICAP11NamespaceUri,
                    ((int)resourceStatus).ToString()
                    );
        }

        public override void Generate
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            this._WrittenRootNode = false;
            xmlWriter.WriteStartDocument(true);
            if (this.RootElement is ICatalog)
                this.Write(xmlWriter, this.RootElement as ICatalog);
            if (this.RootElement is IProvider)
                this.Write(xmlWriter, this.RootElement as IProvider);
            if (this.RootElement is ICourse)
                this.Write(xmlWriter, this.RootElement as ICourse);
            xmlWriter.Flush();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICatalog catalog
            )
        {
            this._WriteStartElement(xmlWriter, "catalog", Configuration.Namespaces.XCRICAP11NamespaceUri);
            if (catalog.Generated.HasValue == false)
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                    xmlWriter.WriteAttributeString("generated", DateTime.Now.ToXCRIString(true));
                else
                    xmlWriter.WriteAttributeString("generated", Configuration.Namespaces.XCRICAP11NamespaceUri, DateTime.Now.ToXCRIString(true));
            else
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                    xmlWriter.WriteAttributeString("generated", catalog.Generated.Value.ToXCRIString(true));
                else
                    xmlWriter.WriteAttributeString("generated", Configuration.Namespaces.XCRICAP11NamespaceUri, catalog.Generated.Value.ToXCRIString(true));
            this.WriteXCRI11GenericItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IGeneric)catalog);
            foreach (XCRI.Interfaces.IProvider provider in catalog.Providers)
                this.Write(xmlWriter, provider);
            this._WriteEndElement(xmlWriter);
        }

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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
            this._WriteStartElement(xmlWriter, "description", Configuration.Namespaces.XCRICAP11NamespaceUri);
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
            switch (description.ContentType)
            {
                case DescriptionContentTypes.Href:
                    if (description.Href != null)
                        this._WriteAttribute
                            (
                            xmlWriter,
                            "href",
                            Configuration.Namespaces.XCRICAP11NamespaceUri,
                            description.Href.ToString(),
                            String.Empty
                            );
                    break;
                case DescriptionContentTypes.XHTML:
                    this._WriteStartElement(xmlWriter, "div", Configuration.Namespaces.XHTMLNamespaceUri);
                    if (!String.IsNullOrEmpty(description.Value))
                        xmlWriter.WriteRaw
                            (
                            description.Value
                            );
                    this._WriteEndElement(xmlWriter);
                    break;
                case DescriptionContentTypes.Text:
                    xmlWriter.WriteValue
                        (
                        description.Value
                        );
                    break;
            }
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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
                "accreditedBy",
                Configuration.Namespaces.XCRICAP11NamespaceUri,
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
            this._WriteStartElement(xmlWriter, "qualification", Configuration.Namespaces.XCRICAP11NamespaceUri);
            this.WriteXCRI11GenericItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IGeneric)qualification);
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
            XCRI.Interfaces.IStudyMode studyMode
            )
        {
            string value = studyMode.GetElementValueAsString();
            if(String.IsNullOrEmpty(value))
                return;
            this._Write
                (
                xmlWriter,
                "studyMode",
                Configuration.Namespaces.XCRICAP11NamespaceUri,
                value,
                false,
                studyMode.XsiTypeValue,
                studyMode.XsiTypeValueNamespace,
                studyMode.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendanceMode attendanceMode
            )
        {
            string value = attendanceMode.GetElementValueAsString();
            if (String.IsNullOrEmpty(value))
                return;
            this._Write
                (
                xmlWriter,
                "attendanceMode",
                Configuration.Namespaces.XCRICAP11NamespaceUri,
                value,
                false,
                attendanceMode.XsiTypeValue,
                attendanceMode.XsiTypeValueNamespace,
                attendanceMode.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendancePattern attendancePattern
            )
        {
            string value = attendancePattern.GetElementValueAsString();
            if (String.IsNullOrEmpty(value))
                return;
            this._Write
                (
                xmlWriter,
                "attendancePattern",
                Configuration.Namespaces.XCRICAP11NamespaceUri,
                value,
                false,
                attendancePattern.XsiTypeValue,
                attendancePattern.XsiTypeValueNamespace,
                attendancePattern.XmlLanguage
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            )
        {
            this._WriteStartElement(xmlWriter, "presentation", Configuration.Namespaces.XCRICAP11NamespaceUri);
            this.WriteXCRI11GenericItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IGeneric)presentation);
            if (presentation.Start.HasValue)
                xmlWriter.WriteElementString("start", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.Start.Value.ToXCRIString(true));
            if (presentation.End.HasValue)
                xmlWriter.WriteElementString("end", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.End.Value.ToXCRIString(true));
            if (String.IsNullOrEmpty(presentation.Duration) == false)
                xmlWriter.WriteElementString("duration", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.Duration);
            this.Write
                (
                xmlWriter,
                presentation.StudyMode
                );
            this.Write
                (
                xmlWriter,
                presentation.AttendanceMode
                );
            this.Write
                (
                xmlWriter,
                presentation.AttendancePattern
                );
            foreach (string language in presentation.LanguageOfInstruction)
                if (String.IsNullOrEmpty(language) == false)
                    xmlWriter.WriteElementString("languageOfInstruction", Configuration.Namespaces.XCRICAP11NamespaceUri, language);
            foreach (string language in presentation.LanguageOfAssessment)
                if (String.IsNullOrEmpty(language) == false)
                    xmlWriter.WriteElementString("languageOfAssessment", Configuration.Namespaces.XCRICAP11NamespaceUri, language);
            foreach (IVenue venue in presentation.Venues)
                this.Write(xmlWriter, venue);
            if (String.IsNullOrEmpty(presentation.PlacesAvailable) == false)
                xmlWriter.WriteElementString("placesAvailable", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.PlacesAvailable);
            if (String.IsNullOrEmpty(presentation.Cost) == false)
                xmlWriter.WriteElementString("cost", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.Cost);
            if (String.IsNullOrEmpty(presentation.ApplyTo) == false)
                xmlWriter.WriteElementString("applyTo", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.ApplyTo);
            if (String.IsNullOrEmpty(presentation.EnquireTo) == false)
                xmlWriter.WriteElementString("enquireTo", Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.EnquireTo);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
            )
        {
            this._WriteStartElement(xmlWriter, "venue", Configuration.Namespaces.XCRICAP11NamespaceUri);
            this.WriteXCRI11OrganisationItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IOrganisation)venue);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            )
        {
            if (uri == null)
                return;
            xmlWriter.WriteElementString
                (
                "url",
                Configuration.Namespaces.XCRICAP11NamespaceUri,
                uri.ToString()
                );
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            )
        {
            this.WriteXCRI11Address(xmlWriter, (XCRI.Interfaces.XCRICAP11.IAddress)address);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            )
        {
            this._WriteStartElement(xmlWriter, "course", Configuration.Namespaces.XCRICAP11NamespaceUri);
            this.WriteXCRI11GenericItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IGeneric)course);
            foreach (XCRI.Interfaces.IQualification qualification in course.Qualifications)
                this.Write(xmlWriter, qualification);
            foreach (XCRI.Interfaces.IPresentation presentation in course.Presentations)
                this.Write(xmlWriter, presentation);
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
            this._WriteStartElement(xmlWriter, "image", Configuration.Namespaces.XCRICAP11NamespaceUri);
            this._WriteXsiTypeAttribute(xmlWriter, image.XsiTypeValue, image.XsiTypeValueNamespace);
            this._WriteXmlLanguageAttribute(xmlWriter, image.XmlLanguage);
            if (image.Source != null)
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                    xmlWriter.WriteAttributeString("src", image.Source.ToString());
                else
                    xmlWriter.WriteAttributeString("src", Configuration.Namespaces.XCRICAP11NamespaceUri, image.Source.ToString());
            if (String.IsNullOrEmpty(image.Title) == false)
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                    xmlWriter.WriteAttributeString("title", image.Title);
                else
                    xmlWriter.WriteAttributeString("title", Configuration.Namespaces.XCRICAP11NamespaceUri, image.Title);
            if (String.IsNullOrEmpty(image.Alt) == false)
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP11NamespaceUri)))
                    xmlWriter.WriteAttributeString("alt", image.Alt);
                else
                    xmlWriter.WriteAttributeString("alt", Configuration.Namespaces.XCRICAP11NamespaceUri, image.Alt);
            this._WriteEndElement(xmlWriter);
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter, 
            XCRI.Interfaces.IProvider provider
            )
        {
            this._WriteStartElement(xmlWriter, "provider", Configuration.Namespaces.XCRICAP11NamespaceUri);
            if (
                (provider.Identifiers.Count == 0)
                &&
                (provider.Url != null)
                )
            {
                provider.Identifiers.Add(new Identifier()
                {
                    Value = provider.Url.ToString()
                });
            }
            if (provider.ReferenceNumber.HasValue)
            {
                Identifier ident = new Identifier()
                {
                    Value = provider.ReferenceNumber.Value.ToString()
                };
                ident.XsiTypeValue = "ukprn";
                ident.XsiTypeValueNamespace = Configuration.Namespaces.UKRegisterOfLearningProvidersNamespaceUri;
                provider.Identifiers.Add(ident);
            }
            this.WriteXCRI11OrganisationItem(xmlWriter, (XCRI.Interfaces.XCRICAP11.IOrganisation)provider);
            foreach (XCRI.Interfaces.ICourse course in provider.Courses)
                this.Write(xmlWriter, course);
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
                    Configuration.Namespaces.XCRICAP11NamespaceUri
                    );
                this._WriteAttribute
                    (
                    xmlWriter,
                    "type",
                    Configuration.Namespaces.XmlSchemaInstanceNamespaceUri,
                    "lat",
                    Configuration.Namespaces.GeolocationNamespaceUri
                    );
                xmlWriter.WriteValue(latitude.Value);
                this._WriteEndElement(xmlWriter);
            }
            if (longitude.HasValue)
            {
                this._WriteStartElement
                    (
                    xmlWriter,
                    "address",
                    Configuration.Namespaces.XCRICAP11NamespaceUri
                    );
                this._WriteAttribute
                    (
                    xmlWriter,
                    "type",
                    Configuration.Namespaces.XmlSchemaInstanceNamespaceUri,
                    "long",
                    Configuration.Namespaces.GeolocationNamespaceUri
                    );
                xmlWriter.WriteValue(longitude.Value);
                this._WriteEndElement(xmlWriter);
            }
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public override

        public override IElement RootElement
        {
            get { return this._RootElement; }
            set
            {
                if (this._RootElement == value)
                    return;
                bool validType = false;
                if(value == null)
                    validType = true;
                if (value is ICatalog)
                    validType = true;
                if (value is IProvider)
                    validType = true;
                if (value is ICourse)
                    validType = true;
                if (validType == false)
                    throw new NotSupportedException("The RootElement must be set to an ICatalog, IProvider or ICourse");
                this._RootElement = value;
            }
        }

        #endregion

        #endregion

    }
}
