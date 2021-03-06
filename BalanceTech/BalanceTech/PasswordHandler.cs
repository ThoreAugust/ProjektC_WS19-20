﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceTech
{
    class PasswordHandler
    {
        private string logHash;

        public PasswordHandler()
        {
        }
        private string HashPassword(string password)
        {
            string pwHash;
            if (!String.IsNullOrEmpty(password))
            {
                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha.ComputeHash(textData);
                    pwHash = BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            return pwHash;
            }
            else
            {
                return "Das Passwort darf nicht leer sein.";
            }
        }
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
        public void changePass(string oldPass, string repeatOld, string newPass)
        {
            if (oldPass.Equals(repeatOld) && checkPass(oldPass) && checkPass(repeatOld))
            {
                savePassToLog(newPass);
            }
        }
    }
}
