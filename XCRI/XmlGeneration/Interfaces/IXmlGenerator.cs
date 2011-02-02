using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration.Interfaces
{
    public interface IXmlGenerator : XCRI.Interfaces.ICatalog
    {
        // Generate overloads
        void Generate
            (
            System.Xml.XmlWriter xmlWriter,
            NamespaceList namespaceList
            );
        void Generate
            (
            System.Xml.XmlWriter xmlWriter
            );
        void Generate
            (
            System.IO.StringWriter stringWriter,
            NamespaceList namespaceList
            );
        void Generate
            (
            System.IO.StringWriter stringWriter
            );
        void Generate
            (
            System.Text.StringBuilder stringBuilder,
            NamespaceList namespaceList
            );
        void Generate
            (
            System.Text.StringBuilder stringBuilder
            );

        // Write methods

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IIdentifier identifier
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ITitle title
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IDescription description
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ISubject subject
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri,
            string Namespace
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IImage image
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationLevel qualLevel
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationType qualType
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAwardedBy awardedBy
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy
            );

        /*
        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElement element
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElementWithChildElements element
            );

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IXmlElementWithSingleValue element
            );
        */

        void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IProvider provider
            );
    }
}
