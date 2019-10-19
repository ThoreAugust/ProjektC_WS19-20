namespace CombinationsTest
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
            this.kategorieLabel = new System.Windows.Forms.Label();
            this.masterPWBox = new System.Windows.Forms.TextBox();
            this.kategorieBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.masterPWRepeatBox = new System.Windows.Forms.TextBox();
            this.masterPWRepeatLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // masterPWLabel
            // 
            this.masterPWLabel.AutoSize = true;
            this.masterPWLabel.Location = new System.Drawing.Point(12, 9);
            this.masterPWLabel.Name = "masterPWLabel";
            this.masterPWLabel.Size = new System.Drawing.Size(157, 13);
            this.masterPWLabel.TabIndex = 0;
            this.masterPWLabel.Text = "Bitte gib ein Masterpasswort an!";
            // 
            // kategorieLabel
            // 
            this.kategorieLabel.AutoSize = true;
            this.kategorieLabel.Location = new System.Drawing.Point(65, 72);
            this.kategorieLabel.Name = "kategorieLabel";
            this.kategorieLabel.Size = new System.Drawing.Size(233, 26);
            this.kategorieLabel.TabIndex = 1;
            this.kategorieLabel.Text = "Wenn du deine Programme kategorisieren willst,\r\ndann gib die Kategorien hier mit " +
    "\";\" getrennt an.";
            // 
            // masterPWBox
            // 
            this.masterPWBox.Location = new System.Drawing.Point(182, 2);
            this.masterPWBox.Name = "masterPWBox";
            this.masterPWBox.PasswordChar = '*';
            this.masterPWBox.Size = new System.Drawing.Size(165, 20);
            this.masterPWBox.TabIndex = 2;
            this.masterPWBox.UseSystemPasswordChar = true;
            // 
            // kategorieBox
            // 
            this.kategorieBox.Location = new System.Drawing.Point(12, 114);
            this.kategorieBox.Multiline = true;
            this.kategorieBox.Name = "kategorieBox";
            this.kategorieBox.Size = new System.Drawing.Size(335, 67);
            this.kategorieBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(141, 190);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // masterPWRepeatBox
            // 
            this.masterPWRepeatBox.Location = new System.Drawing.Point(182, 29);
            this.masterPWRepeatBox.Name = "masterPWRepeatBox";
            this.masterPWRepeatBox.PasswordChar = '*';
            this.masterPWRepeatBox.Size = new System.Drawing.Size(165, 20);
            this.masterPWRepeatBox.TabIndex = 5;
            this.masterPWRepeatBox.UseSystemPasswordChar = true;
            // 
            // masterPWRepeatLabel
            // 
            this.masterPWRepeatLabel.AutoSize = true;
            this.masterPWRepeatLabel.Location = new System.Drawing.Point(12, 36);
            this.masterPWRepeatLabel.Name = "masterPWRepeatLabel";
            this.masterPWRepeatLabel.Size = new System.Drawing.Size(161, 13);
            this.masterPWRepeatLabel.TabIndex = 6;
            this.masterPWRepeatLabel.Text = "Wiederhole das Masterpasswort.";
            // 
            // SetUpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 225);
            this.Controls.Add(this.masterPWRepeatLabel);
            this.Controls.Add(this.masterPWRepeatBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.kategorieBox);
            this.Controls.Add(this.masterPWBox);
            this.Controls.Add(this.kategorieLabel);
            this.Controls.Add(this.masterPWLabel);
            this.Name = "SetUpDialog";
            this.Text = "SetUpDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label masterPWLabel;
        private System.Windows.Forms.Label kategorieLabel;
        private System.Windows.Forms.TextBox masterPWBox;
        private System.Windows.Forms.TextBox kategorieBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox masterPWRepeatBox;
        private System.Windows.Forms.Label masterPWRepeatLabel;
    }
}