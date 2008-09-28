
//
// TransmitLocSettingsDialog.cs
//
// Author:
//    Tomas Restrepo (tomas@winterdom.com)
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Winterdom.BizTalk.Adapters {
   internal partial class TransmitLocSettingsDialog : Form {
      private AdapterConfig _config;

      public AdapterConfig Config {
         get { return _config; }
         set { _config = value; OnConfigChanged(); }
      }

      public TransmitLocSettingsDialog() {
         InitializeComponent();
      }

      private void OnCancelButtonClick(object sender, EventArgs e) {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      private void OnOKButtonClick(object sender, EventArgs e) {
         if ( UpdateConfig() ) {
            DialogResult = DialogResult.OK;
            Close();
         }
      }

      private void OnConfigChanged() {
         if ( Config != null && !String.IsNullOrEmpty(Config.Name) ) {
            nameTextBox.Text = Config.Name;
         } else {
            nameTextBox.Text = "<Please enter a new name>";
         }
      }

      private bool UpdateConfig() {
         if ( Config != null ) {
            Config.Name = nameTextBox.Text;

            IList<string> warnings = Config.Validate();
            if ( warnings.Count > 0 ) {
               warningsLabel.Text = "";
               foreach ( string s in warnings )
                  warningsLabel.Text += s + "\r\n";
               return false;
            }
         }
         return true;
      }

   } // class TransmitLocSettingsDialog

} // namespace Winterdom.BizTalk.Adapters