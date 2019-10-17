﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombinationsTest
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetUpDialog setUp = new SetUpDialog();
            Application.Run(setUp);
            if (setUp.closingForm())
            {
                Application.Run(setUp.GetMainWindow());
            }
        }
    }
}
