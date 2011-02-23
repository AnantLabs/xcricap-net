using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{

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

}
