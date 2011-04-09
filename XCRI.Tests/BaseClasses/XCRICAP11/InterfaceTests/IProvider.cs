using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Tests.ExtensionMethods;
using XCRI.Tests.BaseClasses.InterfaceTests;

namespace XCRI.Tests.BaseClasses.XCRICAP11.InterfaceTests
{
    [TestClass]
    public abstract class IProvider : IOrganisation<XCRI.Interfaces.XCRICAP11.IProvider>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestReferenceNumber();
            this.TestAddress();
        }
        [TestMethod]
        public void TestReferenceNumber()
        {
            this.TestProperty<long?>("ReferenceNumber", 2, 4);
        }
        [TestMethod]
        public void TestAddress()
        {
            this.TestProperty<XCRI.Interfaces.ILocation>("Location", new XCRI.Location()
            {
                Street = "hello street"
            }, new XCRI.Location()
            { 
                Street = "hello world"
            });
        }
    }
}
