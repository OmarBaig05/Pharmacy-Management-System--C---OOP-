using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Person
    {
        protected string name;
        protected string password;
        protected string roll;

        public Person()
        {
            // Default constructor
        }

        public Person(string name, string password, string roll)
        {
            this.name = name;
            this.password = password;
            this.roll = roll;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }
        public string GetRoll()
        {
            return roll;
        }

        public void SetRoll(string roll)
        {
            this.roll = roll;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }
    }
}
