using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;


namespace CombinationsTest
{
    public partial class Form1 : Form
    {
        TimeSpan usage;
        ListViewItem lvi;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewProcesses.Items.Clear();
            foreach (Process process in Process.GetProcesses())
            {
                if(process.MainWindowTitle != "")
                {
                    usage = DateTime.Now.Subtract(process.StartTime);
                    var row = new String[] { "" + process.Id, process.ProcessName, process.MainWindowTitle, usage.ToString(@"hh\:mm\:ss") };
                    lvi = new ListViewItem(row);
                    lvi.Tag = process;

                    listViewProcesses.Items.Add(lvi);
                }
            }
        }

        private void ListViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = (Process)listViewProcesses.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    usage = DateTime.Now.Subtract(selectedItem.StartTime);
                    MessageBox.Show(
                        "Id: " + selectedItem.Id + "\n Name: " + selectedItem.ProcessName + "\n Title: " + selectedItem.MainWindowTitle + "\n Laufzeit: "
                        + usage.ToString(@"hh\:mm\:ss"), "Process details", MessageBoxButtons.OK,MessageBoxIcon.Information
                        );
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
