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

        #endregion

        #region Public

        public Uri Href
        {
            get { return this._Href; }
            set { this._Href = value; }
        }

        #endregion

        #endregion

    }
}
