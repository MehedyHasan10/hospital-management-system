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
    public partial class FormEmployee_Management : Form
    {
        private DataAccess Da { get; set; }
        private FormDashboardAdmin FormAdmin5 { get; set; }
        public FormEmployee_Management()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
            this.AutoIdGenerate();
            this.txtID.ReadOnly = true;

        }

        public FormEmployee_Management(FormDashboardAdmin formAdmin5) : this()
        {
            this.FormAdmin5 = formAdmin5;
        }

       
        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();

        }

        private void PopulateGridView(string sql = "select * from EmployeeInfo;")
        {
            
            var ds = Da.ExecuteQuery(sql);

            this.dgvEmpInfo.AutoGenerateColumns = false;
            this.dgvEmpInfo.DataSource = ds.Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSaveData())
                {
                    MessageBox.Show("Unable to Save Data. Please Fill All The Information To Save Data Successfully!");
                    return;
                }


                var query = "select * from EmployeeInfo where EmpID = '" + this.txtID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {

                    var sql = @"update EmployeeInfo
                                set EmpName = '" + this.txtName.Text + @"',
                                Address = '" + this.txtAddress.Text + @"', 
                                Phone = '" + this.txtPhone.Text + @"',
                                Role = '" + this.cmbRole.Text + @"',
                                Username = '" + this.txtUsername.Text + @"',
                                Password = '" + this.txtPassword.Text + @"'
                                where EmpID = '" + this.txtID.Text + "'; ";

                    int count = this.Da.ExecuteUpdateQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Data updated successfully");
                        
                    }

                    else
                    {
                        MessageBox.Show("Data upgradation failed");
                    }
                    this.PopulateGridView();
                   
                }
                else
                {

                    var sql = @"insert into EmployeeInfo 
                             values('" + this.txtID.Text + "', '" + this.txtName.Text + "', '" + this.txtAddress.Text + "','" + this.txtPhone.Text + "', '" + this.cmbRole.Text + "', '" + this.txtUsername.Text + "', '" + this.txtPassword.Text + "');";

                    int count = this.Da.ExecuteUpdateQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Employee Added Successfully");
                    }

                    else
                    {
                        MessageBox.Show("Employee Added Unuccessfully!");
                    }
                }
                this.PopulateGridView();
                this.ClearContent();

            }
              
                catch (Exception exc)
                {
                    MessageBox.Show("An Error has occured!"+exc.Message);
                }
               
        }

        private bool IsValidToSaveData()
        {
            if (String.IsNullOrEmpty(this.txtID.Text) || String.IsNullOrEmpty(this.txtName.Text) ||
                String.IsNullOrEmpty(this.txtAddress.Text) || String.IsNullOrEmpty(this.txtPhone.Text) ||
                String.IsNullOrEmpty(this.cmbRole.Text) || String.IsNullOrEmpty(this.txtUsername.Text) ||
                String.IsNullOrEmpty(this.txtPassword.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void ClearContent()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtAddress.Clear();
            this.txtPhone.Clear();
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.cmbRole.SelectedIndex = -1;
            this.txtSearchID.Clear();

            this.AutoIdGenerate();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            this.ClearContent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.FormAdmin5.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var EmpId = this.dgvEmpInfo.CurrentRow.Cells[0].Value.ToString();
                var EmpName = this.dgvEmpInfo.CurrentRow.Cells[1].Value.ToString();
                var sql = @"delete from EmployeeInfo where EmpID = '" + EmpId + "';";
                int count = this.Da.ExecuteUpdateQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Employee Deleted Successfully");
                }

                else
                {
                    MessageBox.Show("Employee Deleted Unuccessfully!");
                }
                this.PopulateGridView();
                this.ClearContent();
            }

            catch(Exception exc)
            {
                MessageBox.Show("An Error has Occured"+ exc.Message);
            }
           

        }

        private void dgvEmpInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtID.Text = this.dgvEmpInfo.CurrentRow.Cells["EmpID"].Value.ToString();
                this.txtName.Text = this.dgvEmpInfo.CurrentRow.Cells["EmpName"].Value.ToString();
                this.txtAddress.Text = this.dgvEmpInfo.CurrentRow.Cells["Address"].Value.ToString();
                this.txtPhone.Text = this.dgvEmpInfo.CurrentRow.Cells["Phone"].Value.ToString();
                this.cmbRole.Text = this.dgvEmpInfo.CurrentRow.Cells["Role"].Value.ToString();
                this.txtUsername.Text = this.dgvEmpInfo.CurrentRow.Cells["Username"].Value.ToString();
                this.txtPassword.Text = this.dgvEmpInfo.CurrentRow.Cells["Password"].Value.ToString();

                this.txtID.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }


        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select * from EmployeeInfo order by EmpID desc;";
                DataTable dt = this.Da.ExecuteQueryTable(sql);
                var oldEmpID = dt.Rows[0][0].ToString();
                string[] temp = oldEmpID.Split('-');
                int i = Convert.ToInt32(temp[1]);
                i++;
                String newEmpID = "E-" + i.ToString("d3");
                this.txtID.Text = newEmpID;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from EmployeeInfo where EmpID = '" + this.txtSearchID.Text.ToLower() + "';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void FormEmployee_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void txtAuto_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtID.Text = this.dgvEmpInfo.CurrentRow.Cells["EmpID"].Value.ToString();
                this.txtName.Text = this.dgvEmpInfo.CurrentRow.Cells["EmpName"].Value.ToString();
                this.txtAddress.Text = this.dgvEmpInfo.CurrentRow.Cells["Address"].Value.ToString();
                this.txtPhone.Text = this.dgvEmpInfo.CurrentRow.Cells["Phone"].Value.ToString();
                this.cmbRole.Text = this.dgvEmpInfo.CurrentRow.Cells["Role"].Value.ToString();
                this.txtUsername.Text = this.dgvEmpInfo.CurrentRow.Cells["Username"].Value.ToString();
                this.txtPassword.Text = this.dgvEmpInfo.CurrentRow.Cells["Password"].Value.ToString();

                this.txtID.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }
    }
}
