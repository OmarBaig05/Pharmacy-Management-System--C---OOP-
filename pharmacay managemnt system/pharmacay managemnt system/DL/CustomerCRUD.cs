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
    internal class CustomerCRUD
    {
        private static List<Customer> cust_list = new List<Customer>();

        public static void storeInListCust(Customer ad)
        {
            cust_list.Add(ad);
        }

        public static Customer getObj(Customer obj)
        {
            for (int i = 0; i < cust_list.Count; i++)
            {
                if (cust_list[i].GetName() == obj.GetName() && cust_list[i].GetContact() == obj.GetContact())
                {
                    return cust_list[i];
                }
            }
            return null;
        }

        public static int listCounts()
        {
            return cust_list.Count;
        }

        public static void storeDataInFile(string path)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                foreach (Customer customer in cust_list)
                {
                    file.Write(customer.GetName() + "," + customer.GetContact() + "," + customer.GetAddress() + "," + customer.GetBill() + ",");
                    foreach (Medicine medicine in customer.GetMedicineList())
                    {
                        file.Write( medicine.GetMedicineName() + "/" + medicine.GetQuantity() + "/" + medicine.GetPrice() + "/" + medicine.GetStock() + "/" + "#");
                    }
                    file.WriteLine("#,");
                }
            }
        }


        public static void RetriveDataFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            cust_list.Clear();

            using (StreamReader filevariable = new StreamReader(path))
            {
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');

                    if (splittedRecord.Length >= 5)
                    {
                        string name = splittedRecord[0];
                        string contact = splittedRecord[1];
                        string address = splittedRecord[2];
                        float bill = float.Parse(splittedRecord[3]);

                        List<Medicine> med = new List<Medicine>();

                        // Check if there is data for medicines
                        if (splittedRecord.Length >= 6)
                        {
                            string[] medObj = splittedRecord[4].Split('#');
                            foreach (string medData in medObj)
                            {
                                string[] objData = medData.Split('/');
                                if (objData.Length >= 4)
                                {
                                    string medName = objData[0];
                                    int quantity = int.Parse(objData[1]);
                                    int price = int.Parse(objData[2]);
                                    int stock = int.Parse(objData[3]);
                                    Medicine m = new Medicine(medName, quantity, price, stock);
                                    med.Add(m);
                                }
                            }
                        }

                        Customer c = new Customer(name, contact, address, bill, med);
                        cust_list.Add(c);
                    }
                }
            }
        }

    }

}

