using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Project
{
    public partial class FormDashboardReceptionist : Form
    {
        private FormLogin FormLogin3 {get; set;}
        public FormDashboardReceptionist()
        {
            InitializeComponent();
        }

        public FormDashboardReceptionist(FormLogin formLogin3, string info) : this()
        {
            this.FormLogin3 = formLogin3;
            this.lblNameInfo.Text = info;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Successful");
            this.FormLogin3.Show();
        }

        private void FormCategoryReceptionist_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s2;
            FormInvoice invoice = new FormInvoice(this, s2 = "Receptionist");
            invoice.Show();
            
        }

        private void btnIPD_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s3,sa;
            FormAdmission admission = new FormAdmission(this, s3 = "Receptionist", sa = "");
            admission.Show();
        }

        
    }
}
