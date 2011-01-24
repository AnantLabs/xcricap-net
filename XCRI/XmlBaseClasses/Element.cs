using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.XmlBaseClasses
{
    public abstract class Element : XmlBaseClass
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

        private List<Attribute> __Attributes = new List<Attribute>();
        private List<Element> __ChildElements = new List<Element>();
        private string __ElementName = String.Empty;
        private string __ElementNamespace = String.Empty;
        private XsiTypeAttribute __XsiType = new XsiTypeAttribute()
        {
            AttributeName = "type",
            AttributeNamespace = @"http://www.w3.org/2001/XMLSchema-instance"
        };

        #endregion

        #region Protected

        protected List<Attribute> _Attributes
        {
            get { return this.__Attributes; }
        }

        protected List<Element> _ChildElements
        {
            get { return this.__ChildElements; }
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

        public IEnumerable<Attribute> Attributes
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

        #region Public virtual

        public virtual void WriteEndElement(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            writer.WriteEndElement();
        }

        public virtual void WriteAttributes(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            foreach (Attribute attribute in this.Attributes)
            {
                attribute.GenerateTo(writer, Profile);
            }
            this.XsiType.GenerateTo(writer, Profile);
        }

        public virtual void WriteStartElement(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            if (
                String.IsNullOrEmpty(this.ElementNamespace)
                )
            {
                writer.WriteStartElement
                    (
                    this.ElementName
                    );
            }
            else
            {
                writer.WriteStartElement
                    (
                    this.ElementName,
                    this.ElementNamespace
                    );
            }
            this.WriteAttributes(writer, Profile);
        }

        public abstract void WriteElementContents(System.Xml.XmlWriter writer, XCRIProfiles Profile);

        #endregion

        #region Public override

        public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            this.WriteStartElement(writer, Profile);
            this.WriteElementContents(writer, Profile);
            this.WriteEndElement(writer, Profile);
        }

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
    public class ElementWithStringValue : Element
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

        #region Methods

        #region Public override

        public override void WriteElementContents(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            if (String.IsNullOrEmpty(this.Value))
                return;
            if (this.RenderRaw)
                writer.WriteRaw
                    (
                    this.Value
                    );
            else
                writer.WriteValue
                    (
                    this.Value
                    );
        }

        #endregion

        #endregion

    }
    public class ElementWithChildElements : Element
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

        private List<Element> __ChildElements = new List<Element>();
        
        #endregion

        #region Protected

        protected List<Element> _ChildElements
        {
            get { return this.__ChildElements; }
        }

        #endregion

        #region Public

        public List<Element> ChildElements
        {
            get { return this._ChildElements; }
        }

        #endregion

        #endregion

        #region Methods

        #region Public override

        public override void WriteElementContents(System.Xml.XmlWriter writer, XCRIProfiles Profile)
        {
            foreach (Element childElement in this._ChildElements)
            {
                childElement.GenerateTo(writer, Profile);
            }
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
