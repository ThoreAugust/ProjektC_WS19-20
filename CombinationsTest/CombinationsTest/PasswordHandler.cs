using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsTest
{
    class PasswordHandler
    {
        private Dictionary<string, string> passwordHashPair = new Dictionary<string, string>();
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
                passwordHashPair.Add(password, hash);
                Dictionary<string, string>.ValueCollection values= passwordHashPair.Values;
                using (StreamWriter writer = File.CreateText("pwLog.txt"))
                {
                    writer.WriteLine("[PassHash]");
                    foreach (string value in values)
                    {
                        writer.WriteLine("cur:"+value);
                    }
                }
            }
        }
        private void readPassFromLog()
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
                    string [] splitLine;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != "[PassHash]" && line != "")
                        {
                            if (line.Contains("cur:"))
                            {
                                splitLine = line.Split(':');
                                Console.WriteLine(splitLine[1]);
                                logHash = splitLine[1];
                            }
                        }
                    }
                }
            }
        }
        public bool checkPass(string password)
        {
            readPassFromLog();
            string hashToTest = HashPassword(password);
            Console.WriteLine(password);
            Console.WriteLine(hashToTest);
            Console.WriteLine(logHash.Equals(hashToTest));
            return logHash.Equals(hashToTest);
        }
    }
}
