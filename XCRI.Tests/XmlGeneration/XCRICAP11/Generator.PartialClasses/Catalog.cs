using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.ExtensionMethods;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestCatalog()
        {

            XCRI.Interfaces.XCRICAP11.ICatalog catalog = new XCRI.Catalog();

            this.TestNode
                (
                this.Generate(catalog),
                (n) => { HasCorrectNameAndNamespace(n, "catalog", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

        }

        [TestMethod]
        public void TestCatalogIGeneric()
        {

            XCRI.Interfaces.XCRICAP11.ICatalog catalog = new Catalog();
            this.TestIGeneric(catalog, () => this.Generate(catalog));

        }

        [TestMethod]
        public void TestCatalogGenerated()
        {

            XCRI.Interfaces.XCRICAP11.ICatalog catalog = new XCRI.Catalog();

            catalog.Generated = DateTime.UtcNow;
            this.TestNode
                (
                this.Generate(catalog),
                (n) => { HasAttributeWithValue(n, "generated", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, catalog.Generated.Value.ToISO8601()); }
                );

        }

        [TestMethod]
        public void TestCatalogProviders()
        {

            XCRI.Interfaces.XCRICAP11.ICatalog catalog = new XCRI.Catalog();

            catalog.Providers.Add(new Provider());
            this.TestNode
                (
                this.Generate(catalog),
                (n) => { HasChildElement(n, "provider", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

            catalog.Providers.Add(new Provider());
            this.TestNode
                (
                this.Generate(catalog),
                (n) => { HasChildElements(n, "provider", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, catalog.Providers.Count); }
                );

        }

    }
}
