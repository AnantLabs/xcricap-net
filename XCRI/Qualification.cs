using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Qualification : XmlBaseClasses.ElementWithIdentifiers, Interfaces.IQualification
    {

        #region Properties and Fields

        #region Private

        private Uri __Url = null;
        private Image __Image = null;
        private Interfaces.IQualificationType __Type = null;
        private Interfaces.IQualificationLevel __Level = null;
        private List<Interfaces.ITitle> __Titles = new List<Interfaces.ITitle>();
        private List<Interfaces.IDescription> __Descriptions = new List<Interfaces.IDescription>();
        private List<Interfaces.IQualificationAwardedBy> __AwardedBy = new List<Interfaces.IQualificationAwardedBy>();
        private List<Interfaces.IQualificationAccreditedBy> __AccreditedBy = new List<Interfaces.IQualificationAccreditedBy>();
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;

        #endregion

        #region Protected

        protected ResourceStatus _ResourceStatus
        {
            get { return this.__ResourceStatus; }
            set
            {
                if (this.__ResourceStatus == value) { return; }
                this.OnPropertyChanging("ResourceStatus");
                this.__ResourceStatus = value;
                this.OnPropertyChanged("ResourceStatus");
            }
        }

        protected Interfaces.IQualificationType _Type
        {
            get { return this.__Type; }
            set
            {
                if (this.__Type == value) { return; }
                this.OnPropertyChanging("Type");
                this.__Type = value;
                this.OnPropertyChanged("Type");
            }
        }

        protected Interfaces.IQualificationLevel _Level
        {
            get { return this.__Level; }
            set
            {
                if (this.__Level == value) { return; }
                this.OnPropertyChanging("Level");
                this.__Level = value;
                this.OnPropertyChanged("Level");
            }
        }

        protected List<Interfaces.ITitle> _Titles
        {
            get { return this.__Titles; }
        }

        protected List<Interfaces.IDescription> _Descriptions
        {
            get { return this.__Descriptions; }
        }

        protected List<Interfaces.IQualificationAwardedBy> _AwardedBy
        {
            get { return this.__AwardedBy; }
        }

        protected List<Interfaces.IQualificationAccreditedBy> _AccreditedBy
        {
            get { return this.__AccreditedBy; }
        }

        protected Image _Image
        {
            get { return this.__Image; }
            set
            {
                if (this.__Image == value) { return; }
                this.OnPropertyChanging("Image");
                this.__Image = value;
                this.OnPropertyChanged("Image");
            }
        }

        protected Uri _Url
        {
            get { return this.__Url; }
            set
            {
                if (this.__Url == value) { return; }
                this.OnPropertyChanging("Url");
                this.__Url = value;
                this.OnPropertyChanged("Url");
            }
        }

        #endregion

        #region Public

        #endregion

        #endregion

        #region IQualification Members

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public IList<Interfaces.ITitle> Titles
        {
            get { return this._Titles; }
        }

        public IList<Interfaces.IDescription> Descriptions
        {
            get { return this._Descriptions; }
        }

        public Uri Url
        {
            get { return this._Url; }
            set { this._Url = value; }
        }

        public Image Image
        {
            get { return this._Image; }
            set { this._Image = value; }
        }

        public Interfaces.IQualificationLevel Level
        {
            get { return this._Level; }
            set { this._Level = value; }
        }

        public Interfaces.IQualificationType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        public IList<Interfaces.IQualificationAwardedBy> AwardedBy
        {
            get { return this._AwardedBy; }
        }

        public IList<Interfaces.IQualificationAccreditedBy> AccreditedBy
        {
            get { return this._AccreditedBy; }
        }

        #endregion

    }

    public class QualificationLevel : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IQualificationLevel
    {

    }

    public class QualificationType : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IQualificationType
    {

    }

    public class QualificationAwardedBy : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IQualificationAwardedBy
    {

    }

    public class QualificationAccreditedBy : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IQualificationAccreditedBy
    {

    }

}
