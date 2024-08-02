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
using System.Xml.Serialization;
using System.Threading;
using System.Diagnostics;
using System.Xml.Linq;

namespace pharmacay_managemnt_system
{
    public partial class AddMedicine : Form
    {
        DataTable table = new DataTable("table");
        int index;
        private List<Medicine> filteredList = new List<Medicine>();
        public AddMedicine()
        {
            InitializeComponent();
        }
        private void AddMedicine_Load(object sender, EventArgs e)
        {
            InitializeDataTable();
            displayFromList();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add("Medicine", typeof(string));
            table.Columns.Add("Quantity_mg", typeof(int));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Stock", typeof(int));

            dataGridView1.DataSource = table;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = medNameBox.Text;
            int quantity, price, stock;

            if (!MedicineCRUD.ValidateInput(name, quantityBox.Text, priceBox.Text, stockBox.Text, out quantity, out price, out stock))
                return;

            displayInGrid(name, quantity, price, stock);
            Medicine m = new Medicine(name, quantity, price, stock);
            MedicineCRUD.storeInListMed(m);
            ClearData();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updateData = dataGridView1.Rows[index];
            string name = medNameBox.Text;

            if (!MedicineCRUD.ValidateInput(medNameBox.Text, quantityBox.Text, priceBox.Text, stockBox.Text, out int validatedQuantity, out int validatedPrice, out int validatedStock))
            {
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to make changes?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Medicine m = new Medicine(medNameBox.Text, int.Parse(quantityBox.Text), int.Parse(priceBox.Text), int.Parse(stockBox.Text));
                updateCells(name, validatedQuantity, validatedPrice, validatedStock, updateData); ;
                MedicineCRUD.UpdatingMedicine(m, index);
            }

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            MedicineCRUD.removeMedicine(index);
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearData();
        }


        
        public void updateCells(string name, int quantity, int price, int stock, DataGridViewRow row)
        {
            row.Cells[0].Value = name;
            row.Cells[1].Value = quantity;
            row.Cells[2].Value = price;
            row.Cells[3].Value = stock;
        }
        public void displayFromList()
        {
            int x = MedicineCRUD.getListSize();
            for (int i = 0; i< x; i++)
            {
                displayInGrid(MedicineCRUD.MedIndex(i), int.Parse(MedicineCRUD.QuantityIndex(i)), int.Parse(MedicineCRUD.priceIndex(i)), int.Parse(MedicineCRUD.stockIndex(i)));
            }
        }
        public void displayInGrid(string name, int quantity, int price, int stock)
        {
            table.Rows.Add(name, quantity, price, stock);
        }
        public void ClearData()
        {
            medNameBox.Text = string.Empty;
            priceBox.Text = string.Empty;
            stockBox.Text = string.Empty;
            quantityBox.Text = string.Empty;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            medNameBox.Text = row.Cells[0].Value.ToString();
            quantityBox.Text = row.Cells[1].Value.ToString();
            priceBox.Text = row.Cells[2].Value.ToString();
            stockBox.Text = row.Cells[3].Value.ToString();
        }

    }
}
