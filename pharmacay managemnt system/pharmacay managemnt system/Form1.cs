using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using pharmacay_managemnt_system.DL;
using pharmacay_managemnt_system.WorkerUI;

namespace pharmacay_managemnt_system
{
    public partial class Form1 : Form
    {
        string mPath = "medicineData.txt";
        string sPath = "supplierData.txt";
        string cPath = "customerData.txt";
        string pPath = "personData.txt";

        private static bool checkDataisLoaded = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(!checkDataisLoaded)
            { 
                MedicineCRUD.RetriveDataFromFile(mPath);
                SupplierCRUD.RetriveDataFromFile(sPath);
                PersonCRUD.RetriveDataFromFile(pPath);
                CustomerCRUD.RetriveDataFromFile(cPath);
                checkDataisLoaded = true;
            }
        }
       
        private void SignInBtn_Click_1(object sender, EventArgs e)
        {
            SignInMenu fo = new SignInMenu();
            fo.Show();
            this.Hide();
        }
        private void SignUpBtn_Click_1(object sender, EventArgs e)
        {
            ProtectedSignUp a = new ProtectedSignUp();
            a.Show();
            this.Hide();
        }

        private void StoreDataBtn_Click(object sender, EventArgs e)
        {
            MedicineCRUD.storeDataInFile(mPath);
            SupplierCRUD.storeDataInFile(sPath);
            CustomerCRUD.storeDataInFile(cPath);
            PersonCRUD.storeDataInFile(pPath);
            StoreDataBtn.BackColor = Color.Green;
            MessageBox.Show("Data Stored", "Success", MessageBoxButtons.OK);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

