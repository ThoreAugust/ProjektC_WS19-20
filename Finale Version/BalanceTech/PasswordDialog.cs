using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalanceTech
{
    public partial class PasswordDialog : Form
    {
        //declaration
        private bool stayOpen;
        private PasswordHandler pwHandler;

        //constructor
        public PasswordDialog()
        {
            pwHandler = new PasswordHandler();
            InitializeComponent();
        }

        //functions of passwordialog-buttons
        //__________________________________________
        //checks if password is right and warns if it's wrong
        private void okButton_Click(object sender, EventArgs e)
        {
            stayOpen = !pwHandler.checkPass(passwordBox.Text);
            if (pwHandler.checkPass(passwordBox.Text))
            {
            this.Close();
            }
            else
            {
                MessageBox.Show("Das eingegebene Passwort war Falsch! Versuche es erneut.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //option to cancel the input of a password 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            stayOpen = true;
            this.Close();
        }
        public bool keepWindowOpen ()
        {
            return stayOpen;
        }

        // translation of the users choice in keyboardbuttons
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okButton_Click(sender,e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cancelButton_Click(sender, e);
            }
        }

          //functions of passwordialog window end
        //__________________________________________
    }
}
