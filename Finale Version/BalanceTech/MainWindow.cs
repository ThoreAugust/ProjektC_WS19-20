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
namespace BalanceTech
{
    public partial class MainWindow : Form
    {
        //declaration
        private TimeSpan usage;
        private ListViewItem lvi;
        private List<Category> logCategorys;
        private List<Programm> logPrograms;
        private int ticks;
        private SetUpDialog setUp;
        private DateTime resetTime;
        private ListViewComparer lvwColumnSorter;
        private EditCategory editCats;
        private String projectName = "BalanceTech";
        private int remainingSecondsForWarning1 = 300;
        private int remainingSecondsForWarning2 = 10;
        private bool individualLimitDefault = false;


        //constructor
        public MainWindow()
        {
            //initialize
            setUp = new SetUpDialog(this);
            logCategorys = new List<Category>();
            logPrograms = new List<Programm>();
            resetTime = DateTime.Now;
            InitializeComponent();
            LoadLog();
            editCats = new EditCategory(this);
            if (!setUp.passSet())
            {
                setUp.ShowDialog();
            }
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (reg.GetValue(projectName) != null)
            {
                autostartToolStripMenuItem.Checked = true;
            }
            update.Start();
            lvwColumnSorter = new ListViewComparer();
            installedProgsListView.ListViewItemSorter = lvwColumnSorter;
            currentProgsListView.ListViewItemSorter = lvwColumnSorter;
            savedProgsListView.ListViewItemSorter = lvwColumnSorter;
        }
        
        // MainWindow functions and options
        //_____________________________________________________________
        
       //to load saved categories and programs
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
                            logPrograms.Add(new Programm(splitLine[0], splitLine[1], Convert.ToInt32(splitLine[2]), Convert.ToInt32(splitLine[3])));
                            logPrograms[(logPrograms.Count - 1)].setIndividualLimit(Convert.ToBoolean(splitLine[4]));
                        }
                        if (i == 1 && newDay)
                        {
                            logPrograms.Add(new Programm(splitLine[0], splitLine[1], 0, Convert.ToInt32(splitLine[3])));
                            logPrograms[(logPrograms.Count - 1)].setIndividualLimit(Convert.ToBoolean(splitLine[4]));
                        }
                        if (i == 2)
                        {
                            programs = new List<Programm>();
                            usedTime = 0;
                            for(int j = 2; j < splitLine.Length; j++)
                            {
                                String name = splitLine[j].Split(',')[0];
                                String path = splitLine[j].Split(',')[1];
                                foreach (Programm program in logPrograms)
                                {
                                    if (program.getName() == name && program.getPath() == path)
                                    {
                                        programs.Add(program);
                                        program.setCategory(splitLine[0]);
                                        usedTime += program.getUsedTime();
                                        break;
                                    }
                                }
                            }
                            logCategorys.Add(new Category(splitLine[0], usedTime, Convert.ToInt32(splitLine[1]), programs));
                        }
                    }
                }
            }
        }

        //to save programs and categories
        private void SaveLogs()
        {
            using (StreamWriter writer = File.CreateText("Log.txt"))
            {
                writer.WriteLine("[Programme]");
                foreach (Programm program in logPrograms)
                {
                    writer.WriteLine(program);
                }
                writer.WriteLine("[Kategorien]");
                foreach(Category category in logCategorys)
                {
                    writer.WriteLine(category);
                }
            }
        }

       

        //to clear and update current running programlist
        private void fillCurrentProgsListView()
        {
            currentProgsListView.Items.Clear();
            foreach (Process process in Process.GetProcesses())
            {

                if (process.MainWindowTitle != "" && !process.MainModule.FileName.Contains(Directory.GetCurrentDirectory()))
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
                    //current programs
                    currentProgsListView.Items.Add(lvi);
                }
            }
        }

        //to clear and fill category-dropdown-options
        private void fillCategoryDropDown()
        {
            categoryDropDown.Items.Clear();
            if(logCategorys.Count != 0)
            {
                foreach (Category item in logCategorys)
                {
                    categoryDropDown.Items.Add(item.getName());
                }
            }
        }

        //to clear and fill installed programs to list with installed programs
        private void fillInstalledProgsListView()
        {
            installedProgsListView.Items.Clear();
            foreach (Programm prog in getInstalledPrograms())
            {
                    Console.WriteLine(prog.ToString());
                    string[] row = new string[] { prog.getName(), prog.getPath() };
                    lvi = new ListViewItem(row);
                    lvi.Tag = prog;
                    // all installed programs
                    installedProgsListView.Items.Add(lvi);
            }
        }

        //to clear and add programs to list with saved programs
        private void fillSavedProgsListView()
        {
            savedProgsListView.Items.Clear();
            foreach (Programm savedProgs in logPrograms)
            {
                string[] row = new string[] { savedProgs.getName(), savedProgs.getPath(), savedProgs.getCategory(), "" + savedProgs.getUsedTime(), "" + savedProgs.getMaxTime() };
                lvi = new ListViewItem(row);
                lvi.Tag = savedProgs;
                // all saved programs
                savedProgsListView.Items.Add(lvi);
            }
        }

       
        //to run and update methods in mainwindow
        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Text = projectName;
            fillCurrentProgsListView();
            fillInstalledProgsListView();
            fillSavedProgsListView();
            fillCategoryDropDown();
        }

        //to check logPrograms for unique path and name and save them
        private void AddProgram(Programm program, int maxTime, string catName)
        {
            bool isUnique = true;
            foreach (Programm p in logPrograms)
            {
                if ((program.getPath().Contains(p.getPath()) || p.getPath().Contains(program.getPath()))
                    && program.getName() == p.getName())
                {
                    isUnique = false;
                    program = p;
                    break;
                }
            }
            if (isUnique)
            {
                program.setMaxTime(maxTime);
                if (catName != "")
                {
                    program.setCategory(catName);
                    foreach  (Category cat in logCategorys)
                    {
                        if(cat.getName() == catName)
                        {
                            cat.AddProgram(program);
                        }
                    }
                }
                logPrograms.Add(program);
                SaveLogs();
                fillSavedProgsListView();
                MessageBox.Show("Eintrag gespeichert.", "Success", MessageBoxButtons.OK);
            }
            else
            {
                foreach (Programm p in logPrograms)
                {
                    if (program == p)
                    {
                        if (p.getMaxTime() != maxTime || (catName != "" && catName != p.getCategory()) || p.getIndividualLimit() != individualLimitCheckBox.Checked)
                        {
                            if (p.getCategory() != catName)
                            {
                                foreach(Category c in logCategorys)
                                {
                                    if(c.getName() == p.getCategory())
                                    {
                                        c.RemoveProgram(p);
                                    }
                                    if(c.getName() == catName)
                                    {
                                        c.AddProgram(p);
                                    }
                                }
                                p.setCategory(catName);
                            }
                            p.setIndividualLimit(individualLimitCheckBox.Checked);
                            p.setMaxTime(maxTime);
                            MessageBox.Show("Änderungen gespeichert!", "Success", MessageBoxButtons.OK);
                            SaveLogs();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Programm ist bereits gespeichert!", "Error", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
            }
        }

        //to update time and reset
        private void Update_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks % 10 == 0)
            {
                //daily reset of usetime
                if(resetTime.Date != DateTime.Now.Date)
                {
                    resetTime = DateTime.Now;
                    foreach(Programm p in logPrograms)
                    {
                        p.setUsedTime(0);
                    }
                    foreach(Category c in logCategorys)
                    {
                        c.setUsedTime(0);
                    }
                }
                //update usetime of each category
                foreach(Category category in logCategorys)
                {
                    bool foundOne = false;
                    for (int i = 0; i < currentProgsListView.Items.Count; i++)
                    {
                        var item = currentProgsListView.Items[i];
                        Process process = (Process)item.Tag;
                        foreach(Programm program in category.GetPrograms())
                        {
                            try
                            {
                                if (process.MainModule.FileName.Contains(program.getPath()) && process.ProcessName == program.getName())
                                {
                                    foundOne = true;
                                    break;
                                }
                            }
                            catch { }
                        }
                        if (foundOne)
                        {
                            category.setUsedTime(category.getUsedTime() + 1);
                            if(category.getUsedTime() == (category.getMaxTime() - remainingSecondsForWarning1))
                            {
                                MessageBox.Show("Die Zeit für " + category.getName() + " ist bald aufgebraucht!", "Warnung", MessageBoxButtons.OK);
                            }
                            if (category.getUsedTime() == (category.getMaxTime() - remainingSecondsForWarning2))
                            {
                                MessageBox.Show("Programme aus " + category.getName() + " werden gleich beendet!", "Warnung", MessageBoxButtons.OK);
                            }
                            break;
                        }
                    }
                }
                for (int i = 0; i < currentProgsListView.Items.Count; i++)
                {
                    var item = currentProgsListView.Items[i];
                    Process process = (Process)item.Tag;

                    //usage = usetime since last reset
                    if(process.StartTime.Date == resetTime.Date)
                    {
                        usage = DateTime.Now.Subtract(process.StartTime);
                    }
                    else
                    {
                        usage = DateTime.Now.Subtract(resetTime);
                    }
                    item.SubItems[3].Text = usage.ToString(@"hh\:mm\:ss");

                    //check whether a program to be regulated is running
                    for (int j = 0; j < savedProgsListView.Items.Count; j++)
                    {
                        try
                        {
                            Programm savedProg = (Programm)savedProgsListView.Items[j].Tag;
                            if ((process.MainModule.FileName.Contains(savedProg.getPath()) || savedProg.getPath().Contains(process.MainModule.FileName))
                                && process.ProcessName == savedProg.getName())
                            {
                                savedProg.setUsedTime(Convert.ToInt32(usage.TotalSeconds));
                                //time warning
                                if((savedProg.getIndividualLimit() || savedProg.getCategory() == "" || savedProg.getCategory() == null) 
                                    && savedProg.getUsedTime() == (savedProg.getMaxTime() - remainingSecondsForWarning1))
                                {
                                    String msg = "Die Zeit für " + savedProg.getName() + " ist bald aufgebraucht!";
                                    if (this.WindowState == FormWindowState.Minimized)
                                    {
                                        this.Hide();
                                        timerNotification.ShowBalloonTip(1000, "Warnung", msg, ToolTipIcon.Info);
                                    }
                                    else
                                    {
                                         MessageBox.Show(msg, "Warnung", MessageBoxButtons.OK);   
                                    }
                                }
                                if ((savedProg.getIndividualLimit() || savedProg.getCategory() == "" || savedProg.getCategory() == null)
                                    && savedProg.getUsedTime() == (savedProg.getMaxTime() - remainingSecondsForWarning2))
                                {
                                    String msg = savedProg.getName() + " wird gleich beendet!";
                                    if (this.WindowState == FormWindowState.Minimized)
                                    {
                                        this.Hide();
                                        timerNotification.ShowBalloonTip(1000, "Warnung", msg, ToolTipIcon.Info);
                                    }
                                    else
                                    {
                                        MessageBox.Show(msg, "Warnung", MessageBoxButtons.OK);
                                    }
                                }
                                //max usetime of a program or category has reached it's limit
                                if ((savedProg.getIndividualLimit() || savedProg.getCategory() == "" || savedProg.getCategory() == null)
                                    && savedProg.getUsedTime() >= savedProg.getMaxTime())
                                {
                                    CloseProgram(process);
                                }
                                //Maximale Nutzungszeit der ategory überschritten
                                if (savedProg.getCategory() != "" && savedProg.getCategory() != null)
                                {
                                    Category cat = logCategorys.Find(c => c.getName().Equals(savedProg.getCategory()));
                                    if (cat.getUsedTime() >= cat.getMaxTime())
                                    {
                                        CloseProgram(process);
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

                //keep selected entry
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
                if (savedProgsListView.SelectedItems.Count > 0)
                {
                    string name = savedProgsListView.SelectedItems[0].SubItems[0].Text;
                    string path = savedProgsListView.SelectedItems[0].SubItems[1].Text;
                    fillSavedProgsListView();
                    foreach (ListViewItem lvi in savedProgsListView.Items)
                    {
                        if (name.Equals(lvi.SubItems[0].Text) && path.Equals(lvi.SubItems[1].Text))
                        {
                            lvi.Selected = true;
                        }
                    }
                }
                else
                {
                    fillSavedProgsListView();
                }
                editCats.FillCategoryListView(false);
                updateDetailBox(false);
            }

        }

        //to update minutes on the interface
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
        
        //to update hours on the interface
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

        //to switch Autostart on and off
        private void AutostartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            //Autostart on
            if (autostartToolStripMenuItem.Checked == true)
            {
                reg.SetValue(projectName, Application.ExecutablePath.ToString());
                MessageBox.Show("Autostart aktiviert.", "Notification", MessageBoxButtons.OK);
            }
            //Autostart off
            else
            {
                reg.DeleteValue(projectName);
                MessageBox.Show("Autostart deaktiviert.", "Notification", MessageBoxButtons.OK);
            }
        }

        //manage closing of the program
        private void CloseProgram(Process process)
        {
            process.CloseMainWindow();
            if (!process.WaitForExit(10000))
            {
                process.Kill();
            }
        }

        private bool confirmCloseWithPassword()
        {
            PasswordDialog pw = new PasswordDialog();
            pw.Text = projectName + " - Passworteingabe";
            pw.ShowDialog();            

            return pw.keepWindowOpen();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLogs();
            e.Cancel = confirmCloseWithPassword();
        }

        //save or edit program
        private void saveProgButton_Click(object sender, EventArgs e)
        {
            Programm p = null;
            if (programTabs.SelectedTab == installedProgs)
            {
                p = (Programm)installedProgsListView.SelectedItems[0].Tag;
            }
            if (programTabs.SelectedTab == savedProgs)
            {
                p = (Programm)savedProgsListView.SelectedItems[0].Tag;
            }
            if (programTabs.SelectedTab == currentProgs)
            {
                Process process = (Process)currentProgsListView.SelectedItems[0].Tag;
                p = new Programm(process.ProcessName, process.MainModule.FileName, 0, 0);
            }
            int maxUseTime = maxUseTimeTrackbar.Value;
            string catName = (string) categoryDropDown.SelectedItem;
            AddProgram(p, maxUseTime,catName);
            fillSavedProgsListView();
        }

        //information window
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(projectName + " soll Ihnen dabei helfen die Kontrolle über Ihre Nutzungszeit an Ihrem Computer zu regulieren." +
               "Sie können sich selbst ein Limit über die Category-Einstellungen setzen und bestimmen, wie lange Sie Ihren PC zur Arbeit, " +
               "Freizeit oder sonstigem nutzen möchten." + "\nZur Sicherheit können Sie das Passwort auch an Freunde oder Familie geben, " +
               "die Sie ggf. dabei unterstützen, sich an Ihre eigenen Regeln zu halten." +
               "Befolgen Sie einfach die Anweisungen beim Start des Programms, um das Tool sinngemäß zu nutzen." +
               "\nWir wünschen Ihnen viel Erfolg und Spaß mit Ihrer neu gewonnen Zeit." +
               "\n\nEine Anleitung finden sie auch in der ReadMe."
               , "Hilfe", MessageBoxButtons.OK);
        }

        //Category Options

        public void AddCategory(string name, int maxTime)
        {
            List<Programm> progList = new List<Programm>();
            bool isUnique = true;
            if (logCategorys.Count != 0 )
            {
                foreach (Category category in logCategorys)
                {
                    if (category.getName() == name)
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
            if (isUnique)
            {
                logCategorys.Add(new Category(name, 0, maxTime, progList));
                fillCategoryDropDown();
                SaveLogs();
            }
        }

      
        public void EditCategory(string name, string newName, int maxTime)
        {
            for (int i = 0; i < logCategorys.Count; i++)
            {
                if (logCategorys[i].getName() == name)
                {
                    if (newName != "")
                    {
                        foreach(Programm program in logPrograms)
                        {
                            if (program.getCategory() == logCategorys[i].getName())
                                program.setCategory(newName);
                        }
                        logCategorys[i].setName(newName);
                    }
                    if (maxTime != 0)
                        logCategorys[i].setMaxTime(maxTime);
                    fillCategoryDropDown();
                    SaveLogs();
                    break;
                }
            }
        }

 
        public void DeleteCategory(string name)
        {
            for (int i = 0; i < logCategorys.Count; i++)
            {
                if (logCategorys[i].getName() == name)
                {
                    logCategorys.RemoveAt(i);
                    fillCategoryDropDown();
                    SaveLogs();
                    break;
                }
            }
        }

        //sort entries in listView

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

        //update values in DetailBox
        private void updateDetailBox(bool changedIndex)
        {
            Programm program = null;
            if (programTabs.SelectedTab == installedProgs)
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
            if (programTabs.SelectedTab == savedProgs)
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
            if (programTabs.SelectedTab == currentProgs)
            {
                if (currentProgsListView.SelectedItems.Count > 0)
                {
                    Process process = (Process)currentProgsListView.SelectedItems[0].Tag;
                    program = logPrograms.Find(prog => prog.getName().Equals(process.ProcessName) && 
                    (prog.getPath().Contains(process.MainModule.FileName) || process.MainModule.FileName.Contains(prog.getPath())));
                    if(program != null)
                    {
                        updateDBox(currentProgsListView);
                    }
                    else
                    {
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
                        if (changedIndex)
                        {
                            individualLimitCheckBox.Checked = individualLimitDefault;
                            maxHourUseTimeTextBox.Text = "0";
                            maxMinuteUseTimeTextBox.Text = "0";
                            maxUseTimeTrackbar.Value = 0;
                        }
                    }
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
                Programm selectedItem;
                if (program != null)
                {
                    selectedItem = program;
                }
                else
                {
                    selectedItem = (Programm)listView.SelectedItems[0].Tag;
                }
                if (selectedItem != null)
                {
                    detailBox.Text = selectedItem.getName();
                    detailBox.Visible = true;
                    if (changedIndex)
                    {
                        individualLimitCheckBox.Checked = selectedItem.getIndividualLimit();
                        maxHourUseTimeTextBox.Text = "" + selectedItem.getMaxTime() / 3600;
                        maxMinuteUseTimeTextBox.Text = "" + (selectedItem.getMaxTime() % 3600) / 60;
                        maxUseTimeTrackbar.Value = selectedItem.getMaxTime();
                    }
                    usedHours = selectedItem.getUsedTime() / 3600;
                    usedMinutes = (selectedItem.getUsedTime() % 3600) / 60;
                    usedSeconds = selectedItem.getUsedTime() % 60;
                    currentUseTimeTextBox.Text = usedHours.ToString("00") + ":" + usedMinutes.ToString("00") + ":" + usedSeconds.ToString("00");
                }
            }
        }


        //getter methods of this form     
        private List<Programm> getInstalledPrograms()
        {   
            List<String> programNames = new List<String>();
            List<Programm> installedProgs = new List<Programm>();
            RegistryKey key;

            //to add path and name to installed programs
            void addPathByDisplayName(RegistryKey regKey)
            {
                string displayName;
                string path;
                foreach (String keyName in regKey.GetSubKeyNames())
                {
                    RegistryKey subKey = key.OpenSubKey(keyName);
                    if (IsProgramVisible(subKey))
                    {
                        displayName = subKey.GetValue("DisplayName") as string;
                        path = subKey.GetValue("InstallLocation") as string;
                        Programm temp = new Programm(displayName, path, 0, 0);
                        if (!installedProgs.Contains(temp))
                        {
                            installedProgs.Add(temp);
                        }
                    }
                }
            }

            bool IsProgramVisible(RegistryKey subkey)
            {
                var name = (string)subkey.GetValue("DisplayName");
                var path = (string)subkey.GetValue("InstallLocation");
                var releaseType = (string)subkey.GetValue("ReleaseType");
                var systemComponent = subkey.GetValue("SystemComponent");
                var parentName = (string)subkey.GetValue("ParentDisplayName");

                return
                    !string.IsNullOrEmpty(name)
                    && !string.IsNullOrEmpty(path)
                    && string.IsNullOrEmpty(releaseType)
                    && string.IsNullOrEmpty(parentName)
                    && (systemComponent == null || (int)systemComponent == 0);
            }
            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
       
            addPathByDisplayName(key);


            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
      
            addPathByDisplayName(key);


            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
           
            addPathByDisplayName(key);


            return installedProgs;
        }


        public List<String[]> GetCategory()
        {
            List<String[]> list = new List<String[]>();
            //add to name, usetime and maxtime to each category
            foreach (Category c in logCategorys)
            {
                list.Add(new String[] { c.getName(), "" + c.getUsedTime(), "" + c.getMaxTime() });
            }
            return list;
        }
        
        public String getProjectName()
        {
            return projectName;
        }
        
        //open editCategory window
        private void newCategoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editCats.Show();
        }
        //update DetailBox on changed tab or entry
        private void ProgramTabs_Selected(object sender, TabControlEventArgs e)
        {
            updateDetailBox(true);
        }
        private void InstalledProgsListView_Click(object sender, EventArgs e)
        {
            updateDetailBox(true);
        }
        private void CurrentProgsListView_Click(object sender, EventArgs e)
        {
            updateDetailBox(true);
        }
        private void SavedProgsListView_Click(object sender, EventArgs e)
        {
            updateDetailBox(true);
        }
        //menuItems clicked
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //change maxUseTime with Trackbar
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
 
    }   
}