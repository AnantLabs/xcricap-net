using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XCRI.Tests.XmlGeneration
{
    [TestClass]
    public abstract class XmlGeneratorBase<T> : Interfaces.ITestXmlGenerator
        where T : class, XCRI.XmlGeneration.Interfaces.IXmlGenerator
    {

        public T XmlGenerator = null;
        protected Action<XmlNode, string, string> HasCorrectNameAndNamespace = (node, name, ns)
            =>
            {
                if (!XmlGeneratorBase<T>.__TestNodeHasCorrectNameAndNamespace(node, name, ns))
                    Assert.Fail("The {0} element was not produced, or it was not in the {1} namespace", name, ns);
            };
        protected Action<XmlNode, string> ContainsStringValue = (node, stringValue)
            =>
            {
                if (!(node.FirstChild.Value == stringValue))
                    Assert.Fail("The {0} element did not contain the correct text", node.LocalName);
            };
        protected Action<IEnumerable<XmlNode>, string, string> ContainsElement = (nodeList, name, ns)
            =>
            {
                bool found = false;
                foreach (XmlNode childNode in nodeList)
                    if (
                        (childNode.LocalName == name)
                        &&
                        (childNode.NamespaceURI == ns)
                        )
                    {
                        found = true;
                        break;
                    }
                if (found == false)
                    Assert.Fail("The collection did not contain a {0} element, or the element was not in the {1} namespace", name, ns);
            };
        protected Func<XmlNode, string, string, XmlNode> FindChildNode = (node, name, ns)
            =>
            {
                if(node == null)
                    throw new ArgumentNullException("node");
                foreach(XmlNode child in node.ChildNodes)
                {
                    if (
                        (child.LocalName == name)
                        &&
                        (child.NamespaceURI == ns)
                        )
                        return child;
                }
                throw new XmlException("Node not found");
            };
        protected Func<XmlNode, string, string, IEnumerable<XmlNode>> FindChildNodes = (node, name, ns)
            =>
        {
            if (node == null)
                throw new ArgumentNullException("node");
            List<XmlNode> toReturn = new List<XmlNode>();
            foreach (XmlNode child in node.ChildNodes)
            {
                if (
                    (child.LocalName == name)
                    &&
                    (child.NamespaceURI == ns)
                    )
                    toReturn.Add(child);
            }
            return toReturn;
        };
        protected Action<XmlNode, string, string, string> HasAttributeWithValue = (node, name, ns, value)
            =>
        {
            if (!XmlGeneratorBase<T>.__TestNodeHasAttributeWithValue(node, name, ns, value))
                Assert.Fail("The {0} element did not output the {1} {2} attribute correctly", node.LocalName, ns, name);
        };
        protected Action<XmlNode, string, string, string, string> HasAttributeWithValueWithNamespace = (node, name, ns, value, valueNs)
            =>
        {
            if (!XmlGeneratorBase<T>.__TestNodeHasAttributeWithValue(node, name, ns, value, valueNs))
                Assert.Fail("The {0} element did not output the {1} {2} attribute correctly, or the value was not in the {3} namespace", node.LocalName, ns, name, valueNs);
        };

        protected Action<XmlNode, string, string> HasChildElement = (node, name, ns)
        =>
        {
            if (!XmlGeneratorBase<T>.__TestNodeHasChildElements(node, name, ns, 1))
                Assert.Fail("The {0} element did not output {1} expected childnodes named {2} in the {3} namespace", node.LocalName, 1, name, ns);
        };

        protected Action<XmlNode, string, string, int> HasChildElements = (node, name, ns, expectedCount)
            =>
        {
            if (!XmlGeneratorBase<T>.__TestNodeHasChildElements(node, name, ns, expectedCount))
                Assert.Fail("The {0} element did not output {1} expected childnodes named {2} in the {3} namespace", node.LocalName, expectedCount, name, ns);
        };

        #region Methods

        public virtual void TestNode
            (
            XmlNode toTest,
            params Action<XmlNode>[] actions)
        {
            if (actions == null)
                return;
            foreach (Action<XmlNode> action in actions)
            {
                action(toTest);
            }
        }

        public virtual void TestNodes
            (
            IEnumerable<XmlNode> toTest,
            params Action<IEnumerable<XmlNode>>[] actions)
        {
            if (actions == null)
                return;
            foreach (Action<IEnumerable<XmlNode>> action in actions)
            {
                action(toTest);
            }
        }

        #region Private static

        private static bool __TestNodeHasChildElements
            (
            XmlNode node,
            string childElementName,
            string childElementNamespace,
            int expectedCount
            )
        {
            if (node == null)
                return false;
            int foundChildElements = 0;
            foreach (XmlNode child in node.ChildNodes)
                if (
                    (child.LocalName == childElementName)
                    &&
                    (child.NamespaceURI == childElementNamespace)
                    )
                    foundChildElements++;
            return foundChildElements == expectedCount;
        }

        private static bool __TestNodeHasCorrectNameAndNamespace
            (
            XmlNode toTest,
            string name,
            string ns
            )
        {
            if (toTest == null)
                return false;
            return (
                    (toTest.LocalName == name)
                    &&
                    (toTest.NamespaceURI == ns)
                    );
        }

        private static bool __TestNodeHasAttribute
            (
            XmlNode toTest,
            string name,
            string ns
            )
        {
            if (toTest == null)
                return false;
            if (toTest.Attributes == null)
                return false;
            foreach (XmlAttribute attr in toTest.Attributes)
            {
                if (
                    (attr.LocalName == name)
                    &&
                    (attr.NamespaceURI == ns)
                    )
                    return true;
            }
            return false;
        }

        private static bool __TestNodeHasAttributeWithValue
            (
            XmlNode toTest,
            string name,
            string ns,
            string value
            )
        {
            if (toTest == null)
                return false;
            if (toTest.Attributes == null)
                return false;
            foreach (XmlAttribute attr in toTest.Attributes)
            {
                if (
                    (attr.LocalName == name)
                    &&
                    (attr.NamespaceURI == ns)
                    &&
                    (attr.Value == value)
                    )
                    return true;
                if (
                    (attr.LocalName == name)
                    &&
                    (String.IsNullOrEmpty(attr.Prefix))
                    &&
                    (String.IsNullOrEmpty(attr.NamespaceURI))
                    &&
                    (toTest.NamespaceURI == ns)
                    &&
                    (attr.Value == value)
                    )
                    return true;
            }
            return false;
        }

        private static bool __TestNodeHasAttributeWithValue
            (
            XmlNode toTest,
            string name,
            string ns,
            string value,
            string valueNs
            )
        {
            return XmlGeneratorBase<T>.__TestNodeHasAttributeWithValue
                (
                toTest,
                name,
                ns,
                String.Format("{0}:{1}", toTest.GetPrefixOfNamespace(valueNs), value)
                );
        }

        #endregion

        #region Protected virtual

        protected virtual void _WriteStartRootNode
            (
            System.Xml.XmlWriter xmlWriter,
            string name,
            string ns,
            NamespaceList nsList
            )
        {
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement(name, ns);
            if (nsList != null)
            {
                StringBuilder schemaLocation = new StringBuilder();
                foreach (NamespaceData nsd in nsList)
                {
                    if (String.IsNullOrEmpty(nsd.NamespaceUri) == true)
                        continue;
                    if (String.IsNullOrEmpty(nsd.Prefix) == false)
                        xmlWriter.WriteAttributeString("xmlns", nsd.Prefix, null, nsd.NamespaceUri);
                    if (String.IsNullOrEmpty(nsd.XSDLocation) == false)
                        schemaLocation.AppendFormat("{0} {1} ", nsd.NamespaceUri, nsd.XSDLocation);
                }
                xmlWriter.WriteAttributeString("xsi", "schemaLocation", null, schemaLocation.ToString().Trim());
            }
        }

        protected virtual System.Xml.XmlWriterSettings _GetWriterSettings()
        {
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.ConformanceLevel = System.Xml.ConformanceLevel.Document;
            return xmlWriterSettings;
        }

        protected virtual XmlNode _GetGeneratedNode
            (
            Action<System.Xml.XmlWriter> generateOutput
            )
        {
            return this._GetGeneratedNodes(generateOutput)[0];
        }

        protected virtual IList<XmlNode> _GetGeneratedNodes
           (
           Action<System.Xml.XmlWriter> generateOutput
           )
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (System.IO.StringWriter writer = new System.IO.StringWriter(stringBuilder))
            {
                using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlTextWriter.Create(writer, this._GetWriterSettings()))
                {
                    this._WriteStartRootNode
                        (
                        xmlWriter,
                        "testNode",
                        "http://www.craighawker.co.uk/xcri/1.1/tests",
                        NamespaceList.GetNamespaces(NamespaceList.Namespaces.None)
                        );
                    xmlWriter.Flush();
                    int startAt = stringBuilder.ToString().Length;
                    generateOutput(xmlWriter);
                    xmlWriter.Flush();
                    xmlWriter.WriteEndElement();
                }
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(stringBuilder.ToString());
            List<XmlNode> toReturn = new List<XmlNode>();
            foreach (XmlNode child in document.DocumentElement.ChildNodes)
                toReturn.Add(child);
            return toReturn;
        }

        #endregion

        #endregion

    }
}
