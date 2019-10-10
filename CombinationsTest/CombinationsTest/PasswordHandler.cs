using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsTest
{
    class PasswordHandler
    {
        private Dictionary<string, string> passwordHashPair = new Dictionary<string, string>();

        public PasswordHandler(String password)
        {
            passwordHashPair.Add(password, hashPassword(password));
        }

        public string hashPassword(string password)
        {
            string passwordHash;
            if (String.IsNullOrEmpty(password))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(textData);
                passwordHash = BitConverter.ToString(hash).Replace("-", String.Empty);
            }

            //return passwordHash;
            return "test";
        }

        public void saveHashToLog ()
        {
            Dictionary<string, string>.ValueCollection values= passwordHashPair.Values;
            foreach (var value in values)
            {

            }

        }

        public string readHashFromLog()
        {
            string passwordHash = "test";


            return passwordHash;
        }
    }
}
