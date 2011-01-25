using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	public interface IXmlElement
	{
        string ElementName { get; set; }
        string ElementNamespace { get; set; }
        ICollection<IXmlAttribute> Attributes { get; }
        XmlBaseClasses.XsiTypeAttribute XsiType { get; }
	}
    public interface IXmlElementWithStringValue
    {
        string Value { get; set; }
    }
    public interface IXmlElementWithChildElements
    {
        ICollection<IXmlElement> ChildElements { get; }
    }
}
