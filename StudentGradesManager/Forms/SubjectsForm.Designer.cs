namespace StudentGradesManager.Forms
{
    partial class SubjectsForm
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
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.lblRoleNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Subject Management";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(20, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(98, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Subject Name:";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubjectName.Location = new System.Drawing.Point(125, 62);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(225, 24);
            this.txtSubjectName.TabIndex = 2;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHours.Location = new System.Drawing.Point(20, 110);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(90, 17);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "Credit Hours:";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHours.Location = new System.Drawing.Point(125, 107);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(225, 24);
            this.txtHours.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 5;
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
            this.btnUpdate.Location = new System.Drawing.Point(105, 160);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 6;
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
            this.btnDelete.Location = new System.Drawing.Point(190, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 7;
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
            this.btnClear.Location = new System.Drawing.Point(275, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(370, 57);
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(480, 320);
            this.dgvSubjects.TabIndex = 9;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellClick);
            // 
            // lblRoleNotice
            // 
            this.lblRoleNotice.AutoSize = true;
            this.lblRoleNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRoleNotice.ForeColor = System.Drawing.Color.Red;
            this.lblRoleNotice.Location = new System.Drawing.Point(20, 205);
            this.lblRoleNotice.Name = "lblRoleNotice";
            this.lblRoleNotice.Size = new System.Drawing.Size(325, 15);
            this.lblRoleNotice.TabIndex = 10;
            this.lblRoleNotice.Text = "* Teacher Role: Read-only access (Cannot Add/Update/Delete)";
            this.lblRoleNotice.Visible = false;
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 400);
            this.Controls.Add(this.lblRoleNotice);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Name = "SubjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Subjects";
            this.Load += new System.EventHandler(this.SubjectsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Label lblRoleNotice;
    }
}
