
//
// AdapterConfig.cs
//
// Author:
//    Tomas Restrepo (tomas@winterdom.com)
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

using Microsoft.BizTalk.Admin;

namespace Winterdom.BizTalk.Adapters {
   internal class AdapterConfig {
      private string _name;

      public string Name {
         get { return _name; }
         set { _name = value; }
      }

      public string Uri {
         get { return "null://" + Name; }
      }

      public void Load(IPropertyBag bag) {
         string configXml = (string)GetProp(bag, "AdapterConfig");
         if ( string.IsNullOrEmpty(configXml) ) {
            Name = (string)GetProp(bag, "name");
         } else {
            // sometimes it will only be available from here
            LoadFromXml(configXml);
         }
      }

      public void Save(IPropertyBag bag) {
         SetProp(bag, "name", Name);
         SetProp(bag, "URI", Uri);
         SetProp(bag, "AdapterConfig", ToConfigXml());
      }

      public IList<string> Validate() {
         IList<string> warnings = new List<String>();
         if ( string.IsNullOrEmpty(Name) )
            warnings.Add("The Transmit Location Name cannot be empty");
         return warnings;
      }

      public string ToConfigXml() {
         StringWriter sw = new StringWriter();
         using ( XmlWriter writer = new XmlTextWriter(sw) ) {
            writer.WriteStartElement("CustomProps");
            writer.WriteElementString("name", Name);
            writer.WriteElementString("uri", Uri);
            writer.WriteEndElement();
         }
         return sw.ToString();
      }

      private void LoadFromXml(string configXml) {
         XPathDocument doc = new XPathDocument(new StringReader(configXml));
         XPathNavigator nav = doc.CreateNavigator();

         Name = GetProp(nav, "name");
      }

      private object GetProp(IPropertyBag bag, string propname) {
         object value = null;
         bag.Read(propname, out value, 0);
         return value;
      }

      private string GetProp(XPathNavigator nav, string propname) {
         string xpath = String.Format("string(/CustomProps/{0})", propname);
         return (String)nav.Evaluate(xpath);
      }

      private void SetProp(IPropertyBag bag, string propname, object value) {
         bag.Write(propname, ref value);
      }

   } // class AdapterConfig

} // namespace Winterdom.BizTalk.Adapters
