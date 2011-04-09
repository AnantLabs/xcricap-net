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
    public abstract class ILocation : IElement<XCRI.Interfaces.XCRICAP11.ILocation>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestStreet();
            this.TestTown();
            this.TestPostcode();
            this.TestLatitude();
            this.TestLongitude();
            this.TestPhoneNumber();
            this.TestFaxNumber();
            this.TestEmailAddress();
            this.TestUrl();
        }
        [TestMethod]
        public void TestPhoneNumber()
        {
            this.TestProperty<string>("PhoneNumber", "00000 000000", "01000 000000");
        }
        [TestMethod]
        public void TestFaxNumber()
        {
            this.TestProperty<string>("FaxNumber", "00000 000000", "01000 000000");
        }
        [TestMethod]
        public void TestEmailAddress()
        {
            this.TestProperty<string>("EmailAddress", "test@test.com", "bob@bob.com");
        }
        [TestMethod]
        public void TestUrl()
        {
            this.TestProperty<Uri>("Url", new Uri("http://www.craighawker.co.uk"), new Uri("http://www.xcri.co.uk"));
        }
        [TestMethod]
        public void TestStreet()
        {
            this.TestProperty<string>("Street", "hello world", "123 fake street");
        }
        [TestMethod]
        public void TestTown()
        {
            this.TestProperty<string>("Town", "hello world", "123 fake street");
        }
        [TestMethod]
        public void TestPostcode()
        {
            this.TestProperty<string>("Postcode", "abc 123", "123 abc");
        }
        [TestMethod]
        public void TestLatitude()
        {
            this.TestProperty<decimal?>("Latitude", 0.1m, 0.2m);
        }
        [TestMethod]
        public void TestLongitude()
        {
            this.TestProperty<decimal?>("Longitude", 0.1m, 0.2m);
        }
    }
}
