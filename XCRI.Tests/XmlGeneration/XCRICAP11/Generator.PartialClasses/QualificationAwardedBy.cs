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
        public void TestQualificationAwardedBy()
        {

            XCRI.Interfaces.IQualificationAwardedBy awardedBy = new XCRI.QualificationAwardedBy()
            {
                Value = "Sample awarded by"
            };

            this.TestNode
                (
                this.Generate(awardedBy),
                (n) => { HasCorrectNameAndNamespace(n, "awardedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample awarded by"); }
                );

        }

        [TestMethod]
        public void TestQualificationAwardedByXmlLang()
        {

            XCRI.Interfaces.IQualificationAwardedBy awardedBy = new XCRI.QualificationAwardedBy()
            {
                Value = "Sample awarded by in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(awardedBy),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
