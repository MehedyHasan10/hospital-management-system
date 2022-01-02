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
    public partial class FormMaterial_Management : Form
    {
        private DataAccess Da { get; set; }

        private FormDashboardAdmin FormAdmin4 { get; set; }
        private FormDashboardManager FormManager4 { get; set; }
        public FormMaterial_Management()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.DefaultValue();
            this.PopulateGridView();
            this.AutoIdGenerate();
            this.txtItemID.ReadOnly = true;

            

        }

        public FormMaterial_Management(FormDashboardAdmin formAdmin4, string info, string info2, string info3, string info4) : this()
        {
            this.FormAdmin4 = formAdmin4;
            this.lblUserName.Text = info.ToString();
        }

        public FormMaterial_Management(FormDashboardManager formManager4, string info5, string info6, string info7, string info8) : this()
        {
            this.FormManager4 = formManager4;
            this.lblUserName.Text = info5.ToString();
        }

        private void PopulateGridView(string sql = "select * from Material;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvMaterial.AutoGenerateColumns = false;
            this.dgvMaterial.DataSource = ds.Tables[0];
        }

        private void DefaultValue()
        {
            this.txtStock.Text = "0";
            this.txtPrice.Text = "0";
            this.txtTotalPrice.Text = "0";
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

                var sql = @"insert into Material 
                values('" + this.txtItemID.Text + "', '" + this.txtItemName.Text + "', '" + this.txtDescription.Text + "','" + this.txtStock.Text + "', '" + this.txtPrice.Text + "', '" + this.txtTotalPrice.Text + "');";

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
                MessageBox.Show("An Error has occured! Please enter data correctly." + exc.Message);
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


                var query = "select * from Material where ItemID = '" + this.txtItemID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var sql = @"update Material
                                set ItemName = '" + this.txtItemName.Text + @"',
                                ItemDescription = '" + this.txtDescription.Text + @"', 
                                QtyInStock = '" + this.txtStock.Text + @"',
                                Price = '" + this.txtPrice.Text + @"',
                                TotalPrice = '" + this.txtTotalPrice.Text + @"' 
                                where ItemID = '" + this.txtItemID.Text + "'; ";


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
            if (String.IsNullOrEmpty(this.txtItemID.Text) || String.IsNullOrEmpty(this.txtItemName.Text) ||
                String.IsNullOrEmpty(this.txtStock.Text) ||
                String.IsNullOrEmpty(this.txtPrice.Text) ||
                String.IsNullOrEmpty(this.txtTotalPrice.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            this.InsertData();
            this.DefaultValue();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateData();
            this.DefaultValue();
        }

        private void btnShowInfo_Click_1(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void TotalCount()
        {
            try
            {
                var result = ((Convert.ToDouble(this.txtStock.Text)) * (Convert.ToDouble(this.txtPrice.Text)));
                this.txtTotalPrice.Text = result.ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Quantity and Price ");
            }
       
        }

        private void txtTotalPrice_Click(object sender, EventArgs e)
        {
            this.TotalCount();
            this.txtTotalPrice.ReadOnly = true;
        }

        private void ClearContent()
        {
            this.txtItemID.Clear();
            this.txtItemName.Clear();
            this.txtDescription.Clear();
            this.txtStock.Clear();
            this.txtPrice.Clear();
            this.txtTotalPrice.Clear();

            this.AutoIdGenerate();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            this.ClearContent();
            this.DefaultValue();
        }

        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select * from Material order by ItemID desc;";
                DataTable dt = this.Da.ExecuteQueryTable(sql);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                int i = Convert.ToInt32(temp[1]);
                i++;
                string newId = "Item-" + i.ToString("d4");
                this.txtItemID.Text = newId;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from Material where ItemName = '" + this.txtAutoSearch.Text.ToLower() + "';";
                this.PopulateGridView(sql);

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                if (this.lblUserName.Text == "Admin")
                {
                    FormDashboardAdmin foemadmin = new FormDashboardAdmin();
                    foemadmin.Show();
                }
                else if (this.lblUserName.Text == "Manager")
                {
                    FormManager4.Show();
                }

            }

            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured!" + exc.Message);
            }
        }

        private void FormMaterial_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void dgvMaterial_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID.Text = this.dgvMaterial.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName.Text = this.dgvMaterial.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtDescription.Text = this.dgvMaterial.CurrentRow.Cells["ItemDescription"].Value.ToString();
                this.txtStock.Text = this.dgvMaterial.CurrentRow.Cells["Stock"].Value.ToString();
                this.txtPrice.Text = this.dgvMaterial.CurrentRow.Cells["ItemPrice"].Value.ToString();
                this.txtTotalPrice.Text = this.dgvMaterial.CurrentRow.Cells["TotalPrice"].Value.ToString();

                this.txtItemID.ReadOnly = true;
                this.txtTotalPrice.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var ItemID = this.dgvMaterial.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvMaterial.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from Material where ItemID = '" + ItemID + "';";
                int count = this.Da.ExecuteUpdateQuery(sql);

                if (count == 1)
                    MessageBox.Show(name + " has been deleted successfully");
                else
                    MessageBox.Show(name + "Deletion failed");

                this.PopulateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter the data correctly. " + exc.Message);
            }
        }
    }
}
