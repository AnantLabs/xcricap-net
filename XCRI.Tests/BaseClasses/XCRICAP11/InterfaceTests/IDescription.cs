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
    public abstract class IDescription : IElementWithSingleValue<XCRI.Interfaces.XCRICAP11.IDescription>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestHref();
            this.TestContentType();
        }
        [TestMethod]
        public void TestHref()
        {
            this.TestProperty<Uri>("Href", new Uri("http://www.google.com"), new Uri("http://www.microsoft.com"));
        }
        [TestMethod]
        public void TestContentType()
        {
            Assert.IsTrue(this.TestProperty<XCRI.Interfaces.DescriptionContentTypes>("ContentType", XCRI.Interfaces.DescriptionContentTypes.XHTML, XCRI.Interfaces.DescriptionContentTypes.Text), "The ContentType property does not correctly fire INotifyPropertyChanging or INotifyPropertyChanged");
        }
    }
}
