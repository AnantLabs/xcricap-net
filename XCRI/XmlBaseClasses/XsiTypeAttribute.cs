using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{
    public class XsiTypeAttribute : Attribute
    {

        #region Properties and Fields

        #region Private

        private string __AttributeValueNamespace = String.Empty;

        #endregion

        #region Protected

        protected string _AttributeValueNamespace
        {
            get { return this.__AttributeValueNamespace; }
            set
            {
                if (this.__AttributeValueNamespace == value) { return; }
                this.OnPropertyChanging("AttributeValueNamespace");
                this.__AttributeValueNamespace = value;
                this.OnPropertyChanged("AttributeValueNamespace");
            }
        }

        #endregion

        #region Public

        public string AttributeValueNamespace
        {
            get { return this._AttributeValueNamespace; }
            set { this._AttributeValueNamespace = value; }
        }

        #endregion

        #endregion

    }
}
