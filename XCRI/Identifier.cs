using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.XmlBaseClasses;

namespace XCRI
{
    public class Identifier : ElementWithStringValue
	{

		#region Constructors

		#region Public

		public Identifier()
            : base("identifier", Configuration.XCRINamespaceUri)
		{

		}

		#endregion

		#endregion

	}
}
