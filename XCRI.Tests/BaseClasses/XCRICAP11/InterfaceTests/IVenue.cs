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
    public abstract class IVenue : IOrganisation<XCRI.Interfaces.XCRICAP11.IVenue>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestAddress();
        }
        [TestMethod]
        public void TestAddress()
        {
            this.TestProperty<XCRI.Interfaces.ILocation>("Location", new XCRI.Location()
            {
                Street = "hello world"
            }, new XCRI.Location()
            {
                Street = "123 fake street"
            });
        }
    }
}
