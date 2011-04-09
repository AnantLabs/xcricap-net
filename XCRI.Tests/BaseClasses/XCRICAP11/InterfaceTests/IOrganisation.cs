using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Tests.BaseClasses.InterfaceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.BaseClasses.XCRICAP11.InterfaceTests
{
    [TestClass()]
    public abstract class IOrganisation<T> : IGeneric<XCRI.Interfaces.XCRICAP11.IOrganisation>
        where T : XCRI.Interfaces.XCRICAP11.IOrganisation
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestPhoneNumber();
            this.TestFaxNumber();
            this.TestEmailAddress();
        }
        [TestMethod]
        public void TestPhoneNumber()
        {
            this.TestProperty<string>("PhoneNumber", "01000 000000", "02000 000000");
        }
        [TestMethod]
        public void TestFaxNumber()
        {
            this.TestProperty<string>("FaxNumber", "01000 000000", "02000 000000");
        }
        [TestMethod]
        public void TestEmailAddress()
        {
            this.TestProperty<string>("EmailAddress", "test@test.com", "test123@test123.com");
        }
    }
}
