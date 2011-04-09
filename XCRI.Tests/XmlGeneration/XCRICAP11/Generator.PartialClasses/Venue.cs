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
        public void TestVenue()
        {

            XCRI.Venue venue = new Venue();
            this.TestNode
                (
                this.Generate(venue),
                (n) => { HasCorrectNameAndNamespace(n, "venue", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

        }

        [TestMethod]
        public void TestVenueIOrganisation()
        {

            XCRI.Venue venue = new Venue();
            this.TestIOrganisation(venue, () => this.Generate(venue));

        }

    }
}
