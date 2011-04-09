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
        public void TestTitle()
        {

            XCRI.Interfaces.ITitle title = new XCRI.Title() { Value = "Sample title" };
            this.TestNode
                (
                this.Generate(title),
                (n) => { HasCorrectNameAndNamespace(n, "title", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample title"); }
                );
        }

        [TestMethod]
        public void TestTitleXmlLang()
        {
            XCRI.Interfaces.ITitle title = new XCRI.Title() { Value = "Sample title in Spanish", XmlLanguage = "es" };
            this.TestNode
                (
                this.Generate(title),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

    }
}
