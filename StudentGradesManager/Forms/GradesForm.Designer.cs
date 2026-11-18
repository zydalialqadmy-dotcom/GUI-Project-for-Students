namespace StudentGradesManager.Forms
{
    partial class GradesForm
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabGradeEntry = new System.Windows.Forms.TabPage();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.btnClearGrade = new System.Windows.Forms.Button();
            this.btnDeleteGrade = new System.Windows.Forms.Button();
            this.btnUpdateGrade = new System.Windows.Forms.Button();
            this.btnAddGrade = new System.Windows.Forms.Button();
            this.lblPreviewEval = new System.Windows.Forms.Label();
            this.lblPreviewResult = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.tabGradeRecords = new System.Windows.Forms.TabPage();
            this.dgvFilterRecords = new System.Windows.Forms.DataGridView();
            this.tvRecords = new System.Windows.Forms.TreeView();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.lblSelectionInfo = new System.Windows.Forms.Label();
            this.btnExportResults = new System.Windows.Forms.Button();
            this.chkPassedOnly = new System.Windows.Forms.CheckBox();
            this.lvReports = new System.Windows.Forms.ListView();
            this.colStudent = new System.Windows.Forms.ColumnHeader();
            this.colSubject = new System.Windows.Forms.ColumnHeader();
            this.colGrade = new System.Windows.Forms.ColumnHeader();
            this.colResult = new System.Windows.Forms.ColumnHeader();
            this.colEvaluation = new System.Windows.Forms.ColumnHeader();
            this.tabControlMain.SuspendLayout();
            this.tabGradeEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.tabGradeRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterRecords)).BeginInit();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabGradeEntry);
            this.tabControlMain.Controls.Add(this.tabGradeRecords);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(900, 500);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabGradeEntry
            // 
            this.tabGradeEntry.Controls.Add(this.dgvGrades);
            this.tabGradeEntry.Controls.Add(this.btnClearGrade);
            this.tabGradeEntry.Controls.Add(this.btnDeleteGrade);
            this.tabGradeEntry.Controls.Add(this.btnUpdateGrade);
            this.tabGradeEntry.Controls.Add(this.btnAddGrade);
            this.tabGradeEntry.Controls.Add(this.lblPreviewEval);
            this.tabGradeEntry.Controls.Add(this.lblPreviewResult);
            this.tabGradeEntry.Controls.Add(this.txtGrade);
            this.tabGradeEntry.Controls.Add(this.lblGrade);
            this.tabGradeEntry.Controls.Add(this.cmbSubject);
            this.tabGradeEntry.Controls.Add(this.lblSubject);
            this.tabGradeEntry.Controls.Add(this.cmbStudent);
            this.tabGradeEntry.Controls.Add(this.lblStudent);
            this.tabGradeEntry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabGradeEntry.Location = new System.Drawing.Point(4, 26);
            this.tabGradeEntry.Name = "tabGradeEntry";
            this.tabGradeEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabGradeEntry.Size = new System.Drawing.Size(892, 470);
            this.tabGradeEntry.TabIndex = 0;
            this.tabGradeEntry.Text = "Grade Entry";
            this.tabGradeEntry.UseVisualStyleBackColor = true;
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Location = new System.Drawing.Point(375, 20);
            this.dgvGrades.MultiSelect = false;
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.Size = new System.Drawing.Size(495, 420);
            this.dgvGrades.TabIndex = 12;
            this.dgvGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrades_CellClick);
            // 
            // btnClearGrade
            // 
            this.btnClearGrade.BackColor = System.Drawing.Color.Gray;
            this.btnClearGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClearGrade.ForeColor = System.Drawing.Color.White;
            this.btnClearGrade.Location = new System.Drawing.Point(275, 220);
            this.btnClearGrade.Name = "btnClearGrade";
            this.btnClearGrade.Size = new System.Drawing.Size(75, 32);
            this.btnClearGrade.TabIndex = 11;
            this.btnClearGrade.Text = "Clear";
            this.btnClearGrade.UseVisualStyleBackColor = false;
            this.btnClearGrade.Click += new System.EventHandler(this.btnClearGrade_Click);
            // 
            // btnDeleteGrade
            // 
            this.btnDeleteGrade.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGrade.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGrade.Location = new System.Drawing.Point(190, 220);
            this.btnDeleteGrade.Name = "btnDeleteGrade";
            this.btnDeleteGrade.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteGrade.TabIndex = 10;
            this.btnDeleteGrade.Text = "Delete";
            this.btnDeleteGrade.UseVisualStyleBackColor = false;
            this.btnDeleteGrade.Click += new System.EventHandler(this.btnDeleteGrade_Click);
            // 
            // btnUpdateGrade
            // 
            this.btnUpdateGrade.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdateGrade.ForeColor = System.Drawing.Color.White;
            this.btnUpdateGrade.Location = new System.Drawing.Point(105, 220);
            this.btnUpdateGrade.Name = "btnUpdateGrade";
            this.btnUpdateGrade.Size = new System.Drawing.Size(75, 32);
            this.btnUpdateGrade.TabIndex = 9;
            this.btnUpdateGrade.Text = "Update";
            this.btnUpdateGrade.UseVisualStyleBackColor = false;
            this.btnUpdateGrade.Click += new System.EventHandler(this.btnUpdateGrade_Click);
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAddGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddGrade.ForeColor = System.Drawing.Color.White;
            this.btnAddGrade.Location = new System.Drawing.Point(20, 220);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(75, 32);
            this.btnAddGrade.TabIndex = 8;
            this.btnAddGrade.Text = "Add";
            this.btnAddGrade.UseVisualStyleBackColor = false;
            this.btnAddGrade.Click += new System.EventHandler(this.btnAddGrade_Click);
            // 
            // lblPreviewEval
            // 
            this.lblPreviewEval.AutoSize = true;
            this.lblPreviewEval.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblPreviewEval.ForeColor = System.Drawing.Color.Blue;
            this.lblPreviewEval.Location = new System.Drawing.Point(125, 175);
            this.lblPreviewEval.Name = "lblPreviewEval";
            this.lblPreviewEval.Size = new System.Drawing.Size(89, 17);
            this.lblPreviewEval.TabIndex = 7;
            this.lblPreviewEval.Text = "Evaluation: --";
            // 
            // lblPreviewResult
            // 
            this.lblPreviewResult.AutoSize = true;
            this.lblPreviewResult.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblPreviewResult.ForeColor = System.Drawing.Color.Green;
            this.lblPreviewResult.Location = new System.Drawing.Point(20, 175);
            this.lblPreviewResult.Name = "lblPreviewResult";
            this.lblPreviewResult.Size = new System.Drawing.Size(64, 17);
            this.lblPreviewResult.TabIndex = 6;
            this.lblPreviewResult.Text = "Result: --";
            // 
            // txtGrade
            // 
            this.txtGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGrade.Location = new System.Drawing.Point(115, 122);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(235, 24);
            this.txtGrade.TabIndex = 5;
            this.txtGrade.TextChanged += new System.EventHandler(this.txtGrade_TextChanged);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGrade.Location = new System.Drawing.Point(20, 125);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(87, 17);
            this.lblGrade.TabIndex = 4;
            this.lblGrade.Text = "Grade (0-100):";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(115, 72);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(235, 25);
            this.cmbSubject.TabIndex = 3;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubject.Location = new System.Drawing.Point(20, 75);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(58, 17);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Subject:";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(115, 22);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(235, 25);
            this.cmbStudent.TabIndex = 1;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStudent.Location = new System.Drawing.Point(20, 25);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(60, 17);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Student:";
            // 
            // tabGradeRecords
            // 
            this.tabGradeRecords.Controls.Add(this.dgvFilterRecords);
            this.tabGradeRecords.Controls.Add(this.tvRecords);
            this.tabGradeRecords.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabGradeRecords.Location = new System.Drawing.Point(4, 26);
            this.tabGradeRecords.Name = "tabGradeRecords";
            this.tabGradeRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabGradeRecords.Size = new System.Drawing.Size(892, 470);
            this.tabGradeRecords.TabIndex = 1;
            this.tabGradeRecords.Text = "Grade Records (TreeView)";
            this.tabGradeRecords.UseVisualStyleBackColor = true;
            // 
            // dgvFilterRecords
            // 
            this.dgvFilterRecords.AllowUserToAddRows = false;
            this.dgvFilterRecords.AllowUserToDeleteRows = false;
            this.dgvFilterRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilterRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilterRecords.Location = new System.Drawing.Point(245, 15);
            this.dgvFilterRecords.Name = "dgvFilterRecords";
            this.dgvFilterRecords.ReadOnly = true;
            this.dgvFilterRecords.Size = new System.Drawing.Size(630, 435);
            this.dgvFilterRecords.TabIndex = 1;
            // 
            // tvRecords
            // 
            this.tvRecords.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tvRecords.Location = new System.Drawing.Point(15, 15);
            this.tvRecords.Name = "tvRecords";
            this.tvRecords.Size = new System.Drawing.Size(215, 435);
            this.tvRecords.TabIndex = 0;
            this.tvRecords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRecords_AfterSelect);
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.lblSelectionInfo);
            this.tabReports.Controls.Add(this.btnExportResults);
            this.tabReports.Controls.Add(this.chkPassedOnly);
            this.tabReports.Controls.Add(this.lvReports);
            this.tabReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabReports.Location = new System.Drawing.Point(4, 26);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(892, 470);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Reports (ListView & File)";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // lblSelectionInfo
            // 
            this.lblSelectionInfo.AutoSize = true;
            this.lblSelectionInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectionInfo.ForeColor = System.Drawing.Color.Navy;
            this.lblSelectionInfo.Location = new System.Drawing.Point(20, 420);
            this.lblSelectionInfo.Name = "lblSelectionInfo";
            this.lblSelectionInfo.Size = new System.Drawing.Size(232, 17);
            this.lblSelectionInfo.TabIndex = 3;
            this.lblSelectionInfo.Text = "Click any row above to view details.";
            // 
            // btnExportResults
            // 
            this.btnExportResults.BackColor = System.Drawing.Color.Navy;
            this.btnExportResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportResults.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportResults.ForeColor = System.Drawing.Color.White;
            this.btnExportResults.Location = new System.Drawing.Point(700, 15);
            this.btnExportResults.Name = "btnExportResults";
            this.btnExportResults.Size = new System.Drawing.Size(170, 32);
            this.btnExportResults.TabIndex = 2;
            this.btnExportResults.Text = "Export Results (File)";
            this.btnExportResults.UseVisualStyleBackColor = false;
            this.btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // chkPassedOnly
            // 
            this.chkPassedOnly.AutoSize = true;
            this.chkPassedOnly.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkPassedOnly.Location = new System.Drawing.Point(20, 20);
            this.chkPassedOnly.Name = "chkPassedOnly";
            this.chkPassedOnly.Size = new System.Drawing.Size(193, 23);
            this.chkPassedOnly.TabIndex = 1;
            this.chkPassedOnly.Text = "Show Passed Students Only";
            this.chkPassedOnly.UseVisualStyleBackColor = true;
            this.chkPassedOnly.CheckedChanged += new System.EventHandler(this.chkPassedOnly_CheckedChanged);
            // 
            // lvReports
            // 
            this.lvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStudent,
            this.colSubject,
            this.colGrade,
            this.colResult,
            this.colEvaluation});
            this.lvReports.FullRowSelect = true;
            this.lvReports.GridLines = true;
            this.lvReports.Location = new System.Drawing.Point(20, 60);
            this.lvReports.MultiSelect = false;
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(850, 345);
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.View = System.Windows.Forms.View.Details;
            this.lvReports.SelectedIndexChanged += new System.EventHandler(this.lvReports_SelectedIndexChanged);
            // 
            // colStudent
            // 
            this.colStudent.Text = "Student Name";
            this.colStudent.Width = 200;
            // 
            // colSubject
            // 
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 200;
            // 
            // colGrade
            // 
            this.colGrade.Text = "Grade";
            this.colGrade.Width = 100;
            // 
            // colResult
            // 
            this.colResult.Text = "Result";
            this.colResult.Width = 120;
            // 
            // colEvaluation
            // 
            this.colEvaluation.Text = "Evaluation";
            this.colEvaluation.Width = 180;
            // 
            // GradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tabControlMain);
            this.Name = "GradesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grades & Reports System";
            this.Load += new System.EventHandler(this.GradesForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabGradeEntry.ResumeLayout(false);
            this.tabGradeEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.tabGradeRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterRecords)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabGradeEntry;
        private System.Windows.Forms.TabPage tabGradeRecords;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label lblPreviewResult;
        private System.Windows.Forms.Label lblPreviewEval;
        private System.Windows.Forms.Button btnAddGrade;
        private System.Windows.Forms.Button btnUpdateGrade;
        private System.Windows.Forms.Button btnDeleteGrade;
        private System.Windows.Forms.Button btnClearGrade;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.TreeView tvRecords;
        private System.Windows.Forms.DataGridView dgvFilterRecords;
        private System.Windows.Forms.CheckBox chkPassedOnly;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.ColumnHeader colStudent;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.ColumnHeader colGrade;
        private System.Windows.Forms.ColumnHeader colResult;
        private System.Windows.Forms.ColumnHeader colEvaluation;
        private System.Windows.Forms.Button btnExportResults;
        private System.Windows.Forms.Label lblSelectionInfo;
    }
}
