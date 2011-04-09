using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        public void TestIOrganisation(XCRI.Interfaces.XCRICAP11.IOrganisation element, Func<XmlNode> func)
        {

            // Test base
            this.TestIGeneric((XCRI.Interfaces.XCRICAP11.IGeneric)element, func);

            element.PhoneNumber = "01000 000000";
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "phone", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "phone", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), element.PhoneNumber); }
                );

            element.FaxNumber = "01000 000000";
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "fax", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "fax", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), element.FaxNumber); }
                );

            element.EmailAddress = "test@test.com";
            this.TestNode
                (
                func(),
                (n) => { HasChildElement(n, "email", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "email", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), element.EmailAddress); }
                );

        }

    }
}
