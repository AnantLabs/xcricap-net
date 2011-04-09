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
        public void TestSubject()
        {

            Subject subject = new Subject() { Value = "Sample subject" };
            this.TestNode
                (
                this.Generate(subject),
                (n) => { HasCorrectNameAndNamespace(n, "subject", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample subject"); }
                );

        }

        [TestMethod]
        public void TestSubjectXmlLang()
        {

            Subject subject = new Subject() { Value = "Sample subject" };
            subject.XmlLanguage = "es";
            this.TestNode
                (
                this.Generate(subject),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
