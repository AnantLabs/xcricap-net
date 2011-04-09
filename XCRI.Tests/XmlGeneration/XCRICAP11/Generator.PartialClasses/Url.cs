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
        public void TestUrl()
        {

            Uri test1 = new Uri("http://www.helloworld.com");
            this.TestNode
                (
                this.Generate(test1),
                (n) => { HasCorrectNameAndNamespace(n, "url", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, test1.ToString()); }
                );

        }

    }
}
