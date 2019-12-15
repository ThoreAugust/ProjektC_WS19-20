namespace BalanceTech
{
    partial class PasswordDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.enterPWLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(25, 86);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(14, 50);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(280, 20);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordBox_KeyDown);
            // 
            // enterPWLabel
            // 
            this.enterPWLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterPWLabel.AutoSize = true;
            this.enterPWLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterPWLabel.Location = new System.Drawing.Point(14, 10);
            this.enterPWLabel.Name = "enterPWLabel";
            this.enterPWLabel.Size = new System.Drawing.Size(279, 34);
            this.enterPWLabel.TabIndex = 3;
            this.enterPWLabel.Text = "Willst du das Programm wirklich schließen?\r\nDann gib dein Passwort ein!";
            this.enterPWLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(207, 86);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.
                ms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 121);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.enterPWLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.ShowInTaskbar = false;
            this.Text = "PasswordDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label enterPWLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}