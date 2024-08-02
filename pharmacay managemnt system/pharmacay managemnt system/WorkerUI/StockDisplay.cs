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
    public partial class StockDisplay : Form
    {
        DataTable table = new DataTable("table");
        public StockDisplay()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private void StockDisplay_Load(object sender, EventArgs e)
        {
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
            WorkerDashboard f = new WorkerDashboard();
            f.Show();
            this.Close();
        }
        public void displayFromList()
        {
            int x = MedicineCRUD.getListSize();
            for (int i = 0; i < x; i++)
            {
                displayInGrid(MedicineCRUD.MedIndex(i), int.Parse(MedicineCRUD.QuantityIndex(i)), int.Parse(MedicineCRUD.priceIndex(i)), int.Parse(MedicineCRUD.stockIndex(i)));
            }
        }
        public void displayInGrid(string name, int quantity, int price, int stock)
        {
            table.Rows.Add(name, quantity, price, stock);
        }
    }
}
