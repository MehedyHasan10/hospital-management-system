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
    public partial class FormDashboardAdmin : Form
    {
        private FormLogin FormLogin1 { get; set; }
        public FormDashboardAdmin()
        {
            InitializeComponent();
        }


        public FormDashboardAdmin(FormLogin formLogin1, string info) : this()
        {
            this.FormLogin1 = formLogin1;
            this.lblNameInfo.Text = info;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Successful");
            FormLogin flogin = new FormLogin();
            flogin.Show();
        }

        private void FormCategoryAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s3;
            FormInvoice invoice = new FormInvoice(this, s3 = "Admin");
            invoice.Show();
        }

        private void btnIPD_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s4, sa;
            FormAdmission admission = new FormAdmission(this, s4 = "Admin", sa = "");
            admission.Show();
        }

        private void btnEmpManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEmployee_Management employee = new FormEmployee_Management(this);
            employee.Show();
        }

        private void btnExamAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s5, sa, ss;
            FormAddExam addexam = new FormAddExam(this, s5 = "Admin", sa = "", ss = "");
            addexam.Show();
        }

        private void btnMatManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s6, sa, ss, sd;
            FormMaterial_Management material = new FormMaterial_Management(this, s6 = "Admin", sa = "", ss = "", sd = "");
            material.Show();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s6, sa, ss, sd, sf;
            FormMedicineInfo medicicne = new FormMedicineInfo(this, s6 = "Admin", sa = "", ss = "", sd = "", sf = "");
            medicicne.Show();
        }
    }
}
