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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.currentProgsListView = new System.Windows.Forms.ListView();
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processRuntime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processKillButton = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anzeigenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.programmTabs = new System.Windows.Forms.TabControl();
            this.installedProgs = new System.Windows.Forms.TabPage();
            this.installedProgsListView = new System.Windows.Forms.ListView();
            this.installedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentProgs = new System.Windows.Forms.TabPage();
            this.savedProgs = new System.Windows.Forms.TabPage();
            this.savedProgsListView = new System.Windows.Forms.ListView();
            this.savedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedKat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedUsedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedMaxTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.programmTabs.SuspendLayout();
            this.installedProgs.SuspendLayout();
            this.currentProgs.SuspendLayout();
            this.savedProgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentProgsListView
            // 
            this.currentProgsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processID,
            this.processName,
            this.processTitle,
            this.processRuntime,
            this.processKillButton});
            this.currentProgsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentProgsListView.FullRowSelect = true;
            this.currentProgsListView.GridLines = true;
            this.currentProgsListView.HideSelection = false;
            this.currentProgsListView.Location = new System.Drawing.Point(3, 3);
            this.currentProgsListView.Name = "currentProgsListView";
            this.currentProgsListView.Size = new System.Drawing.Size(643, 638);
            this.currentProgsListView.TabIndex = 0;
            this.currentProgsListView.UseCompatibleStateImageBehavior = false;
            this.currentProgsListView.View = System.Windows.Forms.View.Details;
            this.currentProgsListView.SelectedIndexChanged += new System.EventHandler(this.ListViewProcesses_SelectedIndexChanged);
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
            // processKillButton
            // 
            this.processKillButton.Text = "Beenden";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 54);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // timerNotification
            // 
            this.timerNotification.ContextMenuStrip = this.contextMenuStrip1;
            this.timerNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("timerNotification.Icon")));
            this.timerNotification.Text = "TimerNotification";
            this.timerNotification.Visible = true;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.statistikToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1164, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "MainMenu";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(90, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anzeigenMenuItem});
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.statistikToolStripMenuItem.Text = "Statistik";
            // 
            // anzeigenMenuItem
            // 
            this.anzeigenMenuItem.Name = "anzeigenMenuItem";
            this.anzeigenMenuItem.Size = new System.Drawing.Size(123, 22);
            this.anzeigenMenuItem.Text = "Anzeigen";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionMenuItem,
            this.importMenuItem,
            this.exportMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // optionMenuItem
            // 
            this.optionMenuItem.Name = "optionMenuItem";
            this.optionMenuItem.Size = new System.Drawing.Size(124, 22);
            this.optionMenuItem.Text = "Optionen";
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.Size = new System.Drawing.Size(124, 22);
            this.importMenuItem.Text = "Import";
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exportMenuItem.Text = "Export";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.04467F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.95533F));
            this.tableLayoutPanel1.Controls.Add(this.programmTabs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 676);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // programmTabs
            // 
            this.programmTabs.Controls.Add(this.installedProgs);
            this.programmTabs.Controls.Add(this.currentProgs);
            this.programmTabs.Controls.Add(this.savedProgs);
            this.programmTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programmTabs.Location = new System.Drawing.Point(3, 3);
            this.programmTabs.Name = "programmTabs";
            this.programmTabs.SelectedIndex = 0;
            this.programmTabs.Size = new System.Drawing.Size(657, 670);
            this.programmTabs.TabIndex = 1;
            // 
            // installedProgs
            // 
            this.installedProgs.Controls.Add(this.installedProgsListView);
            this.installedProgs.Location = new System.Drawing.Point(4, 22);
            this.installedProgs.Name = "installedProgs";
            this.installedProgs.Padding = new System.Windows.Forms.Padding(3);
            this.installedProgs.Size = new System.Drawing.Size(649, 644);
            this.installedProgs.TabIndex = 0;
            this.installedProgs.Text = "Installierte Programme";
            this.installedProgs.UseVisualStyleBackColor = true;
            // 
            // installedProgsListView
            // 
            this.installedProgsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.installedName});
            this.installedProgsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.installedProgsListView.GridLines = true;
            this.installedProgsListView.HideSelection = false;
            this.installedProgsListView.Location = new System.Drawing.Point(3, 3);
            this.installedProgsListView.Name = "installedProgsListView";
            this.installedProgsListView.Size = new System.Drawing.Size(643, 638);
            this.installedProgsListView.TabIndex = 0;
            this.installedProgsListView.UseCompatibleStateImageBehavior = false;
            this.installedProgsListView.View = System.Windows.Forms.View.Details;
            // 
            // installedName
            // 
            this.installedName.Text = "Name";
            this.installedName.Width = 200;
            // 
            // currentProgs
            // 
            this.currentProgs.Controls.Add(this.currentProgsListView);
            this.currentProgs.Location = new System.Drawing.Point(4, 22);
            this.currentProgs.Name = "currentProgs";
            this.currentProgs.Padding = new System.Windows.Forms.Padding(3);
            this.currentProgs.Size = new System.Drawing.Size(649, 644);
            this.currentProgs.TabIndex = 1;
            this.currentProgs.Text = "Aktuelle Programme";
            this.currentProgs.UseVisualStyleBackColor = true;
            // 
            // savedProgs
            // 
            this.savedProgs.Controls.Add(this.savedProgsListView);
            this.savedProgs.Location = new System.Drawing.Point(4, 22);
            this.savedProgs.Name = "savedProgs";
            this.savedProgs.Padding = new System.Windows.Forms.Padding(3);
            this.savedProgs.Size = new System.Drawing.Size(649, 644);
            this.savedProgs.TabIndex = 2;
            this.savedProgs.Text = "Gespeicherte Programme";
            this.savedProgs.UseVisualStyleBackColor = true;
            // 
            // savedProgsListView
            // 
            this.savedProgsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.savedName,
            this.savedPath,
            this.savedKat,
            this.savedUsedTime,
            this.savedMaxTime});
            this.savedProgsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedProgsListView.GridLines = true;
            this.savedProgsListView.HideSelection = false;
            this.savedProgsListView.Location = new System.Drawing.Point(3, 3);
            this.savedProgsListView.Name = "savedProgsListView";
            this.savedProgsListView.Size = new System.Drawing.Size(643, 638);
            this.savedProgsListView.TabIndex = 0;
            this.savedProgsListView.UseCompatibleStateImageBehavior = false;
            this.savedProgsListView.View = System.Windows.Forms.View.Details;
            // 
            // savedName
            // 
            this.savedName.Text = "Name";
            this.savedName.Width = 200;
            // 
            // savedPath
            // 
            this.savedPath.Text = "Dateipfad";
            this.savedPath.Width = 150;
            // 
            // savedKat
            // 
            this.savedKat.Text = "Kategorie";
            this.savedKat.Width = 100;
            // 
            // savedUsedTime
            // 
            this.savedUsedTime.Text = "Nutzungszeit";
            this.savedUsedTime.Width = 100;
            // 
            // savedMaxTime
            // 
            this.savedMaxTime.Text = "Max Nutzungszeit";
            this.savedMaxTime.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.programmTabs.ResumeLayout(false);
            this.installedProgs.ResumeLayout(false);
            this.currentProgs.ResumeLayout(false);
            this.savedProgs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView currentProgsListView;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader processTitle;
        private System.Windows.Forms.ColumnHeader processRuntime;
        private System.Windows.Forms.ColumnHeader processKillButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon timerNotification;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl programmTabs;
        private System.Windows.Forms.TabPage installedProgs;
        private System.Windows.Forms.TabPage currentProgs;
        private System.Windows.Forms.TabPage savedProgs;
        private System.Windows.Forms.ListView installedProgsListView;
        private System.Windows.Forms.ListView savedProgsListView;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anzeigenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ColumnHeader installedName;
        private System.Windows.Forms.ColumnHeader savedPath;
        private System.Windows.Forms.ColumnHeader savedName;
        private System.Windows.Forms.ColumnHeader savedKat;
        private System.Windows.Forms.ColumnHeader savedUsedTime;
        private System.Windows.Forms.ColumnHeader savedMaxTime;
    }
}

