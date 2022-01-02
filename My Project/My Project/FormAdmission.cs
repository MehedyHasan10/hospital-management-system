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
    public partial class FormAdmission : Form
    {
        private DataAccess Da { get; set; }
        private FormDashboardAdmin FormAdmin1 { get; set; }
        private FormDashboardManager FormManager1 { get; set; }
        private FormDashboardReceptionist FormReception1 { get; set; }

       
        public FormAdmission()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.DefaultValue();
            this.AutoIdGenerate();
            this.txtRegID.ReadOnly = true;
            this.txtTotalAmount.ReadOnly = true;

        }

        public FormAdmission(FormDashboardAdmin formAdmin1, string info, string info1) : this()
        {
            this.FormAdmin1 = formAdmin1;
            this.lblUserName.Text = info.ToString();
        }

        public FormAdmission(FormDashboardManager formManager1, string info2, string info3) : this()
        {
            this.FormManager1 = formManager1;
            this.lblUserName.Text = info2.ToString();
        }

        public FormAdmission(FormDashboardReceptionist formReception1, string info4, string info5) : this()
        {
            this.FormReception1 = formReception1;
            this.lblUserName.Text = info4.ToString();
        }

        private void PopulateGridView(string sql = "select * from PatientAdmission;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvAdmissionInfo.AutoGenerateColumns = false;
            this.dgvAdmissionInfo.DataSource = ds.Tables[0];
        }

        private void DefaultValue()
        {
            this.txtRegFee.Text = "0";
            this.txtAdmFee.Text = "0";
            this.txtTotalAmount.Text = "0";
            this.txtPaidAmount.Text = "0";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (this.lblUserName.Text == "Admin")
                {
                    FormAdmin1.Show();
                }
                else if (this.lblUserName.Text == "Manager")
                {
                    FormManager1.Show();
                }
                else if (this.lblUserName.Text == "Receptionist")
                {
                    FormReception1.Show();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("An Error has occured!" + exc.Message);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            this.InsertData();
            this.DefaultValue();
        }


        private void TotalCount()
        {
            try
            {
                var result = (Convert.ToDouble(this.txtRegFee.Text) + Convert.ToDouble(this.txtAdmFee.Text));
                this.txtTotalAmount.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Reg.Fee and Adm.Fee" + exc.Message);
            }
            
        }


        private bool IsValidToSaveData()
        {
            if (String.IsNullOrEmpty(this.txtRegID.Text) || String.IsNullOrEmpty(this.txtName.Text) ||
                    String.IsNullOrEmpty(this.txtAge.Text) || String.IsNullOrEmpty(this.dtpDOB.Text) ||
                    String.IsNullOrEmpty(this.cmbGender.Text) ||
                    String.IsNullOrEmpty(this.cmbMaritalStatus.Text) || String.IsNullOrEmpty(this.txtOccupation.Text) ||
                    String.IsNullOrEmpty(this.txtFatherName.Text) || String.IsNullOrEmpty(this.txtMotherName.Text) ||
                    String.IsNullOrEmpty(this.txtNid.Text) ||
                    String.IsNullOrEmpty(this.txtPhone.Text) ||
                    String.IsNullOrEmpty(this.txtAddress.Text) ||
                    String.IsNullOrEmpty(this.txtRefdBy.Text) ||
                    String.IsNullOrEmpty(this.txtDutyDoctor.Text) ||
                    String.IsNullOrEmpty(this.cmbBedName.Text) ||
                    String.IsNullOrEmpty(this.txtBedId.Text) ||
                    String.IsNullOrEmpty(this.txtTotalAmount.Text) ||
                    String.IsNullOrEmpty(this.txtPaidAmount.Text))
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
                this.txtRegID.Clear();
                this.txtName.Clear();
                this.txtAge.Clear();
                this.cmbBloodGroup.SelectedIndex = -1;
                this.cmbGender.SelectedIndex = -1;
                this.cmbMaritalStatus.SelectedIndex = -1;
                this.txtOccupation.Clear();
                this.txtFatherName.Clear();
                this.txtMotherName.Clear();
                this.txtNid.Clear();
                this.txtPhone.Clear();
                this.txtAddress.Clear();
                this.txtRefdBy.Clear();
                this.txtDutyDoctor.Clear();
                this.cmbBedName.SelectedIndex = -1;
                this.txtBedId.Clear();
                this.txtTotalAmount.Clear();
                this.txtPaidAmount.Clear();

                this.AutoIdGenerate();
            }

            

            private void btnNew_Click(object sender, EventArgs e)
            {
                this.ClearContent();
                this.DefaultValue();
        }


            private void AutoIdGenerate()
            {
                try
                {
                    var sql = "select * from PatientAdmission order by RegID desc;";
                    DataTable dt = this.Da.ExecuteQueryTable(sql);
                    var oldRegID = dt.Rows[0][0].ToString();
                    string[] temp = oldRegID.Split('-');
                    int i = Convert.ToInt32(temp[1]);
                    i++;
                    String newRegID = "R-" + i.ToString("d3");
                    this.txtRegID.Text = newRegID;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occured: " + exc.Message);
                }
            

            }


            private void FormAdmission_FormClosed(object sender, FormClosedEventArgs e)
            {
                MessageBox.Show("Do you want to Close this App?");
                Application.Exit();
            }


            private void InsertData()
            {
                try
                {
                    if (!this.IsValidToSaveData())
                    {
                        MessageBox.Show("Unable to Save Data. Please Fill All The Information To Save Data Successfully!");
                        return;
                    }

                        var sql = @"insert into PatientAdmission 
                                 values('" + this.txtRegID.Text + "', '" + this.txtName.Text + "', '" + this.txtAge.Text + "','"
                                 + this.dtpDOB.Text + "', '" + this.cmbBloodGroup.Text + "', '" + this.cmbGender.Text + "', '"
                                 + this.cmbMaritalStatus.Text + "', '" + this.txtOccupation.Text + "', '" + this.txtFatherName.Text + "', '"
                                 + this.txtMotherName.Text + "','" + this.txtNid.Text + "','" + this.txtPhone.Text + "', '"
                                 + this.txtAddress.Text + "', '" + this.txtRefdBy.Text + "', '" + this.txtDutyDoctor.Text + "','"
                                 + this.cmbBedName.Text + "', '" + this.txtBedId.Text + "', '" + this.txtTotalAmount.Text + "', '"
                                 + this.txtPaidAmount.Text + "');";


                        int count = this.Da.ExecuteUpdateQuery(sql);
                        if (count == 1)
                        {
                            MessageBox.Show("Patient Admission Completed");
                        }

                        else
                        {
                            MessageBox.Show("Patient Admission Failed!");
                        }

                        this.ClearContent();

            }

                catch (Exception exc)
                {
                    MessageBox.Show("An Error has occured! Please enter the info. correctly" + exc.Message);
                }
            }



            private void btnSaveShow_Click(object sender, EventArgs e)
            {

                this.InsertData();
                this.ClearContent();
                MessageBox.Show("Do you Want to Continue?");
                this.Hide();
                string s7;
                FormShowAdmissionInfo showadmission = new FormShowAdmissionInfo(this, s7 = "");
                showadmission.Show();
     
            }


        private void btnClear1_Click(object sender, EventArgs e)
        {
            this.txtRefdBy.Clear();
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            this.txtDutyDoctor.Clear();
        }

        private void txtTotalAmount_Click(object sender, EventArgs e)
        {

            this.TotalCount();
            this.txtTotalAmount.ReadOnly = true;
        }

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from PatientAdmission where RegID like '" + this.txtAutoSearch.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateData();
        }
            private void UpdateData()
            {
                try
                {
                    if (!this.IsValidToSaveData())
                    {
                        MessageBox.Show("Unable to Save Data. Please Fill All The Information To Save Data Successfully!");
                        return;
                    }


                    var query = "select * from PatientAdmission where RegID = '" + this.txtRegID.Text + "';";
                    var ds = this.Da.ExecuteQuery(query);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        var sql = @"update ExamInfo
                                set RegName = '" + this.txtName.Text + @"',
                                Age = '" + this.txtAge.Text + @"',
                                DOB = '" + this.dtpDOB.Text + @"',
                                BloodGroup = '" + this.cmbBloodGroup.Text + @"',
                                Gender = '" + this.cmbGender.Text + @"',
                                MaritalStatus = '" + this.cmbMaritalStatus.Text + @"',
                                Occupation = '" + this.txtOccupation.Text + @"',
                                FatherName = '" + this.txtFatherName.Text + @"',
                                MotherName = '" + this.txtMotherName.Text + @"',
                                NID = '" + this.txtNid.Text + @"',
                                Phone = '" + this.txtPhone.Text + @"',
                                Address = '" + this.txtAddress.Text + @"',
                                RefdDoctor = '" + this.txtRefdBy.Text + @"',
                                DutyDoctor = '" + this.txtDutyDoctor.Text + @"',
                                BedName = '" + this.cmbBedName.Text + @"',
                                BedId = '" + this.txtBedId.Text + @"',
                                TotalAmount = '" + this.txtTotalAmount.Text + @"',
                                PaidAmount = '" + this.txtPaidAmount.Text + @"'
                                where RegID = '" + this.txtRegID.Text + "'; ";


                        int count = this.Da.ExecuteUpdateQuery(sql);

                        if (count == 1)
                        {
                            MessageBox.Show("Patient Data updated successfully");

                        }

                        else
                        {
                            MessageBox.Show(" Patient Data upgradation failed");
                        }

                    }
                    this.ClearContent();
                    this.PopulateGridView();

                }

                catch (Exception exc)
                {
                    MessageBox.Show("An Error has occured!" + exc.Message);
                }

            }

        private void dgvAdmissionInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtRegID.Text = this.dgvAdmissionInfo.CurrentRow.Cells["RegID"].Value.ToString();
                this.txtName.Text = this.dgvAdmissionInfo.CurrentRow.Cells["RegName"].Value.ToString();
                this.txtAge.Text = this.dgvAdmissionInfo.CurrentRow.Cells["PAge"].Value.ToString();
                this.dtpDOB.Text = this.dgvAdmissionInfo.CurrentRow.Cells["DOB"].Value.ToString();
                this.cmbBloodGroup.Text = this.dgvAdmissionInfo.CurrentRow.Cells["BloodGroup"].Value.ToString();
                this.cmbGender.Text = this.dgvAdmissionInfo.CurrentRow.Cells["Genderr"].Value.ToString();
                this.cmbMaritalStatus.Text = this.dgvAdmissionInfo.CurrentRow.Cells["MaritalStatus"].Value.ToString();
                this.txtOccupation.Text = this.dgvAdmissionInfo.CurrentRow.Cells["Occupationn"].Value.ToString();
                this.txtFatherName.Text = this.dgvAdmissionInfo.CurrentRow.Cells["FatherName"].Value.ToString();
                this.txtMotherName.Text = this.dgvAdmissionInfo.CurrentRow.Cells["MotherName"].Value.ToString();
                this.txtNid.Text = this.dgvAdmissionInfo.CurrentRow.Cells["NIDD"].Value.ToString();
                this.txtPhone.Text = this.dgvAdmissionInfo.CurrentRow.Cells["Contact"].Value.ToString();
                this.txtAddress.Text = this.dgvAdmissionInfo.CurrentRow.Cells["newAddress"].Value.ToString();
                this.txtRefdBy.Text = this.dgvAdmissionInfo.CurrentRow.Cells["RefdDoctor"].Value.ToString();
                this.txtDutyDoctor.Text = this.dgvAdmissionInfo.CurrentRow.Cells["DutyDoctor"].Value.ToString();
                this.cmbBedName.Text = this.dgvAdmissionInfo.CurrentRow.Cells["BedName"].Value.ToString();
                this.txtBedId.Text = this.dgvAdmissionInfo.CurrentRow.Cells["BedId"].Value.ToString();
                this.txtTotalAmount.Text = this.dgvAdmissionInfo.CurrentRow.Cells["TotalAmount"].Value.ToString();
                this.txtPaidAmount.Text = this.dgvAdmissionInfo.CurrentRow.Cells["PaidAmount"].Value.ToString();

                this.txtRegID.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }
    }
}   
