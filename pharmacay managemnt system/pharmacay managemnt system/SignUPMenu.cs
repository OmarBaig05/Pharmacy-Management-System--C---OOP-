using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using pharmacay_managemnt_system.BL;
using pharmacay_managemnt_system.DL;

namespace pharmacay_managemnt_system
{
    public partial class SignUPMenu : Form
    {
        public SignUPMenu()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text.Trim();
            string roll = "admin";

            if (!(PersonCRUD.ValidateInput(email, password, roll)))
            {
                return;
            }
            Person p = new Admin(email, password, roll);
            PersonCRUD.storeInListPer(p);
            closeForm();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void clearData()
        {
            emailBox.Clear();
            passwordBox.Clear();
        }

        private void SignUPMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
