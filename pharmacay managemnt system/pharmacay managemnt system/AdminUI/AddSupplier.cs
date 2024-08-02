using pharmacay_managemnt_system.BL;
using pharmacay_managemnt_system.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacay_managemnt_system
{
    public partial class AddSupplier : Form
    {
        DataTable table = new DataTable();
        int index;
        public AddSupplier()
        {
            InitializeComponent();
            
        }
        private void AddSupplier_Load(object sender, EventArgs e)
        {
            InitializeDataTable();
            displayFromList();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add("Supplier", typeof(string));
            table.Columns.Add("Medicine", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
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
        private void addBtn_Click(object sender, EventArgs e)
        {
            int quantity, stock, price;

            if (!SupplierCRUD.validation(supplierBox.Text))
                return;
            if (!MedicineCRUD.ValidateInput(medBox.Text, quantityBox.Text, priceBox.Text, stockBox.Text, out quantity, out price, out stock))
                return;

            displayInGrid(supplierBox.Text, medBox.Text, quantity, price, stock);

            Medicine m = new Medicine(medBox.Text, quantity, price, stock);
            Supplier s = new Supplier(supplierBox.Text,m);
            SupplierCRUD.storeInListSup(s);
            clearData();
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearData();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            int quantity, stock, price;
            DataGridViewRow row = dataGridView1.Rows[index];

            if (!SupplierCRUD.validation(supplierBox.Text))
                return;
            if (!MedicineCRUD.ValidateInput(medBox.Text, quantityBox.Text, priceBox.Text, stockBox.Text, out quantity, out price, out stock))
                return;
            DialogResult result = MessageBox.Show("Do you want to make changes?", "Confirmation", MessageBoxButtons.OKCancel);
            if(DialogResult == DialogResult.OK)
            {
                updateData(supplierBox.Text, medBox.Text, quantity, price, stock,row);
                Medicine m = new Medicine(medBox.Text, quantity, price, stock);
                Supplier s = new Supplier(supplierBox.Text, m);
                SupplierCRUD.UpdatingSuppler(s,index);
            }

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            SupplierCRUD.removeSupplier(index);
        }




        public void displayInGrid(string name, string medicine, int quantity, int price, int stock)
        {
            table.Rows.Add(name, medicine, quantity, price, stock);
        }
        public void clearData()
        {
            supplierBox.Text = string.Empty;
            medBox.Text = string.Empty;
            quantityBox.Text = string.Empty;
            priceBox.Text = string.Empty;
            stockBox.Text = string.Empty;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            supplierBox.Text = row.Cells[0].Value.ToString();
            medBox.Text = row.Cells[1].Value.ToString();
            quantityBox.Text = row.Cells[2].Value.ToString();
            priceBox.Text = row.Cells[3].Value.ToString();
            stockBox.Text = row.Cells[4].Value.ToString();
        }
        public void updateData(string name,string medicine,int quantity,int price,int stock, DataGridViewRow row)
        {
            row.Cells[0].Value = name;
            row.Cells[1].Value = medicine;
            row.Cells[2].Value = quantity;
            row.Cells[3].Value = price;
            row.Cells[4].Value = stock;
        }
        public void displayFromList()
        {
            int x = SupplierCRUD.getListSize();
            for (int i = 0; i < x; i++)
            {
                displayInGrid(SupplierCRUD.supplierIndex(i),SupplierCRUD.MedIndex(i), int.Parse(SupplierCRUD.QuantityIndex(i)), int.Parse(SupplierCRUD.priceIndex(i)), int.Parse(SupplierCRUD.stockIndex(i)));
            }
        }

    }
}
