using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceTech
{
    public partial class EditCategory : Form
    {
        //declaration
        MainWindow mw;

        //conctructor
        public EditCategory(MainWindow main)
        {   
            InitializeComponent();
            mw = main;
            FillCategoryListView(false);
        }

        //adds items to categoryListView
        public void FillCategoryListView(bool edited)
        {
            List<String> selected = new List<string>();
            if(categoryList.SelectedItems.Count > 0)
            {
                foreach(ListViewItem item in categoryList.SelectedItems)
                {
                    selected.Add(item.SubItems[0].Text);
                }
            }
            categoryList.Items.Clear();
            List<String[]> list = mw.GetCategory();
            ListViewItem lvi;
            foreach (String[] item in list)
            {
                lvi = new ListViewItem(item);
                categoryList.Items.Add(lvi);
                if(edited && textBox1.Text != "" && textBox1.Text == item[0])
                {
                    categoryList.Items[categoryList.Items.Count - 1].Selected = true;
                }
                else
                {
                    if (selected.Contains(item[0]))
                    {
                        categoryList.Items[categoryList.Items.Count - 1].Selected = true;
                    }
                }
            }
            if (edited)
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        //category options delete, add and edit
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (categoryList.SelectedItems.Count > 0)
            {
                for (int i = 0; i < categoryList.SelectedItems.Count; i++)
                {
                    mw.DeleteCategory(categoryList.SelectedItems[i].SubItems[0].Text);
                }
                FillCategoryListView(true);
            }
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                int maxTime;
                if(textBox2.Text == "")
                {
                    maxTime = 0;
                }
                else
                {
                    try
                    {
                        maxTime = Convert.ToInt32(textBox2.Text);
                    }
                    catch
                    {
                        maxTime = 0;
                    }
                }
                mw.AddCategory(textBox1.Text, maxTime);
                FillCategoryListView(true);
            }
        }

        private void EditCategory_Click(object sender, EventArgs e)
        {
            if(categoryList.SelectedItems.Count > 0)
            {
                int maxTime;
                try
                {
                    maxTime = Convert.ToInt32(textBox2.Text);
                }
                catch
                {
                    maxTime = 0;
                }
                if (textBox1.Text != "")
                {
                    mw.EditCategory(categoryList.SelectedItems[0].SubItems[0].Text, textBox1.Text, maxTime);
                }
                else
                {
                    for(int i = 0; i < categoryList.SelectedItems.Count; i++)
                    {
                        var name = categoryList.SelectedItems[i].SubItems[0].Text;
                        mw.EditCategory(name, name, maxTime);
                    }
                }
                FillCategoryListView(true);
            }
        }

        //to close EditCategory-Window
        private void EditCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }

}
