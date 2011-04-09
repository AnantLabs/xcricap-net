using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Vocabularies.XCRICAP11.Terms;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestStudyMode()
        {

            XCRI.Interfaces.IStudyMode studyMode = new XCRI.StudyMode()
            {
                Value = "Sample study mode (no terms)"
            };
            this.TestNode
                (
                this.Generate(studyMode),
                (n) => { HasCorrectNameAndNamespace(n, "studyMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample study mode (no terms)"); }
                );

        }

        [TestMethod]
        public void TestStudyModeXmlLang()
        {
            XCRI.Interfaces.IStudyMode studyMode = new XCRI.StudyMode()
            {
                Value = "Sample study mode (no terms) in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(studyMode),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

        [TestMethod]
        public void TestTermsStudyMode()
        {

            XCRI.Vocabularies.XCRICAP11.Terms.StudyMode
                am = new XCRI.Vocabularies.XCRICAP11.Terms.StudyMode();

            foreach (Vocabularies.XCRICAP11.Terms.StudyModeTypes smt in Enum.GetValues(typeof(Vocabularies.XCRICAP11.Terms.StudyModeTypes)))
            {
                am.Value = smt;
                this.TestNode
                    (
                    this.Generate(am),
                    (n) => { HasCorrectNameAndNamespace(n, "studyMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                    (n) => { ContainsStringValue(n, smt.ToXCRIString()); }
                    );
            }

        }

    }
}
