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
        public void TestQualificationAccreditedBy()
        {

            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy = new XCRI.QualificationAccreditedBy()
            {
                Value = "Sample accredited by"
            };

            this.TestNode
                (
                this.Generate(accreditedBy),
                (n) => { HasCorrectNameAndNamespace(n, "accreditedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample accredited by"); }
                );

        }

        [TestMethod]
        public void TestQualificationAccreditedByXmlLang()
        {

            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy = new XCRI.QualificationAccreditedBy()
            {
                Value = "Sample accredited by in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(accreditedBy),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
