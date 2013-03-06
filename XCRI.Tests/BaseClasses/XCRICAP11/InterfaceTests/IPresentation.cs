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
    public abstract class IPresentation : IGeneric<XCRI.Interfaces.XCRICAP11.IPresentation>
    {

        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestStart();
            this.TestEnd();
            this.TestDuration();
            this.TestStudyMode();
            this.TestAttendanceMode();
            this.TestAttendancePattern();
            this.TestPlacesAvailable();
            this.TestCost();
            this.TestEnquireTo();
            this.TestApplyTo();
            this.TestAgeRange();
            this.TestApplyFrom();
            this.TestApplyUntil();
        }
        [TestMethod]
        public void TestApplyFrom()
        {
            this.TestProperty<Interfaces.IDate>
                (
                "ApplyFrom",
                new XCRI.Date(DateTime.Now.AddDays(-30)),
                new XCRI.Date(DateTime.Now.AddDays(-15))
                );
        }
        [TestMethod]
        public void TestApplyUntil()
        {
            this.TestProperty<Interfaces.IDate>
                (
                "ApplyUntil",
                new XCRI.Date(DateTime.Now.AddDays(-30)),
                new XCRI.Date(DateTime.Now.AddDays(-15))
                );
        }
        [TestMethod]
        public void TestStart()
        {
            this.TestProperty<Interfaces.IDate>
                (
                "Start",
                new XCRI.Date(DateTime.Now.AddDays(-30)),
                new XCRI.Date(DateTime.Now.AddDays(-15))
                );
        }
        [TestMethod]
        public void TestEnd()
        {
            this.TestProperty<Interfaces.IDate>
                (
                "End",
                new XCRI.Date(DateTime.Now.AddDays(-30)),
                new XCRI.Date(DateTime.Now.AddDays(-15))
                );
        }
        [TestMethod]
        public void TestDuration()
        {
            this.TestProperty<TimeSpan?>
                (
                "Duration",
                TimeSpan.FromDays(10),
                TimeSpan.FromDays(365)
                );
        }
        [TestMethod]
        public void TestAgeRange()
        {
            this.TestProperty<string>
                (
                "AgeRange",
                "1 to 2",
                "18 to 20"
                );
        }
        [TestMethod]
        public void TestStudyMode()
        {
            this.TestProperty<XCRI.Interfaces.IStudyMode>("StudyMode", new XCRI.StudyMode() { Value = "Distance Learning" }, new XCRI.StudyMode() { Value = "On site" });
        }
        [TestMethod]
        public void TestAttendanceMode()
        {
            this.TestProperty<XCRI.Interfaces.IAttendanceMode>("AttendanceMode", new XCRI.AttendanceMode() { Value = "Part time" }, new XCRI.AttendanceMode() { Value = "Full time" });
        }
        [TestMethod]
        public void TestAttendancePattern()
        {
            this.TestProperty<XCRI.Interfaces.IAttendancePattern>("AttendancePattern", new XCRI.AttendancePattern() { Value = "Once per week" }, new XCRI.AttendancePattern() { Value = "Once per week" });
        }
        [TestMethod]
        public void TestPlacesAvailable()
        {
            this.TestProperty<string>("PlacesAvailable", "Unknown", "20");
        }
        [TestMethod]
        public void TestCost()
        {
            this.TestProperty<string>("Cost", "£200", "£20");
        }
        [TestMethod]
        public void TestEnquireTo()
        {
            this.TestProperty<string>("EnquireTo", "Admissions Department", "Head of Year");
        }
        [TestMethod]
        public void TestApplyTo()
        {
            this.TestProperty<string>("ApplyTo", "Admissions Department", "Kirsty Young");
        }
    }
}
