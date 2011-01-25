using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration
{
    public abstract class XmlGeneratorBase : Interfaces.IXmlGenerator
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

        public abstract void Generate
            (
            System.Xml.XmlWriter xmlWriter, 
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            );

        public void Generate
            (
            System.Xml.XmlWriter xmlWriter,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            this.Generate(xmlWriter, Configuration.StandardNamespaces, Providers);
        }

        public void Generate
            (
            System.IO.StringWriter stringWriter,
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.ConformanceLevel = System.Xml.ConformanceLevel.Document;
            using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(stringWriter, xmlWriterSettings))
            {
                this.Generate(xmlWriter, namespaceList, Providers);
            }
        }

        public void Generate
            (
            System.IO.StringWriter stringWriter,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            this.Generate(stringWriter, Configuration.StandardNamespaces, Providers);
        }

        public void Generate
            (
            System.Text.StringBuilder stringBuilder,
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            using (System.IO.StringWriter writer = new System.IO.StringWriter(stringBuilder))
            {
                this.Generate(writer, namespaceList, Providers);
            }
        }

        public void Generate
            (
            System.Text.StringBuilder stringBuilder,
            params XCRI.Interfaces.IProvider[] Providers
            )
        {
            this.Generate(stringBuilder, Configuration.StandardNamespaces, Providers);
        }

        #endregion

        #region Methods

        #region Protected virtual

        protected virtual void _WriteAttribute(System.Xml.XmlWriter xmlWriter, XmlBaseClasses.Attribute attribute)
        {
            if (String.IsNullOrEmpty(attribute.Value))
                return;
            if (String.IsNullOrEmpty(attribute.AttributeNamespace))
            {
                xmlWriter.WriteAttributeString
                    (
                    attribute.AttributeName,
                    attribute.Value
                    );
            }
            else
            {
                xmlWriter.WriteStartAttribute
                    (
                    attribute.AttributeName,
                    attribute.AttributeNamespace
                    );
                xmlWriter.WriteString(attribute.Value);
                xmlWriter.WriteEndAttribute();
            }
        }

        protected virtual void _WriteAttribute(System.Xml.XmlWriter xmlWriter, XmlBaseClasses.XsiTypeAttribute attribute)
        {
            if (String.IsNullOrEmpty(attribute.AttributeNamespace))
            {
                this._WriteAttribute(xmlWriter, attribute as XmlBaseClasses.Attribute);
                return;
            }
            else
            {
                if (String.IsNullOrEmpty(attribute.Value))
                    return;
                xmlWriter.WriteStartAttribute
                    (
                    attribute.AttributeName,
                    attribute.AttributeNamespace
                    );
                if (String.IsNullOrEmpty(attribute.AttributeValueNamespace))
                    xmlWriter.WriteString(attribute.Value);
                else
                {
                    string prefix = xmlWriter.LookupPrefix(attribute.AttributeValueNamespace);
                    xmlWriter.WriteString(String.Format
                        (
                        "{0}:{1}",
                        prefix,
                        attribute.Value
                        ));
                }
                xmlWriter.WriteEndAttribute();
            }
        }

        protected virtual void _WriteEndElement(System.Xml.XmlWriter xmlWriter)
        {
            xmlWriter.WriteEndElement();
        }

        protected virtual void _WriteStartElement
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElement element
            )
        {
            if (
                String.IsNullOrEmpty(element.ElementNamespace)
                )
            {
                xmlWriter.WriteStartElement
                    (
                    element.ElementName
                    );
            }
            else
            {
                xmlWriter.WriteStartElement
                    (
                    element.ElementName,
                    element.ElementNamespace
                    );
            }
            if (element.Attributes != null)
                this._WriteAttributes(xmlWriter, element.Attributes);
            this._WriteAttribute(xmlWriter, element.XsiType);
        }

        protected virtual void _WriteAttributes(System.Xml.XmlWriter xmlWriter, IEnumerable<XCRI.Interfaces.IXmlAttribute> attributes)
        {
            foreach (XmlBaseClasses.Attribute attribute in attributes)
            {
                this._WriteAttribute(xmlWriter, attribute);
            }
        }

        #endregion

        #endregion

    }
}
