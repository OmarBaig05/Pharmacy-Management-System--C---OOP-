using pharmacay_managemnt_system.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.DL
{
    internal class AdminCRUD : PersonCRUD
    {
        public void storeInListAdmin(Admin ad)
        {
            if (!person_list.Contains(ad))
            {
                storeInListPer(ad);
            }
        }
        public void removePerson(Admin obj)
        {
            for (int i = 0; i < person_list.Count; i++)
            {
                if (person_list[i].GetName() == obj.GetName() && person_list[i].GetPassword() == obj.GetPassword() && person_list[i].GetRoll() == obj.GetRoll())
                {
                    person_list.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
