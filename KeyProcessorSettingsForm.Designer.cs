namespace WriteLogKeyProcessor
{
    partial class KeyProcessorSettingsForm
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
            if (disposing && (components != null))
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkedListBoxRadio1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxRadio2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxRadio3 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxRadio4 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxRadio1 = new System.Windows.Forms.CheckBox();
            this.checkBoxRadio2 = new System.Windows.Forms.CheckBox();
            this.checkBoxRadio3 = new System.Windows.Forms.CheckBox();
            this.checkBoxRadio4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(377, 139);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(56, 23);
            this.buttonOK.TabIndex = 40;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(439, 139);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(56, 23);
            this.buttonCancel.TabIndex = 41;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxRadio1
            // 
            this.checkedListBoxRadio1.CheckOnClick = true;
            this.checkedListBoxRadio1.FormattingEnabled = true;
            this.checkedListBoxRadio1.Location = new System.Drawing.Point(3, 37);
            this.checkedListBoxRadio1.Name = "checkedListBoxRadio1";
            this.checkedListBoxRadio1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxRadio1.TabIndex = 4;
            this.checkedListBoxRadio1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRadio1_ItemCheck);
            // 
            // checkedListBoxRadio2
            // 
            this.checkedListBoxRadio2.CheckOnClick = true;
            this.checkedListBoxRadio2.FormattingEnabled = true;
            this.checkedListBoxRadio2.Location = new System.Drawing.Point(129, 37);
            this.checkedListBoxRadio2.Name = "checkedListBoxRadio2";
            this.checkedListBoxRadio2.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxRadio2.TabIndex = 11;
            this.checkedListBoxRadio2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRadio2_ItemCheck);
            // 
            // checkedListBoxRadio3
            // 
            this.checkedListBoxRadio3.CheckOnClick = true;
            this.checkedListBoxRadio3.FormattingEnabled = true;
            this.checkedListBoxRadio3.Location = new System.Drawing.Point(255, 37);
            this.checkedListBoxRadio3.Name = "checkedListBoxRadio3";
            this.checkedListBoxRadio3.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxRadio3.TabIndex = 22;
            this.checkedListBoxRadio3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRadio3_ItemCheck);
            // 
            // checkedListBoxRadio4
            // 
            this.checkedListBoxRadio4.CheckOnClick = true;
            this.checkedListBoxRadio4.FormattingEnabled = true;
            this.checkedListBoxRadio4.Location = new System.Drawing.Point(381, 37);
            this.checkedListBoxRadio4.Name = "checkedListBoxRadio4";
            this.checkedListBoxRadio4.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxRadio4.TabIndex = 33;
            this.checkedListBoxRadio4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRadio4_ItemCheck);
            // 
            // checkBoxRadio1
            // 
            this.checkBoxRadio1.AutoSize = true;
            this.checkBoxRadio1.Location = new System.Drawing.Point(13, 13);
            this.checkBoxRadio1.Name = "checkBoxRadio1";
            this.checkBoxRadio1.Size = new System.Drawing.Size(63, 17);
            this.checkBoxRadio1.TabIndex = 1;
            this.checkBoxRadio1.Text = "Radio &1";
            this.checkBoxRadio1.ThreeState = true;
            this.checkBoxRadio1.UseVisualStyleBackColor = true;
            this.checkBoxRadio1.CheckStateChanged += new System.EventHandler(this.checkBoxRadio1_CheckedChanged);
            // 
            // checkBoxRadio2
            // 
            this.checkBoxRadio2.AutoSize = true;
            this.checkBoxRadio2.Location = new System.Drawing.Point(135, 13);
            this.checkBoxRadio2.Name = "checkBoxRadio2";
            this.checkBoxRadio2.Size = new System.Drawing.Size(63, 17);
            this.checkBoxRadio2.TabIndex = 10;
            this.checkBoxRadio2.Text = "Radio &2";
            this.checkBoxRadio2.ThreeState = true;
            this.checkBoxRadio2.UseVisualStyleBackColor = true;
            this.checkBoxRadio2.CheckStateChanged += new System.EventHandler(this.checkBoxRadio2_CheckedChanged);
            // 
            // checkBoxRadio3
            // 
            this.checkBoxRadio3.AutoSize = true;
            this.checkBoxRadio3.Location = new System.Drawing.Point(264, 13);
            this.checkBoxRadio3.Name = "checkBoxRadio3";
            this.checkBoxRadio3.Size = new System.Drawing.Size(63, 17);
            this.checkBoxRadio3.TabIndex = 20;
            this.checkBoxRadio3.Text = "Radio &3";
            this.checkBoxRadio3.ThreeState = true;
            this.checkBoxRadio3.UseVisualStyleBackColor = true;
            this.checkBoxRadio3.CheckStateChanged += new System.EventHandler(this.checkBoxRadio3_CheckedChanged);
            // 
            // checkBoxRadio4
            // 
            this.checkBoxRadio4.AutoSize = true;
            this.checkBoxRadio4.Location = new System.Drawing.Point(389, 13);
            this.checkBoxRadio4.Name = "checkBoxRadio4";
            this.checkBoxRadio4.Size = new System.Drawing.Size(63, 17);
            this.checkBoxRadio4.TabIndex = 30;
            this.checkBoxRadio4.Text = "Radio &4";
            this.checkBoxRadio4.ThreeState = true;
            this.checkBoxRadio4.CheckStateChanged += new System.EventHandler(this.checkBoxRadio4_CheckedChanged);
            // 
            // KeyProcessorSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(509, 169);
            this.Controls.Add(this.checkBoxRadio1);
            this.Controls.Add(this.checkBoxRadio2);
            this.Controls.Add(this.checkBoxRadio3);
            this.Controls.Add(this.checkBoxRadio4);
            this.Controls.Add(this.checkedListBoxRadio4);
            this.Controls.Add(this.checkedListBoxRadio3);
            this.Controls.Add(this.checkedListBoxRadio2);
            this.Controls.Add(this.checkedListBoxRadio1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyProcessorSettingsForm";
            this.Text = "Allowed Bands per Radio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RunModeSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.RunModeSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckedListBox checkedListBoxRadio1;
        private System.Windows.Forms.CheckedListBox checkedListBoxRadio2;
        private System.Windows.Forms.CheckedListBox checkedListBoxRadio3;
        private System.Windows.Forms.CheckedListBox checkedListBoxRadio4;
        private System.Windows.Forms.CheckBox checkBoxRadio1;
        private System.Windows.Forms.CheckBox checkBoxRadio2;
        private System.Windows.Forms.CheckBox checkBoxRadio3;
        private System.Windows.Forms.CheckBox checkBoxRadio4;
    }
}