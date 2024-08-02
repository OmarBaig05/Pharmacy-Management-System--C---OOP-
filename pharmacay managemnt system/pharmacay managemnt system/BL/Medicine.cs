using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Medicine
    {
        private string medicineName;
        private int quantity;
        private int price;
        private int stock;



        public Medicine(string name, int quantity, int price, int stock)
        {
            this.medicineName = name;
            this.quantity = quantity;
            this.price = price;
            this.stock = stock;
        }
        public Medicine(string name)
        {
            this.medicineName = name;
        }
        public Medicine()
        {
        }
        public Medicine(string name, int quantity)
        {
            this.medicineName = name;
            this.quantity = quantity;
        }
        public Medicine(string name, int quantity, int stock)
        {
            this.medicineName = name;
            this.quantity = quantity;
            this.stock = stock;
        }


        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Getter and setters

        public string GetMedicineName()
        {
            return medicineName;
        }

        public void SetMedicineName(string name)
        {
            medicineName = name;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int qty)
        {
            quantity = qty;
        }

        public int GetPrice()
        {
            return price;
        }

        public void SetPrice(int value)
        {
            price = value;
        }

        public int GetStock()
        {
            return stock;
        }

        public void SetStock(int value)
        {
            stock = value;
        }
    }
}
