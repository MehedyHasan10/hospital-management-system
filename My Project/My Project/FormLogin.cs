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
    public partial class FormLogin : Form
    {
        private DataAccess Da { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "select * from EmployeeInfo where EmpID = '" + this.txtUserId.Text.ToLower() + "' and Password = '" + this.txtPassword.Text + "';";
                DataSet ds = Da.ExecuteQuery(sql);


                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.ClearContent();
                    this.Hide();
                    MessageBox.Show("Login Valid");
                    string name = ds.Tables[0].Rows[0][1].ToString();
                    if (ds.Tables[0].Rows[0][4].ToString() == "Admin")
                    {
                        FormDashboardAdmin dadmin = new FormDashboardAdmin(this, name);
                        dadmin.Show();
                    }
                    else if (ds.Tables[0].Rows[0][4].ToString() == "Manager")
                    {
                        FormDashboardManager dmanager = new FormDashboardManager(this, name);
                        dmanager.Show();
                    }
                    else if (ds.Tables[0].Rows[0][4].ToString() == "Receptionist")
                    {
                        FormDashboardReceptionist dreceptionist = new FormDashboardReceptionist(this, name);
                        dreceptionist.Show();
                    }
                    else if (ds.Tables[0].Rows[0][4].ToString() == "Pharmacist")
                    {
                        FormDashBoardPharmacist dpharmacist = new FormDashBoardPharmacist(this, name);
                        dpharmacist.Show();
                    }


                }
                else
                {
                    MessageBox.Show("Login Invalid!");
                    this.ClearContent();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
     }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearContent()
        {
            this.txtUserId.Clear();
            this.txtPassword.Clear();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }
    }
}
