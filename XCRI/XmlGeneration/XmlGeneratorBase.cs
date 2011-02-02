using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Interfaces;

namespace XCRI.XmlGeneration
{
    public abstract class XmlGeneratorBase : NotifyBaseClass, Interfaces.IXmlGenerator, XCRI.Interfaces.ICatalog

    {

        #region Constructors

        #region Protected

        protected XmlGeneratorBase()
            : base()
        {
        }

        #endregion

        #endregion

        #region IXmlGenerator Members

        public virtual void Generate
            (
            System.Xml.XmlWriter xmlWriter,
            NamespaceList namespaceList
            )
        {
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement("catalog", Configuration.XCRICAP11NamespaceUri);
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
            this._Write(xmlWriter, this as ICatalog);
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
        }

        public void Generate
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            this.Generate(xmlWriter, Configuration.StandardNamespaces);
        }

        public void Generate
            (
            System.IO.StringWriter stringWriter,
            NamespaceList namespaceList
            )
        {
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.ConformanceLevel = System.Xml.ConformanceLevel.Document;
            using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(stringWriter, xmlWriterSettings))
            {
                this.Generate(xmlWriter, namespaceList);
            }
        }

        public void Generate
            (
            System.IO.StringWriter stringWriter
            )
        {
            this.Generate(stringWriter, Configuration.StandardNamespaces);
        }

        public void Generate
            (
            System.Text.StringBuilder stringBuilder,
            NamespaceList namespaceList
            )
        {
            using (System.IO.StringWriter writer = new System.IO.StringWriter(stringBuilder))
            {
                this.Generate(writer, namespaceList);
            }
        }

        public void Generate
            (
            System.Text.StringBuilder stringBuilder
            )
        {
            this.Generate(stringBuilder, Configuration.StandardNamespaces);
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
            Uri uri
            );

        public abstract void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri,
            string Namespace
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

        #endregion

        #region Methods

        #region Protected virtual

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            ResourceStatus resourceStatus
            )
        {
            if (resourceStatus == ResourceStatus.Unknown)
                return;
            xmlWriter.WriteAttributeString
                (
                "recstatus",
                Configuration.XCRICAP11NamespaceUri,
                ((int)resourceStatus).ToString()
                );
        }

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
                Configuration.XMLSchemaInstanceNamespaceUri,
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
        }

        protected virtual void _Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICatalog catalog
            )
        {
            if(catalog.Generated.HasValue == false)
                xmlWriter.WriteAttributeString("generated", DateTime.Now.ToXCRIString());
            else
                xmlWriter.WriteAttributeString("generated", catalog.Generated.Value.ToXCRIString());
            foreach (XCRI.Interfaces.IIdentifier identifier in catalog.Identifiers)
                this.Write(xmlWriter, identifier);
            foreach (XCRI.Interfaces.ITitle title in catalog.Titles)
                this.Write(xmlWriter, title);
            foreach (XCRI.Interfaces.IDescription description in catalog.Descriptions)
                this.Write(xmlWriter, description);
            if (catalog.Url != null)
                this.Write(xmlWriter, catalog.Url);
            if (catalog.Image != null)
                this.Write(xmlWriter, catalog.Image);
            foreach (XCRI.Interfaces.IProvider provider in catalog.Providers)
                this.Write(xmlWriter, provider);
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
            if (String.IsNullOrEmpty(elementValue))
                return;
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
            this._WriteEndElement(xmlWriter);
        }

        #endregion
        
        #endregion

        #region Properties and Fields

        #region Private

        private DateTime? __Generated = null;
        private ResourceStatus __RecStatus = ResourceStatus.Unknown;
        private List<IIdentifier> __Identifiers = new List<IIdentifier>();
        private List<ITitle> __Titles = new List<ITitle>();
        private List<ISubject> __Subjects = new List<ISubject>();
        private List<IDescription> __Descriptions = new List<IDescription>();
        private Uri __Url = null;
        private Image __Image = new Image();
        private List<IProvider> __Providers = new List<IProvider>();

        #endregion

        #region Protected

        protected DateTime? _Generated
        {
            get { return this.__Generated; }
            set
            {
                if (this.__Generated == value)
                    return;
                this.OnPropertyChanging("Generated");
                this.__Generated = value;
                this.OnPropertyChanged("Generated");
            }
        }

        protected ResourceStatus _RecStatus
        {
            get { return this.__RecStatus; }
            set
            {
                if (this.__RecStatus == value)
                    return;
                this.OnPropertyChanging("RecStatus");
                this.__RecStatus = value;
                this.OnPropertyChanged("RecStatus");
            }
        }

        protected List<IIdentifier> _Identifiers
        {
            get { return this.__Identifiers; }
        }

        protected List<ITitle> _Titles
        {
            get { return this.__Titles; }
        }

        protected List<ISubject> _Subjects
        {
            get { return this.__Subjects; }
        }

        protected List<IDescription> _Descriptions
        {
            get { return this.__Descriptions; }
        }

        protected Uri _Url
        {
            get { return this.__Url; }
            set
            {
                if (this.__Url == value)
                    return;
                this.OnPropertyChanging("Url");
                this.__Url = value;
                this.OnPropertyChanged("Url");
            }
        }

        protected Image _Image
        {
            get { return this.__Image; }
            set
            {
                if (this.__Image == value)
                    return;
                this.OnPropertyChanging("Image");
                this.__Image = value;
                this.OnPropertyChanged("Image");
            }
        }

        protected List<IProvider> _Providers 
        {
            get { return this.__Providers; }
        }

        #endregion

        #endregion

        #region ICatalog Members

        public DateTime? Generated
        {
            get { return this._Generated; }
            set { this._Generated = value; }
        }

        public ResourceStatus RecStatus
        {
            get { return this._RecStatus; }
            set { this._RecStatus = value; }
        }

        public IList<IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

        public IList<ITitle> Titles
        {
            get { return this._Titles; }
        }

        public IList<XCRI.Interfaces.ISubject> Subjects
        {
            get { return this._Subjects; }
        }

        public IList<XCRI.Interfaces.IDescription> Descriptions
        {
            get { return this._Descriptions; }
        }

        public Uri Url
        {
            get { return this._Url; }
        }

        public Image Image
        {
            get { return this._Image; }
        }

        public IList<XCRI.Interfaces.IProvider> Providers
        {
            get { return this._Providers; }
        }

        #endregion

    }
}
