﻿using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class MainWindow : Form
    {
        private RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);
        private TimeSpan usage;
        private ListViewItem lvi;
        private List<Kategorie> logKategorien;
        private List<Programm> logProgramme;
        private int ticks;
        private PasswordHandler pwHandler;
        
        public MainWindow()
        {
         //   reg.SetValue("CombinationTest", Application.ExecutablePath.ToString());
            InitializeComponent();
            killTimer.Start();
        }
        private void LoadLog()
        {
            if (!File.Exists("Log.txt"))
            {
                using (StreamWriter sw = File.CreateText("Log.txt"))
                {
                    sw.WriteLine("[Programme]");
                    sw.WriteLine("[Kategorien]");
                }
            } else
            {
                using (StreamReader sr = File.OpenText("Log.txt"))
                {
                    int i = 0;
                    String s;
                    String[] vs;
                    List<Programm> p;
                    Double ut;
                    bool newDay = false;
                    if (File.GetLastWriteTime("Log.txt").Date.CompareTo(DateTime.Today) < 0)
                        newDay = true;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == "[Programme]")
                        {
                            i = 1;
                            continue;
                        }
                        if (s == "[Kategorien]")
                        {
                            i = 2;
                            continue;
                        }
                        if (s == "")
                            break;
                        vs = s.Split(';');
                        if (i == 1 && !newDay)
                            logProgramme.Add(new Programm(vs[0], vs[1], Convert.ToDouble(vs[2]), Convert.ToDouble(vs[3])));
                        if (i == 1 && newDay)
                            logProgramme.Add(new Programm(vs[0], vs[1], 0, Convert.ToDouble(vs[3])));
                        if (i == 2)
                        {
                            p = new List<Programm>();
                            ut = 0;
                            foreach(String n in vs[3].Split(':'))
                            {
                                foreach (Programm programm in logProgramme)
                                {
                                    if (programm.path == n)
                                    {
                                        p.Add(programm);
                                        programm.kategorie = vs[0];
                                        ut += programm.usedTime;
                                    }
                                }
                            }
                            logKategorien.Add(new Kategorie(vs[0], ut, Convert.ToInt64(vs[1]), p));
                        }
                    }
                }
            }
        }
        private void SaveLogs()
        {
            using (StreamWriter sw = File.CreateText("Log.txt"))
            {
                sw.WriteLine("[Programme]");
                foreach (Programm p in logProgramme)
                {
                    sw.WriteLine(p);
                }
                sw.WriteLine("[Kategorien]");
                foreach(Kategorie k in logKategorien)
                {
                    sw.WriteLine(k);
                }
            }
        }
        private List<String> getInstalledProgrammNames()
        {
            List<String> programmNames = new List<String>();
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null && !displayName.Contains("Microsoft") && !displayName.Contains("Windows"))
                {
                    if (!programmNames.Contains(displayName))
                    {
                        programmNames.Add(displayName);
                    }
                }
                

            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null && !displayName.Contains("Microsoft") && !displayName.Contains("Windows"))
                {
                    if (!programmNames.Contains(displayName))
                    {
                        programmNames.Add(displayName);
                    }
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null && !displayName.Contains("Microsoft") && !displayName.Contains("Windows"))
                {
                    if (!programmNames.Contains(displayName))
                    {
                        programmNames.Add(displayName);
                    }
                }
            }
            return programmNames;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logKategorien = new List<Kategorie>();
            logProgramme = new List<Programm>();
            LoadLog();
            currentProgsListView.Items.Clear();
            installedProgsListView.Items.Clear();
            savedProgsListView.Items.Clear();
            foreach (Process process in Process.GetProcesses())
            {
                if(process.MainWindowTitle != "")
                {
                    usage = DateTime.Now.Subtract(process.StartTime);
                    var row = new String[] { "" + process.Id, process.ProcessName, process.MainWindowTitle, usage.ToString(@"hh\:mm\:ss") };
                    lvi = new ListViewItem(row);
                    lvi.Tag = process;
                    //aktuelle Programme
                    currentProgsListView.Items.Add(lvi);
                }
            }
            foreach ( var name in getInstalledProgrammNames())
            {
                var row = new String[] { name };
                lvi = new ListViewItem(row);
                // alle installierten Programme
                installedProgsListView.Items.Add(lvi);
            }
            foreach (var savedProgs in logProgramme)
            {
                var row = new String[] {savedProgs.name, savedProgs.path, savedProgs.kategorie,""+savedProgs.usedTime,""+savedProgs.maxTime };
                lvi = new ListViewItem(row);
                // alle gespeicherten Programme
                savedProgsListView.Items.Add(lvi);
            }
        }
        private void ListViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = (Process)currentProgsListView.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    //usage = DateTime.Now.Subtract(selectedItem.StartTime);
                    //DialogResult result;
                    //result = MessageBox.Show(
                    //    "Id: " + selectedItem.Id + "\n Name: " + selectedItem.ProcessName + "\n Title: " + selectedItem.MainWindowTitle + "\n Laufzeit: "
                    //    + usage.ToString(@"hh\:mm\:ss") + "\n\n Prozess hinzufügen?", "Process details", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                    //    );
                    //if (result == DialogResult.Yes)
                    //    AddProgram(selectedItem);
                    detailBox.Visible = false;
                    detailBox.Text = selectedItem.ProcessName + ", "+ selectedItem.MainWindowTitle;
                    detailBox.Visible = true;

                    currentUseTimeTextBox.Text = DateTime.Now.Subtract(selectedItem.StartTime).ToString(@"hh\:mm\:ss");
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
                logProgramme.Add(new Programm(process.MainWindowTitle,process.MainModule.FileName, usage.TotalMilliseconds, 0));
                SaveLogs();
                MessageBox.Show("Eintrag gespeichert.", "Success", MessageBoxButtons.OK);
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLogs();
            this.Close();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                timerNotification.ShowBalloonTip(1000, "Important notice" , "You have xxx Seconds left for your CurrentApplication", ToolTipIcon.Info);
            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveLogs();
            this.Close();
        }

        private void MaxUseTimeTrackbar_Scroll(object sender, EventArgs e)
        {
            var selectedItem = (Process)currentProgsListView.FocusedItem.Tag;
            int maxHours =  maxUseTimeTrackbar.Value / 60 / 60;
            int maxMinutes = maxUseTimeTrackbar.Value / 60;
            if (maxMinutes >= 60)
            {
                maxMinutes -= maxHours * 60;
            }

            maxHourUseTimeTextBox.Text = ""+maxHours;
            maxMinuteUseTimeTextBox.Text = ""+maxMinutes;   
        }

        private void KillTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            this.Text = ticks.ToString();

            if (ticks == 50)
            {
                //MessageBox.Show("You got xxx Time to save and end your program! Time is gonna reset at midnight.", "Test Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

            if (ticks >= 100)
            {
               //"comboBox1" müsste durch "aktuelle Programme - Liste ersetzt werden, damit er diese Liste durchgeht und Programme bei Zeitüberschreitung schließt

                /*  foreach (var process in Process.GetProcessesByName(comboBox1.Text))
                  {
                      MessageBox.Show("Time is up!", "Test Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                      process.Kill();
                  }*/
                ticks = 0;
            }
        }

        private void MaxMinuteUseTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxMinuteUseTimeTextBox.Text != "")
            {
                int maxMinutes = Int32.Parse(maxMinuteUseTimeTextBox.Text);
                int maxHours = Int32.Parse(maxHourUseTimeTextBox.Text);
                int maxUse = maxUseTimeTrackbar.Value;
                if (maxMinutes >= 60)
                {
                    maxMinutes -= 60;
                    if (maxHours < 5)
                    {
                    maxHours += 1;
                    }
                }
                if (maxHours >= 5)
                {
                    maxHours = 5;
                    maxMinutes = 0;
                }
                maxMinuteUseTimeTextBox.Text = "" + maxMinutes;
                maxHourUseTimeTextBox.Text = "" + maxHours;
                if (maxHours < 5* 3600)
                {
                    maxUseTimeTrackbar.Value = (maxHours * 3600) + (maxMinutes * 60);
                }
                else
                {
                    maxUseTimeTrackbar.Value = 5 * 3600;
                }

            }
        }

        private void MaxHourUseTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxHourUseTimeTextBox.Text != "")
            {
                int maxHours = Int32.Parse(maxHourUseTimeTextBox.Text);
                if (maxHours <= 5)
                {
                    maxUseTimeTrackbar.Value = maxHours * 3600;
                }
                else
                {
                    maxUseTimeTrackbar.Value = 5 * 3600;
                    maxHourUseTimeTextBox.Text = "5";
                }
            }
        }

        private void AutostartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private bool confirmCloseWithPassword()
        {
            PasswordDialog pw = new PasswordDialog();
            pw.ShowDialog();            

            return pw.keepWindowOpen();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = confirmCloseWithPassword();
        }
    }
    public partial class Kategorie
    {
        public String name;
        public double usedTime;
        public double maxTime;
        public List<Programm> programme;

        public Kategorie(String n, double ut, double mt, List<Programm> p)
        {
            name = n;
            usedTime = ut;
            maxTime = mt;
            programme = p;
        }
        override public String ToString()
        {
            String p = "";
            foreach (Programm programm in programme)
                p += programm.path + ":";
            return name + ";" + maxTime + ";" + p;
        }
    }
    public partial class Programm
    {
        public String name;
        public String path;
        public double usedTime;
        public double maxTime;
        public String kategorie;

        public Programm(String n,String p, double ut, double mt)
        {
            name = n;
            path = p;
            usedTime = ut;
            maxTime = mt;
        }
        override public String ToString()
        {
            return name + ";" +path + ";" + usedTime + ";" + maxTime;
        }
    }
}