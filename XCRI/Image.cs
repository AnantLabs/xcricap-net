using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
	public class Image : Element, Interfaces.IXmlGenerator
	{

		#region Constructors

		#region Public

		public Image()
			: base("image")
		{
		}

		#endregion

		#endregion

		#region Properties and Fields

		#region Private

		private Uri __Source = null;
		private string __Title = String.Empty;

		#endregion

		#region Protected

		protected Uri _Source
		{
			get { return this.__Source; }
			set
			{
				if (this.__Source == value) { return; }
				this.OnPropertyChanging("Source");
				this.__Source = value;
				this.OnPropertyChanged("Source");
			}
		}

		protected string _Title
		{
			get { return this.__Title; }
			set
			{
				if (this.__Title == value) { return; }
				this.OnPropertyChanging("Title");
				this.__Title = value;
				this.OnPropertyChanged("Title");
			}
		}

		#endregion

		#region Public

		public Uri Source
		{
			get { return this._Source; }
			set { this._Source = value; }
		}
		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region Public override

		public override void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (this.Source == null)
				return;
			base.WriteStartElement(writer, Profile);
			writer.WriteAttributeString("src", this.Source.ToString());
			writer.WriteAttributeString("title", this.Title);
			base.WriteEndElement(writer, Profile);
		}

		#endregion

		#endregion

	}
}
