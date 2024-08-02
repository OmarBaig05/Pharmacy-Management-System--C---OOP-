using pharmacay_managemnt_system.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace pharmacay_managemnt_system.DL
{
    internal class WorkerCRUD : PersonCRUD
    {
        public static List<Worker> workerList = new List<Worker>();
        public static void storeInListWorker(Worker ad)
        {
            if (!person_list.Contains(ad))
            {
                storeInListPer(ad);
            }
        }
        public static void removePerson(Worker obj)
        {
            for (int i = 0; i < person_list.Count; i++)
            {
                if (person_list[i] is Worker worker && worker.GetName() == obj.GetName() && worker.GetPassword() == obj.GetPassword())
                {
                    person_list.RemoveAt(i);
                    break;
                }
            }
        }
        public static List<Worker> ExtractWorkersFromPersonList()
        {
            List<Worker> workerList = new List<Worker>();

            for (int i = 0; i < person_list.Count; i++)
            {
                if (person_list[i] is Worker worker)
                {
                    workerList.Add(worker);
                }
            }

            return workerList;
        }
        public static void UpdateWorker(string name, string newPassword, int newSalary)
        {
            for (int i = 0; i < person_list.Count; i++)
            {
                if (person_list[i] is Worker worker && worker.GetName() == name)
                {
                    worker.SetPassword(newPassword);
                    worker.SetSallary(newSalary);
                    break;
                }
            }
        }
        public static bool ValidateInput(string email, string password, string salary,out int validSalary)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validSalary = 0;
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validSalary = 0;
                return false;
            }

            if (!int.TryParse(salary,out validSalary) || validSalary <= 0)
            {
                MessageBox.Show("Invalid salary input.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
