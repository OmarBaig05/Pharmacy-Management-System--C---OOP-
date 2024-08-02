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
    internal class MedicineCRUD
    {
        private static List<Medicine> med_list = new List<Medicine>();
        public static void storeInListMed(Medicine ad)
        {
            med_list.Add(ad);
        }

        public static List<Medicine> getMedicineList()
        {
            return med_list;
        }
        public static Medicine findMedicineObj(Medicine obj)
        {
            for (int i = 0; i < med_list.Count(); i++)
            {
                if (med_list[i].GetMedicineName() == obj.GetMedicineName() && med_list[i].GetQuantity() == obj.GetQuantity() && med_list[i].GetPrice() == obj.GetPrice() && med_list[i].GetStock() == obj.GetStock())
                {
                    Medicine med = med_list[i];
                    return med;
                }
            }
            return null;
        }

        public static void UpdatingMedicine(Medicine obj , int i)
        {
           med_list[i].SetPrice(obj.GetPrice());
           med_list[i].SetStock(obj.GetStock());
           med_list[i].SetMedicineName(obj.GetMedicineName());
           med_list[i].SetQuantity(obj.GetQuantity());
        }

        public static void removeMedicine(int i)
        {
            med_list.RemoveAt(i);
        }

        public static Medicine ProvideMedObj(string medicineName, int quantity)
        {
            for (int i = 0; i < med_list.Count; i++)
            {
                if (med_list[i].GetMedicineName() == medicineName && med_list[i].GetQuantity() == quantity)
                {
                    return med_list[i];
                }
            }
            return null;
        }
        public static string MedIndex(int i)
        {
            return med_list[i].GetMedicineName();
        }
        public static string QuantityIndex(int i)
        {
             return med_list[i].GetQuantity().ToString();
        }
        public static string priceIndex(int i)
        {
            return med_list[i].GetPrice().ToString();
        }
        public static string stockIndex(int i)
        {
            return med_list[i].GetStock().ToString();
        }

        public static int getListSize()
        {
            return med_list.Count();
        }
        public static void stockAutoUpdate(List<Medicine> list)
        {
            for (int i = 0; i < med_list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++ )
                if (med_list[i].GetMedicineName() == list[j].GetMedicineName() && med_list[i].GetQuantity() == list[j].GetQuantity())
                {
                    int x = med_list[i].GetStock();
                    int v = list[j].GetStock();
                    x = x - v;
                }
            }
        }
        public static int totalPricePerProduct(int price, int stock)
        {
            price = price * stock;
            return price;
        }
        public static bool ValidateInput(string name, string quantity, string price, string stock, out int validatedQuantity, out int validatedPrice, out int validatedStock)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validatedQuantity = validatedPrice = validatedStock = 0;
                return false;
            }

            if (!int.TryParse(quantity, out validatedQuantity) || validatedQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validatedPrice = validatedStock = 0;
                return false;
            }

            if (!int.TryParse(price, out validatedPrice) || validatedPrice <= 0)
            {
                MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validatedStock = 0;
                return false;
            }

            if (!int.TryParse(stock, out validatedStock) || validatedStock < 0)
            {
                MessageBox.Show("Please enter a valid stock value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public static void storeDataInFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int i = 0; i < med_list.Count(); i++)
            {
                file.WriteLine(med_list[i].GetMedicineName() + ";" + med_list[i].GetQuantity() + ";" + med_list[i].GetPrice() + ";" + med_list[i].GetStock());
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
                string[] objString = record.Split(';');
                string name = objString[0];
                int quantity = int.Parse(objString[1]);
                int price = int.Parse(objString[2]);
                int stock = int.Parse(objString[3]);
                Medicine med = new Medicine(name, quantity, price, stock);
                storeInListMed(med);
            }
            filevariable.Close();
        }
    }
}
