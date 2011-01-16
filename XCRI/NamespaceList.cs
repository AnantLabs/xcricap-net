using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI
{
    public class NamespaceList : IEnumerable<NamespaceData>
	{

		private Dictionary<string, NamespaceData> __NamespaceData = new Dictionary<string, NamespaceData>();

		public void Remove(string NamespaceUri)
		{
			if (this.__NamespaceData.ContainsKey(NamespaceUri) == false)
				return;
			this.__NamespaceData.Remove(NamespaceUri);
		}

		public void Add(string NamespaceUri)
		{
			this.Add(NamespaceUri, null, null);
		}

        public void Add(string NamespaceUri, string Prefix)
        {
            this.Add(NamespaceUri, Prefix, null);
        }

        public void Add(string NamespaceUri, string Prefix, string XSDLocation)
        {
            this.__NamespaceData.Add(NamespaceUri, new NamespaceData()
            {
                NamespaceUri = NamespaceUri,
                Prefix = Prefix,
                XSDLocation = XSDLocation
            });
        }

        public bool Contains(string NamespaceUri)
        {
            return this.__NamespaceData.ContainsKey(NamespaceUri);
        }

		public void SetXSDLocation(string NamespaceUri, string XSDLocation)
		{
			if (this.__NamespaceData.ContainsKey(NamespaceUri) == false)
			{
				this.Add(NamespaceUri, null, XSDLocation);
			}
			else
			{
				this.__NamespaceData[NamespaceUri] = new NamespaceData()
				{
					XSDLocation = XSDLocation,
					NamespaceUri = NamespaceUri,
					Prefix = this.__NamespaceData[NamespaceUri].Prefix
				};
			}
		}

		public void SetPrefix(string NamespaceUri, string Prefix)
		{
			if (this.__NamespaceData.ContainsKey(NamespaceUri) == false)
			{
				this.Add(NamespaceUri, Prefix, null);
			}
			else
			{
				this.__NamespaceData[NamespaceUri] = new NamespaceData()
				{
					XSDLocation = this.__NamespaceData[NamespaceUri].XSDLocation,
					NamespaceUri = NamespaceUri,
					Prefix = Prefix
				};
			}
		}

		#region IEnumerable<NamespaceData> Members

		public IEnumerator<NamespaceData> GetEnumerator()
		{
			return this.__NamespaceData.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.__NamespaceData.Values.GetEnumerator();
		}

		#endregion

	}
    public struct NamespaceData
    {
        public string NamespaceUri;
        public string XSDLocation;
        public string Prefix;
    }
}
