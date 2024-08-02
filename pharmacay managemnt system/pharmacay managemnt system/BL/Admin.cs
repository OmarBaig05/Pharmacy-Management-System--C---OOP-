using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Admin : Person
    {
        public Admin(string name, string password, string roll) : base(name, password, roll)
        {
        }

        public new string GetRoll()
        {
            return roll;
        }

        public new void SetRoll(string value)
        {
            roll = value;
        }
    }
}
