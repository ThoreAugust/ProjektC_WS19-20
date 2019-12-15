using Microsoft.Win32;
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
    public partial class SetUpDialog : Form
    {
        //declaration
        PasswordHandler pwHandler;
        MainWindow mw;
        string pass;

        //constructor
        public SetUpDialog(MainWindow main)
        {
            mw = main;
            pwHandler = new PasswordHandler();
            pwHandler.readPassFromLog();
            InitializeComponent();
        }

        // OK-Btn executes choosen options
        private void OkButton_Click(object sender, EventArgs e)
        {
            
            if(masterPWBox.Text.Equals(masterPWRepeatBox.Text))
            {
                pwHandler.savePassToLog(masterPWBox.Text);
                pass = masterPWBox.Text;
                if (categoryBox.Text != "")
                {   
                    // add categorys to CategoryList
                    foreach (string category in categoryBox.Text.Split(';'))
                    {
                        mw.AddCategory(category, 0);
                    }
                }
                //to turn autostart on/off
                if (AutostartCheckBox.Checked)
                {
                    RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    reg.SetValue(mw.getProjectName(), Application.ExecutablePath.ToString());
                }
                this.Close();
            }
        }

        //checks if passwords matches
        public bool passSet()
        {
            pwHandler.readPassFromLog();
            return pwHandler.hasLogHash();
        }
    }
}
