
namespace My_Project
{
    partial class FormShowAdmissionInfo
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
            this.dgvShowAdInfo = new System.Windows.Forms.DataGridView();
            this.RegID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Occupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefdDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DutyDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAdInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvShowAdInfo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 618);
            this.panel1.TabIndex = 0;
            // 
            // dgvShowAdInfo
            // 
            this.dgvShowAdInfo.AllowUserToAddRows = false;
            this.dgvShowAdInfo.AllowUserToDeleteRows = false;
            this.dgvShowAdInfo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvShowAdInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowAdInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegID,
            this.RegName,
            this.Age,
            this.DOB,
            this.BloodGroup,
            this.Gender,
            this.MaritalStatus,
            this.Occupation,
            this.FatherName,
            this.MotherName,
            this.NID,
            this.Phone,
            this.Address,
            this.RefdDoctor,
            this.DutyDoctor,
            this.BedName,
            this.BedId,
            this.TotalAmount,
            this.PaidAmount});
            this.dgvShowAdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowAdInfo.Location = new System.Drawing.Point(0, 100);
            this.dgvShowAdInfo.Name = "dgvShowAdInfo";
            this.dgvShowAdInfo.ReadOnly = true;
            this.dgvShowAdInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowAdInfo.Size = new System.Drawing.Size(922, 518);
            this.dgvShowAdInfo.TabIndex = 2;
            this.dgvShowAdInfo.DoubleClick += new System.EventHandler(this.dgvShowAdInfo_DoubleClick);
            // 
            // RegID
            // 
            this.RegID.DataPropertyName = "RegID";
            this.RegID.HeaderText = "Reg. ID";
            this.RegID.Name = "RegID";
            this.RegID.ReadOnly = true;
            // 
            // RegName
            // 
            this.RegName.DataPropertyName = "RegName";
            this.RegName.HeaderText = "Patient Name";
            this.RegName.Name = "RegName";
            this.RegName.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // DOB
            // 
            this.DOB.DataPropertyName = "DOB";
            this.DOB.HeaderText = "Date Of Birth";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            // 
            // BloodGroup
            // 
            this.BloodGroup.DataPropertyName = "BloodGroup";
            this.BloodGroup.HeaderText = "Blood Group";
            this.BloodGroup.Name = "BloodGroup";
            this.BloodGroup.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // MaritalStatus
            // 
            this.MaritalStatus.DataPropertyName = "MaritalStatus";
            this.MaritalStatus.HeaderText = "Marital Status";
            this.MaritalStatus.Name = "MaritalStatus";
            this.MaritalStatus.ReadOnly = true;
            // 
            // Occupation
            // 
            this.Occupation.DataPropertyName = "Occupation";
            this.Occupation.HeaderText = "Occupation";
            this.Occupation.Name = "Occupation";
            this.Occupation.ReadOnly = true;
            // 
            // FatherName
            // 
            this.FatherName.DataPropertyName = "FatherName";
            this.FatherName.HeaderText = "Father\'s Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            // 
            // MotherName
            // 
            this.MotherName.DataPropertyName = "MotherName";
            this.MotherName.HeaderText = "Mother\'s Name";
            this.MotherName.Name = "MotherName";
            this.MotherName.ReadOnly = true;
            // 
            // NID
            // 
            this.NID.DataPropertyName = "NID";
            this.NID.HeaderText = "NID";
            this.NID.Name = "NID";
            this.NID.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // RefdDoctor
            // 
            this.RefdDoctor.DataPropertyName = "RefdDoctor";
            this.RefdDoctor.HeaderText = "Refd. By";
            this.RefdDoctor.Name = "RefdDoctor";
            this.RefdDoctor.ReadOnly = true;
            // 
            // DutyDoctor
            // 
            this.DutyDoctor.DataPropertyName = "DutyDoctor";
            this.DutyDoctor.HeaderText = "Duty Doctor";
            this.DutyDoctor.Name = "DutyDoctor";
            this.DutyDoctor.ReadOnly = true;
            // 
            // BedName
            // 
            this.BedName.DataPropertyName = "BedName";
            this.BedName.HeaderText = "Bed Name";
            this.BedName.Name = "BedName";
            this.BedName.ReadOnly = true;
            // 
            // BedId
            // 
            this.BedId.DataPropertyName = "BedId";
            this.BedId.HeaderText = "Bed ID";
            this.BedId.Name = "BedId";
            this.BedId.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // PaidAmount
            // 
            this.PaidAmount.DataPropertyName = "PaidAmount";
            this.PaidAmount.HeaderText = "Paid Amount";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 100);
            this.panel2.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(823, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(45, 16);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(777, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 16);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "User:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(704, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search (ID)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(543, 62);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lab One Hospital Ltd.";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnBack.Location = new System.Drawing.Point(804, 59);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<<Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormShowAdmissionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 618);
            this.Controls.Add(this.panel1);
            this.Name = "FormShowAdmissionInfo";
            this.Text = "FormShowAdmissionInfo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormShowAdmissionInfo_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAdInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvShowAdInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloodGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Occupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefdDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DutyDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblName;
    }
}