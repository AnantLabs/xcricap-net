using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration.Interfaces
{
    public interface IXmlGenerator : XCRI.Interfaces.ICatalog
    {
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
    }
}
