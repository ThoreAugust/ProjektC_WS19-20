using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceTech
{
    class PasswordHandler
    {   
        //declare
        private string logHash;

        //constructor
        public PasswordHandler()
        {

        }

       //functions to save and change password
       //__________________________________________
        private string HashPassword(string password)
        {
            string pwHash;
            if (!String.IsNullOrEmpty(password))
            {   
                //encoding the input
                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha.ComputeHash(textData);
                    pwHash = BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            return pwHash;
            }
            // confirms that pw is not empty
            else
            {
                return "Das Passwort darf nicht leer sein.";
            }
        }

        //saves pw to pwlog.txt
        public void savePassToLog (string password)
        {
            string hash = HashPassword(password);
            if (!hash.Equals("Das Passwort darf nicht leer sein."))
            {
                using (StreamWriter writer = File.CreateText("pwLog.txt"))
                {
                    writer.WriteLine("[PassHash]");
                    writer.WriteLine(hash);
                }
            }
        }

        // reades pw from pwlog.txt
        public void readPassFromLog()
        {
            if (!File.Exists("pwLog.txt"))
            {
                using (StreamWriter writer = File.CreateText("pwLog.txt"))
                {
                    writer.WriteLine("[PassHash]");
                }
            }
            else
            {
                using (StreamReader reader = File.OpenText("pwLog.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != "[PassHash]" && line != "")
                        {
                            logHash = line;
                        }
                    }
                }
            }
        }

        // checks if pw matches saved pw from pwlog.txt 
        public bool checkPass(string password)
        {
            string hashToTest = null;
            if (String.IsNullOrEmpty(logHash))
            {
                readPassFromLog();
            }
            if (password != null)
            {
            hashToTest = HashPassword(password);
            Console.WriteLine(password);
            Console.WriteLine(hashToTest);
                if(logHash != null && !password.Equals("Das Passwort darf nicht leer sein.") && hashToTest != null)
                {
                Console.WriteLine(logHash.Equals(hashToTest));
                return logHash.Equals(hashToTest);
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        
        //checks if loghash is empty or not
        public bool hasLogHash()
        {
            if (!String.IsNullOrEmpty(logHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //to change password
        public void changePass(string oldPass, string repeatOld, string newPass)
        {
            if (oldPass.Equals(repeatOld) && checkPass(oldPass) && checkPass(repeatOld))
            {
                savePassToLog(newPass);
            }
        }
        //functions to save and change password end
        //__________________________________________
    }
}
