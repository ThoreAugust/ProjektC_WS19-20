namespace CombinationsTest
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.neueKategorieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anzeigenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autostartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neueKategorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.programmTabs = new System.Windows.Forms.TabControl();
            this.installedProgs = new System.Windows.Forms.TabPage();
            this.installedProgsListView = new System.Windows.Forms.ListView();
            this.installedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentProgs = new System.Windows.Forms.TabPage();
            this.savedProgs = new System.Windows.Forms.TabPage();
            this.savedProgsListView = new System.Windows.Forms.ListView();
            this.savedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedKat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedUsedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savedMaxTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailBox = new System.Windows.Forms.GroupBox();
            this.individualLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.individualLimitLabel = new System.Windows.Forms.Label();
            this.kategorieDropDown = new System.Windows.Forms.ComboBox();
            this.kategorieLabel = new System.Windows.Forms.Label();
            this.saveProgButton = new System.Windows.Forms.Button();
            this.maxMinuteUseTimeLabel = new System.Windows.Forms.Label();
            this.maxMinuteUseTimeTextBox = new System.Windows.Forms.TextBox();
            this.maxHourUseTimeLabel = new System.Windows.Forms.Label();
            this.usedTimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.usedTimeLabel = new System.Windows.Forms.Label();
            this.maxUseTimeTrackbar = new System.Windows.Forms.TrackBar();
            this.maxHourUseTimeTextBox = new System.Windows.Forms.TextBox();
            this.maxUseTimeLabel = new System.Windows.Forms.Label();
            this.currentUseTimeTextBox = new System.Windows.Forms.TextBox();
            this.currentUseTimeLabel = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.programmTabs.SuspendLayout();
            this.installedProgs.SuspendLayout();
            this.currentProgs.SuspendLayout();
            this.savedProgs.SuspendLayout();
            this.detailBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxUseTimeTrackbar)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.currentProgsListView.MultiSelect = false;
            this.currentProgsListView.Name = "currentProgsListView";
            this.currentProgsListView.Size = new System.Drawing.Size(606, 638);
            this.currentProgsListView.TabIndex = 0;
            this.currentProgsListView.UseCompatibleStateImageBehavior = false;
            this.currentProgsListView.View = System.Windows.Forms.View.Details;
            this.currentProgsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.currentProgsListView_ColumnClick);
            this.currentProgsListView.Click += new System.EventHandler(this.CurrentProgsListView_Click);
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
            this.einstellungenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1164, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "MainMenu";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueKategorieToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neueKategorieToolStripMenuItem1
            // 
            this.neueKategorieToolStripMenuItem1.Name = "neueKategorieToolStripMenuItem1";
            this.neueKategorieToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.neueKategorieToolStripMenuItem1.Text = "Neue Kategorie";
            this.neueKategorieToolStripMenuItem1.Click += new System.EventHandler(this.NeueKategorieToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
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
            this.optionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autostartToolStripMenuItem});
            this.optionMenuItem.Name = "optionMenuItem";
            this.optionMenuItem.Size = new System.Drawing.Size(124, 22);
            this.optionMenuItem.Text = "Optionen";
            // 
            // autostartToolStripMenuItem
            // 
            this.autostartToolStripMenuItem.CheckOnClick = true;
            this.autostartToolStripMenuItem.Name = "autostartToolStripMenuItem";
            this.autostartToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.autostartToolStripMenuItem.Text = "Autostart";
            this.autostartToolStripMenuItem.Click += new System.EventHandler(this.AutostartToolStripMenuItem_Click);
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
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.HilfeToolStripMenuItem_Click);
            // 
            // neueKategorieToolStripMenuItem
            // 
            this.neueKategorieToolStripMenuItem.Name = "neueKategorieToolStripMenuItem";
            this.neueKategorieToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.neueKategorieToolStripMenuItem.Text = "Neue Kategorie";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.78928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.21072F));
            this.tableLayoutPanel1.Controls.Add(this.programmTabs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.detailBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            this.programmTabs.Size = new System.Drawing.Size(620, 670);
            this.programmTabs.TabIndex = 1;
            this.programmTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.ProgrammTabs_Selected);
            // 
            // installedProgs
            // 
            this.installedProgs.Controls.Add(this.installedProgsListView);
            this.installedProgs.Location = new System.Drawing.Point(4, 22);
            this.installedProgs.Name = "installedProgs";
            this.installedProgs.Padding = new System.Windows.Forms.Padding(3);
            this.installedProgs.Size = new System.Drawing.Size(612, 644);
            this.installedProgs.TabIndex = 0;
            this.installedProgs.Text = "Installierte Programme";
            this.installedProgs.UseVisualStyleBackColor = true;
            // 
            // installedProgsListView
            // 
            this.installedProgsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.installedName,
            this.installedPath});
            this.installedProgsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.installedProgsListView.FullRowSelect = true;
            this.installedProgsListView.GridLines = true;
            this.installedProgsListView.HideSelection = false;
            this.installedProgsListView.Location = new System.Drawing.Point(3, 3);
            this.installedProgsListView.MultiSelect = false;
            this.installedProgsListView.Name = "installedProgsListView";
            this.installedProgsListView.Size = new System.Drawing.Size(606, 638);
            this.installedProgsListView.TabIndex = 0;
            this.installedProgsListView.UseCompatibleStateImageBehavior = false;
            this.installedProgsListView.View = System.Windows.Forms.View.Details;
            this.installedProgsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.installedProgsListView_ColumnClick);
            this.installedProgsListView.Click += new System.EventHandler(this.InstalledProgsListView_Click);
            // 
            // installedName
            // 
            this.installedName.Text = "Name";
            this.installedName.Width = 200;
            // 
            // installedPath
            // 
            this.installedPath.Text = "Dateipfad";
            this.installedPath.Width = 200;
            // 
            // currentProgs
            // 
            this.currentProgs.Controls.Add(this.currentProgsListView);
            this.currentProgs.Location = new System.Drawing.Point(4, 22);
            this.currentProgs.Name = "currentProgs";
            this.currentProgs.Padding = new System.Windows.Forms.Padding(3);
            this.currentProgs.Size = new System.Drawing.Size(612, 644);
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
            this.savedProgs.Size = new System.Drawing.Size(612, 644);
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
            this.savedProgsListView.MultiSelect = false;
            this.savedProgsListView.Name = "savedProgsListView";
            this.savedProgsListView.Size = new System.Drawing.Size(606, 638);
            this.savedProgsListView.TabIndex = 0;
            this.savedProgsListView.UseCompatibleStateImageBehavior = false;
            this.savedProgsListView.View = System.Windows.Forms.View.Details;
            this.savedProgsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.savedProgsListView_ColumnClick);
            this.savedProgsListView.Click += new System.EventHandler(this.SavedProgsListView_Click);
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
            // detailBox
            // 
            this.detailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailBox.Controls.Add(this.individualLimitCheckBox);
            this.detailBox.Controls.Add(this.individualLimitLabel);
            this.detailBox.Controls.Add(this.kategorieDropDown);
            this.detailBox.Controls.Add(this.kategorieLabel);
            this.detailBox.Controls.Add(this.saveProgButton);
            this.detailBox.Controls.Add(this.maxMinuteUseTimeLabel);
            this.detailBox.Controls.Add(this.maxMinuteUseTimeTextBox);
            this.detailBox.Controls.Add(this.maxHourUseTimeLabel);
            this.detailBox.Controls.Add(this.usedTimeProgressBar);
            this.detailBox.Controls.Add(this.usedTimeLabel);
            this.detailBox.Controls.Add(this.maxUseTimeTrackbar);
            this.detailBox.Controls.Add(this.maxHourUseTimeTextBox);
            this.detailBox.Controls.Add(this.maxUseTimeLabel);
            this.detailBox.Controls.Add(this.currentUseTimeTextBox);
            this.detailBox.Controls.Add(this.currentUseTimeLabel);
            this.detailBox.Location = new System.Drawing.Point(629, 12);
            this.detailBox.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.detailBox.Name = "detailBox";
            this.detailBox.Size = new System.Drawing.Size(532, 661);
            this.detailBox.TabIndex = 2;
            this.detailBox.TabStop = false;
            this.detailBox.Text = "detailBox";
            this.detailBox.Visible = false;
            // 
            // individualLimitCheckBox
            // 
            this.individualLimitCheckBox.AutoSize = true;
            this.individualLimitCheckBox.Checked = false;
            this.individualLimitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.individualLimitCheckBox.Location = new System.Drawing.Point(143, 154);
            this.individualLimitCheckBox.Name = "individualLimitCheckBox";
            this.individualLimitCheckBox.Size = new System.Drawing.Size(15, 14);
            this.individualLimitCheckBox.TabIndex = 14;
            this.individualLimitCheckBox.UseVisualStyleBackColor = true;
            // 
            // individualLimitLabel
            // 
            this.individualLimitLabel.AutoSize = true;
            this.individualLimitLabel.Location = new System.Drawing.Point(15, 155);
            this.individualLimitLabel.Name = "individualLimitLabel";
            this.individualLimitLabel.Size = new System.Drawing.Size(89, 13);
            this.individualLimitLabel.TabIndex = 13;
            this.individualLimitLabel.Text = "Individuelles Limit";
            // 
            // kategorieDropDown
            // 
            this.kategorieDropDown.FormattingEnabled = true;
            this.kategorieDropDown.Location = new System.Drawing.Point(166, 255);
            this.kategorieDropDown.Name = "kategorieDropDown";
            this.kategorieDropDown.Size = new System.Drawing.Size(186, 21);
            this.kategorieDropDown.TabIndex = 12;
            this.kategorieDropDown.Text = "Kategorie";
            // 
            // kategorieLabel
            // 
            this.kategorieLabel.AutoSize = true;
            this.kategorieLabel.Location = new System.Drawing.Point(15, 255);
            this.kategorieLabel.Name = "kategorieLabel";
            this.kategorieLabel.Size = new System.Drawing.Size(106, 13);
            this.kategorieLabel.TabIndex = 11;
            this.kategorieLabel.Text = "Kategorie auswählen";
            // 
            // saveProgButton
            // 
            this.saveProgButton.Location = new System.Drawing.Point(380, 629);
            this.saveProgButton.Name = "saveProgButton";
            this.saveProgButton.Size = new System.Drawing.Size(134, 23);
            this.saveProgButton.TabIndex = 10;
            this.saveProgButton.Text = "Einstellungen speichern";
            this.saveProgButton.UseVisualStyleBackColor = true;
            this.saveProgButton.Click += new System.EventHandler(this.saveProgButton_Click);
            // 
            // maxMinuteUseTimeLabel
            // 
            this.maxMinuteUseTimeLabel.AutoSize = true;
            this.maxMinuteUseTimeLabel.Location = new System.Drawing.Point(253, 118);
            this.maxMinuteUseTimeLabel.Name = "maxMinuteUseTimeLabel";
            this.maxMinuteUseTimeLabel.Size = new System.Drawing.Size(45, 13);
            this.maxMinuteUseTimeLabel.TabIndex = 9;
            this.maxMinuteUseTimeLabel.Text = "Minuten";
            // 
            // maxMinuteUseTimeTextBox
            // 
            this.maxMinuteUseTimeTextBox.Location = new System.Drawing.Point(227, 115);
            this.maxMinuteUseTimeTextBox.Name = "maxMinuteUseTimeTextBox";
            this.maxMinuteUseTimeTextBox.Size = new System.Drawing.Size(20, 20);
            this.maxMinuteUseTimeTextBox.TabIndex = 8;
            this.maxMinuteUseTimeTextBox.Text = "0";
            this.maxMinuteUseTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxMinuteUseTimeTextBox.TextChanged += new System.EventHandler(this.MaxMinuteUseTimeTextBox_TextChanged);
            // 
            // maxHourUseTimeLabel
            // 
            this.maxHourUseTimeLabel.AutoSize = true;
            this.maxHourUseTimeLabel.Location = new System.Drawing.Point(174, 118);
            this.maxHourUseTimeLabel.Name = "maxHourUseTimeLabel";
            this.maxHourUseTimeLabel.Size = new System.Drawing.Size(47, 13);
            this.maxHourUseTimeLabel.TabIndex = 7;
            this.maxHourUseTimeLabel.Text = "Stunden";
            // 
            // usedTimeProgressBar
            // 
            this.usedTimeProgressBar.Location = new System.Drawing.Point(166, 194);
            this.usedTimeProgressBar.Name = "usedTimeProgressBar";
            this.usedTimeProgressBar.Size = new System.Drawing.Size(348, 23);
            this.usedTimeProgressBar.Step = 1;
            this.usedTimeProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.usedTimeProgressBar.TabIndex = 6;
            // 
            // usedTimeLabel
            // 
            this.usedTimeLabel.AutoSize = true;
            this.usedTimeLabel.Location = new System.Drawing.Point(15, 194);
            this.usedTimeLabel.Name = "usedTimeLabel";
            this.usedTimeLabel.Size = new System.Drawing.Size(131, 13);
            this.usedTimeLabel.TabIndex = 5;
            this.usedTimeLabel.Text = "Abgelaufene Nutzungszeit";
            // 
            // maxUseTimeTrackbar
            // 
            this.maxUseTimeTrackbar.LargeChange = 3600;
            this.maxUseTimeTrackbar.Location = new System.Drawing.Point(310, 112);
            this.maxUseTimeTrackbar.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.maxUseTimeTrackbar.Maximum = 18000;
            this.maxUseTimeTrackbar.Name = "maxUseTimeTrackbar";
            this.maxUseTimeTrackbar.Size = new System.Drawing.Size(204, 45);
            this.maxUseTimeTrackbar.SmallChange = 1800;
            this.maxUseTimeTrackbar.TabIndex = 4;
            this.maxUseTimeTrackbar.TickFrequency = 1800;
            this.maxUseTimeTrackbar.Scroll += new System.EventHandler(this.MaxUseTimeTrackbar_Scroll);
            // 
            // maxHourUseTimeTextBox
            // 
            this.maxHourUseTimeTextBox.Location = new System.Drawing.Point(143, 115);
            this.maxHourUseTimeTextBox.Name = "maxHourUseTimeTextBox";
            this.maxHourUseTimeTextBox.Size = new System.Drawing.Size(25, 20);
            this.maxHourUseTimeTextBox.TabIndex = 3;
            this.maxHourUseTimeTextBox.Text = "0";
            this.maxHourUseTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxHourUseTimeTextBox.TextChanged += new System.EventHandler(this.MaxHourUseTimeTextBox_TextChanged);
            // 
            // maxUseTimeLabel
            // 
            this.maxUseTimeLabel.AutoSize = true;
            this.maxUseTimeLabel.Location = new System.Drawing.Point(15, 115);
            this.maxUseTimeLabel.Name = "maxUseTimeLabel";
            this.maxUseTimeLabel.Size = new System.Drawing.Size(115, 13);
            this.maxUseTimeLabel.TabIndex = 2;
            this.maxUseTimeLabel.Text = "Maximale Nutzungszeit";
            // 
            // currentUseTimeTextBox
            // 
            this.currentUseTimeTextBox.Location = new System.Drawing.Point(143, 43);
            this.currentUseTimeTextBox.Name = "currentUseTimeTextBox";
            this.currentUseTimeTextBox.ReadOnly = true;
            this.currentUseTimeTextBox.Size = new System.Drawing.Size(146, 20);
            this.currentUseTimeTextBox.TabIndex = 1;
            this.currentUseTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // currentUseTimeLabel
            // 
            this.currentUseTimeLabel.AutoSize = true;
            this.currentUseTimeLabel.Location = new System.Drawing.Point(15, 43);
            this.currentUseTimeLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.currentUseTimeLabel.Name = "currentUseTimeLabel";
            this.currentUseTimeLabel.Size = new System.Drawing.Size(109, 13);
            this.currentUseTimeLabel.TabIndex = 0;
            this.currentUseTimeLabel.Text = "Aktuelle Nutzungszeit";
            // 
            // update
            // 
            this.update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(410, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 8);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 700);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
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
            this.detailBox.ResumeLayout(false);
            this.detailBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxUseTimeTrackbar)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox detailBox;
        private System.Windows.Forms.TrackBar maxUseTimeTrackbar;
        private System.Windows.Forms.TextBox maxHourUseTimeTextBox;
        private System.Windows.Forms.Label maxUseTimeLabel;
        private System.Windows.Forms.TextBox currentUseTimeTextBox;
        private System.Windows.Forms.Label currentUseTimeLabel;
        private System.Windows.Forms.Label usedTimeLabel;
        private System.Windows.Forms.ProgressBar usedTimeProgressBar;
        private System.Windows.Forms.Label maxMinuteUseTimeLabel;
        private System.Windows.Forms.TextBox maxMinuteUseTimeTextBox;
        private System.Windows.Forms.Label maxHourUseTimeLabel;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.ToolStripMenuItem autostartToolStripMenuItem;
        private System.Windows.Forms.Button saveProgButton;
        private System.Windows.Forms.ToolStripMenuItem neueKategorieToolStripMenuItem;
        private System.Windows.Forms.ComboBox kategorieDropDown;
        private System.Windows.Forms.Label kategorieLabel;
        private System.Windows.Forms.ToolStripMenuItem neueKategorieToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader installedPath;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.CheckBox individualLimitCheckBox;
        private System.Windows.Forms.Label individualLimitLabel;
    }
}

