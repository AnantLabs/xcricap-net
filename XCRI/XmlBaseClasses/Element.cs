using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{

    public abstract class Element : NotifyBaseClass, Interfaces.IElement
    {

        #region Properties and Fields

        #region Private

        private string __XsiTypeValue = String.Empty;
        private string __XsiTypeValueNamespace = String.Empty;
        private string __XmlLanguage = String.Empty;
        private XCRIProfiles __CompatibleWith = XCRIProfiles.None;

        #endregion

        #region Protected

        protected string _XsiTypeValue
        {
            get { return this.__XsiTypeValue; }
            set
            {
                if (this.__XsiTypeValue == value)
                    return;
                this.OnPropertyChanging("XsiTypeValue");
                this.__XsiTypeValue = value;
                this.OnPropertyChanged("XsiTypeValue");
            }
        }

        protected XCRIProfiles _CompatibleWith
        {
            get { return this.__CompatibleWith; }
            set
            {
                if (this.__CompatibleWith == value)
                    return;
                this.OnPropertyChanging("CompatibleWith");
                this.__CompatibleWith = value;
                this.OnPropertyChanged("CompatibleWith");
            }
        }

        protected string _XsiTypeValueNamespace
        {
            get { return this.__XsiTypeValueNamespace; }
            set
            {
                if (this.__XsiTypeValueNamespace == value)
                    return;
                this.OnPropertyChanging("XsiTypeValueNamespace");
                this.__XsiTypeValueNamespace = value;
                this.OnPropertyChanged("XsiTypeValueNamespace");
            }
        }

        protected string _XmlLanguage
        {
            get { return this.__XmlLanguage; }
            set
            {
                if (this.__XmlLanguage == value)
                    return;
                this.OnPropertyChanging("XmlLanguage");
                this.__XmlLanguage = value;
                this.OnPropertyChanged("XmlLanguage");
            }
        }

        #endregion

        #region Public

        public virtual string XsiTypeValue
        {
            get { return this._XsiTypeValue; }
            set { this._XsiTypeValue = value; }
        }

        public XCRIProfiles CompatibleWith
        {
            get { return this._CompatibleWith; }
            set { this._CompatibleWith = value; }
        }

        public string XsiTypeValueNamespace
        {
            get { return this._XsiTypeValueNamespace; }
            set { this._XsiTypeValueNamespace = value; }
        }

        public string XmlLanguage
        {
            get { return this._XmlLanguage; }
            set { this._XmlLanguage = value; }
        }

        #endregion

        #endregion

    }

}
