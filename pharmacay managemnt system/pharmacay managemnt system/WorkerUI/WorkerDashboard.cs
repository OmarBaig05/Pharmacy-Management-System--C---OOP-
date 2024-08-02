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
    public partial class WorkerDashboard : Form
    {
        public WorkerDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakeOrderUI f = new TakeOrderUI();
            f.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PreviewOrderUI f = new PreviewOrderUI();
            f.Show();
            this.Close();
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

    }
}
