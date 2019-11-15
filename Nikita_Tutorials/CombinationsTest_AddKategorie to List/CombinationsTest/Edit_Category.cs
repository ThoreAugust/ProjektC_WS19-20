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
        private List<Edit_Category> cont_Categorys;
        public Edit_Category()
            
        {
            cont_Categorys = new List<Edit_Category>();
            InitializeComponent();
        }


        private void AddCategory_Click(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem();
            item.SubItems.Add(textBox1.Text);
            item.SubItems.Add(textBox2.Text);


            categoryView.Items.Add(item);
            textBox1.Clear();
            textBox2.Clear();

        }

        public string value { get; set; }

        public void SetUpDialog_Load()
        {
            /*bool isUnique = true;
            if (cont_Categorys.Count != 0)
            {
                foreach (Edit_Category category in cont_Categorys)
                {
                    if (categoryView.Items.ContainsKey(category.value))
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
            if (isUnique)
            {*/
                categoryView.Items.Add(value);
           // }
        }

    }
}
