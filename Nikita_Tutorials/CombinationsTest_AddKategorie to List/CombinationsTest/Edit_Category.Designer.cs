namespace CombinationsTest
{
    partial class Edit_Category
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
            this.categoryView = new System.Windows.Forms.ListView();
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maxTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addCategory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryView
            // 
            this.categoryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.category,
            this.maxTime});
            this.categoryView.GridLines = true;
            this.categoryView.Location = new System.Drawing.Point(41, 370);
            this.categoryView.Name = "categoryView";
            this.categoryView.Size = new System.Drawing.Size(338, 220);
            this.categoryView.TabIndex = 0;
            this.categoryView.UseCompatibleStateImageBehavior = false;
            this.categoryView.View = System.Windows.Forms.View.Details;
            // 
            // category
            // 
            this.category.Text = "Kategorien";
            this.category.Width = 166;
            // 
            // maxTime
            // 
            this.maxTime.Text = "maximale Nutzungszeit";
            this.maxTime.Width = 175;
            // 
            // addCategory
            // 
            this.addCategory.Location = new System.Drawing.Point(184, 192);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(100, 36);
            this.addCategory.TabIndex = 1;
            this.addCategory.Text = "Kategorie hinzufügen";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addCategory);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(193, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 253);
            this.panel1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(184, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategorie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "maximale Nutzungszeit";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 2;
            // 
            // Edit_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.categoryView);
            this.Name = "Edit_Category";
            this.Text = "Edit_Category";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView categoryView;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ColumnHeader maxTime;
        public System.Windows.Forms.ColumnHeader category;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}