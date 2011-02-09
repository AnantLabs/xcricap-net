using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XCRI.Interfaces
{
	/// <summary>
    /// Represents an element within the output XML document.
    /// Contains standard element properties allowing the type, language
    /// and resource status to be provided.
    /// </summary>
    public interface IElement : INotifyPropertyChanged, INotifyPropertyChanging
	{
        /// <summary>
        /// The XSI type to output.  Normally, type is indicated using an attribute as follows:
        ///     xsi:type="namespace:value"
        /// This property indicates the "value" section indicated above.
        /// </summary>
        string XsiTypeValue { get; set; }
        /// <summary>
        /// The XSI type to output.  Normally, type is indicated using an attribute as follows:
        ///     xsi:type="namespace:value"
        /// This property indicates the "namespace" section indicated above.
        /// PLEASE NOTE that this property should be set to the full namespace and the system
        /// will correctly output the prefix provided it has been set properly in the NamespaceList
        /// property of the associated Generator object.
        /// </summary>
        string XsiTypeValueNamespace { get; set; }
        /// <summary>
        /// The language of the resource
        /// </summary>
        string XmlLanguage { get; set; }
	}
    public interface IElementWithSingleValue : IElement
    {
        object Value { get; set; }
        bool RenderRaw { get; set; }
    }
    public interface IElementWithSingleValue<T> : IElementWithSingleValue
    {
        new T Value { get; set; }
        string GetElementValueAsString();
    }
}
