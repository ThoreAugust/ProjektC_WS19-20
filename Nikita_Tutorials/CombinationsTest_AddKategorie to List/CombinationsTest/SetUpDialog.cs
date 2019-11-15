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
        Edit_Category ec = new Edit_Category();
        string pass;
        public SetUpDialog(MainWindow main)
        {
            mw = main;
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

                        //to add the data to Edit_Category- Form
                        Edit_Category ec = new Edit_Category();
                        ec.MdiParent = this.MdiParent; // sets Edit_Category as 'parent window'
                        ec.value = kategorieBox.Text; // sets variable 'value' in form2 equal to yourTextBox value after button is clicked
                        ec.SetUpDialog_Load(); //loads value from textbox to Edit_category-Formy
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
