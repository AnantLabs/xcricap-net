using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Description : XmlBaseClasses.ElementWithSingleValue<string>, Interfaces.IDescription
    {

        #region Properties and Fields

        #region Private
        
        private Uri __Href = null;
        private XCRI.Interfaces.DescriptionContentTypes __ContentType = Interfaces.DescriptionContentTypes.Text;
        
        #endregion

        #region Protected

        protected Uri _Href
        {
            get { return this.__Href; }
            set
            {
                if (this.__Href == value)
                    return;
                this.OnPropertyChanging("Href");
                this.__Href = value;
                this.OnPropertyChanged("Href");
            }
        }

        protected XCRI.Interfaces.DescriptionContentTypes _ContentType
        {
            get { return this.__ContentType; }
            set
            {
                if (this.__ContentType == value)
                    return;
                this.OnPropertyChanging("ContentType");
                this.__ContentType = value;
                this.OnPropertyChanged("ContentType");
            }
        }

        #endregion

        #region Public

        public Uri Href
        {
            get { return this._Href; }
            set { this._Href = value; }
        }

        public XCRI.Interfaces.DescriptionContentTypes ContentType
        {
            get { return this._ContentType; }
            set { this._ContentType = value; }
        }

        #endregion

        #endregion

    }
}
