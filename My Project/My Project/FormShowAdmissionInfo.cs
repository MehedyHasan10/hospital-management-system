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
    public partial class FormShowAdmissionInfo : Form
    {
        private DataAccess Da { get; set; }

        private FormAdmission Fa { get; set; }
        public FormShowAdmissionInfo()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            
            this.PopulateGridView();
        }


        public FormShowAdmissionInfo( FormAdmission fa, string info):this()
        {
            this.Fa = fa;
            this.lblUserName.Text = info;
        }

        private void PopulateGridView(string sql = "select * from PatientAdmission;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvShowAdInfo.AutoGenerateColumns = false;
            this.dgvShowAdInfo.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from PatientAdmission where RegID = '" + this.txtSearch.Text.ToLower() + "';";
                this.PopulateGridView(sql);

            }
                catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void dgvShowAdInfo_DoubleClick(object sender, EventArgs e)
        {
            
            this.Hide();
            FormAdmission fg = new FormAdmission();
            fg.Show();
            //Fa.txtRegID.Text = this.dgvShowAdInfo.CurrentRow.Cells["RegID"].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (this.lblUserName.Text == "")
                {
                    Fa.Show();
                }
                else if (this.lblUserName.Text == "")
                {
                    Fa.Show();
                }
                else if (this.lblUserName.Text == "")
                {
                    Fa.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured!" + exc.Message);
            }

        }

        private void FormShowAdmissionInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }
    }
}
