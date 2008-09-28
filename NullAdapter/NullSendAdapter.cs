
//
// NullSendAdapter.cs
//
// Author:
//    Tomas Restrepo (tomasr@mvps.org)
//

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.XPath;


using Microsoft.BizTalk.TransportProxy.Interop;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;



namespace Winterdom.BizTalk.Adapters {
   /// <summary>
   /// Dev/null Adapter implementation for BizTalk Server 2004.
   /// </summary>
   /// <remarks>
   /// This class implements an Asynchronous Batch-Supported
   /// Send Adapter that just sends messages to dev/null
   /// (i.e. messages go *poof*).
   /// 
   /// <para>
   /// The adapter will simply consume messages sent to it
   /// from the MsgBox and do nothing with them at all.
   /// </para>
   /// </remarks>
   public class NullSendAdapter :
      IBTTransport,
      IBTTransportControl,
      IPersistPropertyBag,
      IBTTransmitter {
      private const string NAME = "/dev/null adapter";
      private const string DESCRIPTION =
               "/dev/null Send Adapter for BizTalk Server 2004";
      private const string VERSION = "1.0.0.1";
      private readonly Guid CLSID = new Guid("{95810ff9-f609-4395-aebe-995855430547}");
      private const string TRANSPORTTYPE = "null";
      private const string PROPNS = "urn:schemas-winterdom-com:nulladapter";

      //
      // Private variables
      //
      private IBTTransportProxy _tp;
      private TerminationController _terminate = new TerminationController();


      #region IBTTransport Members

      public string Name {
         get { return NAME; }
      }

      public string Description {
         get { return DESCRIPTION; }
      }

      public string Version {
         get { return VERSION; }
      }

      public Guid ClassID {
         get { return CLSID; }
      }

      public string TransportType {
         get { return TRANSPORTTYPE; }
      }

      #endregion


      #region IPersistPropertyBag Members

      public void InitNew() {
         // do nothing
      }

      public void GetClassID(out Guid classID) {
         classID = CLSID;
      }

      public void Load(IPropertyBag propertyBag, int errorLog) {
      }

      public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties) {
      }

      #endregion


      #region IBTTransmitter Members

      /// <summary>
      /// Terminate the adapter
      /// </summary>
      /// <remarks>
      /// Wait for all send operations to end,
      /// then release the transport proxy and terminate
      /// </remarks>
      public void Terminate() {
         _terminate.Leave();
         _terminate.Terminate();
         Marshal.ReleaseComObject(_tp);
         _tp = null;
      }

      /// <summary>
      /// Transmit a message handed down by the EPM
      /// </summary>
      /// <param name="msg">Message to send</param>
      /// <returns>True if the message was sent successfuly</returns>
      public bool TransmitMessage(IBaseMessage msg) {
         _terminate.Enter();
         try {
            bool logMessages = Convert.ToBoolean(
                              GetAdapterConfigValue(msg.Context, "logMessages")
                           );

            if ( logMessages ) {
               SystemMessageContext ctxt = new SystemMessageContext(msg.Context);
               LogHelper.LogMessage(msg.MessageID, ctxt.InterchangeID);
            }
            // 
            // discard the message
            //
            return true;
         } finally {
            _terminate.Leave();
         }
      }

      /// <summary>
      /// Initialize the Adapter
      /// </summary>
      /// <param name="transportProxy">Transport Proxy reference</param>
      public void Initialize(IBTTransportProxy transportProxy) {
         _terminate.Enter();
         _tp = transportProxy;
      }


      #endregion


      /// <summary>
      /// Loads the transmit location adapter configuration
      /// and gets the value of the specified field
      /// </summary>
      /// <param name="propBag">PropertyBag</param>
      /// <param name="propname">Property name</param>
      /// <returns>The value</returns>
      public string GetAdapterConfigValue(IBasePropertyBag propBag, string propname) {
         string config = (string)propBag.Read("AdapterConfig", PROPNS);
         if ( config == null )
            return null;

         XPathDocument doc = new XPathDocument(new StringReader(config));
         XPathNavigator nav = doc.CreateNavigator();

         string xpath = string.Format("string(/CustomProps/{0})", propname);
         return (string)nav.Evaluate(xpath);
      }

   } // class NullSendAdapter
} // namespace Winterdom.BizTalk.Adapters
