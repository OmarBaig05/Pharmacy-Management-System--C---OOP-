using pharmacay_managemnt_system.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacay_managemnt_system.DL
{
    internal class PersonCRUD
    {
        protected static List<Person> person_list = new List<Person>();
        public static void storeInListPer(Person ad)
        {
            if (!person_list.Contains(ad))
            {
                person_list.Add(ad);
            }
        }
        public static string signIn(Person obj)
        {
            for (int i = 0; i < person_list.Count; i++)
            {
                if (person_list[i].GetName() == obj.GetName() && person_list[i].GetPassword() == obj.GetPassword() && person_list[i].GetRoll() == obj.GetRoll())
                {
                    return person_list[i].GetRoll();
                }
            }
            return null;
        }
        public static int listSize()
        {
            return person_list.Count;
        }
        public static void storeDataInFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int i = 0; i < person_list.Count(); i++)
            {
                file.WriteLine(person_list[i].GetName() + "," + person_list[i].GetPassword() + "," + person_list[i].GetRoll());
            }
            file.Flush();
            file.Close();
        }
        public static void RetriveDataFromFile(string path)
        {
            StreamReader filevariable = new StreamReader(path);
            string record;
            while ((record = filevariable.ReadLine()) != null)
            {
                string[] resultarray = record.Split(',');
                string name = resultarray[0];
                string password = resultarray[1];
                string roll = resultarray[2];
                Person ad = new Person(name, password, roll);
                storeInListPer(ad);
            }
            filevariable.Close();
        }
        public static bool ValidateInput(string email, string password, string roll)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(roll))
            {
                MessageBox.Show("Roll cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
