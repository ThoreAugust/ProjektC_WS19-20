using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsTest
{
    class Programm
    {
        private string name;
        private string path;
        private int usedTime;
        private int maxTime;
        private string kategorie;

        public Programm(String n, String p, int ut, int mt)
        {
            name = n;
            path = p;
            usedTime = ut;
            maxTime = mt;
            kategorie = "Keine Kategorie";
        }
        public void setUsedTime(int newUsedTime)
        {
            usedTime = newUsedTime;
        }
        public int getUsedTime()
        {
            return usedTime;
        }
        public string getPath()
        {
            return path;
        }
        public string getName()
        {
            return name;
        }
        public int getMaxTime()
        {
            return maxTime;
        }
        public void setMaxTime(int newMaxTime)
        {
            maxTime = newMaxTime;
        }
        public string getKategorie()
        {
            return kategorie;
        }
        public void setKategorie(string newKategorie)
        {
            kategorie = newKategorie;
        }
        public override string ToString()
        {
            return name + ";" + path + ";" + usedTime + ";" + maxTime + ";" + kategorie;
        }
    }
}
