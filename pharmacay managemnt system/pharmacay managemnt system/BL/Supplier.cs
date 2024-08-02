using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacay_managemnt_system.BL
{
    internal class Supplier
    {
        private string supplierName;
        private Medicine med_obj;

        public Supplier(string supplierName, Medicine med_obj)
        {
            this.supplierName = supplierName;
            this.med_obj = med_obj;
        }
        public string GetSupplierName()
        {
            return supplierName;
        }

        public void SetSupplierName(string name)
        {
            supplierName = name;
        }

        public Medicine GetMedObj()
        {
            return med_obj;
        }

        public void SetMedObj(Medicine medicine)
        {
            med_obj = medicine;
        }
    }
}
