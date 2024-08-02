using pharmacay_managemnt_system.BL;
using pharmacay_managemnt_system.DL;
using pharmacay_managemnt_system.WorkerUI;
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
    public partial class SignInMenu : Form
    {
        public SignInMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
            this.Hide();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text.Trim();
            string roll = rollComboBox.Text;
            
            if (!(PersonCRUD.ValidateInput(email, password, roll)))
            {
              return;
            }
            
            Person p = new Admin(email, password, roll);
            string flag = PersonCRUD.signIn(p);
            if(flag == "admin")
            {
              ShowAdminDashboard();
            }
            else if (flag == "worker")
            {
              ShowWorkerDashboard();
            }
            else
            {
              MessageBox.Show("User Not Found.", "Recognition error. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void ShowAdminDashboard()
        {
            AdminDashboard a = new AdminDashboard();
            a.Show();
            this.Hide();
        }
        private void ShowWorkerDashboard()
        {
            WorkerDashboard a = new WorkerDashboard();
            a.Show();
            this.Hide();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clearData();
        }
        private void clearData()
        {
            emailBox.Clear();
            passwordBox.Clear();
            rollComboBox.Items.Clear();
        }

        private void SignInMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
