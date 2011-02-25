using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Interfaces;

namespace XCRI.XmlGeneration.XCRICAP12
{
    public class Generator : XmlGeneratorBase
    {

        #region Constructors

        #region Internal

        internal Generator()
            : base()
        {
            base._Namespaces = NamespaceList.GetNamespaces(NamespaceList.Namespaces.XCRICAP12_All);
        }

        #endregion

        #endregion

        #region Methods

        #region Public override

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            ResourceStatus resourceStatus
            )
        {
            /* Delta update pattern not supported in 1.2, so far as I can tell */
            return;
        }

        public override void Generate
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            this._WrittenRootNode = false;
            xmlWriter.WriteStartDocument(true);
            if (this.RootElement is ICatalog)
                this.Write(xmlWriter, this.RootElement as ICatalog);
            if (this.RootElement is IProvider)
                this.Write(xmlWriter, this.RootElement as IProvider);
            if (this.RootElement is ICourse)
                this.Write(xmlWriter, this.RootElement as ICourse);
            xmlWriter.Flush();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICatalog catalog
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IIdentifier identifier
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ITitle title
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IDescription description
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ISubject subject
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationLevel qualLevel
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationType qualType
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAwardedBy awardedBy
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualificationAccreditedBy accreditedBy
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IQualification qualification
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IStudyMode studyMode
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendanceMode attendanceMode
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAttendancePattern attendancePattern
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IPresentation presentation
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IVenue venue
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            Uri uri
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IAddress address
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.ICourse course
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IImage image
            )
        {
            throw new NotImplementedException();
        }

        public override void Write
            (
            System.Xml.XmlWriter xmlWriter,
            XCRI.Interfaces.IProvider provider
            )
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public virtual

        public virtual void WriteLatitudeLongitude
            (
            System.Xml.XmlWriter xmlWriter,
            decimal? latitude,
            decimal? longitude
            )
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Public override

        public override IElement RootElement
        {
            get { return this._RootElement; }
            set
            {
                if (this._RootElement == value)
                    return;
                bool validType = false;
                if (value == null)
                    validType = true;
                if (value is ICatalog)
                    validType = true;
                if (value is IProvider)
                    validType = true;
                if (value is ICourse)
                    validType = true;
                if (validType == false)
                    throw new NotSupportedException("The RootElement must be set to an ICatalog, IProvider or ICourse");
                this._RootElement = value;
            }
        }

        #endregion

        #endregion

    }
}
