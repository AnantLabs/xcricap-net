using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestPresentation()
        {

            XCRI.Presentation presentation = new Presentation();

            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasCorrectNameAndNamespace(n, "presentation", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationIGeneric()
        {

            XCRI.Presentation presentation = new Presentation();
            this.TestIGeneric(presentation, () => this.Generate(presentation));

        }

        [TestMethod]
        public void TestPresentationStart()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.Start = new XCRI.Date(DateTime.Now.AddDays(60));
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "start", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationEnd()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.End = new XCRI.Date(DateTime.Now.AddDays(60).AddDays(365));
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "end", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationDuration()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.Duration = TimeSpan.FromDays(365);
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "duration", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationStudyMode()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.StudyMode = new XCRI.StudyMode() { Value = "evening" };
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "studyMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationAttendanceMode()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.AttendanceMode = new XCRI.AttendanceMode() { Value = "evening" };
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "attendanceMode", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationAttendancePattern()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.AttendancePattern = new XCRI.AttendancePattern() { Value = "evening" };
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "attendancePattern", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationLanguageOfInstruction()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.LanguagesOfInstruction.Add("English");
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "languageOfInstruction", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            presentation.LanguagesOfInstruction.Add("Spanish");
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElements(n, "languageOfInstruction", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.LanguagesOfInstruction.Count); }
            );

        }

        [TestMethod]
        public void TestPresentationLanguageOfAssessment()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.LanguagesOfAssessment.Add("English");
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "languageOfAssessment", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            presentation.LanguagesOfAssessment.Add("Spanish");
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElements(n, "languageOfAssessment", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.LanguagesOfAssessment.Count); }
            );

        }

        [TestMethod]
        public void TestPresentationVenues()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.Venues.Add(new XCRI.Venue());
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "venue", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            presentation.Venues.Add(new XCRI.Venue());
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElements(n, "venue", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, presentation.Venues.Count); }
            );

        }

        [TestMethod]
        public void TestPresentationPlacesAvailable()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.PlacesAvailable = "30";
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "placesAvailable", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationCost()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.Cost = "£500";
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "cost", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationApplyTo()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.ApplyTo = "Main admissions office";
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "applyTo", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestPresentationEnquireTo()
        {

            XCRI.Presentation presentation = new Presentation();

            presentation.EnquireTo = "Marketing department";
            this.TestNode
                (
                this.Generate(presentation),
                (n) => { HasChildElement(n, "enquireTo", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

    }
}
