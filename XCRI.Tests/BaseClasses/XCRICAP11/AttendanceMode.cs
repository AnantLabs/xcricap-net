using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.BaseClasses.XCRICAP11
{
    [TestClass]
    public class AttendanceMode : InterfaceTests.IAttendanceMode
    {
        [TestInitialize]
        public void Setup()
        {
            this.ToTest = new XCRI.AttendanceMode();
        }
    }
}
