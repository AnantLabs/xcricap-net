using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Interfaces;
using XCRI.XmlBaseClasses;

namespace XCRI.XmlGeneration
{
    public abstract class XmlGeneratorBase : NotifyBaseClass, Interfaces.IXmlGenerator

    {

        #region Constructors

        #region Protected

        protected XmlGeneratorBase()
            : base()
        {
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Private

        private NamespaceList __Namespaces = NamespaceList.GetNamespaces(NamespaceList.Namespaces.None);
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;
        private IElement __RootElement = null;
        private bool __WrittenRootNode = false;

        #endregion

        #region Protected

        protected IElement _RootElement
        {
            get { return this.__RootElement; }
            set
            {
                if (this.__RootElement == value)
                    return;
                this.OnPropertyChanging("RootElement");
                this.__RootElement = value;
                this.OnPropertyChanged("RootElement");
            }
        }

        protected bool _WrittenRootNode
        {
            get { return this.__WrittenRootNode; }
            set
            {
                if (this.__WrittenRootNode == value) { return; }
                this.OnPropertyChanging("WrittenRootNode");
                this.__WrittenRootNode = value;
                this.OnPropertyChanged("WrittenRootNode");
            }
        }

        protected ResourceStatus _ResourceStatus
        {
            get { return this.__ResourceStatus; }
            set
            {
                if (this.__ResourceStatus == value) { return; }
                this.OnPropertyChanging("ResourceStatus");
                this.__ResourceStatus = value;
                this.OnPropertyChanged("ResourceStatus");
            }
        }

        protected NamespaceList _Namespaces
        {
            get { return this.__Namespaces; }
            set
            {
                if (this.__Namespaces == value)
                    return;
                this.OnPropertyChanging("Namespaces");
                this.__Namespaces = value;
                this.OnPropertyChanged("Namespaces");
            }
        }

        #endregion

        #endregion

        #region IXmlGenerator Members

        public abstract IElement RootElement { get; set; }

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public NamespaceList Namespaces
        {
            get { return this._Namespaces; }
        }

        public abstract void Generate
            (
            System.Xml.XmlWriter xmlWriter
            );

        public void Generate
            (
            System.IO.TextWriter textWriter
            )
        {
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.OmitXmlDeclaration = true;
            using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(textWriter, xmlWriterSettings))
            {
                this.Generate(xmlWriter);
            }
        }

        public void Generate
            (
            System.IO.StringWriter stringWriter
            )
        {
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.ConformanceLevel = System.Xml.ConformanceLevel.Document;
            using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(stringWriter, xmlWriterSettings))
            {
                this.Generate(xmlWriter);
            }
        }

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IStudyMode studyMode
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendanceMode attendanceMode
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendancePattern attendancePattern
            );

        public void Generate
            (
            System.Text.StringBuilder stringBuilder
            )
        {
            using (System.IO.StringWriter writer = new System.IO.StringWriter(stringBuilder))
            {
                this.Generate(writer);
            }
        }

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IIdentifier identifier
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ITitle title
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IDescription description
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ISubject subject
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICatalog catalog
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IImage image
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationLevel qualLevel
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationType qualType
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAwardedBy awardedBy
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IProvider provider
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            ResourceStatus resourceStatus
            );

        #endregion

        #region Methods

        #region Protected virtual

        protected virtual void _WriteXmlLanguageAttribute
            (
            System.Xml.XmlWriter xmlWriter,
            string xmlLanguage
            )
        {
            this._WriteAttribute
                (
                xmlWriter,
                "xml:lang",
                String.Empty,
                xmlLanguage,
                String.Empty
                );
        }

        protected virtual void _WriteXsiTypeAttribute
            (
            System.Xml.XmlWriter xmlWriter,
            string xsiTypeValue,
            string xsiTypeValueNamespace
            )
        {
            this._WriteAttribute
                (
                xmlWriter,
                "type",
                Configuration.Namespaces.XmlSchemaInstanceNamespaceUri,
                xsiTypeValue,
                xsiTypeValueNamespace
                );
        }

        protected virtual void _WriteAttribute
            (
            System.Xml.XmlWriter xmlWriter,
            string attributeName,
            string attributeNamespace,
            string attributeValue,
            string attributeValueNamespace
            )
        {
            if (String.IsNullOrEmpty(attributeValue))
                return;
            if (attributeName.Contains(":"))
            {
                xmlWriter.WriteStartAttribute
                    (
                    attributeName.Substring(0, attributeName.IndexOf(":")),
                    attributeName.Substring(attributeName.IndexOf(":")+1),
                    String.Empty
                    );
            }
            else
            {
                xmlWriter.WriteStartAttribute
                    (
                    attributeName,
                    attributeNamespace
                    );
            }
            if (String.IsNullOrEmpty(attributeValueNamespace))
                xmlWriter.WriteString(attributeValue);
            else
                xmlWriter.WriteString(String.Format
                    (
                    "{0}:{1}",
                    xmlWriter.LookupPrefix(attributeValueNamespace),
                    attributeValue
                    ));
            xmlWriter.WriteEndAttribute();
        }

        protected virtual void _WriteEndElement
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            xmlWriter.WriteEndElement();
        }

        protected virtual void _WriteStartElement
            (
            System.Xml.XmlWriter xmlWriter,
            string elementName,
            string elementNamespace
            )
        {
            if (
                String.IsNullOrEmpty(elementNamespace)
                )
            {
                xmlWriter.WriteStartElement
                    (
                    elementName
                    );
            }
            else
            {
                xmlWriter.WriteStartElement
                    (
                    elementName,
                    elementNamespace
                    );
            }
            if (this.__WrittenRootNode == false)
            {

                if (this.Namespaces != null)
                {
                    StringBuilder schemaLocation = new StringBuilder();
                    foreach (NamespaceData ns in this.Namespaces)
                    {
                        if (String.IsNullOrEmpty(ns.NamespaceUri) == true)
                            continue;
                        if (
                            (String.IsNullOrEmpty(ns.Prefix) == false)
                            && 
                            (ns.NamespaceUri != elementNamespace)
                            )
                            xmlWriter.WriteAttributeString("xmlns", ns.Prefix, null, ns.NamespaceUri);
                        if (String.IsNullOrEmpty(ns.XSDLocation) == false)
                            schemaLocation.AppendFormat("{0} {1} ", ns.NamespaceUri, ns.XSDLocation);
                    }
                    xmlWriter.WriteAttributeString("xsi", "schemaLocation", null, schemaLocation.ToString().Trim());
                }
            }
            this.__WrittenRootNode = true;
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            string elementName,
            string elementNamespace,
            string elementValue,
            bool renderRaw,
            string xsiType,
            string xsiTypeNamespace,
            string xmlLanguage
            )
        {
            this._WriteStartElement(xmlWriter, elementName, elementNamespace);
            this._WriteXsiTypeAttribute
                (
                xmlWriter,
                xsiType,
                xsiTypeNamespace
                );
            this._WriteXmlLanguageAttribute
                (
                xmlWriter,
                xmlLanguage
                );
            if (!String.IsNullOrEmpty(elementValue))
            {
                if (renderRaw)
                    xmlWriter.WriteRaw
                        (
                        elementValue
                        );
                else
                    xmlWriter.WriteValue
                        (
                        elementValue
                        );
            }
            this._WriteEndElement(xmlWriter);
        }

        #endregion
        
        #endregion


    }
}
