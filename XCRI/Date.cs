using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Date : XmlBaseClasses.ElementWithSingleValue<DateTimeOffset>, Interfaces.IDate
    {

        #region Properties and Fields

        #region Private

        private string __DisplayValue = String.Empty;

        #endregion

        #region Protected

        protected string _DisplayValue
        {
            get { return this.__DisplayValue; }
            set
            {
                if (this._DisplayValue == value)
                    return;
                this.OnPropertyChanging("DisplayValue");
                this.__DisplayValue = value;
                this.OnPropertyChanged("DisplayValue");
            }
        }

        #endregion

        #endregion

        #region Constructors

        #region Public

        public Date()
            : base()
        {
            
        }

        public Date(DateTime dateTime)
            : this(new DateTimeOffset(dateTime))
        {
        }

        public Date(DateTimeOffset dateTimeOffset)
            : this()
        {
            this.Value = dateTimeOffset;
        }

        #endregion

        #endregion

        #region IDate Members

        public string DisplayValue
        {
            get { return this._DisplayValue; }
            set { this._DisplayValue = value; }
        }

        #endregion

    }
}
