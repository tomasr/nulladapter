
//
// NullAdapterMgmt.cs
//
// Author:
//    Tomas Restrepo (tomas@winterdom.com)
//

using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml;

using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Adapter.Framework;

namespace Winterdom.BizTalk.Adapters {
   /// <summary>
   /// Adapter Management class for the NullAdapter.
   /// </summary>
   public class NullAdapterMgmt
      : IAdapterConfig,
        IAdapterConfigValidation {
      private const string NS = "Winterdom.BizTalk.Adapters";


      #region IAdapterConfig Members

      public string GetConfigSchema(ConfigType configType) {
         return null;
      }

      public Result GetSchema(string uri, string namespaceName, out string fileLocation) {
         fileLocation = null;
         return Result.Continue;
      }

      #endregion

      #region IAdapterConfigValidation Members

      public string ValidateConfiguration(ConfigType configType, string configuration) {
         return configuration;
      }

      #endregion

   } // class NullAdapterMgmt

} // namespace Winterdom.BizTalk.Adapters
