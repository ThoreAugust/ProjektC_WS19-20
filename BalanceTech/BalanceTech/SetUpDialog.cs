﻿using Microsoft.Win32;
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
        PasswordHandler pwHandler;
        MainWindow mw;
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
                        mw.AddKategorie(kategorie, 0);
                    }
                }
                if (AutostartCheckBox.Checked)
                {
                    RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    reg.SetValue(mw.getProjectName(), Application.ExecutablePath.ToString());
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
