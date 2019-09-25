namespace CombinationsTest
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processRuntime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processLabel = new System.Windows.Forms.Label();
            this.processKillButton = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewProcesses
            // 
            this.listViewProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processID,
            this.processName,
            this.processTitle,
            this.processRuntime,
            this.processKillButton});
            this.listViewProcesses.FullRowSelect = true;
            this.listViewProcesses.GridLines = true;
            this.listViewProcesses.HideSelection = false;
            this.listViewProcesses.Location = new System.Drawing.Point(12, 101);
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(1140, 587);
            this.listViewProcesses.TabIndex = 0;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewProcesses.View = System.Windows.Forms.View.Details;
            this.listViewProcesses.SelectedIndexChanged += new System.EventHandler(this.ListViewProcesses_SelectedIndexChanged);
            // 
            // processID
            // 
            this.processID.Text = "ID";
            // 
            // processName
            // 
            this.processName.Text = "Name";
            this.processName.Width = 200;
            // 
            // processTitle
            // 
            this.processTitle.Text = "Title";
            this.processTitle.Width = 200;
            // 
            // processRuntime
            // 
            this.processRuntime.Text = "Time";
            this.processRuntime.Width = 120;
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.Location = new System.Drawing.Point(13, 82);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(138, 13);
            this.processLabel.TabIndex = 1;
            this.processLabel.Text = "Currently running Processes";
            // 
            // processKillButton
            // 
            this.processKillButton.Text = "Beenden";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 700);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.listViewProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewProcesses;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader processTitle;
        private System.Windows.Forms.ColumnHeader processRuntime;
        private System.Windows.Forms.ColumnHeader processKillButton;
    }
}

