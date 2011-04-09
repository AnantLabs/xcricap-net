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
        public void TestQualificationType()
        {

            XCRI.Interfaces.IQualificationType qualificationType = new XCRI.QualificationType()
            {
                Value = "Sample type"
            };

            this.TestNode
                (
                this.Generate(qualificationType),
                (n) => { HasCorrectNameAndNamespace(n, "type", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample type"); }
                );

        }

        [TestMethod]
        public void TestQualificationTypeXmlLang()
        {

            XCRI.Interfaces.IQualificationType qualificationType = new XCRI.QualificationType()
            {
                Value = "Sample type in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(qualificationType),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
