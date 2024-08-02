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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMedicine f = new AddMedicine();
            f.Show();
            this.Hide();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            addSupplier.Show();
            this.Close();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            AddWorker addWorker = new AddWorker();
            addWorker.Show();
            this.Close();
        }

    }
}
