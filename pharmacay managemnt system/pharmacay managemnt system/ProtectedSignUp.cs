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
    public partial class ProtectedSignUp : Form
    {
        public ProtectedSignUp()
        {
            InitializeComponent();
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == "1234")
            {
                SignUPMenu signUPMenu = new SignUPMenu();
                signUPMenu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid Pin.", "Validity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProtectedSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
