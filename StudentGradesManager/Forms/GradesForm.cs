using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StudentGradesManager.Helpers;
using StudentGradesManager.Models;
using StudentGradesManager.Services;

namespace StudentGradesManager.Forms
{
    public partial class GradesForm : Form
    {
        private StudentService _studentService;
        private SubjectService _subjectService;
        private GradeService _gradeService;
        private string _currentUserRole;
        private int _selectedGradeId = 0;
        private bool _isLoaded = false;   // Guard: prevent events firing before form is fully loaded

        public GradesForm(string userRole)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _subjectService = new SubjectService();
            _gradeService = new GradeService();
            _currentUserRole = userRole;
        }

        private void GradesForm_Load(object sender, EventArgs e)
        {
            // Event 1: Form Load
            LoadComboBoxes();
            LoadGradesData();
            SetupTreeViewNodes();
            LoadReportsListView();
            _isLoaded = true;  // Mark as fully loaded so TabControl events can fire
        }

        public void SelectTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < tabControlMain.TabCount)
            {
                tabControlMain.SelectedIndex = tabIndex;
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event 2: TabControl SelectedIndexChanged
            // Guard: skip if form not fully loaded yet
            if (!_isLoaded) return;

            if (tabControlMain.SelectedIndex == 0)
            {
                LoadGradesData();
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                // Refresh TreeView grid if a node is already selected
                if (tvRecords.SelectedNode != null)
                {
                    tvRecords_AfterSelect(this, new TreeViewEventArgs(tvRecords.SelectedNode));
                }
            }
            else if (tabControlMain.SelectedIndex == 2)
            {
                LoadReportsListView();
            }
        }

        // ==========================================
        // TAB 1: GRADE ENTRY & CRUD
        // ==========================================

        private void LoadComboBoxes()
        {
            try
            {
                // Load Students into ComboBox using DataTable binding
                DataTable dtStudents = _studentService.GetAllStudents();
                cmbStudent.DataSource = dtStudents;
                cmbStudent.DisplayMember = "StudentName";
                cmbStudent.ValueMember = "StudentId";

                // Load Subjects into ComboBox
                DataTable dtSubjects = _subjectService.GetAllSubjects();
                cmbSubject.DataSource = dtSubjects;
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "SubjectId";

                // Reset selection to blank (no item selected)
                cmbStudent.SelectedIndex = -1;
                cmbSubject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdown data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGradesData()
        {
            try
            {
                DataTable dt = _gradeService.GetAllGrades();
                dgvGrades.DataSource = dt;

                // Hide internal ID columns from the user
                if (dgvGrades.Columns["GradeId"] != null)
                    dgvGrades.Columns["GradeId"].Visible = false;
                if (dgvGrades.Columns["StudentId"] != null)
                    dgvGrades.Columns["StudentId"].Visible = false;
                if (dgvGrades.Columns["SubjectId"] != null)
                    dgvGrades.Columns["SubjectId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grades: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {
            // Event 3: TextBox TextChanged – Live Preview of Result & Evaluation
            string text = txtGrade.Text.Trim();

            if (decimal.TryParse(text, out decimal val) && val >= 0 && val <= 100)
            {
                Grade tempGrade = new Grade();
                tempGrade.GradeValue = val;
                lblPreviewResult.Text = "Result: " + tempGrade.GetResult();
                lblPreviewEval.Text   = "Evaluation: " + tempGrade.GetEvaluation();
            }
            else
            {
                lblPreviewResult.Text = "Result: --";
                lblPreviewEval.Text   = "Evaluation: --";
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event 4: ComboBox SelectedIndexChanged (placeholder for future use / event demo)
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            // Event 5: Button Click
            int studentId = GetComboBoxSelectedId(cmbStudent);
            int subjectId = GetComboBoxSelectedId(cmbSubject);

            if (!ValidationHelper.ValidateGrade(studentId, subjectId, txtGrade.Text.Trim(), out decimal gradeValue))
                return;

            try
            {
                bool success = _gradeService.AddGrade(studentId, subjectId, gradeValue);
                if (success)
                {
                    MessageBox.Show("Grade recorded successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGradeInputs();
                    LoadGradesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateGrade_Click(object sender, EventArgs e)
        {
            if (_selectedGradeId <= 0)
            {
                MessageBox.Show("Please select a grade from the grid to update.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = GetComboBoxSelectedId(cmbStudent);
            int subjectId = GetComboBoxSelectedId(cmbSubject);

            if (!ValidationHelper.ValidateGrade(studentId, subjectId, txtGrade.Text.Trim(), out decimal gradeValue))
                return;

            try
            {
                bool success = _gradeService.UpdateGrade(_selectedGradeId, studentId, subjectId, gradeValue);
                if (success)
                {
                    MessageBox.Show("Grade updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGradeInputs();
                    LoadGradesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteGrade_Click(object sender, EventArgs e)
        {
            if (_selectedGradeId <= 0)
            {
                MessageBox.Show("Please select a grade from the grid to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this grade entry?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                bool success = _gradeService.DeleteGrade(_selectedGradeId);
                if (success)
                {
                    MessageBox.Show("Grade deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGradeInputs();
                    LoadGradesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearGrade_Click(object sender, EventArgs e)
        {
            ClearGradeInputs();
        }

        private void dgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event 6: DataGridView CellClick
            // Guard: skip header row clicks (e.RowIndex == -1 on header)
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvGrades.Rows[e.RowIndex];

                // Read hidden ID values from the underlying DataTable
                DataTable dt = dgvGrades.DataSource as DataTable;
                if (dt == null || e.RowIndex >= dt.Rows.Count) return;

                DataRow dataRow = dt.Rows[e.RowIndex];

                _selectedGradeId = Convert.ToInt32(dataRow["GradeId"]);
                int studentId    = Convert.ToInt32(dataRow["StudentId"]);
                int subjectId    = Convert.ToInt32(dataRow["SubjectId"]);
                decimal grade    = Convert.ToDecimal(dataRow["Grade"]);

                // Set ComboBox selections safely
                cmbStudent.SelectedValue = studentId;
                cmbSubject.SelectedValue = subjectId;
                txtGrade.Text = grade.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting grade row: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGradeInputs()
        {
            _selectedGradeId = 0;
            cmbStudent.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            txtGrade.Clear();
            lblPreviewResult.Text = "Result: --";
            lblPreviewEval.Text   = "Evaluation: --";
        }

        // Helper: safely get the integer value from a ComboBox bound to a DataTable
        private int GetComboBoxSelectedId(ComboBox cmb)
        {
            if (cmb.SelectedValue == null) return 0;
            try { return Convert.ToInt32(cmb.SelectedValue); }
            catch { return 0; }
        }

        // ==========================================
        // TAB 2: TREEVIEW & RECORDS
        // ==========================================

        private void SetupTreeViewNodes()
        {
            tvRecords.Nodes.Clear();

            TreeNode studentsNode = new TreeNode("Students");
            studentsNode.Nodes.Add("All Students");

            TreeNode subjectsNode = new TreeNode("Subjects");
            subjectsNode.Nodes.Add("All Subjects");

            TreeNode gradesNode = new TreeNode("Grades");
            gradesNode.Nodes.Add("All Grades");
            gradesNode.Nodes.Add("Passed Students");
            gradesNode.Nodes.Add("Failed Students");

            tvRecords.Nodes.Add(studentsNode);
            tvRecords.Nodes.Add(subjectsNode);
            tvRecords.Nodes.Add(gradesNode);

            tvRecords.ExpandAll();
        }

        private void tvRecords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Event 7: TreeView AfterSelect
            if (e.Node == null) return;

            string nodeText = e.Node.Text;

            try
            {
                if (nodeText == "Students" || nodeText == "All Students")
                {
                    DataTable dt = _studentService.GetAllStudents();
                    dgvFilterRecords.DataSource = dt;
                }
                else if (nodeText == "Subjects" || nodeText == "All Subjects")
                {
                    DataTable dt = _subjectService.GetAllSubjects();
                    dgvFilterRecords.DataSource = dt;
                }
                else if (nodeText == "Grades" || nodeText == "All Grades")
                {
                    DataTable dt = _gradeService.GetAllGrades();
                    dgvFilterRecords.DataSource = dt;
                }
                else if (nodeText == "Passed Students")
                {
                    DataTable dt = _gradeService.GetAllGrades();
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "Result = 'Pass'";
                    dgvFilterRecords.DataSource = dv.ToTable();
                }
                else if (nodeText == "Failed Students")
                {
                    DataTable dt = _gradeService.GetAllGrades();
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "Result = 'Fail'";
                    dgvFilterRecords.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // TAB 3: REPORTS (LISTVIEW, CHECKBOX & FILE EXPORT)
        // ==========================================

        private void LoadReportsListView()
        {
            try
            {
                lvReports.Items.Clear();
                DataTable dt = _gradeService.GetAllGrades();

                foreach (DataRow row in dt.Rows)
                {
                    string result = row["Result"].ToString();

                    // Event 8: CheckBox CheckedChanged filter applied here
                    if (chkPassedOnly.Checked && result != "Pass")
                        continue;

                    ListViewItem item = new ListViewItem(row["StudentName"].ToString());
                    item.SubItems.Add(row["SubjectName"].ToString());
                    item.SubItems.Add(row["Grade"].ToString());
                    item.SubItems.Add(result);
                    item.SubItems.Add(row["Evaluation"].ToString());

                    lvReports.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPassedOnly_CheckedChanged(object sender, EventArgs e)
        {
            // Event 8: CheckBox CheckedChanged – filter ListView
            LoadReportsListView();
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event 9: ListView SelectedIndexChanged – update info label
            if (lvReports.SelectedItems.Count > 0)
            {
                ListViewItem item = lvReports.SelectedItems[0];
                string student    = item.SubItems[0].Text;
                string subject    = item.SubItems[1].Text;
                string grade      = item.SubItems[2].Text;
                string result     = item.SubItems[3].Text;
                string evaluation = item.SubItems[4].Text;

                lblSelectionInfo.Text =
                    $"Selected: {student}  |  Subject: {subject}  |  Grade: {grade}  |  Result: {result}  ({evaluation})";
            }
        }

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            // Files and PDF Generation: Export to StudentResults.pdf using iTextSharp
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath    = Path.Combine(desktopPath, "StudentResults.pdf");

                DataTable dt = _gradeService.GetAllGrades();

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Create a new document with A4 page size and margins
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // 1. Add Report Title
                    Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                    Paragraph title = new Paragraph("Student Grades Official Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // 2. Add Date
                    Font dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                    Paragraph date = new Paragraph("Generated On: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dateFont);
                    date.Alignment = Element.ALIGN_CENTER;
                    date.SpacingAfter = 20f;
                    doc.Add(date);

                    // 3. Create Table
                    PdfPTable table = new PdfPTable(5); // 5 columns
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 2.5f, 2.5f, 1f, 1.5f, 2f });

                    // Headers Styling
                    Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    BaseColor headerBg = new BaseColor(23, 42, 80); // Navy Blue

                    string[] headers = { "Student Name", "Subject", "Grade", "Result", "Evaluation" };
                    foreach (string h in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(h, headerFont));
                        cell.BackgroundColor = headerBg;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Padding = 7;
                        table.AddCell(cell);
                    }

                    // 4. Fill Data Rows
                    Font rowFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                    foreach (DataRow row in dt.Rows)
                    {
                        PdfPCell cellStudent = new PdfPCell(new Phrase(row["StudentName"].ToString(), rowFont)) { Padding = 5 };
                        PdfPCell cellSubject = new PdfPCell(new Phrase(row["SubjectName"].ToString(), rowFont)) { Padding = 5 };
                        
                        PdfPCell cellGrade = new PdfPCell(new Phrase(row["Grade"].ToString(), rowFont));
                        cellGrade.Padding = 5;
                        cellGrade.HorizontalAlignment = Element.ALIGN_CENTER;
                        
                        PdfPCell cellResult = new PdfPCell(new Phrase(row["Result"].ToString(), rowFont));
                        cellResult.Padding = 5;
                        cellResult.HorizontalAlignment = Element.ALIGN_CENTER;
                        
                        PdfPCell cellEval = new PdfPCell(new Phrase(row["Evaluation"].ToString(), rowFont));
                        cellEval.Padding = 5;
                        cellEval.HorizontalAlignment = Element.ALIGN_CENTER;

                        table.AddCell(cellStudent);
                        table.AddCell(cellSubject);
                        table.AddCell(cellGrade);
                        table.AddCell(cellResult);
                        table.AddCell(cellEval);
                    }

                    doc.Add(table);
                    doc.Close();
                    writer.Close();
                }

                MessageBox.Show(
                    "Results exported successfully as PDF!\n\nFile saved to:\n" + filePath,
                    "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
