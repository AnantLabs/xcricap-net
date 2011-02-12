﻿using System;
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

    public class ElementWithSingleValue : Element, Interfaces.IElementWithSingleValue
    {
        
        #region Properties and Fields

        #region Private

        private object __Value = null;
        private bool __RenderRaw = false;

        #endregion

        #region Protected

        protected object _Value
        {
            get { return this.__Value; }
            set
            {
                if (value == this.__Value) { return; }
                this.OnPropertyChanging("Value");
                this.__Value = value;
                this.OnPropertyChanged("Value");
            }
        }

        protected bool _RenderRaw
        {
            get { return this.__RenderRaw; }
            set
            {
                if (this.__RenderRaw == value) { return; }
                this.OnPropertyChanging("RenderRaw");
                this.__RenderRaw = value;
                this.OnPropertyChanged("RenderRaw");
            }
        }

        #endregion

        #region Public

        public virtual object Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        public bool RenderRaw
        {
            get { return this._RenderRaw; }
            set { this._RenderRaw = value; }
        }

        #endregion

        #endregion

    }

    public class ElementWithSingleValue<T> : ElementWithSingleValue, Interfaces.IElementWithSingleValue<T>
    {

        #region Properties and Fields

        #region Public

        public new T Value
        {
            get
            {
                return (T)base.Value;
            }
            set
            {
                base.Value = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public virtual

        public virtual string GetElementValueAsString()
        {
            return this.Value == null 
                ? String.Empty : 
                this.Value.ToString();
        }

        #endregion

        #endregion

    }
    public class ElementWithIdentifiers : Element, Interfaces.IElementWithIdentifiers
    {

        #region Properties and Fields

        #region Private

        private List<Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();

        #endregion

        #region Protected

        protected IList<Interfaces.IIdentifier> _Identifiers
        {
            get { return this.__Identifiers; }
        }

        #endregion

        #region Public

        public IList<Interfaces.IIdentifier> Identifiers
        {
            get { return this._Identifiers; }
        }

        #endregion

        #endregion

    }
}