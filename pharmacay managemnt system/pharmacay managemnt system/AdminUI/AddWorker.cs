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

namespace pharmacay_managemnt_system
{
    public partial class AddWorker : Form
    {
        DataTable table = new DataTable();
        int index;
        public AddWorker()
        {
            InitializeComponent();
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {
            InitializeDataTable();
            displayFromList();
        }
        private void InitializeDataTable()
        {
            table.Columns.Add("Worker Name/Email", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Columns.Add("Salary", typeof(int));

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
            string name = nameBox.Text, password = passwordBox.Text;
            int salary;

            if (WorkerCRUD.ValidateInput(name, passwordBox.Text, salaryBox.Text, out salary))
            {
                Worker w = new Worker(name, password, "worker", salary);
                displayInGrid(name, password, salary);
                PersonCRUD.storeInListPer(w);
                clearData();
            }
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[index];
            string nameFixed = nameBox.Text, password = passwordBox.Text;
            int salary;

            if (WorkerCRUD.ValidateInput(nameFixed, passwordBox.Text, salaryBox.Text, out salary))
            {
                DialogResult result = MessageBox.Show("Do you want to make changes?", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    WorkerCRUD.UpdateWorker(nameFixed, password, salary);
                    updateCells(passwordBox.Text, salary, row);
                    clearData();
                }
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            Worker w = new Worker(nameBox.Text, passwordBox.Text,"worker");
            WorkerCRUD.removePerson(w);
        }




        public void displayInGrid(string name, string passwrd, int salary)
        {
            table.Rows.Add(name, passwrd, salary);
        }
        public void updateCells(string password, int salary, DataGridViewRow row)
        {
            row.Cells[1].Value = password;
            row.Cells[2].Value = salary;
        }
        public void clearData()
        {
            nameBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
            salaryBox.Text = string.Empty;
        }
        public void updateData(string name, string password, int salary,DataGridViewRow row)
        {
            row.Cells[0].Value = name;
            row.Cells[1].Value = password;
            row.Cells[2].Value = salary;
        }
        public void displayFromList()
        {
            List<Worker> list =  WorkerCRUD.ExtractWorkersFromPersonList();
            for (int i = 0; i < list.Count; i++)
            {
                displayInGrid(list[i].GetName(), list[i].GetPassword(), list[i].GetSallary());
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            nameBox.Text = row.Cells[0].Value.ToString();
            passwordBox.Text = row.Cells[1].Value.ToString();
            salaryBox.Text = row.Cells[2].Value.ToString();
        }
    }
}
