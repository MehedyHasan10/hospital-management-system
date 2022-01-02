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
    public partial class FormDashboardManager : Form
    {
        private FormLogin FormLogin2 { get; set; }
        public FormDashboardManager()
        {
            InitializeComponent();
        }

        public FormDashboardManager(FormLogin formLogin2, string info)
        {
            InitializeComponent();
            this.FormLogin2 = formLogin2;
            this.lblNameInfo.Text = info;
        }


        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Successful");
            this.FormLogin2.Show();
        }

        private void FormCategoryManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s;
            FormInvoice invoice = new FormInvoice(this,s = "Manager");
            invoice.Show();
        }

        private void btnIPD_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s4, sa;
            FormAdmission admission = new FormAdmission(this, s4 = "Manager", sa = "");
            admission.Show();
        }

        private void btnExamAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s5, sa, ss;
            FormAddExam addexam = new FormAddExam(this, s5 = "Manager", sa= "", ss = "");
            addexam.Show();
        }

        private void btnMatManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            string s6, sa, ss, sd;
            FormMaterial_Management material = new FormMaterial_Management(this, s6 = "Admin", sa = "", ss = "", sd = "");
            material.Show();
        }
    }
}
