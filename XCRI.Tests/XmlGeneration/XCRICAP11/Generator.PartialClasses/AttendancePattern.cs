using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Vocabularies.XCRICAP11.Terms;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestAttendancePattern()
        {

            XCRI.Interfaces.IAttendancePattern attendancePattern = new XCRI.AttendancePattern()
            {
                Value = "Sample attendance pattern (no terms)"
            };

            this.TestNode
                (
                this.Generate(attendancePattern),
                (n) => { HasCorrectNameAndNamespace(n, "attendancePattern", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample attendance pattern (no terms)"); }
                );

        }

        [TestMethod]
        public void TestAttendancePatternXmlLang()
        {

            XCRI.Interfaces.IAttendancePattern attendancePattern = new XCRI.AttendancePattern()
            {
                Value = "Sample attendance pattern (no terms) in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(attendancePattern),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

        [TestMethod]
        public void TestTermsAttendancePattern()
        {

            XCRI.Vocabularies.XCRICAP11.Terms.AttendancePattern
                am = new XCRI.Vocabularies.XCRICAP11.Terms.AttendancePattern();

            foreach (Vocabularies.XCRICAP11.Terms.AttendancePatternTypes apt in Enum.GetValues(typeof(Vocabularies.XCRICAP11.Terms.AttendancePatternTypes)))
            {
                am.Value = apt;
                this.TestNode
                    (
                    this.Generate(am),
                    (n) => { HasCorrectNameAndNamespace(n, "attendancePattern", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                    (n) => { ContainsStringValue(n, apt.ToXCRIString()); }
                    );
            }

        }

    }
}
