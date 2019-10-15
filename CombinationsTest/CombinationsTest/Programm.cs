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
        private double usedTime;
        private double maxTime;
        private string kategorie;

        public Programm(String n, String p, double ut, double mt)
        {
            name = n;
            path = p;
            usedTime = ut;
            maxTime = mt;
        }
        public void setUsedTime(double newUsedTime)
        {
            usedTime = newUsedTime;
        }
        public double getUsedTime()
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
        public double getMaxTime()
        {
            return maxTime;
        }
        public void setMaxTime(double newMaxTime)
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
            return name + ";" + path + ";" + usedTime + ";" + maxTime;
        }
    }
}
