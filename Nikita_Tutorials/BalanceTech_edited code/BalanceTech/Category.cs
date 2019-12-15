using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceTech
{
    class Category
    {   
        //declaration
        private String name;
        private int usedTime;
        private int maxTime;
        private List<Program> programs;

        //constructor
        public Category(String n, int ut, int mt, List<Program> p)
        {
            //initialize
            name = n;
            usedTime = ut;
            maxTime = mt;
            programs = p;
        }

        //getter/setter 
        public void AddProgram(Program prog)
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
        public int getUsedTime()
        {
            return usedTime;
        }
        public void setUsedTime(int ut)
        {
            usedTime = ut;
        }
        public List<Program> GetPrograms()
        {
            return programs;
        }
        override public String ToString()
        {
            String p = "";
            if (programs != null)
            {
                foreach (Program program in programs)
                    p += ";" + program.getName() + "," + program.getPath();
            }
            return name + ";" + maxTime + p;
        }
        public void RemoveProgram(Program program)
        {
            programs.Remove(program);
        }
    }
}
