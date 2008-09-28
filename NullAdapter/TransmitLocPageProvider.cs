
//
// TransmitLocPageProvider.cs
//
// Author:
//    Tomas Restrepo (tomas@winterdom.com)
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Microsoft.BizTalk.Admin;
using IPPB = Microsoft.BizTalk.ExplorerOM.IPersistPropertyBag;
using IPB = Microsoft.BizTalk.ExplorerOM.IPropertyBag;


namespace Winterdom.BizTalk.Adapters {
   [ComVisible(true)]
   [Guid("c6085098-b9f6-4214-be1c-b07ef5265e4d")]
   [ClassInterface(ClassInterfaceType.None)]
   public class TransmitLocPageProvider
      : IPropertyPageFrame,
        IPersistPropertyBag,
        IPPB {
      private AdapterConfig _config = new AdapterConfig();

      #region IPropertyPageFrame Members

      public bool ShowPropertyFrame(IntPtr hwndParent, string pageTitle) {
         NativeWindow wnd = new NativeWindow();
         try {
            wnd.AssignHandle(hwndParent);
            using ( TransmitLocSettingsDialog dlg = new TransmitLocSettingsDialog() ) {
               dlg.Text = pageTitle ?? "";
               dlg.Config = _config;
               DialogResult res = dlg.ShowDialog(wnd);
               return res == DialogResult.OK;
            }
         } finally {
            wnd.ReleaseHandle();
         }
      }

      #endregion

      #region IPersistPropertyBag Members

      public void GetClassID(out Guid classID) {
         classID = new Guid("c6085098-b9f6-4214-be1c-b07ef5265e4d");
      }

      public void InitNew() {
      }

      public void Load(IPropertyBag propertyBag, int errorLog) {
         _config.Load(propertyBag);
      }

      public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties) {
         _config.Save(propertyBag);
      }

      #endregion


      #region IPPB Members

      public void Load(IPB propertyBag, int errorLog) {
         _config.Load(new PropBagAdaptor(propertyBag));
      }

      public void Save(IPB propertyBag, bool clearDirty, bool saveAllProperties) {
         _config.Save(new PropBagAdaptor(propertyBag));
      }

      #endregion

   } // class TransmitLocPageProvider

} // namespace Winterdom.BizTalk.Adapters
