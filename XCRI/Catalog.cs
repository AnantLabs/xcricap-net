using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;
using XCRI.Interfaces;

namespace XCRI
{
    public class Catalog : Element, Interfaces.ICatalog
    {

        #region Properties and Fields

        #region Private

        private DateTime? __Generated = null;
        private ResourceStatus __ResourceStatus = ResourceStatus.Unknown;
        private List<ITitle> __Titles = new List<ITitle>();
        private List<ISubject> __Subjects = new List<ISubject>();
        private List<IDescription> __Descriptions = new List<IDescription>();
        private Uri __Url = null;
        private Interfaces.IImage __Image = null;
        private List<IProvider> __Providers = new List<IProvider>();

        private List<Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();

        #endregion

        #region Protected

        protected IList<Interfaces.IIdentifier> _Identifiers
        {
            get { return this.__Identifiers; }
        }


        protected DateTime? _Generated
        {
            get { return this.__Generated; }
            set
            {
                if (this.__Generated == value)
                    return;
                this.OnPropertyChanging("Generated");
                this.__Generated = value;
                this.OnPropertyChanged("Generated");
            }
        }

        protected ResourceStatus _ResourceStatus
        {
            get { return this.__ResourceStatus; }
            set
            {
                if (this.__ResourceStatus == value)
                    return;
                this.OnPropertyChanging("ResourceStatus");
                this.__ResourceStatus = value;
                this.OnPropertyChanged("ResourceStatus");
            }
        }

        protected List<ITitle> _Titles
        {
            get { return this.__Titles; }
        }

        protected List<ISubject> _Subjects
        {
            get { return this.__Subjects; }
        }

        protected List<IDescription> _Descriptions
        {
            get { return this.__Descriptions; }
        }

        protected Uri _Url
        {
            get { return this.__Url; }
            set
            {
                if (this.__Url == value)
                    return;
                this.OnPropertyChanging("Url");
                this.__Url = value;
                this.OnPropertyChanged("Url");
            }
        }

        protected Interfaces.IImage _Image
        {
            get { return this.__Image; }
            set
            {
                if (this.__Image == value)
                    return;
                this.OnPropertyChanging("Image");
                this.__Image = value;
                this.OnPropertyChanged("Image");
            }
        }

        protected List<IProvider> _Providers
        {
            get { return this.__Providers; }
        }

        #endregion

        #endregion

        #region ICatalog Members

        public IList<Interfaces.IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

        public DateTime? Generated
        {
            get { return this._Generated; }
            set { this._Generated = value; }
        }

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public IList<ITitle> Titles
        {
            get { return this._Titles; }
        }

        public IList<XCRI.Interfaces.ISubject> Subjects
        {
            get { return this._Subjects; }
        }

        public IList<XCRI.Interfaces.IDescription> Descriptions
        {
            get { return this._Descriptions; }
        }

        public Uri Url
        {
            get { return this._Url; }
            set { this._Url = value; }
        }

        public Interfaces.IImage Image
        {
            get { return this._Image; }
            set { this._Image = value; }
        }

        public IList<XCRI.Interfaces.IProvider> Providers
        {
            get { return this._Providers; }
        }

        #endregion

    }
}
