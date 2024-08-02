using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Customer
    {
        private string name;
        private string contact;
        private string address;
        private float bill;
        private List<Medicine> medList = new List<Medicine>();

        //Constructors
        public Customer(string name, string contact, string address, float price, List<Medicine> medList)
        {
            this.name = name;
            this.contact = contact;
            this.address = address;
            this.medList = medList;
            this.bill = price;
        }

        public Customer(string name, string contact)
        {
            this.name = name;
            this.contact = contact;
        }
        //getter and setters 
        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public string GetContact()
        {
            return contact;
        }

        public void SetContact(string value)
        {
            contact = value;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string value)
        {
            address = value;
        }
        public float GetBill()
        {
            return bill;
        }

        public void SetBill(float bill)
        {
            this.bill = bill;
        }

        public List<Medicine> GetMedicineList()
        {
            return medList;
        }

        public void SetMedicineList(List<Medicine> medicine)
        {
            medList = medicine;
        }
    }
}
