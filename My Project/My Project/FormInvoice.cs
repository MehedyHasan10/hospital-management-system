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
    public partial class FormInvoice : Form
    {
        private DataAccess Da { get; set; }
        private FormDashboardAdmin FormAdmin2 { get; set; }
        private FormDashboardManager FormManager2 { get; set; }
        private FormDashboardReceptionist FormReceptionist2 { get; set; }
        
        public FormInvoice()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.DefaultValue();
            this.AutoIdGenerate();
            this.txtInvoiceID.ReadOnly = true;
        }

        public FormInvoice(FormDashboardAdmin formAdmin2, string info3) : this()
        {
            this.FormAdmin2 = formAdmin2;
            this.lblUserName.Text = info3.ToString();


        }

        public FormInvoice(FormDashboardManager formManager2, string info) : this()
        {
            this.FormManager2 = formManager2;
            this.lblUserName.Text = info.ToString();

        }

        public FormInvoice(FormDashboardReceptionist formReceptionist2, string info2) : this()
        {
            this.FormReceptionist2 = formReceptionist2;
            this.lblUserName.Text = info2.ToString();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (this.lblUserName.Text == "Admin")
                {
                    FormAdmin2.Show();
                }
                else if (this.lblUserName.Text == "Manager")
                {
                    FormManager2.Show();
                }
                else if (this.lblUserName.Text == "Receptionist")
                {
                    FormReceptionist2.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.InsertData();
            this.DefaultValue();


        }


        private void DefaultValue()
        {
            this.txtRate1.Text = "0";
            this.txtRate2.Text = "0";
            this.txtRate3.Text = "0";
            this.txtRate4.Text = "0";
            this.txtRate5.Text = "0";
            this.txtRate6.Text = "0";
            this.txtRate7.Text = "0";
            this.txtRate8.Text = "0";

            this.txtQuantity1.Text = "0";
            this.txtQuantity2.Text = "0";
            this.txtQuantity3.Text = "0";
            this.txtQuantity4.Text = "0";
            this.txtQuantity5.Text = "0";
            this.txtQuantity6.Text = "0";
            this.txtQuantity7.Text = "0";
            this.txtQuantity8.Text = "0";

            this.txtItemTotal1.Text = "0";
            this.txtItemTotal2.Text = "0";
            this.txtItemTotal3.Text = "0";
            this.txtItemTotal4.Text = "0";
            this.txtItemTotal5.Text = "0";
            this.txtItemTotal6.Text = "0";
            this.txtItemTotal7.Text = "0";
            this.txtItemTotal8.Text = "0";

            this.txtItemTotalBill.Text = "0";
            this.txtVAT.Text = "0";
            this.txtDiscount.Text = "0";
            this.txtTotalBill.Text = "0";
            this.txtPaidAmount.Text = "0";
            this.txtDueAmount.Text = "0";

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


                var sql = @"insert into PatientInfo 
                                 values('" + this.txtInvoiceID.Text + "', '" + this.txtPatientName.Text + "',  '"
                                           + this.txtAddress.Text + "','" + this.txtAge.Text + "','"
                                           + this.dtpDOB.Text + "',  '" + this.cmbGender.Text + "','" 
                                           + this.txtPhone.Text + "', '" + this.rbSelf.Text + "', '"+ this.dtpDelivery.Text + "' ,  '" 
                                           + this.txtItemTotalBill.Text + "','" + this.txtDiscount.Text + "', '" 
                                           + this.txtTotalBill.Text + "', '" + this.txtPaidAmount.Text + "', '" 
                                           + this.txtDueAmount.Text + "','" + this.lblPaymentStatus.Text + "');";


                int count = this.Da.ExecuteUpdateQuery(sql);
                if (count == 1)
                {
                    MessageBox.Show("Invoice Data Inserted Successfully");
                }

                else
                {
                    MessageBox.Show("Invoice Data Inserted Unsuccessfully!");
                }

                this.ClearContent();
                this.AutoIdGenerate();

            }

            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured! Please enter data correctly.");
            }
        }


        private bool IsValidToSaveData()
        {
            if (String.IsNullOrEmpty(this.txtInvoiceID.Text) ||
                String.IsNullOrEmpty(this.txtPatientName.Text) ||
                String.IsNullOrEmpty(this.txtAddress.Text) ||
                String.IsNullOrEmpty(this.txtAge.Text) || 
                String.IsNullOrEmpty(this.cmbGender.Text) ||
                String.IsNullOrEmpty(this.cmbMaritalStatus.Text) || 
                String.IsNullOrEmpty(this.txtPhone.Text) ||
                String.IsNullOrEmpty(this.dtpDelivery.Text) ||
                String.IsNullOrEmpty(this.cmbDeliveryStatus.Text) ||
                String.IsNullOrEmpty(this.txtItemID1.Text) ||
                String.IsNullOrEmpty(this.txtItemName1.Text) ||
                String.IsNullOrEmpty(this.txtRate1.Text) ||
                String.IsNullOrEmpty(this.txtQuantity1.Text))
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
            this.txtInvoiceID.Clear();
            this.txtPatientName.Clear();
            this.txtAddress.Clear();
            this.txtAge.Clear();
            this.cmbGender.SelectedIndex = -1;
            this.cmbMaritalStatus.SelectedIndex = -1;
            this.cmbBloodGroup.SelectedIndex = -1;
            this.txtPhone.Clear();
            this.rbSelf.Checked = false;
            this.rbDoctor.Checked = false;
            this.txtDoctorName.Clear();
            this.txtRemark.Clear();
            this.cmbDeliveryStatus.SelectedIndex = -1;
            this.txtItemID1.Clear();
            this.txtItemID2.Clear();
            this.txtItemID3.Clear();
            this.txtItemID4.Clear();
            this.txtItemID5.Clear();
            this.txtItemID6.Clear();
            this.txtItemID7.Clear();
            this.txtItemID8.Clear();
            this.txtItemName1.Clear();
            this.txtItemName2.Clear();
            this.txtItemName3.Clear();
            this.txtItemName4.Clear();
            this.txtItemName5.Clear();
            this.txtItemName6.Clear();
            this.txtItemName7.Clear();
            this.txtItemName8.Clear();
            this.txtRate1.Clear();
            this.txtRate2.Clear();
            this.txtRate3.Clear();
            this.txtRate4.Clear();
            this.txtRate5.Clear();
            this.txtRate6.Clear();
            this.txtRate7.Clear();
            this.txtRate8.Clear();
            this.txtQuantity1.Clear();
            this.txtQuantity2.Clear();
            this.txtQuantity3.Clear();
            this.txtQuantity4.Clear();
            this.txtQuantity5.Clear();
            this.txtQuantity6.Clear();
            this.txtQuantity7.Clear();
            this.txtQuantity8.Clear();

            this.txtItemTotal1.Clear();
            this.txtItemTotal2.Clear();
            this.txtItemTotal3.Clear();
            this.txtItemTotal4.Clear();
            this.txtItemTotal5.Clear();
            this.txtItemTotal6.Clear();
            this.txtItemTotal7.Clear();
            this.txtItemTotal8.Clear();

            this.txtItemTotalBill.Clear();
            this.txtVAT.Clear();
            this.txtDiscount.Clear();
            this.txtTotalBill.Clear();
            this.txtPaidAmount.Clear();
            this.txtDueAmount.Clear();

            this.AutoIdGenerate();
        }

        private void rbSelf_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDoctorName.ReadOnly = true;
        }

        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select * from PatientInfo order by InvoiceID desc;";
                DataTable dt = this.Da.ExecuteQueryTable(sql);
                var InvoiceID = dt.Rows[0][0].ToString();
                string[] temp = InvoiceID.Split('-');
                int i = Convert.ToInt32(temp[1]);
                i++;
                String newInvoiceID = "V-" + i.ToString("d4");
                this.txtInvoiceID.Text = newInvoiceID;

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
         
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            this.ClearContent();
            this.DefaultValue();
        }

       

        private void TotalCount()
        {
            try
            {
                var result = (Convert.ToDouble(this.txtRate1.Text) * Convert.ToDouble(this.txtQuantity1.Text));
                this.txtItemTotal1.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }


        private void TotalCount1()
        {
            try
            {
                var result1 = (Convert.ToDouble(this.txtRate2.Text) * Convert.ToDouble(this.txtQuantity2.Text));
                this.txtItemTotal2.Text = result1.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }

        private void TotalCount2()
        {
            try
            {
                var result2 = (Convert.ToDouble(this.txtRate3.Text) * Convert.ToDouble(this.txtQuantity3.Text));
                this.txtItemTotal3.Text = result2.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
           
        }

        private void TotalCount3()
        {
            try
            {
                var result3 = (Convert.ToDouble(this.txtRate4.Text) * Convert.ToDouble(this.txtQuantity4.Text));
                this.txtItemTotal4.Text = result3.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
           
        }

        private void TotalCount4()
        {
            try
            {
                var result4 = (Convert.ToDouble(this.txtRate5.Text) * Convert.ToDouble(this.txtQuantity5.Text));
                this.txtItemTotal5.Text = result4.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }

        private void TotalCount5()
        {
            try
            {
                var result5 = (Convert.ToDouble(this.txtRate6.Text) * Convert.ToDouble(this.txtQuantity6.Text));
                this.txtItemTotal6.Text = result5.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
           
        }

        private void TotalCount6()
        {
            try
            {
                var result6 = (Convert.ToDouble(this.txtRate7.Text) * Convert.ToDouble(this.txtQuantity7.Text));
                this.txtItemTotal7.Text = result6.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }

        private void TotalCount7()
        {
            try
            {
                var result7 = (Convert.ToDouble(this.txtRate8.Text) * Convert.ToDouble(this.txtQuantity8.Text));
                this.txtItemTotal8.Text = result7.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }

        private void TotalCount8()
        {
            try
            {
                var result8 = (Convert.ToDouble(this.txtItemTotal1.Text) + Convert.ToDouble(this.txtItemTotal2.Text) +
                               Convert.ToDouble(this.txtItemTotal3.Text) + Convert.ToDouble(this.txtItemTotal4.Text) + 
                               Convert.ToDouble(this.txtItemTotal5.Text) + Convert.ToDouble(this.txtItemTotal6.Text) + 
                               Convert.ToDouble(this.txtItemTotal7.Text) + Convert.ToDouble(this.txtItemTotal8.Text));

                this.txtItemTotalBill.Text = result8.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Rate and Quantity ");
            }
            
        }


        private void TotalBillCount()
        {
            try
            {
                var result9 = (((Convert.ToDouble(this.txtItemTotalBill.Text)) + (Convert.ToDouble(this.txtVAT.Text)) - (Convert.ToDouble(this.txtDiscount.Text))));
                this.txtTotalBill.Text = result9.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Bill, VAT and Discount ");
            }
            

           
        }

        private void TotalPaidBillCount()
        {
            try
            {
                var result10 = ((Convert.ToDouble(this.txtTotalBill.Text)) - (Convert.ToDouble(this.txtPaidAmount.Text)));
                this.txtDueAmount.Text = result10.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured! Please enter value of Paid Amount");
            }
            

            
        }

        private void txtItemTotal1_Click(object sender, EventArgs e)
        {
            this.txtItemTotal1.ReadOnly = true;
            this.TotalCount();
        }

        private void txtItemTotal2_Click(object sender, EventArgs e)
        {
            this.txtItemTotal2.ReadOnly = true;
            this.TotalCount1(); 
        }

        private void txtItemTotal3_Click(object sender, EventArgs e)
        {
            this.txtItemTotal3.ReadOnly = true;
            this.TotalCount2();
        }

        private void txtItemTotal4_Click(object sender, EventArgs e)
        {
            this.txtItemTotal4.ReadOnly = true;
            this.TotalCount3();
        }

        private void txtItemTotal5_Click(object sender, EventArgs e)
        {
            this.txtItemTotal5.ReadOnly = true;
            this.TotalCount4();
        }

        private void txtItemTotal6_Click(object sender, EventArgs e)
        {
            this.txtItemTotal6.ReadOnly = true;
            this.TotalCount5();
        }

        private void txtItemTotal7_Click(object sender, EventArgs e)
        {
            this.txtItemTotal7.ReadOnly = true;
            this.TotalCount6();
        }

        private void txtItemTotal8_Click(object sender, EventArgs e)
        {
            this.txtItemTotal8.ReadOnly = true;
            this.TotalCount7();
        }

        private void txtItemTotalBill_Click(object sender, EventArgs e)
        {
            this.txtItemTotalBill.ReadOnly = true;
            this.TotalCount8();
        }

        private void txtTotalBill_Click(object sender, EventArgs e)
        {
            this.txtTotalBill.ReadOnly = true;
            this.TotalBillCount();
        }

        private void txtDueAmount_Click(object sender, EventArgs e)
        {
            this.txtDueAmount.ReadOnly = true;
            this.TotalPaidBillCount();
            this.PaymentStatus();
        }

        private void PaymentStatus()
        {
            try
            {
                if (this.txtDueAmount.Text == "0")
                {
                    this.lblPaymentStatus.Text = "PAID";
                }
                else
                {
                    this.lblPaymentStatus.Text = "DUE";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }

        private void dgvTestName_DoubleClick(object sender, EventArgs e)
        {
            this.SearchTestName();
        }


        private void SearchTestName()
        {
            try
            {
                this.txtItemID1.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName1.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate1.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void PopulateGridView(string sql = "select * from ExamInfo;")
        {

            var ds = Da.ExecuteQuery(sql);

            this.dgvTestName.AutoGenerateColumns = false;
            this.dgvTestName.DataSource = ds.Tables[0];
        }

        private void txtItemName1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName1.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
   
        }

        private void txtItemName2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName2.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
   
        }

        private void txtItemName3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName3.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
   
        }

        private void txtItemName4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName4.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
    
        }

        private void txtItemName5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName5.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
      
        }

        private void txtItemName6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName6.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
    
        }

        private void txtItemName7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName7.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
         
        }

        private void txtItemName8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from ExamInfo where ItemName like '" + this.txtItemName8.Text + "%';";
                this.PopulateGridView(sql);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }

        private void txtItemName1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID1.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName1.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate1.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID1.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }

        private void txtItemName2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID2.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName2.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate2.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID2.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void txtItemName3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID3.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName3.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate3.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID3.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }

        private void txtItemName4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID4.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName4.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate4.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID4.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void txtItemName5_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID5.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName5.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate5.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID5.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }

        private void txtItemName6_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID6.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName6.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate6.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID6.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void txtItemName7_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID7.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName7.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate7.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID7.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
            
        }

        private void txtItemName8_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtItemID8.Text = this.dgvTestName.CurrentRow.Cells["ItemID"].Value.ToString();
                this.txtItemName8.Text = this.dgvTestName.CurrentRow.Cells["ItemName"].Value.ToString();
                this.txtRate8.Text = this.dgvTestName.CurrentRow.Cells["ItemRate"].Value.ToString();

                this.txtItemID8.ReadOnly = true;
                this.txtRate1.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
           
        }

        private void btnSaveShow_Click(object sender, EventArgs e)
        {
            this.InsertData();
            MessageBox.Show("Do you Want to Continue?");
            this.Hide();
            string s8;
            FormShowInvoice showinvoice = new FormShowInvoice(this, s8 = "");
            showinvoice.Show();
        }
    }
}
