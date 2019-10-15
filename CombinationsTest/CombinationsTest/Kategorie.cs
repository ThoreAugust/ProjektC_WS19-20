using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsTest
{
    class Kategorie
    {
        private String name;
        private double usedTime;
        private double maxTime;
        private List<Programm> programs;

        public Kategorie(String n, double ut, double mt, List<Programm> p)
        {
            name = n;
            usedTime = ut;
            maxTime = mt;
            programs = p;
        }
        override public String ToString()
        {
            String p = "";
            foreach (Programm program in programs)
                p += program.getPath() + ":";
            return name + ";" + maxTime + ";" + p;
        }
    }
}
