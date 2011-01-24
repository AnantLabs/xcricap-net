using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{
    public class Attribute : XmlBaseClass
    {

        #region Properties and Fields

        #region Private

        private string __AttributeName = String.Empty;
        private string __AttributeNamespace = String.Empty;
        private string __Value = String.Empty;

        #endregion

        #region Protected

        protected string _AttributeName
        {
            get { return this.__AttributeName; }
            set
            {
                if (this.__AttributeName == value) { return; }
                this.OnPropertyChanging("AttributeName");
                this.__AttributeName = value;
                this.OnPropertyChanged("AttributeName");
            }
        }

        protected string _AttributeNamespace
        {
            get { return this.__AttributeNamespace; }
            set
            {
                if (this.__AttributeNamespace == value) { return; }
                this.OnPropertyChanging("AttributeNamespace");
                this.__AttributeNamespace = value;
                this.OnPropertyChanged("AttributeNamespace");
            }
        }

        protected string _Value
        {
            get { return this.__Value; }
            set
            {
                if (this.__Value == value) { return; }
                this.OnPropertyChanging("Value");
                this.__Value = value;
                this.OnPropertyChanged("Value");
            }
        }

        #endregion

        #region Public

        public string AttributeName
        {
            get { return this._AttributeName; }
            set { this._AttributeName = value; }
        }

        public string AttributeNamespace
        {
            get { return this._AttributeNamespace; }
            set { this._AttributeNamespace = value; }
        }

        public string Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        #endregion

        #endregion

        #region IXmlGenerator Members

        public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            if (String.IsNullOrEmpty(this.Value))
                return;
            if (String.IsNullOrEmpty(this.AttributeNamespace))
            {
                writer.WriteAttributeString
                    (
                    this.AttributeName,
                    this.Value
                    );
            }
            else
            {
                writer.WriteStartAttribute
                    (
                    this.AttributeName,
                    this.AttributeNamespace
                    );
                writer.WriteString(this.Value);
                writer.WriteEndAttribute();
            }
        }

        #endregion

    }
}
