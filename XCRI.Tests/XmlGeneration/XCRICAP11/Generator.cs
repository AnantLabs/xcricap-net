using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XCRI.Tests.XmlGeneration.XCRICAP11
{
    [TestClass]
    public partial class Generator : XmlGeneratorBase<XCRI.XmlGeneration.XCRICAP11.Generator>
    {

        [TestInitialize]
        public void Initialise()
        {
            this.XmlGenerator
                = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRIProfiles.XCRI_v1_1) as XCRI.XmlGeneration.XCRICAP11.Generator;
        }

        [TestMethod]
        public void AssignValidRootNodes()
        {
            this.XmlGenerator.RootElement = new XCRI.Catalog();
            this.XmlGenerator.RootElement = new XCRI.Provider();
            this.XmlGenerator.RootElement = new XCRI.Course();
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException), "RootNode set to invalid value but no exception thrown")]
        public void AssignInvalidRootNode()
        {
            this.XmlGenerator.RootElement = new XCRI.Location();
        }

        public System.Xml.XmlNode Generate(Uri uri)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, uri);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IIdentifier identifier)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, identifier);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.ITitle title)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, title);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IDescription description)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, description);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.ISubject subject)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, subject);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IQualification qualification)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, qualification);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IPresentation presentation)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, presentation);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IStudyMode studyMode)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, studyMode);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IAttendanceMode attendanceMode)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, attendanceMode);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IAttendancePattern attendancePattern)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, attendancePattern);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IVenue venue)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, venue);
            });
        }

        public IEnumerable<XmlNode> Generate(XCRI.Interfaces.XCRICAP11.ILocation address)
        {
            return this._GetGeneratedNodes((w) =>
            {
                this.XmlGenerator.Write(w, address);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.ICourse course)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, course);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IImage image)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, image);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IQualificationLevel qualLevel)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, qualLevel);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IQualificationType qualType)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, qualType);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IQualificationAwardedBy awardedBy)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, awardedBy);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IQualificationAccreditedBy accreditedBy)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, accreditedBy);
            });
        }

        public System.Xml.XmlNode Generate(XCRI.Interfaces.XCRICAP11.IProvider provider)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, provider);
            });
        }

        public XmlNode Generate(XCRI.Interfaces.XCRICAP11.ICatalog catalog)
        {
            return this._GetGeneratedNode((w) =>
            {
                this.XmlGenerator.Write(w, catalog);
            });
        }

        

    }
}
