using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XCRI
{
	/// <summary>
	/// Provides a base implementation of INotifyPropertyChanged and INotifyPropertyChanging.
	/// Also provides protected helper methods for OnPropertyChanged and OnPropertyChanging.
	/// </summary>
	public abstract class NotifyBaseClass : INotifyPropertyChanged, INotifyPropertyChanging
	{

		#region Methods

		#region Protected

		protected void OnPropertyChanging(string propertyName)
		{
			if (this.PropertyChanging == null) { return; }
			this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged == null) { return; }
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		#endregion

		#region INotifyPropertyChanging Members

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

	}
	/*
	/// <summary>
	/// Extends NotifyBaseClass by also exposing an identifier object.
	/// </summary>
	public abstract class NotifyBaseClassWithIdentifiers : NotifyBaseClass, Interfaces.IObjectWithIdentifiers
	{

		#region Properties and Fields

		#region Private

		private List<XCRI.Interfaces.IIdentifier> __Identifiers = new List<Interfaces.IIdentifier>();

		#endregion

		#region Protected

		protected List<XCRI.Interfaces.IIdentifier> _Identifiers
		{
			get { return this.__Identifiers; }
		}

		#endregion

		#endregion

		#region IObjectWithIdentifier Members

		public IEnumerable<XCRI.Interfaces.IIdentifier> Identifiers
		{
			get { return this._Identifiers; }
		}

		#endregion

		#region Methods

		#region Public

		public void AddIdentifier(Interfaces.IIdentifier Identifier)
		{
			this._Identifiers.Add(Identifier);
		}

		#endregion

		#endregion

	}
	*/
}
