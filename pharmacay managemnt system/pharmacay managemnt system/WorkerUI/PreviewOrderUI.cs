using pharmacay_managemnt_system.BL;
using pharmacay_managemnt_system.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacay_managemnt_system.WorkerUI
{
    public partial class PreviewOrderUI : Form
    {

        DataTable table  = new DataTable();
        public PreviewOrderUI()
        {
            InitializeComponent();
            initializeTable();
        }

        private void PreviewOrderUI_Load(object sender, EventArgs e)
        {
            
        }
        
        public void checkForCustomer()
        {
            string name = CustomerBox.Text;
            string contact = ContactBox.Text;

            if (int.TryParse(contact, out int value))
            {
                Customer c = new Customer(name, contact);
                c = CustomerCRUD.getObj(c);
                if (c != null)
                {
                    textBox1.Text = c.GetBill().ToString();
                    List<Medicine> list = c.GetMedicineList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        displayInGrid(list[i].GetMedicineName(), list[i].GetQuantity(), list[i].GetPrice(), list[i].GetStock());
                    }
                }
                else
                {
                    MessageBox.Show("Customer Not Found", "Invalid Input", MessageBoxButtons.OK);
                }
            }
        }
        public void displayInGrid(string name, int quantity, int price, int amount)
        {
            table.Rows.Add(name, quantity, price, amount);
        }
        public void initializeTable()
        {
            table.Columns.Add("Medicine", typeof(string));
            table.Columns.Add("Quantity(mg)", typeof(string));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Amount", typeof(int));

            dataGridView1.DataSource = table;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            checkForCustomer();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WorkerDashboard f = new WorkerDashboard();
            f.Show();
            this.Close();
        }

    }
}
