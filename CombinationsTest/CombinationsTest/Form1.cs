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
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Win32;


namespace CombinationsTest
{
    public partial class Kategorie
    {
        public String name;
        public double usedTime;
        public double maxTime;

        public Kategorie(String n, double ut, double mt)
        {
            name = n;
            usedTime = ut;
            maxTime = mt;
        }

        override public String ToString()
        {
            return name + ";" + usedTime + ";" + maxTime;
        }
    }

    public partial class Programm
    {
        public String path;
        public String kategorie;
        public double usedTime;
        public double maxTime;

        public Programm(String p, String k, double ut, double mt)
        {
            path = p;
            kategorie = k;
            usedTime = ut;
            maxTime = mt;
        }

        override public String ToString()
        {
            return path + ";" + kategorie + ";" + usedTime + ";" + maxTime;
        }
    }

    public partial class Form1 : Form
    {
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
        TimeSpan usage;
        ListViewItem lvi;
        List<Kategorie> logKategorien;
        List<Programm> logProgramme;
        
        public Form1()
        {
            reg.SetValue("CombinationTest", Application.ExecutablePath.ToString());
            InitializeComponent();
            
        }

        private void LoadLog()
        {
            if (!File.Exists("Log.txt"))
            {
                using (StreamWriter sw = File.CreateText("Log.txt"))
                {
                    sw.WriteLine("[Kategorien]");
                    sw.WriteLine("[Programme]");
                }
            } else
            {
                using (StreamReader sr = File.OpenText("Log.txt"))
                {
                    int i = 0;
                    String s;
                    String[] vs;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == "[Kategorien]")
                        {
                            i = 1;
                            continue;
                        }
                        if (s == "[Programme]")
                        {
                            i = 2;
                            continue;
                        }
                        if (s == "")
                            break;
                        vs = s.Split(';');
                        if (i == 1)
                            logKategorien.Add(new Kategorie( vs[0], Convert.ToInt64(vs[1]), Convert.ToInt64(vs[2])));
                        if (i == 2)
                            logProgramme.Add(new Programm(vs[0], vs[1], Convert.ToDouble(vs[2]), Convert.ToDouble(vs[3])));
                    }
                }
            }
        }

        private void SaveLogs()
        {
            using (StreamWriter sw = File.CreateText("Log.txt"))
            {
                sw.WriteLine("[Kategorien]");
                foreach(Kategorie k in logKategorien)
                {
                    sw.WriteLine(k);
                }
                sw.WriteLine("[Programme]");
                foreach(Programm p in logProgramme)
                {
                    sw.WriteLine(p);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logKategorien = new List<Kategorie>();
            logProgramme = new List<Programm>();
            LoadLog();
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
                    DialogResult result;
                    result = MessageBox.Show(
                        "Id: " + selectedItem.Id + "\n Name: " + selectedItem.ProcessName + "\n Title: " + selectedItem.MainWindowTitle + "\n Laufzeit: "
                        + usage.ToString(@"hh\:mm\:ss") + "\n\n Prozess hinzufügen?", "Process details", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        );
                    if (result == DialogResult.Yes)
                        AddProgram(selectedItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddProgram(Process process)
        {
            var path = process.MainModule.FileName;
            Console.WriteLine(path);
            bool b = true;
            foreach (Programm p in logProgramme)
            {
                if (path == p.path)
                {
                    MessageBox.Show("Prozess ist bereits gespeichert!", "Error", MessageBoxButtons.OK);
                    b = false;
                    break;
                }
            }
            if (b)
            {
                logProgramme.Add(new Programm(process.MainModule.FileName, null, usage.TotalMilliseconds, 0));
                SaveLogs();
                MessageBox.Show("Eintrag gespeichert.", "Success", MessageBoxButtons.OK);
            }
        }
    }
}
