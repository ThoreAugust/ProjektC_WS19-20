namespace BalanceTech
{
    partial class SetUpDialog
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
            this.masterPWLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.masterPWBox = new System.Windows.Forms.TextBox();
            this.categoryBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.masterPWRepeatBox = new System.Windows.Forms.TextBox();
            this.masterPWRepeatLabel = new System.Windows.Forms.Label();
            this.AutostartLabel = new System.Windows.Forms.Label();
            this.AutostartCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // masterPWLabel
            // 
            this.masterPWLabel.AutoSize = true;
            this.masterPWLabel.Location = new System.Drawing.Point(12, 5);
            this.masterPWLabel.Name = "masterPWLabel";
            this.masterPWLabel.Size = new System.Drawing.Size(157, 13);
            this.masterPWLabel.TabIndex = 0;
            this.masterPWLabel.Text = "Bitte gib ein Masterpasswort an!";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(65, 88);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(233, 26);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Wenn du deine Programme kategorisieren willst,\r\ndann gib die Kategorien hier mit " +
    "\";\" getrennt an.";
            // 
            // masterPWBox
            // 
            this.masterPWBox.Location = new System.Drawing.Point(182, 5);
            this.masterPWBox.Name = "masterPWBox";
            this.masterPWBox.PasswordChar = '*';
            this.masterPWBox.Size = new System.Drawing.Size(165, 20);
            this.masterPWBox.TabIndex = 1;
            this.masterPWBox.UseSystemPasswordChar = true;
            // 
            // categoryBox
            // 
            this.categoryBox.Location = new System.Drawing.Point(12, 130);
            this.categoryBox.Multiline = true;
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(335, 67);
            this.categoryBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(141, 206);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // masterPWRepeatBox
            // 
            this.masterPWRepeatBox.Location = new System.Drawing.Point(182, 30);
            this.masterPWRepeatBox.Name = "masterPWRepeatBox";
            this.masterPWRepeatBox.PasswordChar = '*';
            this.masterPWRepeatBox.Size = new System.Drawing.Size(165, 20);
            this.masterPWRepeatBox.TabIndex = 2;
            this.masterPWRepeatBox.UseSystemPasswordChar = true;
            // 
            // masterPWRepeatLabel
            // 
            this.masterPWRepeatLabel.AutoSize = true;
            this.masterPWRepeatLabel.Location = new System.Drawing.Point(12, 30);
            this.masterPWRepeatLabel.Name = "masterPWRepeatLabel";
            this.masterPWRepeatLabel.Size = new System.Drawing.Size(161, 13);
            this.masterPWRepeatLabel.TabIndex = 6;
            this.masterPWRepeatLabel.Text = "Wiederhole das Masterpasswort.";
            // 
            // AutostartLabel
            // 
            this.AutostartLabel.AutoSize = true;
            this.AutostartLabel.Location = new System.Drawing.Point(12, 55);
            this.AutostartLabel.Name = "AutostartLabel";
            this.AutostartLabel.Size = new System.Drawing.Size(115, 13);
            this.AutostartLabel.TabIndex = 7;
            this.AutostartLabel.Text = "Autostart mit Windows.";
            // 
            // AutostartCheckBox
            // 
            this.AutostartCheckBox.AutoSize = true;
            this.AutostartCheckBox.Location = new System.Drawing.Point(182, 55);
            this.AutostartCheckBox.Name = "AutostartCheckBox";
            this.AutostartCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutostartCheckBox.TabIndex = 8;
            this.AutostartCheckBox.UseVisualStyleBackColor = true;
            // 
            // SetUpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 244);
            this.Controls.Add(this.AutostartCheckBox);
            this.Controls.Add(this.AutostartLabel);
            this.Controls.Add(this.masterPWRepeatLabel);
            this.Controls.Add(this.masterPWRepeatBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.masterPWBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.masterPWLabel);
            this.Name = "SetUpDialog";
            this.Text = "SetUpDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label masterPWLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.TextBox masterPWBox;
        private System.Windows.Forms.TextBox categoryBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox masterPWRepeatBox;
        private System.Windows.Forms.Label masterPWRepeatLabel;
        private System.Windows.Forms.Label AutostartLabel;
        private System.Windows.Forms.CheckBox AutostartCheckBox;
    }
}