using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Tests.BaseClasses.InterfaceTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.BaseClasses
{
    [TestClass()]
    public abstract class IElement<T> : INotifyPropertyChangingAndINotifyPropertyChanged<XCRI.Interfaces.IElement>
        where T : XCRI.Interfaces.IElement
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestXsiTypeValue();
            this.TestXsiTypeValueNamespace();
            this.TestXmlLangauge();
            this.TestCompatibleWith();
        }
        [TestMethod]
        public void TestXsiTypeValue()
        {
            this.TestProperty<string>("XsiTypeValue", "123", "456");
        }
        [TestMethod]
        public void TestXsiTypeValueNamespace()
        {
            this.TestProperty<string>("XsiTypeValueNamespace", Configuration.Namespaces.XCRICAP11NamespaceUri, Configuration.Namespaces.XCRICAP11TermsNamespaceUri);
        }
        [TestMethod]
        public void TestXmlLangauge()
        {
            this.TestProperty<string>("XmlLanguage", "es", "en-gb");
        }
        [TestMethod]
        public void TestCompatibleWith()
        {
            this.TestProperty<XCRIProfiles>("CompatibleWith", XCRIProfiles.XCRI_v1_1, XCRIProfiles.XCRI_v1_2);
        }
    }
    [TestClass()]
    public abstract class IElementWithSingleValue<T> : IElement<T>
        where T : XCRI.Interfaces.IElementWithSingleValue
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestValue();
            this.TestRenderRaw();
        }
        [TestMethod]
        public void TestValue()
        {
            this.TestProperty<object>("Value", "123", "456");
        }
        [TestMethod]
        public void TestRenderRaw()
        {
            this.TestProperty<bool>("RenderRaw", true, false);
        }
    }
}
