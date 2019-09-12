using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StartKillProcessInCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start("winword");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start("excel");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            foreach(var process in Process.GetProcessesByName(comboBox1.Text))
            {
                process.Kill();
            }
        }

     
    }
}
