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
    public partial class FormShowInvoice : Form
    {
        private DataAccess Da { get; set; }

        private FormInvoice FInvoice { get; set; }

        public FormShowInvoice()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
            this.InvoiceID.ReadOnly = true;
        }

        public FormShowInvoice(FormInvoice finvoice, string info):this()
        {
            this.FInvoice = finvoice;
            this.lblUserName.Text = info;
        }

        private void PopulateGridView(string sql = "select * from PatientInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvInvoiceInfo.AutoGenerateColumns = false;
            this.dgvInvoiceInfo.DataSource = ds.Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (this.lblUserName.Text == "")
                {
                    FInvoice.Show();
                }
                else if (this.lblUserName.Text == "")
                {
                    FInvoice.Show();
                }
                else if (this.lblUserName.Text == "")
                {
                    FInvoice.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An Error has occured!" + exc.Message);
            }

        }
    

        private void FormShowInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Do you want to Close this App?");
            Application.Exit();
        }
    }
}
