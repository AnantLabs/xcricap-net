using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Tests.ExtensionMethods;
using System.ComponentModel;
using System.Reflection;

namespace XCRI.Tests.BaseClasses.InterfaceTests
{
    [TestClass]
    public abstract class INotifyPropertyChangingAndINotifyPropertyChanged<T>
        where T : class, INotifyPropertyChanged, INotifyPropertyChanging
    {

        /// <summary>
        /// The element to test
        /// </summary>
        public T ToTest = null;

        /// <summary>
        /// Tests whether an object implements INotifyPropertyChanging
        /// and INotifyPropertyChanged for all properties.
        /// Calls _ModifyProperties to allow objects that inherit to correctly
        /// test their own properties.
        /// </summary>
        [TestMethod]
        public void TestINotifyPropertyChangingAndChanged()
        {
            if (this.ToTest == null)
                throw new ArgumentNullException("item");
            Dictionary<string, PropertyStatus> properties = new Dictionary<string, PropertyStatus>();
            foreach (PropertyInfo property in this.ToTest.GetType().GetPublicProperties())
            {
                if (property.CanRead == false)
                    continue;
                if (property.CanWrite == false)
                    continue;
                if(properties.ContainsKey(property.Name) == false)
                    properties.Add(property.Name, PropertyStatus.NotCalled);
            }
            PropertyChangingEventHandler method1 = (o, e)
                =>
            {
                if (properties.ContainsKey(e.PropertyName) == false)
                    throw new InvalidOperationException("The property '" + e.PropertyName + "' was not found on object type '" + typeof(T).FullName + "'");
                properties[e.PropertyName] |= PropertyStatus.Changing;
            };
            PropertyChangedEventHandler method2 = (o, e)
                =>
            {
                if (properties.ContainsKey(e.PropertyName) == false)
                    throw new InvalidOperationException("The property '" + e.PropertyName + "' was not found on object type '" + typeof(T).FullName + "'");
                properties[e.PropertyName] |= PropertyStatus.Changed;
            };
            this.ToTest.PropertyChanging += method1;
            this.ToTest.PropertyChanged += method2;
            this._ModifyProperties();
            this.ToTest.PropertyChanging -= method1;
            this.ToTest.PropertyChanged -= method2;
            bool returnValue = properties.Values.All((p) =>
            {
                return (p & PropertyStatus.Changed) > 0 && (p & PropertyStatus.Changing) > 0;
            });
            if (returnValue == false)
            {
                List<string> failedProperties = new List<string>();
                foreach (string key in properties.Keys)
                {
                    PropertyStatus propertyStatus = properties[key];
                    if (
                        ((propertyStatus & PropertyStatus.Changed) == 0)
                        ||
                        ((propertyStatus & PropertyStatus.Changing) == 0)
                        )
                        failedProperties.Add(key);
                    
                }
                Assert.Fail("{0} propert{1} ({2}) did not fire PropertyChanged or PropertyChanging.", failedProperties.Count, failedProperties.Count == 1 ? "y" : "ies", String.Join(", ", failedProperties));
            }
        }

        /// <summary>
        /// The status of a property
        /// </summary>
        public enum PropertyStatus
        {
            NotCalled = 0,
            Changing = 1,
            Changed = 2
        }

        /// <summary>
        /// Modifies all properties - ensure that base._ModifyProperties()
        /// is called to ensure that properties in sub-classes are modified too.
        /// Wrap each property test in an Assert.IsTrue with a call to TestProperty
        /// to check each individual property.
        /// </summary>
        /// <example>
        /// Assert.IsTrue(this.TestProperty&lt;string&gt;("XsiTypeValue", "123", "456"), "The XsiTypeValue property does not correctly fire INotifyPropertyChanging or INotifyPropertyChanged");
        /// </example>
        protected virtual void _ModifyProperties()
        {
        }

        /// <summary>
        /// Tests to see whether a specified property correctly fires the "PropertyChanging" and "PropertyChanged" events.
        /// </summary>
        /// <typeparam name="T">The type of the property (e.g. string)</typeparam>
        /// <param name="propertyName">The property name (case sensitive)</param>
        /// <param name="value1">The first value to set the property to</param>
        /// <param name="value2">The second value to set the property to</param>
        /// <returns>true if correctly fired, false otherwise</returns>
        public bool TestProperty<A>(string propertyName, A value1, A value2)
        {
            if (String.IsNullOrEmpty(propertyName))
                throw new ArgumentException("The propertyName argument must be supplied");
            PropertyInfo property = this.ToTest.GetType().GetPublicProperties().Where(p =>
                {
                    return
                        (
                        (p.Name == propertyName)
                        &&
                        (p.PropertyType == typeof(A))
                        );
                }).First();
            if (property == null)
                Assert.Fail("The " + propertyName + " property could not be found on object type " + typeof(T).FullName);
            if (!property.CanRead || !property.CanWrite)
                Assert.Fail("The " + propertyName + " property must be read and write on object type " + typeof(T).FullName);
            PropertyStatus propertyStatus = PropertyStatus.NotCalled;
            PropertyChangingEventHandler method1 = (o, e)
                =>
            {
                if (e.PropertyName == propertyName)
                    propertyStatus |= PropertyStatus.Changing;
            };
            PropertyChangedEventHandler method2 = (o, e)
                =>
            {
                if (e.PropertyName == propertyName)
                    propertyStatus |= PropertyStatus.Changed;
            };
            this.ToTest.PropertyChanging += method1;
            this.ToTest.PropertyChanged += method2;
            property.SetValue(this.ToTest, value1, null);
            property.SetValue(this.ToTest, value2, null);
            this.ToTest.PropertyChanging -= method1;
            this.ToTest.PropertyChanged -= method2;
            bool returnValue = (propertyStatus & PropertyStatus.Changed) > 0 && (propertyStatus & PropertyStatus.Changing) > 0;
            if (returnValue == false)
            {
                if (propertyStatus == PropertyStatus.NotCalled)
                    Assert.Fail("Property {0}  did not fire either PropertyChanging or PropertyChanged", propertyName);
                if (propertyStatus == PropertyStatus.Changing)
                    Assert.Fail("Property {0}  did not fire PropertyChanged", propertyName);
                if (propertyStatus == PropertyStatus.Changed)
                    Assert.Fail("Property {0}  did not fire PropertyChanging", propertyName);
            }
            // Right, now test it does NOT fire if the same object is applied.
            propertyStatus = PropertyStatus.NotCalled;
            property.SetValue(this.ToTest, value2, null);
            this.ToTest.PropertyChanging += method1;
            this.ToTest.PropertyChanged += method2;
            property.SetValue(this.ToTest, value2, null);
            this.ToTest.PropertyChanging -= method1;
            this.ToTest.PropertyChanged -= method2;
            returnValue = (propertyStatus == PropertyStatus.NotCalled);
            if (returnValue == false)
            {
                if (propertyStatus == PropertyStatus.Changing)
                    Assert.Fail("Property {0}  fired PropertyChanged even though the value was set to the same object", propertyName);
                if (propertyStatus == PropertyStatus.Changed)
                    Assert.Fail("Property {0}  did PropertyChanging even though the value was set to the same object", propertyName);
            }
            return returnValue;
        }

    }
}
