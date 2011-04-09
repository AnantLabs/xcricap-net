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
        public void TestProvider()
        {

            XCRI.Interfaces.XCRICAP11.IProvider provider = new XCRI.Provider();

            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasCorrectNameAndNamespace(n, "provider", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

        }

        [TestMethod]
        public void TestProviderIOrganisation()
        {

            XCRI.Interfaces.XCRICAP11.IProvider provider = new XCRI.Provider();
            this.TestIOrganisation(provider, () => this.Generate(provider));

        }

        [TestMethod]
        public void TestProviderAddress()
        {

            XCRI.Interfaces.XCRICAP11.IProvider provider = new XCRI.Provider();

            provider.Location = new Location()
            {
                Street = "123 fake street",
                Town = "fakesborough",
                Postcode = "AB1 1AB"
            };

            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasChildElement(n, "street", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "street", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), provider.Location.Street); }
                );

            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasChildElement(n, "town", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "town", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), provider.Location.Town); }
                );

            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasChildElement(n, "postcode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(FindChildNode(n, "postcode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri), provider.Location.Postcode); }
                );

        }

        [TestMethod]
        public void TestProviderCourses()
        {

            XCRI.Interfaces.XCRICAP11.IProvider provider = new XCRI.Provider();

            provider.Courses.Add(new Course());
            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasChildElement(n, "course", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

            provider.Courses.Add(new Course());
            this.TestNode
                (
                this.Generate(provider),
                (n) => { HasChildElements(n, "course", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, provider.Courses.Count); }
                );

        }

    }
}
