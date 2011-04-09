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
        public void TestAttendanceMode()
        {

            XCRI.Interfaces.IAttendanceMode attendanceMode = new XCRI.AttendanceMode()
            {
                Value = "Sample attendance mode (no terms)"
            };

            this.TestNode
                (
                this.Generate(attendanceMode),
                (n) => { HasCorrectNameAndNamespace(n, "attendanceMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                (n) => { ContainsStringValue(n, "Sample attendance mode (no terms)"); }
                );

        }

        [TestMethod]
        public void TestAttendanceModeXmlLang()
        {

            XCRI.Interfaces.IAttendanceMode attendanceMode = new XCRI.AttendanceMode()
            {
                Value = "Sample attendance mode (no terms) in Spanish",
                XmlLanguage = "es"
            };

            this.TestNode
                (
                this.Generate(attendanceMode),
                (n) => { HasAttributeWithValue(n, "lang", XCRI.Configuration.Namespaces.XmlNamespace, "es"); }
                );

        }

        [TestMethod]
        public void TestTermsAttendanceMode()
        {

            XCRI.Vocabularies.XCRICAP11.Terms.AttendanceMode
                am = new XCRI.Vocabularies.XCRICAP11.Terms.AttendanceMode();

            foreach (Vocabularies.XCRICAP11.Terms.AttendanceModeTypes amt in Enum.GetValues(typeof(Vocabularies.XCRICAP11.Terms.AttendanceModeTypes)))
            {
                am.Value = amt;
                this.TestNode
                    (
                    this.Generate(am),
                    (n) => { HasCorrectNameAndNamespace(n, "attendanceMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); },
                    (n) => { ContainsStringValue(n, amt.ToXCRIString()); }
                    );
            }

        }

    }
}
