using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.BaseClasses.XCRICAP11
{
    [TestClass]
    public class Provider : InterfaceTests.IProvider
    {
        [TestInitialize]
        public void Setup()
        {
            this.ToTest = new XCRI.Provider();
        }
    }
}
