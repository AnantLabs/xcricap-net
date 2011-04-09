using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Tests.BaseClasses.InterfaceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.BaseClasses.XCRICAP11.InterfaceTests
{
    [TestClass()]
    public abstract class IGeneric<T> : IElement<XCRI.Interfaces.XCRICAP11.IGeneric>
        where T : XCRI.Interfaces.XCRICAP11.IGeneric
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestUrl();
            this.TestImage();
            this.TestResourceStatus();
        }
        [TestMethod]
        public void TestUrl()
        {
            this.TestProperty<Uri>("Url", new Uri("http://www.google.com"), new Uri("http://www.microsoft.com"));
        }
        [TestMethod]
        public void TestImage()
        {
            this.TestProperty<XCRI.Interfaces.IImage>("Image", new XCRI.Image() { Source = new Uri("abc.gif", UriKind.Relative) }, new XCRI.Image() { Source = new Uri("xyz.gif", UriKind.Relative) });
        }
        [TestMethod]
        public void TestResourceStatus()
        {
            this.TestProperty<ResourceStatus>("ResourceStatus", ResourceStatus.Added, ResourceStatus.Deleted);
        }
    }
}
