namespace StudentGradesManager.Forms
{
    partial class StudentsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lblRoleNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Management";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtStudentName.Location = new System.Drawing.Point(130, 57);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(220, 24);
            this.txtStudentName.TabIndex = 2;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumber.Location = new System.Drawing.Point(20, 100);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(113, 17);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Student Number:";
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtStudentNumber.Location = new System.Drawing.Point(130, 97);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(220, 24);
            this.txtStudentNumber.TabIndex = 4;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.Location = new System.Drawing.Point(20, 140);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(86, 17);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "Computer Science",
            "Information Technology",
            "Software Engineering",
            "Information Systems"});
            this.cmbDepartment.Location = new System.Drawing.Point(130, 137);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(220, 25);
            this.cmbDepartment.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(105, 185);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(190, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(275, 185);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(370, 57);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(480, 320);
            this.dgvStudents.TabIndex = 11;
            this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            // 
            // lblRoleNotice
            // 
            this.lblRoleNotice.AutoSize = true;
            this.lblRoleNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRoleNotice.ForeColor = System.Drawing.Color.Red;
            this.lblRoleNotice.Location = new System.Drawing.Point(20, 230);
            this.lblRoleNotice.Name = "lblRoleNotice";
            this.lblRoleNotice.Size = new System.Drawing.Size(325, 15);
            this.lblRoleNotice.TabIndex = 12;
            this.lblRoleNotice.Text = "* Teacher Role: Read-only access (Cannot Add/Update/Delete)";
            this.lblRoleNotice.Visible = false;
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 400);
            this.Controls.Add(this.lblRoleNotice);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtStudentNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Name = "StudentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Students";
            this.Load += new System.EventHandler(this.StudentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblRoleNotice;
    }
}
