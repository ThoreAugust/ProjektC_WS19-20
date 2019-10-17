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
        
        public MainWindow()
        {
         //   reg.SetValue("CombinationTest", Application.ExecutablePath.ToString());
            InitializeComponent();
            update.Start();
            logKategorien = new List<Kategorie>();
            logProgramme = new List<Programm>();
        }
        private void LoadLog()
        {
            if (!File.Exists("Log.txt"))
            {
                using (StreamWriter writer = File.CreateText("Log.txt"))
                {
                    writer.WriteLine("[Programme]");
                    writer.WriteLine("[Kategorien]");
                }
            } else
            {
                using (StreamReader reader = File.OpenText("Log.txt"))
                {
                    int i = 0;
                    String s; //kann man das bitte klar benennen das jeder weiß was damit gemeint ist
                    String[] vs;//hier genauso
                    List<Programm> programs;
                    Double usedTime;
                    bool newDay = false;
                    if (File.GetLastWriteTime("Log.txt").Date.CompareTo(DateTime.Today) < 0)
                        newDay = true;
                    while ((s = reader.ReadLine()) != null)
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
                            programs = new List<Programm>();
                            usedTime = 0;
                            foreach(String n in vs[3].Split(':'))
                            {
                                foreach (Programm programm in logProgramme)
                                {
                                    if (programm.getPath() == n)
                                    {
                                        programs.Add(programm);
                                        programm.setKategorie(vs[0]);
                                        usedTime += programm.getUsedTime();
                                    }
                                }
                            }
                            logKategorien.Add(new Kategorie(vs[0], usedTime, Convert.ToInt64(vs[1]), programs));
                        }
                    }
                }
            }
        }
        private void SaveLogs()
        {
            using (StreamWriter writer = File.CreateText("Log.txt"))
            {
                writer.WriteLine("[Programme]");
                foreach (Programm program in logProgramme)
                {
                    writer.WriteLine(program);
                }
                writer.WriteLine("[Kategorien]");
                foreach(Kategorie kategorie in logKategorien)
                {
                    writer.WriteLine(kategorie);
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
            LoadLog();
            fillCurrentProgsListView();
            fillInstalledProgsListView();
            fillSavedProgsListView();
        }
        private void fillCurrentProgsListView()
        {
            currentProgsListView.Items.Clear();
            foreach (Process process in Process.GetProcesses())
            {
                if (process.MainWindowTitle != "")
                {
                    usage = DateTime.Now.Subtract(process.StartTime);
                    string[] row = new String[] { "" + process.Id, process.ProcessName, process.MainWindowTitle, usage.ToString(@"hh\:mm\:ss") };
                    lvi = new ListViewItem(row);
                    lvi.Tag = process;
                    //aktuelle Programme
                    currentProgsListView.Items.Add(lvi);
                }
            }
        }
        private void fillInstalledProgsListView()
        {
            installedProgsListView.Items.Clear();
            foreach (string name in getInstalledProgrammNames())
            {
                string[] row = new String[] { name };
                lvi = new ListViewItem(row);
                // alle installierten Programme
                installedProgsListView.Items.Add(lvi);
            }
        }
        private void fillSavedProgsListView()
        {
            LoadLog();
            savedProgsListView.Items.Clear();
            foreach (Programm savedProgs in logProgramme)
            {
                string[] row = new string[] { savedProgs.getName(), savedProgs.getPath(), savedProgs.getKategorie(), "" + savedProgs.getUsedTime(), "" + savedProgs.getMaxTime() };
                lvi = new ListViewItem(row);
                lvi.Tag = savedProgs;
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
        private void AddProgram(Process process, double maxTime)
        {
            var path = process.MainModule.FileName;
            Console.WriteLine(path);
            bool isUnique = true;
            foreach (ListViewItem item in savedProgsListView.Items)
            {
                Programm p =(Programm) item.Tag;
                if (path == p.getPath())
                {
                    MessageBox.Show("Prozess ist bereits gespeichert!", "Error", MessageBoxButtons.OK);
                    isUnique = false;
                    break;
                }
            }
            if (isUnique)
            {
                usage = DateTime.Now.Subtract(process.StartTime);
                Console.WriteLine("hi there: " + usage.TotalMilliseconds);
                savedProgsListView.Items.Add(new ListViewItem(new String[] { process.MainWindowTitle, process.MainModule.FileName, "", "" + usage.TotalMilliseconds, "" + maxTime }));
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
        private void Update_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks % 10 == 0)
            {
                for (int i = 0; i < currentProgsListView.Items.Count; i++)
                {
                   var item = currentProgsListView.Items[i];
                   Process process = (Process) item.Tag;
                   usage = DateTime.Now.Subtract(process.StartTime);
                    if (item.Selected)
                    {
                        currentUseTimeTextBox.Text = usage.ToString(@"hh\:mm\:ss");
                    }
                   item.SubItems[3].Text = usage.ToString(@"hh\:mm\:ss");
                    //for (int j = 0; j < savedProgsListView.Items.Count; j++)
                    //{ 
                    //    Programm savedProg = (Programm) savedProgsListView.Items[j].Tag;
                    //    if (process.MainModule.FileName.Equals(savedProg.getPath()))
                    //    {
                    //        savedProg.setUsedTime(usage.TotalMilliseconds);
                    //    }
                    //}
                }
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
            SaveLogs();
            e.Cancel = confirmCloseWithPassword();
        }
        private void saveProgButton_Click(object sender, EventArgs e)
        {
            Process p = (Process) currentProgsListView.SelectedItems[0].Tag;
            double maxUseTime = maxUseTimeTrackbar.Value * 1000;
            AddProgram(p, maxUseTime);
        }
    }   
}