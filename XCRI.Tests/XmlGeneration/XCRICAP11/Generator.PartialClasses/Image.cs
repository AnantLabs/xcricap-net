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
        public void TestImage()
        {

            XCRI.Interfaces.XCRICAP11.IImage image = new Image();

            this.TestNode
                (
                this.Generate(image),
                (n) => { HasCorrectNameAndNamespace(n, "image", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

        }

        [TestMethod]
        public void TestImageSource()
        {

            XCRI.Interfaces.XCRICAP11.IImage image = new Image();

            image.Source = new Uri("http://wwww.craighawker.co.uk/logo.gif");
            this.TestNode
                (
                this.Generate(image),
                (n) => { HasAttributeWithValue(n, "src", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, image.Source.ToString()); }
                );

        }

        [TestMethod]
        public void TestImageTitle()
        {

            XCRI.Interfaces.XCRICAP11.IImage image = new Image();

            image.Title = "hello world (title)";
            this.TestNode
                (
                this.Generate(image),
                (n) => { HasAttributeWithValue(n, "title", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, image.Title); }
                );

        }

        [TestMethod]
        public void TestImageAlt()
        {

            XCRI.Interfaces.XCRICAP11.IImage image = new Image();

            image.Alt = "hello world (alt)";
            this.TestNode
                (
                this.Generate(image),
                (n) => { HasAttributeWithValue(n, "alt", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, image.Alt); }
                );

        }

    }
}
