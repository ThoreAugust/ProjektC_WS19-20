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
        private bool stayOpen;
        private PasswordHandler pwHandler;
        public PasswordDialog()
        {
            pwHandler = new PasswordHandler();
            InitializeComponent();
        }
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
        private void cancelButton_Click(object sender, EventArgs e)
        {
            stayOpen = true;
            this.Close();
        }
        public bool keepWindowOpen ()
        {
            return stayOpen;
        }

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
    }
}
