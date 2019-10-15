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

namespace CombinationsTest
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
            stayOpen = false;
            this.Close();
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
    }
}
