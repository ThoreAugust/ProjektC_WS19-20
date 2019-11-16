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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addCategory = new System.Windows.Forms.Button();
            this.categoryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteCategory = new System.Windows.Forms.Button();
            this.editCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(173, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategorie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "maximale Nutzungszeit";
            // 
            // addCategory
            // 
            this.addCategory.Location = new System.Drawing.Point(220, 170);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(75, 34);
            this.addCategory.TabIndex = 4;
            this.addCategory.Text = "Kategorie hinzufügen";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // categoryList
            // 
            this.categoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.categoryList.GridLines = true;
            this.categoryList.Location = new System.Drawing.Point(19, 231);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(276, 237);
            this.categoryList.TabIndex = 5;
            this.categoryList.UseCompatibleStateImageBehavior = false;
            this.categoryList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kategorie";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "maximale Nutzungszeit";
            this.columnHeader2.Width = 120;
            // 
            // deleteCategory
            // 
            this.deleteCategory.Location = new System.Drawing.Point(120, 170);
            this.deleteCategory.Name = "deleteCategory";
            this.deleteCategory.Size = new System.Drawing.Size(75, 34);
            this.deleteCategory.TabIndex = 6;
            this.deleteCategory.Text = "Kategorie entfernen";
            this.deleteCategory.UseVisualStyleBackColor = true;
            this.deleteCategory.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // editCategory
            // 
            this.editCategory.Location = new System.Drawing.Point(19, 170);
            this.editCategory.Name = "editCategory";
            this.editCategory.Size = new System.Drawing.Size(75, 34);
            this.editCategory.TabIndex = 7;
            this.editCategory.Text = "Kategorie bearbeiten";
            this.editCategory.UseVisualStyleBackColor = true;
            this.editCategory.Click += new System.EventHandler(this.EditCategory_Click);
            // 
            // Edit_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 477);
            this.Controls.Add(this.editCategory);
            this.Controls.Add(this.deleteCategory);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.addCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "Edit_Category";
            this.Text = "Edit Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.ListView categoryList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button deleteCategory;
        private System.Windows.Forms.Button editCategory;
    }
}