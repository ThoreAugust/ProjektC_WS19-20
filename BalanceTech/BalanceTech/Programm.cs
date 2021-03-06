﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceTech
{
    class Programm
    {
        private string name;
        private string path;
        private int usedTime;
        private int maxTime;
        private string kategorie;
        private bool individualLimit;

        public Programm(String n, String p, int ut, int mt)
        {
            name = n;
            path = p;
            usedTime = ut;
            maxTime = mt;
            kategorie = "";
            individualLimit = false;
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
        public bool getIndividualLimit()
        {
            return individualLimit;
        }
        public void setIndividualLimit(bool limit)
        {
            individualLimit = limit;
        }
        public override string ToString()
        {
            return name + ";" + path + ";" + usedTime + ";" + maxTime + ";" + individualLimit;
        }
    }
}
