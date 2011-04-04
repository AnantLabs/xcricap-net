using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class Credit
        : XmlBaseClasses.Element, Interfaces.ICredit
    {

        #region Properties and Fields

        #region Private

        private List<string> __Schemas = new List<string>();
        private List<string> __Levels = new List<string>();
        private List<string> __Values = new List<string>();

        #endregion

        #region Protected

        protected List<string> _Schemas
        {
            get { return this.__Schemas; }
        }

        protected List<string> _Levels
        {
            get { return this.__Levels; }
        }

        protected List<string> _Values
        {
            get { return this.__Values; }
        }

        #endregion

        #endregion

        #region ICredit Members

        public IList<string> Schemes
        {
            get { return this._Schemas; }
        }

        public IList<string> Levels
        {
            get { return this._Levels; }
        }

        public IList<string> Values
        {
            get { return this._Values; }
        }

        #endregion

    }
}
