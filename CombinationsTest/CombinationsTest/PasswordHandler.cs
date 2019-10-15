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

        public PasswordHandler()
        {
        }

        private void hashPassword(string password)
        {
            string pwHash;
            if (!String.IsNullOrEmpty(password))
            {
                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha.ComputeHash(textData);
                    pwHash = BitConverter.ToString(hash).Replace("-", String.Empty);
                    passwordHashPair.Add(password, pwHash);
                }
            }

        }

        public void savePassToLog ()
        {
            Dictionary<string, string>.ValueCollection values= passwordHashPair.Values;
            foreach (var value in values)
            {

            }
            using (StreamWriter writer = File.CreateText("pwLog.txt"))
            {
                writer.WriteLine("[PassHash]");
                foreach (string value in values)
                {
                    writer.WriteLine("cur:"+value);
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
                    string [] splitLine;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != "[PassHash]" && line != "")
                        {
                            if (line.Contains("cur:"))
                            {
                                splitLine = line.Split(':');
                                foreach (string item in splitLine)
                                {
                                    Console.WriteLine(item);
                                }
                                hash = splitLine[1];
                            }
                        }
                    }
                }
            }
        }
    }
}
