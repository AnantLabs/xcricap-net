using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlGeneration.Interfaces
{
    public interface IXmlGenerator
    {
        void Generate
            (
            System.Xml.XmlWriter xmlWriter,
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            );
        void Generate
            (
            System.Xml.XmlWriter xmlWriter,
            params XCRI.Interfaces.IProvider[] Providers
            );
        void Generate
            (
            System.IO.StringWriter stringWriter,
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            );
        void Generate
            (
            System.IO.StringWriter stringWriter,
            params XCRI.Interfaces.IProvider[] Providers
            );
        void Generate
            (
            System.Text.StringBuilder stringBuilder,
            NamespaceList namespaceList,
            params XCRI.Interfaces.IProvider[] Providers
            );
        void Generate
            (
            System.Text.StringBuilder stringBuilder,
            params XCRI.Interfaces.IProvider[] Providers
            );
    }
}
