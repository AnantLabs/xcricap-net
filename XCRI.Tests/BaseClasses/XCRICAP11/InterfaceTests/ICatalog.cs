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
    public abstract class ICatalog : IGeneric<XCRI.Interfaces.XCRICAP11.ICatalog>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestGeneratedAttribute();
        }
        [TestMethod]
        public void TestGeneratedAttribute()
        {
            this.TestProperty<DateTimeOffset?>
                (
                "Generated",
                new DateTimeOffset(DateTime.Now.AddDays(-30)),
                new DateTimeOffset(DateTime.Now.AddDays(30))
                );
        }
    }
}
