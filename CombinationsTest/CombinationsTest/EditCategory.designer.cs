namespace CombinationsTest
{
    partial class EditCategory
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
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.categoryList = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maxTimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteCategoryButton = new System.Windows.Forms.Button();
            this.editCategoryButton = new System.Windows.Forms.Button();
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
            this.textBox2.Location = new System.Drawing.Point(173, 53);
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
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "maximale Nutzungszeit";
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(19, 92);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(75, 34);
            this.addCategoryButton.TabIndex = 4;
            this.addCategoryButton.Text = "Kategorie hinzufügen";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // categoryList
            // 
            this.categoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.TimeColumnHeader,
            this.maxTimeColumnHeader});
            this.categoryList.GridLines = true;
            this.categoryList.HideSelection = false;
            this.categoryList.Location = new System.Drawing.Point(12, 142);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(276, 323);
            this.categoryList.TabIndex = 5;
            this.categoryList.UseCompatibleStateImageBehavior = false;
            this.categoryList.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Kategorie";
            this.nameColumnHeader.Width = 151;
            // 
            // TimeColumnHeader
            // 
            this.TimeColumnHeader.Text = "Zeit";
            // 
            // maxTimeColumnHeader
            // 
            this.maxTimeColumnHeader.Text = "Max Zeit";
            // 
            // deleteCategoryButton
            // 
            this.deleteCategoryButton.Location = new System.Drawing.Point(220, 92);
            this.deleteCategoryButton.Name = "deleteCategoryButton";
            this.deleteCategoryButton.Size = new System.Drawing.Size(75, 34);
            this.deleteCategoryButton.TabIndex = 6;
            this.deleteCategoryButton.Text = "Kategorie entfernen";
            this.deleteCategoryButton.UseVisualStyleBackColor = true;
            this.deleteCategoryButton.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // editCategoryButton
            // 
            this.editCategoryButton.Location = new System.Drawing.Point(117, 92);
            this.editCategoryButton.Name = "editCategoryButton";
            this.editCategoryButton.Size = new System.Drawing.Size(75, 34);
            this.editCategoryButton.TabIndex = 7;
            this.editCategoryButton.Text = "Kategorie bearbeiten";
            this.editCategoryButton.UseVisualStyleBackColor = true;
            this.editCategoryButton.Click += new System.EventHandler(this.EditCategory_Click);
            // 
            // EditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 477);
            this.Controls.Add(this.editCategoryButton);
            this.Controls.Add(this.deleteCategoryButton);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "EditCategory";
            this.Text = "Edit Category";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditCategory_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.ListView categoryList;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader maxTimeColumnHeader;
        private System.Windows.Forms.Button deleteCategoryButton;
        private System.Windows.Forms.ColumnHeader TimeColumnHeader;
        private System.Windows.Forms.Button editCategoryButton;
    }
}