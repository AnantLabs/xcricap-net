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
    public abstract class IQualification : IGeneric<XCRI.Interfaces.XCRICAP11.IQualification>
    {
        protected override void _ModifyProperties()
        {
            base._ModifyProperties();
            this.TestLevel();
            this.TestType();
            this.TestAbbreviation();
            this.TestEducationLevel();
        }
        [TestMethod]
        public void TestLevel()
        {
            this.TestProperty<XCRI.Interfaces.IQualificationLevel>
                (
                "Level",
                new XCRI.QualificationLevel() { Value = "ABC Uni" },
                new XCRI.QualificationLevel() { Value = "My College" }
                );
        }
        [TestMethod]
        public void TestAbbreviation()
        {
            this.TestProperty<XCRI.Interfaces.IAbbreviation>
                (
                "Abbreviation",
                new XCRI.Abbreviation() { Value = "abc" },
                new XCRI.Abbreviation() { Value = "def" }
                );
        }
        [TestMethod]
        public void TestEducationLevel()
        {
            this.TestProperty<XCRI.Interfaces.IEducationLevel>
                (
                "EducationLevel",
                new XCRI.EducationLevel() { Value = "3 A-Levels, grade A-C or similar" },
                new XCRI.EducationLevel() { Value = "Suitable for postgraduates only" }
                );
        }
        [TestMethod]
        public void TestType()
        {
            this.TestProperty<XCRI.Interfaces.IQualificationType>
                (
                "Type",
                new XCRI.QualificationType() { Value = "123" }, 
                new XCRI.QualificationType() { Value = "ABC" }
                );
        }
    }
}
