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
    public partial class FormMedicineInfo : Form
    {
        private DataAccess Da { get; set; }

        private FormDashboardAdmin FormAdmin5 { get; set; }
        private FormDashBoardPharmacist FormPharmacist1 { get; set; }
        public FormMedicineInfo()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.AutoIdGenerate();
            this.DefaultValue();
            this.txtMedicineID.ReadOnly = true;
        }


        public FormMedicineInfo(FormDashboardAdmin formAdmin5, string info, string info2, string info3, string info4, string info5 ) :this()
        {
            this.FormAdmin5 = formAdmin5;
            this.lblUserName.Text = info.ToString();
        }

        public FormMedicineInfo(FormDashBoardPharmacist formPharmacist1, string info) : this()
        {
            this.FormPharmacist1 = formPharmacist1;
            this.lblUserName.Text = info.ToString();
        }

        private void PopulateGridView(string sql = "select * from MedicineInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvMedicine.AutoGenerateColumns = false;
            this.dgvMedicine.DataSource = ds.Tables[0];
        }

        private void DefaultValue()
        {
            this.txtQuantityInStock.Text = "0";
            this.txtMedicinePrice.Text = "0";
            this.txtMedicineTotalPrice.Text = "0";
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

                var sql = @"insert into MedicineInfo
                values('" + this.txtMedicineID.Text + "', '" + this.txtMedicineName.Text + "', '" 
                          + this.txtMedicineDescription.Text + "','" + this.txtQuantityInStock.Text + "', '" 
                          + this.txtMedicinePrice.Text + "', '" + this.txtMedicineTotalPrice.Text + "');";

                int count = this.Da.ExecuteUpdateQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Item Added Successfully in Stock");
                }

                else
                {
                    MessageBox.Show("Item not Added in Stock!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured! Please enter data correctly.");
            }
            this.ClearContent();
            this.PopulateGridView();
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


                var query = "select * from MedicineInfo where MedicineID = '" + this.txtMedicineID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var sql = @"update MedicineInfo
                                set MedicineName = '" + this.txtMedicineName.Text + @"',
                                MedicineDescription = '" + this.txtMedicineDescription.Text + @"', 
                                QuantityInStock = '" + this.txtQuantityInStock.Text + @"',
                                Price = '" + this.txtMedicinePrice.Text + @"',
                                TotalPrice = '" + this.txtMedicineTotalPrice.Text + @"' 
                                where MedicineID = '" + this.txtMedicineID.Text + "'; ";


                    int count = this.Da.ExecuteUpdateQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Item Data updated successfully");

                    }

                    else
                    {
                        MessageBox.Show("Item Data upgradation failed");
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

        private bool IsValidToSaveData()
        {
            if (String.IsNullOrEmpty(this.txtMedicineID.Text) || String.IsNullOrEmpty(this.txtMedicineName.Text) ||
                String.IsNullOrEmpty(this.txtQuantityInStock.Text) ||
                String.IsNullOrEmpty(this.txtMedicinePrice.Text) ||
                String.IsNullOrEmpty(this.txtMedicineTotalPrice.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void TotalCount()
        {
            try
            {
                var result = ((Convert.ToDouble(this.txtQuantityInStock.Text)) * (Convert.ToDouble(this.txtMedicinePrice.Text)));
                this.txtMedicineTotalPrice.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Quantity and Price : " + exc.Message);
            }

        }

        

        private void ClearContent()
        {
            this.txtMedicineID.Clear();
            this.txtMedicineName.Clear();
            this.txtMedicineDescription.Clear();
            this.txtQuantityInStock.Clear();
            this.txtMedicinePrice.Clear();
            this.txtMedicineTotalPrice.Clear();

            this.AutoIdGenerate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.InsertData();
            this.DefaultValue();
        }


        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select * from MedicineInfo order by MedicineID desc;";
                DataTable dt = this.Da.ExecuteQueryTable(sql);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                int i = Convert.ToInt32(temp[1]);
                i++;
                string newId = "MI-" + i.ToString("d4");
                this.txtMedicineID.Text = newId;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateData();
            this.DefaultValue();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
            this.AutoIdGenerate();
            this.DefaultValue();
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from MedicineInfo where MedicineName = '" + this.txtAutoSearch.Text.ToLower() + "';";
                this.PopulateGridView(sql);

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter Test name correctly. ");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                if (this.lblUserName.Text == "Admin")
                {
                    FormDashboardAdmin formadmin = new FormDashboardAdmin();
                    formadmin.Show();
                }
                else if (this.lblUserName.Text == "Pharmacist")
                {
                    FormPharmacist1.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void txtMedicineTotalPrice_Click(object sender, EventArgs e)
        {
            this.TotalCount();
            this.txtMedicineTotalPrice.ReadOnly = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var MedicineID = this.dgvMedicine.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvMedicine.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from MedicineInfo where MedicineID = '" + MedicineID + "';";
                int count = this.Da.ExecuteUpdateQuery(sql);

                if (count == 1)
                    MessageBox.Show(name + " has been deleted successfully");
                else
                    MessageBox.Show("Data deletion failed");

                this.PopulateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void dgvMedicine_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtMedicineID.Text = this.dgvMedicine.CurrentRow.Cells["MedicineID"].Value.ToString();
                this.txtMedicineName.Text = this.dgvMedicine.CurrentRow.Cells["MedicineName"].Value.ToString();
                this.txtMedicineDescription.Text = this.dgvMedicine.CurrentRow.Cells["MedicineDescription"].Value.ToString();
                this.txtQuantityInStock.Text = this.dgvMedicine.CurrentRow.Cells["QuantityInStock"].Value.ToString();
                this.txtMedicinePrice.Text = this.dgvMedicine.CurrentRow.Cells["MedicinePrice"].Value.ToString();
                this.txtMedicineTotalPrice.Text = this.dgvMedicine.CurrentRow.Cells["MedicineTotalPrice"].Value.ToString();

                this.txtMedicineID.ReadOnly = true;
                this.txtMedicineTotalPrice.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void FormMedicineInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }
    }
}
