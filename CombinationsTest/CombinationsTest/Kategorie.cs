﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsTest
{
    class Kategorie
    {
        private String name;
        private int usedTime;
        private int maxTime;
        private List<Programm> programs;

        public Kategorie(String n, int ut, int mt, List<Programm> p)
        {
            name = n;
            usedTime = ut;
            maxTime = mt;
            programs = p;
        }
        public void AddProgramm(Programm prog)
        {
            if (!programs.Contains(prog))
            {
                programs.Add(prog);
            }
        }
        public string getName()
        {
            return name;
        }
        public void setName(string n)
        {
            name = n;
        }
        public int getMaxTime()
        {
            return maxTime;
        }
        public void setMaxTime(int mt)
        {
            maxTime = mt;
        }
        override public String ToString()
        {
            String p = "";
            if (programs != null)
            {
                foreach (Programm program in programs)
                    p += program.getPath() + ",";
            }
            return name + ";" + maxTime + ";" + p;
        }
        public void RemoveProgramm(Programm programm)
        {
            programs.Remove(programm);
        }
    }
}
