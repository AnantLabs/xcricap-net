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
        IList<IXmlAttribute> Attributes { get; }
        XmlBaseClasses.XsiTypeAttribute XsiType { get; }
        ResourceStatus ResourceStatus { get; set; }
	}
    public interface IXmlElementWithSingleValue : IXmlElement
    {
        object Value { get; set; }
        bool RenderRaw { get; set; }
    }
    public interface IXmlElementWithSingleValue<T> : IXmlElementWithSingleValue
    {
        new T Value { get; set; }
    }
    public interface IXmlElementWithChildElements : IXmlElement
    {
        IList<IXmlElement> ChildElements { get; }
    }
}
