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
        override public String ToString()
        {
            String p = "";
            foreach (Programm program in programs)
                p += program.getPath() + ":";
            return name + ";" + maxTime + ";" + p;
        }
    }
}
