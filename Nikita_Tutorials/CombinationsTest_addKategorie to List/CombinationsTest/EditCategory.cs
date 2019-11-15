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


        private void AddCategory_Click(object sender, EventArgs e)
        {

            ListViewItem newList = new ListViewItem(textBox1.Text);
            newList.SubItems.Add(textBox2.Text);
            //newList.SubItems.Add(DateTime.Now.ToLongTimeString());

            categoryList.Items.Add(newList);

            textBox1.Clear();
            textBox2.Clear();

        }



        public void EditCategory_Load()
        {
            ListViewItem newList = new ListViewItem(value);
            newList.SubItems.Add(value);
            categoryList.Items.Add(newList);
            
        }

    }

}
