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
        public void TestQualificationLevel()
        {

            XCRI.Interfaces.IQualificationLevel qualificationLevel = new XCRI.QualificationLevel()
            {
                Value = "Sample level"
            };

            this.TestNode
                (
                this.Generate(qualificationLevel),
                (n) => { HasCorrectNameAndNamespace(n, "level", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample level"); }
                );

        }

        [TestMethod]
        public void TestQualificationLevelXmlLang()
        {

            XCRI.Interfaces.IQualificationLevel qualificationLevel = new XCRI.QualificationLevel()
            {
                Value = "Sample level in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(qualificationLevel),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
