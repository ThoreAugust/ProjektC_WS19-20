using System;
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
        private SetUpDialog setUp;
        private DateTime resetTime;
        private ListViewComparer lvwColumnSorter;


        public MainWindow()
        {
            setUp = new SetUpDialog(this);
            logKategorien = new List<Kategorie>();
            logProgramme = new List<Programm>();
            resetTime = DateTime.Now;
         //   reg.SetValue("CombinationTest", Application.ExecutablePath.ToString());
            InitializeComponent();
            if(!setUp.passSet())
            {
                setUp.ShowDialog();
            }
            update.Start();
            lvwColumnSorter = new ListViewComparer();
            installedProgsListView.ListViewItemSorter = lvwColumnSorter;
            currentProgsListView.ListViewItemSorter = lvwColumnSorter;
            savedProgsListView.ListViewItemSorter = lvwColumnSorter;
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
            }
            else
            {
                using (StreamReader reader = File.OpenText("Log.txt"))
                {
                    int i = 0;
                    String readLine;
                    String[] splitLine;
                    List<Programm> programs = null;
                    int usedTime = 0;
                    bool newDay = false;
                    if (File.GetLastWriteTime("Log.txt").Date.CompareTo(DateTime.Today) < 0)
                        newDay = true;
                    while ((readLine = reader.ReadLine()) != null)
                    {
                        if (readLine == "[Programme]")
                        {
                            i = 1;
                            continue;
                        }
                        if (readLine == "[Kategorien]")
                        {
                            i = 2;
                            continue;
                        }
                        if (readLine == "")
                            break;
                        splitLine = readLine.Split(';');
                        if (i == 1 && !newDay)
                        {
                            logProgramme.Add(new Programm(splitLine[0], splitLine[1], Convert.ToInt32(splitLine[2]), Convert.ToInt32(splitLine[3])));
                        }
                        if (i == 1 && newDay)
                        {
                            logProgramme.Add(new Programm(splitLine[0], splitLine[1], 0, Convert.ToInt32(splitLine[3])));
                        }
                        if (i == 2)
                        {
                            programs = new List<Programm>();
                            usedTime = 0;
                            foreach(String n in splitLine[2].Split(','))
                            {
                                foreach (Programm programm in logProgramme)
                                {
                                    if (programm.getPath() == n)
                                    {
                                        programs.Add(programm);
                                        programm.setKategorie(splitLine[0]);
                                        usedTime += programm.getUsedTime();
                                    }
                                }
                            }
                            logKategorien.Add(new Kategorie(splitLine[0], usedTime, Convert.ToInt32(splitLine[1]), programs));
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
        private List<Programm> getInstalledProgramms()
        {
            List<String> programmNames = new List<String>();
            List<Programm> installedProgs = new List<Programm>();
            RegistryKey key;
            void addNamesForKey(RegistryKey regKey)
            {
                string displayName;
                foreach (String keyName in regKey.GetSubKeyNames())
                {
                    RegistryKey subkey = regKey.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && !displayName.Contains("Microsoft") && !displayName.Contains("Windows"))
                    {
                        if (!programmNames.Contains(displayName))
                        {
                            programmNames.Add(displayName);
                        }
                    }
                }
            }
            void addPathByDisplayName(RegistryKey regKey)
            {
                string displayName;
                string path;
                foreach (String keyName in regKey.GetSubKeyNames())
                {
                    RegistryKey subKey = key.OpenSubKey(keyName);
                    displayName = subKey.GetValue("DisplayName") as string;
                    try
                    {
                        foreach  (string name in programmNames)
                        {
                            if (displayName == name)
                            {
                                path = subKey.GetValue("InstallLocation") as string;
                                Programm temp = new Programm(name,path,0,0);
                                if (!installedProgs.Contains(temp))
                                {
                                    installedProgs.Add(temp);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            addNamesForKey(key);
            addPathByDisplayName(key);


            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            addNamesForKey(key);
            addPathByDisplayName(key);


            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            addNamesForKey(key);
            addPathByDisplayName(key);


            return installedProgs;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLog();
            fillCurrentProgsListView();
            fillInstalledProgsListView();
            fillSavedProgsListView();
            fillKategorieDropDown();
        }
        private void fillCurrentProgsListView()
        {
            currentProgsListView.Items.Clear();
            foreach (Process process in Process.GetProcesses())
            {

                if (process.MainWindowTitle != "")
                {
                    if (process.StartTime.Date == resetTime.Date)
                    {
                        usage = DateTime.Now.Subtract(process.StartTime);
                    }
                    else
                    {
                        usage = DateTime.Now.Subtract(resetTime);
                    }
                    var row = new String[] { "" + process.Id, process.ProcessName, process.MainWindowTitle, usage.ToString(@"hh\:mm\:ss") };
                    lvi = new ListViewItem(row);
                    lvi.Tag = process;
                    //aktuelle Programme
                    currentProgsListView.Items.Add(lvi);
                }
            }
        }
        private void fillKategorieDropDown()
        {
            kategorieDropDown.Items.Clear();
            if(logKategorien.Count != 0)
            {
                foreach (Kategorie item in logKategorien)
                {
                    kategorieDropDown.Items.Add(item.getName());
                    //kategorieDropDown.Tag = item;
                }
            }
        }
        private void fillInstalledProgsListView()
        {
            installedProgsListView.Items.Clear();
            foreach (Programm prog in getInstalledProgramms())
            {
                    Console.WriteLine(prog.ToString());
                    string[] row = new string[] { prog.getName(), prog.getPath() };
                    lvi = new ListViewItem(row);
                    lvi.Tag = prog;
                    // alle installierten Programme
                    installedProgsListView.Items.Add(lvi);
            }
        }
        private void fillSavedProgsListView()
        {
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
        private void AddProgram(Programm programm, int maxTime, string katName)
        {
            bool isUnique = true;
            foreach (Programm p in logProgramme)
            {
                if (programm.getPath().Contains(p.getPath()) || p.getPath().Contains(programm.getPath()))
                {
                    isUnique = false;
                    programm = p;
                    break;
                }
            }
            if (isUnique)
            {
                programm.setMaxTime(maxTime);
                if (katName != "")
                {
                    programm.setKategorie(katName);
                    foreach  (Kategorie kat in logKategorien)
                    {
                        if(kat.getName() == katName)
                        {
                            kat.AddProgramm(programm);
                        }
                    }
                }
                logProgramme.Add(programm);
                SaveLogs();
                fillSavedProgsListView();
                MessageBox.Show("Eintrag gespeichert.", "Success", MessageBoxButtons.OK);
            }
            else
            {
                foreach (Programm p in logProgramme)
                {
                    if (programm == p && p.getMaxTime() != maxTime)
                    {
                        String message = "Maximale Nutzungszeit gespeichert!";
                        if (p.getKategorie() != katName)
                        {
                            message = "Änderungen gespeichert!.";
                        }
                        p.setMaxTime(maxTime);
                        MessageBox.Show(message, "Success", MessageBoxButtons.OK);
                        SaveLogs();
                        break;
                    }
                    else if(programm == p && katName != "")
                    {
                        p.setKategorie(katName);
                        MessageBox.Show("Kategorie gespeichert!", "Success", MessageBoxButtons.OK);
                        SaveLogs();
                        break;
                    }
                    else if(programm == p)
                    {
                        MessageBox.Show("Programm ist bereits gespeichert!", "Error", MessageBoxButtons.OK);
                        break;
                    }
                }
            }
        }
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            this.Close();
        }
        private void MaxUseTimeTrackbar_Scroll(object sender, EventArgs e)
        {
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
                if(resetTime.Date != DateTime.Now.Date)
                {
                    resetTime = DateTime.Now;
                    foreach(Programm p in logProgramme)
                    {
                        p.setUsedTime(0);
                    }
                }
                for (int i = 0; i < currentProgsListView.Items.Count; i++)
                {
                    var item = currentProgsListView.Items[i];
                    Process process = (Process)item.Tag;
                    if(process.StartTime.Date == resetTime.Date)
                    {
                        usage = DateTime.Now.Subtract(process.StartTime);
                    }
                    else
                    {
                        usage = DateTime.Now.Subtract(resetTime);
                    }
                    item.SubItems[3].Text = usage.ToString(@"hh\:mm\:ss");
                    for (int j = 0; j < savedProgsListView.Items.Count; j++)
                    {
                        try
                        {
                            Programm savedProg = (Programm)savedProgsListView.Items[j].Tag;
                            if (process.MainModule.FileName.Contains(savedProg.getPath()))
                            {
                                savedProg.setUsedTime(Convert.ToInt32(usage.TotalSeconds));
                                //Maximale Nutzungszeit überschritten
                                if (savedProg.getUsedTime() >= savedProg.getMaxTime())
                                {
                                    CloseProgram(process);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                if (currentProgsListView.SelectedItems.Count > 0)
                {
                    string id = currentProgsListView.SelectedItems[0].SubItems[0].Text;
                    fillCurrentProgsListView();
                    foreach (ListViewItem lvi in currentProgsListView.Items)
                    {
                        if (id.Equals(lvi.SubItems[0].Text))
                        {
                            lvi.Selected = true;
                        }
                    }
                }
                else
                {
                    fillCurrentProgsListView();
                }
                updateDetailBox();
            }

        }
        private void CloseProgram(Process process)
        {
            process.CloseMainWindow();
            if (!process.WaitForExit(10000))
            {
                process.Kill();
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
            Programm p = null;
            if (programmTabs.SelectedTab == installedProgs)
            {
                p = (Programm)installedProgsListView.SelectedItems[0].Tag;
            }
            if (programmTabs.SelectedTab == savedProgs)
            {
                p = (Programm)savedProgsListView.SelectedItems[0].Tag;
            }
            if (programmTabs.SelectedTab == currentProgs)
            {
                Process process = (Process)currentProgsListView.SelectedItems[0].Tag;
                p = new Programm(process.ProcessName, process.MainModule.FileName, 0, 0);
            }
            int maxUseTime = maxUseTimeTrackbar.Value;
            string katName = (string) kategorieDropDown.SelectedItem;
            AddProgram(p, maxUseTime,katName);
            fillSavedProgsListView();
        }
        public void AddKategorie(string name)
        {
            Programm test;
            List<Programm> testList = new List<Programm>();
            bool isUnique = true;
            if (logKategorien.Count != 0 )
            {
                foreach (Kategorie kategorie in logKategorien)
                {
                    if (kategorie.getName() == name)
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
            if (isUnique)
            {
                test = new Programm("test", "X://test.exe", 120, 18000);
                test.setKategorie(name);
                testList.Add(test);
                logKategorien.Add(new Kategorie(name, 0, 0, testList));
                SaveLogs();
            }
        }
        private void installedProgsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            installedProgsListView.Sort();
        }
        private void currentProgsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            currentProgsListView.Sort();
        }
        private void savedProgsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            savedProgsListView.Sort();
        }
        private void updateDetailBox()
        {
            if (programmTabs.SelectedTab == installedProgs)
            {
                if(installedProgsListView.SelectedItems.Count > 0)
                {
                    updateDBox(installedProgsListView);
                }
                else
                {
                    detailBox.Visible = false;
                }
            }
            if (programmTabs.SelectedTab == savedProgs)
            {
                if (savedProgsListView.SelectedItems.Count > 0)
                {
                    updateDBox(savedProgsListView);
                }
                else
                {
                    detailBox.Visible = false;
                }
            }
            if (programmTabs.SelectedTab == currentProgs)
            {
                if (currentProgsListView.SelectedItems.Count > 0)
                {
                    Process process = (Process)currentProgsListView.SelectedItems[0].Tag;
                    if (process.StartTime.Date == resetTime.Date)
                    {
                        usage = DateTime.Now.Subtract(process.StartTime);
                    }
                    else
                    {
                        usage = DateTime.Now.Subtract(resetTime);
                    }
                    detailBox.Text = process.ProcessName;
                    detailBox.Visible = true;
                    currentUseTimeTextBox.Text = usage.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    detailBox.Visible = false;
                }
            }
            void updateDBox(ListView listView)
            {
                int usedHours;
                int usedMinutes;
                int usedSeconds;
                var selectedItem = (Programm)listView.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    detailBox.Text = selectedItem.getName();
                    detailBox.Visible = true;
                    usedHours = selectedItem.getUsedTime() / 3600;
                    usedMinutes = (selectedItem.getUsedTime() % 3600) / 60;
                    usedSeconds = selectedItem.getUsedTime() % 60;
                    currentUseTimeTextBox.Text = usedHours.ToString("00") + ":" + usedMinutes.ToString("00") + ":" + usedSeconds.ToString("00");
                }
            }
        }
        private void ProgrammTabs_Selected(object sender, TabControlEventArgs e)
        {
            updateDetailBox();
        }
        private void installedProgsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDetailBox();
        }
        private void CurrentProgsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDetailBox();
        }
        private void SavedProgsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDetailBox();
        }
    }   
}