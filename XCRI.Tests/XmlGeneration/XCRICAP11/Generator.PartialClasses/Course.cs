using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestMethod]
        public void TestCourse()
        {

            XCRI.Interfaces.ICourse course = new XCRI.Course();

            this.TestNode
                (
                this.Generate(course),
                (n) => { HasCorrectNameAndNamespace(n, "course", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

        }

        [TestMethod]
        public void TestCourseIGeneric()
        {

            Course course = new Course();
            this.TestIGeneric(course, () => this.Generate(course));

        }

        [TestMethod]
        public void TestCourseQualifications()
        {

            XCRI.Interfaces.ICourse course = new XCRI.Course();

            course.Qualifications.Add(new Qualification());
            this.TestNode
                (
                this.Generate(course),
                (n) => { HasChildElement(n, "qualification", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

            course.Qualifications.Add(new Qualification());
            this.TestNode
                (
                this.Generate(course),
                (n) => { HasChildElements(n, "qualification", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, course.Qualifications.Count); }
                );

        }

        [TestMethod]
        public void TestCoursePresentations()
        {

            XCRI.Interfaces.ICourse course = new XCRI.Course();

            course.Presentations.Add(new Presentation());
            this.TestNode
                (
                this.Generate(course),
                (n) => { HasChildElement(n, "presentation", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
                );

            course.Presentations.Add(new Presentation());
            this.TestNode
                (
                this.Generate(course),
                (n) => { HasChildElements(n, "presentation", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, course.Presentations.Count); }
                );

        }

    }
}
