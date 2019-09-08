using System;
using System.Data;
using System.Windows;


namespace listPrgs_test
{
    class tryListProgramms
    {
        static void Main(string[] args)
        {
            listPrgs();
            
        }
        private void listPrgs(object sender, EventArgs e)
        {

            object line;
            string softwareinstallpath = string.Empty;
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var key = baseKey.OpenSubKey(registry_key))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        using (var subKey = key.OpenSubKey(subkey_name))
                        {
                            line = subKey.GetValue("DisplayName");
                            if (line != null && (line.ToString().ToUpper().Contains("SPARK")))
                            {

                                softwareinstallpath = subKey.GetValue("InstallLocation").ToString();
                                listBox1.Items.Add(subKey.GetValue("InstallLocation"));
                                break;
                            }
                        }
                    }
                }
            }

            if (softwareinstallpath.Equals(string.Empty))
            {
                Console.WriteLine("The Mirth connect software not installed in this system.");
            }



            string targetPath = softwareinstallpath + @"\custom-lib\";
            string[] files = System.IO.Directory.GetFiles(@"D:\BaseFiles");

            // Copy the files and overwrite destination files if they already exist. 
            foreach (var item in files)
            {
                string srcfilepath = item;
                string fileName = System.IO.Path.GetFileName(item);
                System.IO.File.Copy(srcfilepath, targetPath + fileName, true);
            }
            return;

        }

    }
}
