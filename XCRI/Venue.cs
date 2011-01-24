using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
	public class Venue : Address, Interfaces.IVenue
	{

		#region Properties and Fields

		#region Private

		private string __Title = String.Empty;
		private Uri __Uri = null;
		private Image __Image = null;

		#endregion

		#region Protected

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

		protected Uri _Uri
		{
			get { return this.__Uri; }
			set
			{
				if (this.__Uri == value) { return; }
				this.OnPropertyChanging("Uri");
				this.__Uri = value;
				this.OnPropertyChanged("Uri");
			}
		}

		protected Image _Image
		{
			get { return this.__Image; }
			set
			{
				if (this.__Image == value) { return; }
				this.OnPropertyChanging("Image");
				this.__Image = value;
				this.OnPropertyChanged("Image");
			}
		}

		#endregion

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

		#region IVenue Members

		public string Title
		{
			get { return this._Title; }
			set { this._Title = value; }
		}

		public Uri Uri
		{
			get { return this._Uri; }
			set { this._Uri = value; }
		}

		public Image Image
		{
			get { return this._Image; }
			set { this._Image = value; }
		}

		public new void GenerateTo(System.Xml.XmlWriter writer, XCRIProfiles Profile)
		{
			if (Profile != XCRIProfiles.XCRI_v1_1)
				throw new ArgumentException("XCRI Profile not supported");
			foreach (Identifier identifier in this.Identifiers)
			{
				if (identifier != null)
					identifier.GenerateTo(writer, Profile);
			}
			if (String.IsNullOrEmpty(this.Title))
				writer.WriteElementString("title", this.Title);
			base.GenerateTo(writer, Profile);
			if (this.Uri != null)
				writer.WriteElementString("url", this.Uri.ToString());
			if (this.Image != null)
				this.Image.GenerateTo(writer, Profile);
		}

		#endregion

	}
}
