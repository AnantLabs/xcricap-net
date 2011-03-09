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

        public override void Generate
            (
            System.Xml.XmlWriter xmlWriter
            )
        {
            throw new NotImplementedException();
            /*
            this._WrittenRootNode = false;
            xmlWriter.WriteStartDocument(true);
            if (this.RootElement is ICatalog)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.ICatalog);
            if (this.RootElement is IProvider)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.IProvider);
            if (this.RootElement is ICourse)
                this.Write(xmlWriter, this.RootElement as XCRI.Interfaces.XCRICAP12.ICourse);
            xmlWriter.Flush();
            */
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
                if (value is XCRI.Interfaces.XCRICAP12.ICatalog)
                    validType = true;
                if (value is XCRI.Interfaces.XCRICAP12.IProvider)
                    validType = true;
                if (value is XCRI.Interfaces.XCRICAP12.ICourse)
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
