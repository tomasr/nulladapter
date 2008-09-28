namespace Winterdom.BizTalk.Adapters
{
   partial class TransmitLocSettingsDialog
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if ( disposing && (components != null) )
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.tabControl = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.warningsLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.nameTextBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.cancelButton = new System.Windows.Forms.Button();
         this.okButton = new System.Windows.Forms.Button();
         this.tabControl.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl
         // 
         this.tabControl.Controls.Add(this.tabPage1);
         this.tabControl.Location = new System.Drawing.Point(3, 2);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedIndex = 0;
         this.tabControl.Size = new System.Drawing.Size(418, 388);
         this.tabControl.TabIndex = 0;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.warningsLabel);
         this.tabPage1.Controls.Add(this.label2);
         this.tabPage1.Controls.Add(this.nameTextBox);
         this.tabPage1.Controls.Add(this.label1);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(410, 362);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Settings";
         // 
         // warningsLabel
         // 
         this.warningsLabel.ForeColor = System.Drawing.Color.Red;
         this.warningsLabel.Location = new System.Drawing.Point(8, 132);
         this.warningsLabel.Name = "warningsLabel";
         this.warningsLabel.Size = new System.Drawing.Size(370, 127);
         this.warningsLabel.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 71);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(370, 46);
         this.label2.TabIndex = 2;
         this.label2.Text = "Provide a unique name for each transmit location that uses the adapter. This name" +
             " will be used to identify this send port instance and will be used to define the" +
             " URI associated with it.";
         // 
         // nameTextBox
         // 
         this.nameTextBox.Location = new System.Drawing.Point(11, 35);
         this.nameTextBox.Name = "nameTextBox";
         this.nameTextBox.Size = new System.Drawing.Size(367, 20);
         this.nameTextBox.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(154, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Transmit location unique name:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.cancelButton);
         this.panel1.Controls.Add(this.okButton);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 390);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(425, 45);
         this.panel1.TabIndex = 1;
         // 
         // cancelButton
         // 
         this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancelButton.Location = new System.Drawing.Point(346, 10);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 1;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(265, 10);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 23);
         this.okButton.TabIndex = 0;
         this.okButton.Text = "OK";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.OnOKButtonClick);
         // 
         // TransmitLocSettingsDialog
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cancelButton;
         this.ClientSize = new System.Drawing.Size(425, 435);
         this.Controls.Add(this.tabControl);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TransmitLocSettingsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Transmit Location Settings";
         this.tabControl.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.TextBox nameTextBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label warningsLabel;
   }
}