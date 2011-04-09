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
        public void TestQualification()
        {

            Qualification qual = new Qualification();
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasCorrectNameAndNamespace(n, "qualification", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestQualificationIGeneric()
        {

            Qualification qual = new Qualification();
            this.TestIGeneric(qual, () => this.Generate(qual));

        }

        [TestMethod]
        public void TestQualificationQualificationLevel()
        {

            Qualification qual = new Qualification();

            qual.Level = new QualificationLevel() { Value = "HND" };
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElement(n, "level", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestQualificationQualificationType()
        {

            Qualification qual = new Qualification();

            qual.Type = new QualificationType() { Value = "asd asd" };
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElement(n, "type", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );

        }

        [TestMethod]
        public void TestQualificationQualificationAwardedBy()
        {

            Qualification qual = new Qualification();

            qual.AwardedBy.Add(new XCRI.QualificationAwardedBy() { Value = "hello world" });
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElement(n, "awardedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            qual.AwardedBy.Add(new XCRI.QualificationAwardedBy() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElements(n, "awardedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, qual.AwardedBy.Count); }
            );

        }

        [TestMethod]
        public void TestQualificationQualificationAccreditedBy()
        {

            Qualification qual = new Qualification();

            qual.AccreditedBy.Add(new XCRI.QualificationAccreditedBy() { Value = "hello world" });
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElement(n, "accreditedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri); }
            );
            qual.AccreditedBy.Add(new XCRI.QualificationAccreditedBy() { Value = "hola mundo", XmlLanguage = "es" });
            this.TestNode
                (
                this.Generate(qual),
                (n) => { HasChildElements(n, "accreditedBy", XCRI.Configuration.Namespaces.XCRICAP11NamespaceUri, qual.AccreditedBy.Count); }
            );

        }

    }
}
