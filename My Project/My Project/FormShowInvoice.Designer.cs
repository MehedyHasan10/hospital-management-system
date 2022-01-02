
namespace My_Project
{
    partial class FormShowInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvInvoiceInfo = new System.Windows.Forms.DataGridView();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genderr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefdBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discountt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 533);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvInvoiceInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 417);
            this.panel3.TabIndex = 1;
            // 
            // dgvInvoiceInfo
            // 
            this.dgvInvoiceInfo.AllowUserToAddRows = false;
            this.dgvInvoiceInfo.AllowUserToDeleteRows = false;
            this.dgvInvoiceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.PatientName,
            this.PatientAddress,
            this.PatientAge,
            this.DOB,
            this.Genderr,
            this.ContactNo,
            this.RefdBy,
            this.DeliveryDate,
            this.ItemTotal,
            this.Discountt,
            this.TotalBill,
            this.PaidAmount,
            this.DueAmount,
            this.PaymentStatus});
            this.dgvInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceInfo.Name = "dgvInvoiceInfo";
            this.dgvInvoiceInfo.ReadOnly = true;
            this.dgvInvoiceInfo.Size = new System.Drawing.Size(883, 417);
            this.dgvInvoiceInfo.TabIndex = 0;
            // 
            // InvoiceID
            // 
            this.InvoiceID.DataPropertyName = "InvoiceID";
            this.InvoiceID.HeaderText = "Invoice ID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Patient Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // PatientAddress
            // 
            this.PatientAddress.DataPropertyName = "Address";
            this.PatientAddress.HeaderText = "Address";
            this.PatientAddress.Name = "PatientAddress";
            this.PatientAddress.ReadOnly = true;
            // 
            // PatientAge
            // 
            this.PatientAge.DataPropertyName = "Age";
            this.PatientAge.HeaderText = "Age";
            this.PatientAge.Name = "PatientAge";
            this.PatientAge.ReadOnly = true;
            // 
            // DOB
            // 
            this.DOB.DataPropertyName = "DOB";
            this.DOB.HeaderText = "Date of Birth";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            // 
            // Genderr
            // 
            this.Genderr.DataPropertyName = "Gender";
            this.Genderr.HeaderText = "Gender";
            this.Genderr.Name = "Genderr";
            this.Genderr.ReadOnly = true;
            // 
            // ContactNo
            // 
            this.ContactNo.DataPropertyName = "ContactNo";
            this.ContactNo.HeaderText = "Phone";
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.ReadOnly = true;
            // 
            // RefdBy
            // 
            this.RefdBy.DataPropertyName = "RefdBy";
            this.RefdBy.HeaderText = "Refd. By";
            this.RefdBy.Name = "RefdBy";
            this.RefdBy.ReadOnly = true;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.DataPropertyName = "DeliveryDate";
            this.DeliveryDate.HeaderText = "Delivery Date";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.ReadOnly = true;
            // 
            // ItemTotal
            // 
            this.ItemTotal.DataPropertyName = "ItemTotal";
            this.ItemTotal.HeaderText = "Item Total";
            this.ItemTotal.Name = "ItemTotal";
            this.ItemTotal.ReadOnly = true;
            // 
            // Discountt
            // 
            this.Discountt.DataPropertyName = "Discount";
            this.Discountt.HeaderText = "Discount";
            this.Discountt.Name = "Discountt";
            this.Discountt.ReadOnly = true;
            // 
            // TotalBill
            // 
            this.TotalBill.DataPropertyName = "TotalBill";
            this.TotalBill.HeaderText = "Total Bill";
            this.TotalBill.Name = "TotalBill";
            this.TotalBill.ReadOnly = true;
            // 
            // PaidAmount
            // 
            this.PaidAmount.DataPropertyName = "PaidAmount";
            this.PaidAmount.HeaderText = "Paid Amount";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.ReadOnly = true;
            // 
            // DueAmount
            // 
            this.DueAmount.DataPropertyName = "DueAmount";
            this.DueAmount.HeaderText = "Due Amount";
            this.DueAmount.Name = "DueAmount";
            this.DueAmount.ReadOnly = true;
            // 
            // PaymentStatus
            // 
            this.PaymentStatus.DataPropertyName = "PaymentStatus";
            this.PaymentStatus.HeaderText = "Payment Status";
            this.PaymentStatus.Name = "PaymentStatus";
            this.PaymentStatus.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 114);
            this.panel2.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(807, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(35, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Name";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(769, 27);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(32, 13);
            this.label30.TabIndex = 6;
            this.label30.Text = "User:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Azure;
            this.btnBack.Location = new System.Drawing.Point(761, 74);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(81, 27);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<<Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::My_Project.Properties.Resources.Screenshot__242_;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(23, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(471, 55);
            this.panel5.TabIndex = 8;
            // 
            // FormShowInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 533);
            this.Controls.Add(this.panel1);
            this.Name = "FormShowInvoice";
            this.Text = "FormShowInvoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormShowInvoice_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvInvoiceInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genderr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefdBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discountt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentStatus;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel5;
    }
}