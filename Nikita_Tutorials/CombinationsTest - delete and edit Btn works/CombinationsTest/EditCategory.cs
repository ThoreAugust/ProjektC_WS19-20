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


        public Edit_Category(MainWindow main)
        {
            InitializeComponent();
            mw = main;
            FillListView();
        }
   
        public void FillListView()
        {
            categoryList.Items.Clear();
            List<String[]> list = mw.GetKategorien();
            ListViewItem lvi;
            foreach (String[] item in list)
            {
                lvi = new ListViewItem(item);
                categoryList.Items.Add(lvi);
            }
        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (categoryList.SelectedItems.Count > 0)
            {
                for (int i = 0; i < categoryList.SelectedItems.Count; i++)
                {
                    mw.DeleteKategorie(categoryList.SelectedItems[i].SubItems[0].Text);
                }
                FillListView();
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
                mw.AddKategorie(textBox1.Text, maxTime);
                textBox1.Clear();
                textBox2.Clear();
                FillListView();
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
                    mw.EditKategorie(categoryList.SelectedItems[0].SubItems[0].Text, textBox1.Text, maxTime);
                }
                else
                {
                    for(int i = 0; i < categoryList.SelectedItems.Count; i++)
                    {
                        var name = categoryList.SelectedItems[i].SubItems[0].Text;
                        mw.EditKategorie(name, name, maxTime);
                    }
                }
                textBox1.Clear();
                textBox2.Clear();
                FillListView();
            }
        }
    }

}
