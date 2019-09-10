using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ChristopherWpfTutorial
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRefreshAll_Click(object sender, RoutedEventArgs e)
        {
            TextBlockID.Text = "";
            TextBlockName.Text = "";
            TextBlockTitel.Text = "";
            foreach (Process p in Process.GetProcesses())   //Alle Prozesse hinzufügen
            {
                TextBlockID.Text += p.Id + "\n";
                TextBlockName.Text += p.ProcessName + "\n";
                TextBlockTitel.Text += p.MainWindowTitle + "\n";
            }
        }

        private void ButtonRefreshTitle_Click(object sender, RoutedEventArgs e)
        {
            TextBlockID.Text = "";
            TextBlockName.Text = "";
            TextBlockTitel.Text = "";
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "")    //Nur hinzufügen wenn der Prozess ein Fenster hat
                {
                    TextBlockID.Text += p.Id + "\n";
                    TextBlockName.Text += p.ProcessName + "\n";
                    TextBlockTitel.Text += p.MainWindowTitle + "\n";
                }
            }
        }
    }
}
