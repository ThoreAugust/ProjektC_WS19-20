using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombinationsTest
{
    public partial class Edit_Category : Form
    {

        MainWindow mw;
        SetUpDialog sd;

        
        public Edit_Category(SetUpDialog setUpDialog)

        {
            sd = setUpDialog;
            InitializeComponent();
        }

        public Edit_Category(MainWindow main)
        {
            InitializeComponent();
            main = mw;
        }

        public string value { get; internal set; }
   
   
        public void EditCategory_Load()
        {
            ListViewItem newList = new ListViewItem(value);
            newList.SubItems.Add(value);
            categoryList.Items.Add(newList);
            
        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < categoryList.Items.Count; i++)
            {
                if (categoryList.Items[i].Selected)
                {
                    categoryList.Items[i].Remove();
                }
            }
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            ListViewItem newList = new ListViewItem(textBox1.Text);
            newList.SubItems.Add(textBox2.Text);
            //newList.SubItems.Add(DateTime.Now.ToLongTimeString());

            categoryList.Items.Add(newList);

            textBox1.Clear();
            textBox2.Clear();
        }

        private void EditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                categoryList.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                categoryList.SelectedItems[0].SubItems[1].Text = textBox2.Text;
               // categoryList.SelectedItems[0].SubItems[2].Text = txtCarName.Text;
            }
            catch { }

        }
    }

}
