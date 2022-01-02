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
    public partial class FormDashBoardPharmacist : Form
    {
        private FormLogin FormLogin4 { get; set; }
        public FormDashBoardPharmacist()
        {
            InitializeComponent();
        }
        public FormDashBoardPharmacist(FormLogin formLogin4, string info4) : this()
        {
            this.FormLogin4 = formLogin4;
            this.lblNameInfo.Text = info4;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Successful");
            this.FormLogin4.Show();
        }

        private void btnMedicine_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            string s6;
            FormMedicineInfo medicine = new FormMedicineInfo(this, s6 = "Pharmacist");
            medicine.Show();
        }
    }
}
