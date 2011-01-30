using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{

    public abstract class Element : NotifyBaseClass, Interfaces.IXmlElement
    {

        #region Constructors

        #region Public

        public Element(string Name, string Namespace)
            : base()
        {
            this.ElementName = Name;
            this.ElementNamespace = Namespace;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Private

        private List<XCRI.Interfaces.IXmlAttribute> __Attributes = new List<XCRI.Interfaces.IXmlAttribute>();
        private string __ElementName = String.Empty;
        private string __ElementNamespace = String.Empty;
        private XsiTypeAttribute __XsiType = new XsiTypeAttribute()
        {
            AttributeName = "type",
            AttributeNamespace = Configuration.XMLSchemaInstanceNamespaceUri
        };
        private ResourceStatus __ResourceStatus = XCRI.ResourceStatus.Unknown;

        #endregion

        #region Protected

        protected ResourceStatus _ResourceStatus
        {
            get { return this.__ResourceStatus; }
            set
            {
                if (this.__ResourceStatus == value) { return; }
                this.OnPropertyChanging("ResourceStatus");
                this.__ResourceStatus = value;
                this.OnPropertyChanged("ResourceStatus");
            }
        }

        protected List<XCRI.Interfaces.IXmlAttribute> _Attributes
        {
            get { return this.__Attributes; }
        }

        protected string _ElementName
        {
            get { return this.__ElementName; }
            set
            {
                if (this.__ElementName == value) { return; }
                this.OnPropertyChanging("ElementName");
                this.__ElementName = value;
                this.OnPropertyChanged("ElementName");
            }
        }

        protected XsiTypeAttribute _XsiType
        {
            get { return this.__XsiType; }
        }

        protected string _ElementNamespace
        {
            get { return this.__ElementNamespace; }
            set
            {
                if (this.__ElementNamespace == value) { return; }
                this.OnPropertyChanging("ElementNamespace");
                this.__ElementNamespace = value;
                this.OnPropertyChanged("ElementNamespace");
            }
        }

        #endregion

        #region Public

        public ResourceStatus ResourceStatus
        {
            get { return this._ResourceStatus; }
            set { this._ResourceStatus = value; }
        }

        public IList<XCRI.Interfaces.IXmlAttribute> Attributes
        {
            get { return this._Attributes; }
        }

        public string ElementName
        {
            get { return this._ElementName; }
            set { this._ElementName = value; }
        }

        public string ElementNamespace
        {
            get { return this._ElementNamespace; }
            set { this._ElementNamespace = value; }
        }

        public XsiTypeAttribute XsiType
        {
            get { return this._XsiType; }
        }

        #endregion

        #endregion

        #region Methods

        #region Public override

        #endregion

        #region Public

        public void SetAttribute(string Name, string Value)
        {
            this.SetAttribute(Name, this.ElementNamespace, Value);
        }

        public void SetAttribute(string Name, string Namespace, string Value)
        {
            Attribute attr = this.GetAttribute(Name, Namespace);
            if (attr == null)
            {
                this.Attributes.Add(new Attribute()
                {
                    AttributeName = Name,
                    AttributeNamespace = Namespace, 
                    Value = Value
                });
            }
            else
            {
                attr.Value = Value;
            }
        }

        public Attribute GetAttribute(string Name)
        {
            return this.GetAttribute(Name, this.ElementNamespace);
        }

        public Attribute GetAttribute(string Name, string Namespace)
        {
            foreach (Attribute attr in this._Attributes)
            {
                if (
                    (Name == attr.AttributeName)
                    &&
                    (Namespace == attr.AttributeNamespace)
                    )
                    return attr;
            }
            return null;
        }

        #endregion

        #endregion

    }

    public class ElementWithSingleValue : Element, Interfaces.IXmlElementWithSingleValue
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

        #region Constructors

        #region Public

        public ElementWithSingleValue(string Name, string Namespace)
            : base(Name, Namespace)
        {
            this.ElementNamespace = Namespace;
        }

        #endregion

        #endregion

    }

    public class ElementWithSingleValue<T> : ElementWithSingleValue, Interfaces.IXmlElementWithSingleValue<T>
    {

        #region Constructors

        #region Public

        public ElementWithSingleValue(string Name, string Namespace)
            : base(Name, Namespace)
        {
            this.ElementNamespace = Namespace;
        }

        #endregion

        #endregion

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

    }

    public class ElementWithChildElements : Element, Interfaces.IXmlElementWithChildElements
    {

        #region Constructors

        #region Public

        public ElementWithChildElements(string Name, string Namespace)
            : base(Name, Namespace)
        {
            this.ElementNamespace = Namespace;
        }

        #endregion

        #endregion

        #region Properties and Fields

        #region Private

        private List<Interfaces.IXmlElement> __ChildElements = new List<Interfaces.IXmlElement>();
        
        #endregion

        #region Protected

        protected List<Interfaces.IXmlElement> _ChildElements
        {
            get { return this.__ChildElements; }
        }

        #endregion

        #region Public

        public IList<Interfaces.IXmlElement> ChildElements
        {
            get { return this._ChildElements; }
        }

        #endregion

        #endregion

    }
    public class ElementWithIdentifiers : ElementWithChildElements, Interfaces.IElementWithIdentifiers
    {

        #region Constructors

        #region Public

        public ElementWithIdentifiers(string Name, string Namespace)
            : base(Name, Namespace)
        {
        }

        #endregion

        #endregion

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
