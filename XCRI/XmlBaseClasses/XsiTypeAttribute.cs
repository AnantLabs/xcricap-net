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

        #region Methods

        #region Public override

        public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            if (String.IsNullOrEmpty(this.AttributeNamespace))
                base.GenerateTo(writer, Profile);
            else
            {
                if (String.IsNullOrEmpty(this.Value))
                    return;
                writer.WriteStartAttribute
                    (
                    writer.LookupPrefix(this.AttributeNamespace),
                    this.AttributeName,
                    this.AttributeNamespace
                    );
                if (String.IsNullOrEmpty(this.AttributeValueNamespace))
                    writer.WriteString(this.Value);
                else
                {
                    string prefix = writer.LookupPrefix(this.AttributeValueNamespace);
                    writer.WriteString(String.Format
                        (
                        "{0}:{1}",
                        prefix,
                        this.Value
                        ));
                }
                writer.WriteEndAttribute();
            }
        }

        #endregion

        #endregion

    }
}
