using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XCRI.Interfaces
{
	public interface IXmlElement : INotifyPropertyChanged, INotifyPropertyChanging
	{
        string XsiTypeValue { get; set; }
        string XsiTypeValueNamespace { get; set; }
        string XmlLanguage { get; set; }
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
}
