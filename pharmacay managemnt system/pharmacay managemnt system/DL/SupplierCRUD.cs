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
    internal class SupplierCRUD
    {
        private static List<Supplier> sup_list = new List<Supplier>();

        public static void storeInListSup(Supplier ad)
        {
            sup_list.Add(ad);
        }
        public static void removeSupplier(int i)
        {
           sup_list.RemoveAt(i);
                
        }
        public static void UpdatingSuppler(Supplier obj, int i)
        {
            sup_list[i].SetSupplierName(obj.GetSupplierName());
            sup_list[i].GetMedObj().SetMedicineName(obj.GetMedObj().GetMedicineName());
            sup_list[i].GetMedObj().SetQuantity(obj.GetMedObj().GetQuantity());
            sup_list[i].GetMedObj().SetPrice(obj.GetMedObj().GetPrice());
            sup_list[i].GetMedObj().SetStock(obj.GetMedObj().GetStock());
        }
        public static string displayStock(int i)
        {
            if (i >= 0 && i < sup_list.Count)
            {
                return (sup_list[i].GetSupplierName() + "\t\t\t" + sup_list[i].GetMedObj().GetMedicineName() + "\t\t\t" + sup_list[i].GetMedObj().GetQuantity() + "\t\t " + sup_list[i].GetMedObj().GetPrice().ToString() + "\t\t " + sup_list[i].GetMedObj().GetStock().ToString());
            }
            return null;
        }
        public static int getListSize()
        {
            return sup_list.Count();
        }
        public static bool validation(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Supplier section cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }




        public static string supplierIndex(int i)
        {
            return sup_list[i].GetSupplierName();
        }
        public static string MedIndex(int i)
        {
            return sup_list[i].GetMedObj().GetMedicineName();
        }
        public static string QuantityIndex(int i)
        {
            return sup_list[i].GetMedObj().GetQuantity().ToString();
        }
        public static string priceIndex(int i)
        {
            return sup_list[i].GetMedObj().GetPrice().ToString();
        }
        public static string stockIndex(int i)
        {
            return sup_list[i].GetMedObj().GetStock().ToString();
        }




        public static void storeDataInFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int i = 0; i < sup_list.Count(); i++)
            {
                file.WriteLine(sup_list[i].GetSupplierName() + "," + sup_list[i].GetMedObj().GetMedicineName().ToString() + ";" + sup_list[i].GetMedObj().GetQuantity().ToString() + ";" + sup_list[i].GetMedObj().GetPrice().ToString() + ";" + sup_list[i].GetMedObj().GetStock().ToString());
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
                string[] splittedRecord = record.Split(',');
                string supplierName = splittedRecord[0];
                string[] objString = splittedRecord[1].Split(';');
                string name = objString[0];
                int quantity =  int.Parse(objString[1]);
                int price = int.Parse(objString[2]);
                int stock = int.Parse(objString[3]);
                Medicine med = new Medicine(name, quantity, price, stock);
                Supplier ad = new Supplier(supplierName, med);
                storeInListSup(ad);
            }
            filevariable.Close();
        }
    }
}
