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
    public abstract class IImage : IElement<XCRI.Interfaces.XCRICAP11.IImage>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestSource();
            this.TestTitle();
            this.TestAlt();
        }
        [TestMethod]
        public void TestSource()
        {
            this.TestProperty<Uri>("Source", new Uri("abc.gif", UriKind.Relative), new Uri("xyz.gif", UriKind.Relative));
        }
        [TestMethod]
        public void TestTitle()
        {
            this.TestProperty<string>("Title", "hello world", "123 456");
        }
        [TestMethod]
        public void TestAlt()
        {
            this.TestProperty<string>("Alt", "hello world", "123 456");
        }
    }
}
