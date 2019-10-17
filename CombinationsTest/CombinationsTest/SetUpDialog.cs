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
        bool closing;
        public SetUpDialog()
        {
            closing = false;
            mw = new MainWindow();
            pwHandler = new PasswordHandler();
            InitializeComponent();
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            
            if(masterPWBox.Text.Equals(masterPWRepeatBox.Text))
            {
                pwHandler.savePassToLog(masterPWBox.Text);
                foreach (string kategorie in kategorieBox.Text.Split(';'))
                {
                    mw.AddKategorie(kategorie);
                }
                closing = true;
                this.Close();
            }
        }
        public MainWindow GetMainWindow()
        {
            return mw;
        }
        public bool closingForm()
        {
            mw.Show();
            return closing;
        }
    }
}
