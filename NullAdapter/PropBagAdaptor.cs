
//
// PropBagAdaptor.cs
//
// Author:
//    Tomas Restrepo (tomas@winterdom.com)
//

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.BizTalk.Admin;
using IPB = Microsoft.BizTalk.ExplorerOM.IPropertyBag;

namespace Winterdom.BizTalk.Adapters {
   internal class PropBagAdaptor : IPropertyBag {
      private IPB _bag;

      public PropBagAdaptor(IPB bag) {
         if ( bag == null )
            throw new ArgumentNullException("bag");
         _bag = bag;
      }

      #region IPB Members

      public void Read(string propName, out object ptrVar, int errorLog) {
         _bag.Read(propName, out ptrVar, errorLog);
      }

      public void Write(string propName, ref object ptrVar) {
         _bag.Write(propName, ref ptrVar);
      }

      #endregion
   } // class PropBagAdaptor
} // namespace Winterdom.BizTalk.Adapters
