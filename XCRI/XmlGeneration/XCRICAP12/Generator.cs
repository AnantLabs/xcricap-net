using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Interfaces;
using XCRI.ExtensionMethods;

namespace XCRI.XmlGeneration.XCRICAP12
{
    public class Generator : XmlGeneratorBase
    {

        #region Constructors

        #region Internal

        internal Generator()
            : base()
        {
            base._Namespaces = NamespaceList.GetNamespaces(NamespaceList.Namespaces.XCRICAP12_All);
        }

        #endregion

        #endregion

        #region Methods

        #region Protected virtual

        protected virtual void WriteXCRI12CommonAndCommonDescriptiveElements
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ICommonAndCommonDescriptiveElements commonAndCommonDescriptiveElements
            )
        {
            if (commonAndCommonDescriptiveElements == null)
                throw new ArgumentNullException("commonAndCommonDescriptiveElements");
            if ((commonAndCommonDescriptiveElements.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this.WriteXCRI12CommonElements
                (
                xmlWriter, 
                commonAndCommonDescriptiveElements as XCRI.Interfaces.XCRICAP12.ICommonElements
                );
            foreach (XCRI.Interfaces.XCRICAP12.IAbstract element in commonAndCommonDescriptiveElements.Abstracts)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IApplicationProcedure element in commonAndCommonDescriptiveElements.ApplicationProcedures)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IAssessment element in commonAndCommonDescriptiveElements.Assessments)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.ILearningOutcome element in commonAndCommonDescriptiveElements.LearningOutcomes)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IObjective element in commonAndCommonDescriptiveElements.Objectives)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IPrerequisite element in commonAndCommonDescriptiveElements.Prerequisites)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IRegulations element in commonAndCommonDescriptiveElements.Prerequisites)
                this.Write(xmlWriter, element);
        }

        protected virtual void WriteXCRI12CommonElements
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ICommonElements commonElements
            )
        {
            if (commonElements == null)
                throw new ArgumentNullException("commonElements");
            if ((commonElements.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            foreach (XCRI.Interfaces.XCRICAP12.IContributor contributor in commonElements.Contributors)
                if (contributor != null)
                    this.Write(xmlWriter, contributor);
            foreach (XCRI.Interfaces.XCRICAP12.IDescription description in commonElements.Descriptions)
                if (description != null)
                    this.Write(xmlWriter, description);
            foreach (XCRI.Interfaces.XCRICAP12.IIdentifier identifier in commonElements.Identifiers)
                if (identifier != null)
                    this.Write(xmlWriter, identifier);
            if (commonElements.Image != null)
                this.Write(xmlWriter, commonElements.Image);
            foreach (XCRI.Interfaces.XCRICAP12.ISubject subject in commonElements.Subjects)
                if (subject != null)
                    this.Write(xmlWriter, subject);
            foreach (XCRI.Interfaces.XCRICAP12.ITitle title in commonElements.Titles)
                if (title != null)
                    this.Write(xmlWriter, title);
            foreach (XCRI.Interfaces.XCRICAP12.IType type in commonElements.Types)
                if (type != null)
                    this.Write(xmlWriter, type);
            if (commonElements.Url != null)
                this.Write(xmlWriter, commonElements.Url);
        }

        protected virtual void WriteDescription
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IDescription description,
            string elementName,
            string elementNamespace
            )
        {
            if (description == null)
                throw new ArgumentNullException("description");
            if ((description.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, elementName, elementNamespace);
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
                            elementNamespace,
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

        #endregion

        #region Public override

        public override void Generate
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            this._WrittenRootNode = false;
            xmlWriter.WriteStartDocument(true);
            if (this.RootElement is ICatalog)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.ICatalog);
            if (this.RootElement is IProvider)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.IProvider);
            if (this.RootElement is ICourse)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.ICourse);
            xmlWriter.Flush();
        }

        #endregion

        #region Public virtual

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationType element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._Write
                (
                xmlWriter,
                "type",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.EducationalCredit.ICredit element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "credit", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri);
            foreach (string scheme in element.Schemes)
                this._Write
                    (
                    xmlWriter,
                    "scheme",
                    Configuration.Namespaces.CENEducationalCreditInformationModelNamespaceUri,
                    scheme,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            foreach (string level in element.Levels)
                this._Write
                    (
                    xmlWriter,
                    "level",
                    Configuration.Namespaces.CENEducationalCreditInformationModelNamespaceUri,
                    level,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            foreach (string value in element.Values)
                this._Write
                    (
                    xmlWriter,
                    "value",
                    Configuration.Namespaces.CENEducationalCreditInformationModelNamespaceUri,
                    value,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IAssessment element
            )
        {
            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "assessment",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IObjective element
            )
        {
            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "objective",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IPrerequisite element
            )
        {
            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "prerequisite",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IAbstract element
            )
        {
            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "abstract",
                Configuration.Namespaces.XCRICAP12NamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IApplicationProcedure element
            )
        {

            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "applicationProcedure",
                Configuration.Namespaces.XCRICAP12NamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ILearningOutcome element
            )
        {

            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "learningOutcome",
                Configuration.Namespaces.XCRICAP12NamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IRegulations element
            )
        {

            this.WriteDescription
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.IDescription,
                "regulations",
                Configuration.Namespaces.XCRICAP12NamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IProvider provider
            )
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            if ((provider.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "provider", Configuration.Namespaces.XCRICAP12NamespaceUri);
            this.WriteXCRI12CommonElements(xmlWriter, provider);
            foreach (XCRI.Interfaces.XCRICAP12.ICourse course in provider.Courses)
                if (course != null)
                    this.Write(xmlWriter, course);
            foreach (XCRI.Interfaces.XCRICAP12.ILocation location in provider.Locations)
                if (location != null)
                    this.Write(xmlWriter, location);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ICourse course
            )
        {
            if (course == null)
                throw new ArgumentNullException("course");
            if ((course.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "course", Configuration.Namespaces.XCRICAP12NamespaceUri);
            this.WriteXCRI12CommonAndCommonDescriptiveElements
                (
                xmlWriter, 
                course as XCRI.Interfaces.XCRICAP12.ICommonAndCommonDescriptiveElements
                );
            foreach (XCRI.Interfaces.XCRICAP12.ICourseLevel element in course.Levels)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IQualification element in course.Qualifications)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.EducationalCredit.ICredit element in course.Credits)
                this.Write(xmlWriter, element);
            foreach (XCRI.Interfaces.XCRICAP12.IPresentation element in course.Presentations)
                this.Write(xmlWriter, element);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "venue", Configuration.Namespaces.XCRICAP12NamespaceUri);
            this._WriteStartElement(xmlWriter, "provider", Configuration.Namespaces.XCRICAP12NamespaceUri);
            foreach (XCRI.Interfaces.XCRICAP12.ITitle title in element.Titles)
                if (title != null)
                    this.Write(xmlWriter, title);
            this.Write(xmlWriter, element.Location);
            this._WriteEndElement(xmlWriter);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IAbbreviation element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "abbr",
                Configuration.Namespaces.XCRICAP12NamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ICourseLevel element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "level",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IPresentation element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "presentation", Configuration.Namespaces.XCRICAP12NamespaceUri);
            this.WriteXCRI12CommonAndCommonDescriptiveElements
                (
                xmlWriter,
                element as XCRI.Interfaces.XCRICAP12.ICommonAndCommonDescriptiveElements
                );
            if (element.Start != null)
                this.Write
                    (
                    xmlWriter,
                    element.Start, 
                    "start", 
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                    );
            if (element.End != null)
                this.Write
                    (
                    xmlWriter,
                    element.End, 
                    "end",
                    Configuration.Namespaces.XCRICAP12NamespaceUri
                    );
            if (element.Duration.HasValue && element.Duration.Value != TimeSpan.Zero)
                this.Write
                    (
                    xmlWriter, element.Duration.Value, 
                    "duration",
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                    );
            if (String.IsNullOrEmpty(element.ApplyTo) == false)
                this._Write
                    (
                    xmlWriter,
                    "applyTo",
                    Configuration.Namespaces.XCRICAP12NamespaceUri,
                    element.ApplyTo,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            foreach (XCRI.Interfaces.IEngagement engagement in element.Engagements)
                this.Write(xmlWriter, engagement);
            if(element.StudyMode != null)
                this.Write(xmlWriter, element.StudyMode);
            if (element.AttendanceMode != null)
                this.Write(xmlWriter, element.AttendanceMode);
            if (element.AttendancePattern != null)
                this.Write(xmlWriter, element.AttendancePattern);
            foreach (string language in element.LanguagesOfInstruction)
                this._Write
                    (
                    xmlWriter,
                    "languageOfInstruction",
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                    language,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            foreach (string language in element.LanguagesOfAssessment)
                this._Write
                    (
                    xmlWriter,
                    "languageOfAssessment",
                    Configuration.Namespaces.XCRICAP12NamespaceUri,
                    language,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            if (String.IsNullOrEmpty(element.PlacesAvailable) == false)

                this._Write
                    (
                    xmlWriter,
                    "places",
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                    element.PlacesAvailable,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            if (String.IsNullOrEmpty(element.Cost) == false)

                this._Write
                    (
                    xmlWriter,
                    "cost",
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                    element.Cost,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            if (String.IsNullOrEmpty(element.AgeRange) == false)

                this._Write
                    (
                    xmlWriter,
                    "age",
                    Configuration.Namespaces.XCRICAP12NamespaceUri,
                    element.AgeRange,
                    false,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            foreach (XCRI.Interfaces.IVenue venue in element.Venues)
                this.Write(xmlWriter, venue);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IStudyMode element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            if (String.IsNullOrEmpty(element.Value))
                return;
            this._WriteStartElement(xmlWriter, "studyMode", Configuration.Namespaces.XCRICAP12NamespaceUri);
            string identifier = String.Empty;
            if (this._TryExtractStudyModeIdentifierFromRecommendedVocab(element.Value, out identifier))
                this._WriteAttribute
                    (
                    xmlWriter,
                    "identifier",
                    String.Empty,
                    identifier,
                    String.Empty
                    );
            xmlWriter.WriteValue(element.Value);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IEngagement element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "engagement",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendanceMode element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            if (String.IsNullOrEmpty(element.Value))
                return;
            this._WriteStartElement(xmlWriter, "attendanceMode", Configuration.Namespaces.XCRICAP12NamespaceUri);
            string identifier = String.Empty;
            if (this._TryExtractAttendanceModeIdentifierFromRecommendedVocab(element.Value, out identifier))
                this._WriteAttribute
                    (
                    xmlWriter,
                    "identifier",
                    String.Empty,
                    identifier,
                    String.Empty
                    );
            xmlWriter.WriteValue(element.Value);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            TimeSpan duration,
            string elementName,
            string elementNamespace
            )
        {
            if (duration == null)
                throw new ArgumentNullException("duration");
            this._WriteStartElement(xmlWriter, elementName, elementNamespace);
            this._WriteAttribute
                (
                xmlWriter,
                "interval",
                String.Empty,
                duration.ToISO8601(),
                String.Empty
                );
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendancePattern element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            if (String.IsNullOrEmpty(element.Value))
                return;
            this._WriteStartElement(xmlWriter, "attendancePattern", Configuration.Namespaces.XCRICAP12NamespaceUri);
            string identifier = String.Empty;
            if (this._TryExtractAttendancePatternIdentifierFromRecommendedVocab(element.Value, out identifier))
                this._WriteAttribute
                    (
                    xmlWriter,
                    "identifier",
                    String.Empty,
                    identifier,
                    String.Empty
                    );
            xmlWriter.WriteValue(element.Value);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IQualification element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement
                (
                xmlWriter, 
                "qualification",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
                );
            foreach (XCRI.Interfaces.XCRICAP12.IIdentifier identifier in element.Identifiers)
                this.Write(xmlWriter, identifier);
            foreach (XCRI.Interfaces.XCRICAP12.ITitle title in element.Titles)
                this.Write(xmlWriter, title);
            if(element.Abbreviation != null)
                this.Write(xmlWriter, element.Abbreviation);
            foreach (XCRI.Interfaces.XCRICAP12.IDescription desc in element.Descriptions)
                this.WriteDescription(xmlWriter, desc, "description", Configuration.Namespaces.DublinCoreNamespaceUri);
            if (element.EducationLevel != null)
                this.Write(xmlWriter, element.EducationLevel);
            if (element.Type != null)
                this.Write(xmlWriter, element.Type);
            if ((element.AwardedBy != null) && (element.AwardedBy.Count > 0))
                this.Write(xmlWriter, element.AwardedBy[0]);
            if ((element.AccreditedBy != null) && (element.AccreditedBy.Count > 0))
                this.Write(xmlWriter, element.AccreditedBy[0]);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IEducationLevel element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "educationLevel",
                Configuration.Namespaces.DublinCoreTermsNamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IQualificationAwardedBy element
            )
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "awardedBy",
                Configuration.Namespaces.XCRICAP12NamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IQualificationAccreditedBy element
            )
        {

            if (element == null)
                throw new ArgumentNullException("element");
            if ((element.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "accreditedBy",
                Configuration.Namespaces.XCRICAP12NamespaceUri,
                element.Value,
                element.RenderRaw,
                element.XsiTypeValue,
                element.XsiTypeValueNamespace,
                element.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IContributor contributor
            )
        {
            if (contributor == null)
                throw new ArgumentNullException("contributor");
            if ((contributor.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "contributor",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                contributor.Value,
                contributor.RenderRaw,
                contributor.XsiTypeValue,
                contributor.XsiTypeValueNamespace,
                contributor.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IDate date,
            string elementName,
            string elementNamespace
            )
        {
            if (date == null)
                throw new ArgumentNullException("date");
            if ((date.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, elementName, elementNamespace);
            this._WriteAttribute
                (
                xmlWriter,
                "dtf",
                String.Empty,
                date.Value.ToISO8601(),
                String.Empty
                );
            if (String.IsNullOrEmpty(date.DisplayValue) == false)
                xmlWriter.WriteString(date.DisplayValue);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ICatalog catalog
            )
        {
            if (catalog == null)
                throw new ArgumentNullException("catalog");
            if ((catalog.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "catalog", Configuration.Namespaces.XCRICAP12NamespaceUri);
            if (catalog.Generated.HasValue == false)
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP12NamespaceUri)))
                    xmlWriter.WriteAttributeString("generated", (new DateTimeOffset(DateTime.Now)).ToISO8601(true));
                else
                    xmlWriter.WriteAttributeString("generated", Configuration.Namespaces.XCRICAP12NamespaceUri, (new DateTimeOffset(DateTime.Now)).ToISO8601(true));
            else
                if (String.IsNullOrEmpty(xmlWriter.LookupPrefix(Configuration.Namespaces.XCRICAP12NamespaceUri)))
                    xmlWriter.WriteAttributeString("generated", catalog.Generated.Value.ToISO8601(true));
                else
                    xmlWriter.WriteAttributeString("generated", Configuration.Namespaces.XCRICAP12NamespaceUri, catalog.Generated.Value.ToISO8601(true));
            this.WriteXCRI12CommonElements(xmlWriter, catalog);
            foreach (XCRI.Interfaces.XCRICAP12.IProvider provider in catalog.Providers)
                if (provider != null)
                    this.Write(xmlWriter, provider);
            this._WriteEndElement(xmlWriter);

        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ILocation location
            )
        {
            if (location == null)
                throw new ArgumentNullException("location");
            if ((location.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "location", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri);
            
            if (String.IsNullOrEmpty(location.Postcode) == false)
                this._Write(xmlWriter, "postcode", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.Postcode, false, String.Empty, String.Empty, String.Empty);
            this.WriteLatitudeLongitude(xmlWriter, location.Latitude, location.Longitude);
            if (String.IsNullOrEmpty(location.Street) == false)
                this._Write(xmlWriter, "address", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.Street, false, String.Empty, String.Empty, String.Empty);
            if (String.IsNullOrEmpty(location.Town) == false)
                this._Write(xmlWriter, "address", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.Town, false, String.Empty, String.Empty, String.Empty);
            if (String.IsNullOrEmpty(location.PhoneNumber) == false)
                this._Write(xmlWriter, "phone", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.PhoneNumber, false, String.Empty, String.Empty, String.Empty);
            if (String.IsNullOrEmpty(location.FaxNumber) == false)
                this._Write(xmlWriter, "fax", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.FaxNumber, false, String.Empty, String.Empty, String.Empty);
            if (String.IsNullOrEmpty(location.EmailAddress) == false)
                this._Write(xmlWriter, "email", Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri, location.EmailAddress, false, String.Empty, String.Empty, String.Empty);
            if (location.Url != null)
                this.Write(xmlWriter, location.Url);
            this._WriteEndElement(xmlWriter);
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IDescription description
            )
        {
            this.WriteDescription
                (
                xmlWriter, 
                description,
                "description",
                Configuration.Namespaces.DublinCoreNamespaceUri
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IIdentifier identifier
            )
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");
            if ((identifier.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "identifier",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                identifier.Value,
                identifier.RenderRaw,
                identifier.XsiTypeValue,
                identifier.XsiTypeValueNamespace,
                identifier.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IImage image
            )
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if ((image.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            this._WriteStartElement(xmlWriter, "image", Configuration.Namespaces.XCRICAP12NamespaceUri);
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

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ISubject subject
            )
        {
            if (subject == null)
                throw new ArgumentNullException("subject");
            if ((subject.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            if (String.IsNullOrEmpty(subject.Value))
                return;
            base._Write
                (
                xmlWriter,
                "subject",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                subject.Value,
                subject.RenderRaw,
                subject.XsiTypeValue,
                subject.XsiTypeValueNamespace,
                subject.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.ITitle title
            )
        {
            if (title == null)
                throw new ArgumentNullException("title");
            if ((title.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "title",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                title.Value,
                title.RenderRaw,
                title.XsiTypeValue,
                title.XsiTypeValueNamespace,
                title.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.XCRICAP12.IType type
            )
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if ((type.CompatibleWith & XCRIProfiles.XCRI_v1_2) == 0)
                return;
            base._Write
                (
                xmlWriter,
                "type",
                Configuration.Namespaces.DublinCoreNamespaceUri,
                type.Value,
                type.RenderRaw,
                type.XsiTypeValue,
                type.XsiTypeValueNamespace,
                type.XmlLanguage
                );
        }

        public virtual void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri url
            )
        {
            if (url == null)
                throw new ArgumentNullException("url");
            base._Write
                (
                xmlWriter,
                "url",
                Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri,
                url.ToString(),
                true,
                null,
                null,
                null
                );
        }

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
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
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
                    Configuration.Namespaces.MetadataForLearningOpportunitiesNamespaceUri
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

        #region Protected virtual

        protected virtual bool _TryExtractStudyModeIdentifierFromRecommendedVocab(string studyMode, out string identifier)
        {
            identifier = String.Empty;
            try
            {
                XCRI.Interfaces.XCRICAP12.StudyModes studyModeEnum =
                    (XCRI.Interfaces.XCRICAP12.StudyModes)Enum.Parse
                        (
                        typeof(XCRI.Interfaces.XCRICAP12.StudyModes),
                        studyMode.ToLower().Replace(" ", String.Empty).Trim(),
                        true
                        );
                switch (studyModeEnum)
                {
                    case XCRI.Interfaces.XCRICAP12.StudyModes.NotKnown:
                        identifier = "NK";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.StudyModes.Flexible:
                        identifier = "FL";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.StudyModes.FullTime:
                        identifier = "FT";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.StudyModes.PartOfAFullTimeProgramme:
                        identifier = "PF";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.StudyModes.PartTime:
                        identifier = "PT";
                        return true;
                }
                return false;
            }
            catch
            {
                identifier = String.Empty;
                return false;
            }
        }

        protected virtual bool _TryExtractAttendancePatternIdentifierFromRecommendedVocab(string attendancePattern, out string identifier)
        {
            identifier = String.Empty;
            try
            {
                XCRI.Interfaces.XCRICAP12.AttendancePatterns attendancePatternEnum =
                    (XCRI.Interfaces.XCRICAP12.AttendancePatterns)Enum.Parse
                        (
                        typeof(XCRI.Interfaces.XCRICAP12.AttendancePatterns),
                        attendancePattern.ToLower().Replace(" ", String.Empty).Trim(),
                        true
                        );
                switch (attendancePatternEnum)
                {
                    case XCRI.Interfaces.XCRICAP12.AttendancePatterns.Daytime:
                        identifier = "DT";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendancePatterns.Evening:
                        identifier = "EV";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendancePatterns.DayOrBlockRelease:
                        identifier = "DR";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendancePatterns.Weekend:
                        identifier = "WE";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendancePatterns.Customised:
                        identifier = "CS";
                        return true;
                }
                return false;
            }
            catch
            {
                identifier = String.Empty;
                return false;
            }
        }

        protected virtual bool _TryExtractAttendanceModeIdentifierFromRecommendedVocab(string attendanceMode, out string identifier)
        {
            identifier = String.Empty;
            try
            {
                XCRI.Interfaces.XCRICAP12.AttendanceModes attendanceModeEnum =
                    (XCRI.Interfaces.XCRICAP12.AttendanceModes)Enum.Parse
                        (
                        typeof(XCRI.Interfaces.XCRICAP12.AttendanceModes),
                        attendanceMode.ToLower().Replace(" ", String.Empty).Trim(),
                        true
                        );
                switch (attendanceModeEnum)
                {
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.Campus:
                        identifier = "CM";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.DistanceWithAttendance:
                        identifier = "DA";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.DistanceWithoutAttendance:
                        identifier = "DS";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.FaceToFaceNonCampus:
                        identifier = "NC";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.MixedMode:
                        identifier = "MM";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.OnlineWithoutAttendance:
                        identifier = "ON";
                        return true;
                    case XCRI.Interfaces.XCRICAP12.AttendanceModes.WorkBased:
                        identifier = "WB";
                        return true;
                }
                return false;
            }
            catch
            {
                identifier = String.Empty;
                return false;
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
                if (value == null)
                    validType = true;
                if (value is XCRI.Interfaces.XCRICAP12.ICatalog)
                    validType = true;
                if (value is XCRI.Interfaces.XCRICAP12.IProvider)
                    validType = true;
                if (value is XCRI.Interfaces.XCRICAP12.ICourse)
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
