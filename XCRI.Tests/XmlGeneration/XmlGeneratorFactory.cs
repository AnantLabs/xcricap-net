using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.XmlGeneration
{
    [TestClass]
    public class XmlGeneratorFactory
    {
        [TestMethod]
        public void CheckXCRI11()
        {
            XCRI.XmlGeneration.Interfaces.IXmlGenerator gen
                = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRIProfiles.XCRI_v1_1);
            if (gen == null)
                Assert.Fail("XmlGeneratorFactory did not return a generator for XCRI 1.1");
            if (!(gen is XCRI.XmlGeneration.XCRICAP11.Generator))
                Assert.Fail("XmlGeneratorFactory did not return an instance of XmlGeneration.XCRICAP11.Generator when expected");
        }
        [TestMethod]
        public void CheckXCRI12()
        {
            XCRI.XmlGeneration.Interfaces.IXmlGenerator gen
                = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRIProfiles.XCRI_v1_2);
            if (gen == null)
                Assert.Fail("XmlGeneratorFactory did not return a generator for XCRI 1.2");
            if (!(gen is XCRI.XmlGeneration.XCRICAP12.Generator))
                Assert.Fail("XmlGeneratorFactory did not return an instance of XmlGeneration.XCRICAP12.Generator when expected");
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void CheckNoProfile()
        {
            XCRI.XmlGeneration.Interfaces.IXmlGenerator gen
                = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRIProfiles.None);
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void CheckAllProfiles()
        {
            XCRI.XmlGeneration.Interfaces.IXmlGenerator gen
                = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRIProfiles.All);
        }
    }
}
