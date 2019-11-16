
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
    public partial class SetUpDialog : Form
    {
        PasswordHandler pwHandler;
        MainWindow mw;
        Edit_Category ed;
        string pass;
        private Edit_Category edit_Category;

        public SetUpDialog(MainWindow main)
        {
            mw = main;
            ed = new Edit_Category(this);
            pwHandler = new PasswordHandler();
            pwHandler.readPassFromLog();
            InitializeComponent();
        }


        private void OkButton_Click(object sender, EventArgs e)
        {
            
            if(masterPWBox.Text.Equals(masterPWRepeatBox.Text))
            {
                pwHandler.savePassToLog(masterPWBox.Text);
                pass = masterPWBox.Text;
                if (kategorieBox.Text != "")
                {
                    foreach (string kategorie in kategorieBox.Text.Split(';'))
                    {
                        mw.AddKategorie(kategorie);

                        //to add the data to CategoryView- Form
                      
                        ed.MdiParent = this.MdiParent; // sets CategoryView as 'parent window'
                        ed.value = kategorie; // sets variable 'value' in form2 equal to yourTextBox value after button is clicked
                        ed.EditCategory_Load();
                        ed.Show(); //shows from textbox to CategoryView
                        
                        
                    }
                }
                this.Close();
            }
        }
        public bool passSet()
        {
            pwHandler.readPassFromLog();
            return pwHandler.hasLogHash();
        }
    }
}
