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
        public void TestDescriptionTextContents()
        {

            this.TestNode
                (
                this.Generate(new XCRI.Description() { Value = "Sample description" }),
                (n) => { HasCorrectNameAndNamespace(n, "description", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { _TestTextDescriptionNodeContents(n, "Sample description"); }
                );

        }

        [TestMethod]
        public void TestDescriptionXhtmlContents()
        {
            this.TestNode
                (
                this.Generate(new XCRI.Description() { Value = "<p>Sample description</p>", ContentType = XCRI.Interfaces.DescriptionContentTypes.XHTML }),
                (n) => { HasCorrectNameAndNamespace(n, "description", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { _TestXHTMLDescriptionNodeContents(n, "<p>Sample description</p>"); }
                );

        }

        [TestMethod]
        public void TestDescriptionXmlLang()
        {

            this.TestNode
               (
                this.Generate(new XCRI.Description() { Value = "Sample description in Spanish", XmlLanguage = "es" }),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

        [TestMethod]
        public void TestDescriptionHref()
        {

            Uri href = new Uri("http://www.craighawker.co.uk/");
            this.TestNode
                (
                this.Generate(new XCRI.Description() { Href = href, ContentType = XCRI.Interfaces.DescriptionContentTypes.Href }),
                (n) => { HasAttributeWithValue(n, "href", Configuration.Namespaces.XCRICAP11NamespaceUri, href.ToString()); }
                );

        }

        [TestMethod]
        public void TestTermsDescription()
        {

            XCRI.Vocabularies.XCRICAP11.Terms.Description
                am = new XCRI.Vocabularies.XCRICAP11.Terms.Description();

            foreach (Vocabularies.XCRICAP11.Terms.DescriptionTypes dt in Enum.GetValues(typeof(Vocabularies.XCRICAP11.Terms.DescriptionTypes)))
            {
                am.XsiTypeValue = dt;
                if (am.XsiTypeValue != dt)
                    Assert.Fail("XCRI.Vocabularies.XCRICAP11.Terms.Description did not keep correct XsiTypeValue");
                this.TestNode
                    (
                    this.Generate(am),
                    (n) => { HasCorrectNameAndNamespace(n, "description", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                    (n) => { HasAttributeWithValueWithNamespace(n, "type", XCRI.Configuration.Namespaces.XmlSchemaInstanceNamespaceUri, dt.ToString(), XCRI.Configuration.Namespaces.XCRICAP11TermsNamespaceUri); }
                    );
            }

        }
        
        protected Action<XmlNode, string> _TestXHTMLDescriptionNodeContents = (n, expectedContents)
            =>
        {
            XmlNode divNode = n.FirstChild;
            if (divNode.LocalName != "div")
                Assert.Fail("The {0} node in {1} did not contain a <div> element", n.LocalName, n.NamespaceURI);
            if (divNode.NamespaceURI != Configuration.Namespaces.XHTMLNamespaceUri)
                Assert.Fail("The {0} node in {1} did not contain an XHTML <div> element", n.LocalName, n.NamespaceURI);
            string actualContents = divNode.OuterXml.Substring("<div xmlns=\"http://www.w3.org/1999/xhtml\">".Length);
            actualContents = actualContents.Substring(0, actualContents.Length - 6);
            if (!(actualContents == expectedContents))
                Assert.Fail("The {0} node in {1} element's XHTML div did not contain the correct encoded XHTML", n.LocalName, n.NamespaceURI);
        };
        protected Action<XmlNode, string> _TestTextDescriptionNodeContents = (n, expectedContents)
            =>
        {
            if (!(n.InnerXml == expectedContents))
                Assert.Fail("The {0} node in {1} element's XHTML div did not contain the correct encoded text", n.LocalName, n.NamespaceURI);
        };

    }
}
