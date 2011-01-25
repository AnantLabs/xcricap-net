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

        #endregion

        #region Protected

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

        public ICollection<XCRI.Interfaces.IXmlAttribute> Attributes
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
                this.AddAttribute(Name, Namespace, Value);
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

        public void AddAttribute(string Name, string Namespace, string Value)
        {
            this.AddAttribute(new Attribute()
            {
                AttributeName = Name,
                AttributeNamespace = Namespace,
                Value = Value
            });
        }

        public void AddAttribute(Attribute attribute)
        {
            this._Attributes.Add(attribute);
        }

        #endregion

        #endregion

    }

    public class ElementWithStringValue : Element, Interfaces.IXmlElementWithStringValue
    {
        
        #region Properties and Fields

        #region Private

        private string __Value = String.Empty;
        private bool __RenderRaw = false;

        #endregion

        #region Protected

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

        public string Value
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

        public ElementWithStringValue(string Name, string Namespace)
            : base(Name, Namespace)
        {
            this.ElementNamespace = Namespace;
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

        public ICollection<Interfaces.IXmlElement> ChildElements
        {
            get { return this._ChildElements; }
        }

        #endregion

        #endregion

    }
    public class ElementWithIdentifiers : ElementWithChildElements
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

        #region Public

        public IEnumerable<Identifier> Identifiers
        {
            get
            {
                foreach (Element el in this._ChildElements)
                {
                    if (el is Identifier)
                        yield return el as Identifier;
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        public void AddIdentifier(Identifier identifier)
        {
            this._ChildElements.Add(identifier);
        }

        #endregion

        #endregion

    }
}
