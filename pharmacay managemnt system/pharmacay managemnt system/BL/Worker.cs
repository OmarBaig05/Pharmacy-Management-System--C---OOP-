using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Worker : Person
    {
        private int salary;


        public Worker(string name, string password, string roll ,int salary ) : base(name, password, roll)
        {
            this.salary = salary;
        }
        public Worker(string name, string password, string roll) : base(name, password, roll)
        {

        }
        public int GetSallary()
        {
            return this.salary;
        }

        public void SetSallary(int value)
        {
            salary = value;
        }
    }
}
