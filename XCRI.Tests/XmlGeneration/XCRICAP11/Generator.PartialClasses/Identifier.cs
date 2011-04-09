using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestIdentifier()
        {
            XCRI.Interfaces.IIdentifier ident = new XCRI.Identifier()
            {
                Value = "http://www.mydomain.com/"
            };
            this.TestNode
                (
                this.Generate(ident),
                (n) => { HasCorrectNameAndNamespace(n, "identifier", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "http://www.mydomain.com/"); }
                );

        }

        [TestMethod]
        public void TestIdentifierXmlLang()
        {
            XCRI.Interfaces.IIdentifier ident = new XCRI.Identifier()
            {
                Value = "http://www.mydomain.com/",
                XmlLanguage = "es"
            };
            this.TestNode
                (
                this.Generate(ident),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );
        }
        [TestMethod]
        public void TestIdentifierUKPRN()
        {
            XCRI.Interfaces.IIdentifier ident = new XCRI.Identifier()
            {
                Value = "12345678",
                XsiTypeValueNamespace = Configuration.Namespaces.UKRegisterOfLearningProvidersNamespaceUri,
                XsiTypeValue = "ukprn"
            };
            this.TestNode
                (
                this.Generate(ident),
                (n) => { ContainsStringValue(n, ident.Value); },
                (n) => { HasAttributeWithValueWithNamespace(n, "type", Configuration.Namespaces.XmlSchemaInstanceNamespaceUri, "ukprn", Configuration.Namespaces.UKRegisterOfLearningProvidersNamespaceUri); }
                );

        }

    }
}
