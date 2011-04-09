using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestAddress()
        {

            XCRI.Interfaces.ILocation address = new Location();
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count > 0) { Assert.Fail("Address should have been empty"); } }
                );

        }

        [TestMethod]
        public void TestAddressLatitude()
        {

            XCRI.Interfaces.ILocation address = new Location();

            address.Latitude = 51.500612m;
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "address", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.Latitude.Value.ToString()); },
                (n) => { HasAttributeWithValueWithNamespace(n.Last(), "type", XCRI.Configuration.Namespaces.XmlSchemaInstanceNamespaceUri, "lat", XCRI.Configuration.Namespaces.GeolocationNamespaceUri); }
                );

        }

        [TestMethod]
        public void TestAddressLongitude()
        {

            XCRI.Interfaces.ILocation address = new Location();

            address.Longitude = -0.124637m;
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "address", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.Longitude.Value.ToString()); },
                (n) => { HasAttributeWithValueWithNamespace(n.Last(), "type", XCRI.Configuration.Namespaces.XmlSchemaInstanceNamespaceUri, "long", XCRI.Configuration.Namespaces.GeolocationNamespaceUri); }
                );

        }

        [TestMethod]
        public void TestAddressStreet()
        {

            XCRI.Interfaces.ILocation address = new Location();

            address.Street = "123 fake street";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "street", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.Street); }
                );

        }

        [TestMethod]
        public void TestAddressTown()
        {

            XCRI.Interfaces.ILocation address = new Location();

            address.Town = "fakesborough";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "town", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.Town); }
                );

        }

        [TestMethod]
        public void TestAddressPostcode()
        {

            XCRI.Interfaces.ILocation address = new Location();

            address.Postcode = "AB1 1AB";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "postcode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.Postcode); }
                );

        }

        /*
        [TestMethod]
        public void TestAddressPhoneNumber()
        {

            XCRI.Interfaces.IAddress address = new Address();

            address.PhoneNumber = "00000 000000";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "phone", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.PhoneNumber); }
                );

        }

        [TestMethod]
        public void TestAddressFaxNumber()
        {

            XCRI.Interfaces.IAddress address = new Address();

            address.FaxNumber = "00000 000000";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "fax", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.FaxNumber); }
                );

        }

        [TestMethod]
        public void TestAddressEmailAddress()
        {

            XCRI.Interfaces.IAddress address = new Address();

            address.EmailAddress = "test@test.com";
            this.TestNodes
                (
                this.Generate(address),
                (n) => { if ((new List<XmlNode>(n)).Count != 1) { Assert.Fail("Address should only have one element"); } },
                (n) => { HasCorrectNameAndNamespace(n.Last(), "email", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n.Last(), address.EmailAddress); }
                );

        }
        */

    }
}
