using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        public void TestIGeneric(XCRI.Interfaces.XCRICAP11.IGeneric element, Func<XmlNode> func)
        {
            // Identifiers
            element.Identifiers.Add(new XCRI.Identifier() { Value = "hello world" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "identifier", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            element.Identifiers.Add(new XCRI.Identifier() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElements(n, "identifier", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, element.Identifiers.Count); }
            );

            // Titles
            element.Titles.Add(new XCRI.Title() { Value = "hello world" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "title", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            element.Titles.Add(new XCRI.Title() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElements(n, "title", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, element.Titles.Count); }
            );

            // Subjects
            element.Subjects.Add(new XCRI.Subject() { Value = "hello world" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "subject", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            element.Subjects.Add(new XCRI.Subject() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElements(n, "subject", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, element.Subjects.Count); }
            );

            // Descriptions
            element.Descriptions.Add(new XCRI.Description() { Value = "hello world" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "description", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            element.Descriptions.Add(new XCRI.Description() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                func(),
                (n) => { HasChildElements(n, "description", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, element.Descriptions.Count); }
            );

            // Url
            element.Url = new Uri("http://www.myeducationalinstitution.ac.uk");
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "url", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

            // Image
            element.Image = new Image() { Source = new Uri("http://www.myeducationalinstitution.ac.uk/images/logo.png") };
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "image", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

            // Resource Status
            element.ResourceStatus = ResourceStatus.Added;
            this.TestNode
                (
                func(),
                (n) => { HasAttributeWithValue(n, "recstatus", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, ((int)element.ResourceStatus).ToString()); }
            );

            element.ResourceStatus = ResourceStatus.Deleted;
            this.TestNode
                (
                func(),
                (n) => { HasAttributeWithValue(n, "recstatus", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, ((int)element.ResourceStatus).ToString()); }
            );

        }

    }
}
