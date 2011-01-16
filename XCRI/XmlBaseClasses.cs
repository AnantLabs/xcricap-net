using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
	public abstract class XmlBaseClass : NotifyBaseClass, Interfaces.IXmlGenerator
	{

		#region Properties and Fields

		#region Private

		private string __Name = String.Empty;
		private string __Namespace = String.Empty;
		private string __Value = String.Empty;

		#endregion

		#region Protected

		protected string _Name
		{
			get { return this.__Name; }
			set
			{
				if (this.__Name == value) { return; }
				this.OnPropertyChanging("Name");
				this.__Name = value;
				this.OnPropertyChanged("Name");
			}
		}

		protected string _Namespace
		{
			get { return this.__Namespace; }
			set
			{
				if (this.__Namespace == value) { return; }
				this.OnPropertyChanging("Namespace");
				this.__Namespace = value;
				this.OnPropertyChanged("Namespace");
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

		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; }
		}
		public string Namespace
		{
			get { return this._Namespace; }
			set { this._Namespace = value; }
		}
		public string Value
		{
			get { return this._Value; }
			set { this._Value = value; }
		}

		#endregion

		#endregion

		#region IXmlGenerator Members

		public virtual void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			this.WriteStartElement(writer, Profile);
			this.WriteElementContents(writer, Profile);
			this.WriteEndElement(writer, Profile);
		}

		#endregion

		#region Methods

		#region Public virtual

		public virtual void WriteStartElement(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (
				String.IsNullOrEmpty(this.Namespace) 
				||
				(writer.LookupPrefix(this.Namespace) == String.Empty)
				)
			{
				writer.WriteStartElement
					(
					this.Name
					);
			}
			else
			{
				writer.WriteStartElement
					(
					this.Name,
					this.Namespace
					);
			}
		}

		public virtual void WriteElementContents(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (String.IsNullOrEmpty(this.Value))
				return;
			writer.WriteValue(this.Value);
		}

		public virtual void WriteEndElement(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			writer.WriteEndElement();
		}

		#endregion

		#endregion

	}
	public class Element : XmlBaseClass
	{

		#region Constructors

		#region Public

		public Element(string Name)
			: base()
		{
			this.Name = Name;
		}

		public Element(string Name, string Namespace)
			: this(Name)
		{
			this.Namespace = Namespace;
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private List<Attribute> __Attributes = new List<Attribute>();
		private List<Element> __ChildElements = new List<Element>();

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

		#endregion

		#region Public

		public IEnumerable<Attribute> Attributes
		{
			get { return this._Attributes; }
		}

		/*
		public IEnumerable<Element> ChildElements
		{
			get { return this._ChildElements; }
		}
		*/

		#endregion

		#endregion

		#region Methods

		#region Public virtual

		public virtual void WriteAttributes(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			foreach (Attribute attribute in this.Attributes)
			{
				attribute.GenerateTo(writer, Profile);
			}
		}

		#endregion

		#region Public override

		public override void WriteStartElement(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			base.WriteStartElement(writer, Profile);
			this.WriteAttributes(writer, Profile);
		}

		public override void WriteElementContents(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (this._ChildElements.Count == 0)
			{
				if(String.IsNullOrEmpty(this.Value) == false)
					writer.WriteValue
						(
						this.Value
						);
			}
			else
			{
				foreach (Element childElement in this._ChildElements)
				{
					childElement.GenerateTo(writer, Profile);
				}
			}
		}

		#endregion

		#region Public

		public void SetAttribute(string Name, string Value)
		{
			this.SetAttribute(Name, this.Namespace, Value);
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
			return this.GetAttribute(Name, this.Namespace);
		}

		public Attribute GetAttribute(string Name, string Namespace)
		{
			foreach (Attribute attr in this._Attributes)
			{
				if (
					(Name == attr.Name)
					&&
					(Namespace == attr.Namespace)
					)
					return attr;
			}
			return null;
		}

		public void AddAttribute(string Name, string Namespace, string Value)
		{
			this.AddAttribute(new Attribute()
			{
				Name = Name,
				Namespace = Namespace,
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
	public class ElementWithIdentifiers : Element
	{

		#region Constructors

		#region Public

		public ElementWithIdentifiers(string Name)
			: base(Name)
		{
		}
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
	public class Attribute : XmlBaseClass
	{

		#region IXmlGenerator Members

		public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (String.IsNullOrEmpty(this.Value))
				return;
			if (String.IsNullOrEmpty(this.Namespace))
			{
				writer.WriteAttributeString
					(
					this.Name,
					this.Value
					);
			}
			else
			{
				writer.WriteAttributeString
					(
					null, //writer.LookupPrefix(this.Namespace),
					this.Name,
					this.Namespace,
					this.Value
					);
			}
		}

		#endregion

	}
}
