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
    public partial class FormAddExam : Form
    {

        private DataAccess Da { get; set; }

        private FormDashboardAdmin FormAdmin3 { get; set; }
        private FormDashboardManager FormManager3 { get; set; }
        public FormAddExam()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        public FormAddExam(FormDashboardAdmin formAdmin3, string info, string info2, string info3) : this()
        {
            this.FormAdmin3 = formAdmin3;
            this.lblUserName.Text = info.ToString();
        }

        public FormAddExam(FormDashboardManager formManager3, string info4, string info5, string info6) : this()
        {
            this.FormManager3 = formManager3;
            this.lblUserName.Text = info4.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.InsertData();
            this.PopulateGridView();
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

                var sql = @"insert into ExamInfo 
                                 values('" + this.txtItemID.Text + "', '" + this.txtItemName.Text + "',  '"
                                           + this.txtRate.Text + "');";

                int count = this.Da.ExecuteUpdateQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Test Item Added Successfully");
                }

                else
                {
                    MessageBox.Show("Test Item Adition Failed!");
                }

                this.ClearContent();
                this.PopulateGridView();

            }

            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured!" + exc.Message);
            }
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


                var query = "select * from ExamInfo where ItemID = '" + this.txtItemID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var sql = @"update ExamInfo
                                set ItemName = '" + this.txtItemName.Text + @"',
                                Rate = '" + this.txtRate.Text + @"' 
                                where ItemID = '" + this.txtItemID.Text + "'; ";


                    int count = this.Da.ExecuteUpdateQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Test Item Data updated successfully");

                    }

                    else
                    {
                        MessageBox.Show(" Test Item Data upgradation failed");
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
                String.IsNullOrEmpty(this.txtRate.Text))
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
            this.txtItemID.Clear();
            this.txtItemName.Clear();
            this.txtRate.Clear();

            this.AutoIdGenerate();
        }


        private void AutoIdGenerate()
        {
            var sql = "select * from ExamInfo order by ItemID desc;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            var ItemID = dt.Rows[0][0].ToString();
            string[] temp = ItemID.Split('-');
            int i = Convert.ToInt32(temp[1]);
            i++;
            String newItemID = "B-" + i.ToString("d4");
            this.txtItemID.Text = newItemID;

        }

        private void PopulateGridView(string sql = "select * from ExamInfo;")
        {

            var ds = Da.ExecuteQuery(sql);

            this.dgvExamInfo.AutoGenerateColumns = false;
            this.dgvExamInfo.DataSource = ds.Tables[0];
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (this.lblUserName.Text == "Admin")
            {
                FormAdmin3.Show();
            }
            else if (this.lblUserName.Text == "Manager")
            {
                FormManager3.Show();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateData();
            this.PopulateGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }


        private void FormAddExam_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            var sql = "select * from ExamInfo where ItemName like '" + this.txtAutoSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void dgvExamInfo_DoubleClick(object sender, EventArgs e)
        {
            this.txtItemID.Text = this.dgvExamInfo.CurrentRow.Cells["ItemID"].Value.ToString();
            this.txtItemName.Text = this.dgvExamInfo.CurrentRow.Cells["ItemName"].Value.ToString();
            this.txtRate.Text = this.dgvExamInfo.CurrentRow.Cells["ItemRate"].Value.ToString();

            this.txtItemID.ReadOnly = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var ItemId = this.dgvExamInfo.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvExamInfo.CurrentRow.Cells[1].Value.ToString();

                var sql = @"delete from ExamInfo where ItemName = '" + ItemName + "';";
                int count = this.Da.ExecuteUpdateQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show(name + " Deleted Successfully");
                }

                else
                {
                    MessageBox.Show(name + "Deletion Failed!");
                }
                this.PopulateGridView();
                this.ClearContent();
            }

            catch (Exception exc)
            {
                MessageBox.Show("An Error has Occured" + exc.Message);
            }
        }
    }   
}
