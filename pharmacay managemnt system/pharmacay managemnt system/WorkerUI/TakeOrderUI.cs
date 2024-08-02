using pharmacay_managemnt_system.BL;
using pharmacay_managemnt_system.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacay_managemnt_system.WorkerUI
{
    public partial class TakeOrderUI : Form
    {
        DataTable table = new DataTable();
        int index;
        public TakeOrderUI()
        {
            InitializeComponent();
            initializeTable();
        }

        public void initializeTable()
        {
            table.Columns.Add("Medicine", typeof(string));
            table.Columns.Add("Quantity(mg)", typeof(string));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Amount", typeof(int));

            dataGridView1.DataSource = table;
        }

        public void goBack()
        {
            WorkerDashboard f = new WorkerDashboard();
            f.Show();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            goBack();
        }

        public void ClearData()
        {
            medNameBox.Text = string.Empty;
            priceBox.Text = string.Empty;
            quantityBox.Text = string.Empty;
            amountBox.Text = string.Empty;
        }

        public void displayInGrid(string name, int quantity, int price,int amount)
        {
            table.Rows.Add(name, quantity, price, amount);
        }

        public bool checkCustomer()
        {
            string n = contactBox.Text;
            if(!int.TryParse(n, out int value))
            {
                MessageBox.Show("Invalid PhOne Number Formate", "Invalid Formate", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        public void CompletingtheOrder()
        {
            List<Medicine> orderedMedicines = new List<Medicine>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string name = row.Cells[0].Value.ToString();
                int quantity = int.Parse(row.Cells[1].Value.ToString());
                int price = int.Parse(row.Cells[2].Value.ToString());
                int amount = int.Parse(row.Cells[3].Value.ToString());

                Medicine med = new Medicine(name, quantity, price,amount);
                orderedMedicines.Add(med);
            }

            Customer c = new Customer(custNameBox.Text, contactBox.Text, addressBox.Text,CalculateTotalPrice() ,orderedMedicines);
            CustomerCRUD.storeInListCust(c);
            MedicineCRUD.stockAutoUpdate(orderedMedicines);
            
        }

        public int CalculateTotalPrice()
        {
            int totalPrice = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                    int quantity = int.Parse(row.Cells[1].Value.ToString());
                    int price = int.Parse(row.Cells[2].Value.ToString());
                    int amount = quantity * price;

                    totalPrice += amount;
            }

            return totalPrice;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = CalculateTotalPrice().ToString();
        }

        private void placeOrderBtn_Click(object sender, EventArgs e)
        {
            if(checkCustomer())
            {
                CompletingtheOrder();
                goBack();
            }
        }

        private void TakeOrderUI_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            addMedicine();
        }

        public void addMedicine()
        {
            string name = medNameBox.Text;
            int quantity, price, amount;

            if (!MedicineCRUD.ValidateInput(name, quantityBox.Text, priceBox.Text, amountBox.Text, out quantity, out price, out amount))
                return;

            displayInGrid(name, quantity, price,amount);
            ClearData();
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            medNameBox.Text = row.Cells[0].Value.ToString();
            quantityBox.Text = row.Cells[1].Value.ToString();
            priceBox.Text = row.Cells[2].Value.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
