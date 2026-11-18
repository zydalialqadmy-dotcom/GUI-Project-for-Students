using System;
using System.Data;
using System.Windows.Forms;
using StudentGradesManager.Helpers;
using StudentGradesManager.Models;
using StudentGradesManager.Services;

namespace StudentGradesManager.Forms
{
    public partial class StudentsForm : Form
    {
        private StudentService _studentService;
        private string _currentUserRole;
        private int _selectedStudentId = 0;

        public StudentsForm(string userRole)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _currentUserRole = userRole;
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            // Event 1: Form Load
            ApplyRolePermissions();
            LoadStudentsData();
        }

        private void ApplyRolePermissions()
        {
            // If Teacher: disable Add, Update, Delete buttons (UI-level permission)
            if (_currentUserRole != "Admin")
            {
                btnAdd.Enabled    = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                lblRoleNotice.Visible = true;
            }
        }

        private void LoadStudentsData()
        {
            try
            {
                // Data Binding: Database -> SqlDataAdapter -> DataTable -> DataGridView
                DataTable dt = _studentService.GetAllStudents();
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load students: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Event 2: Button Click
            string name       = txtStudentName.Text.Trim();
            string number     = txtStudentNumber.Text.Trim();
            string department = GetDepartment();

            if (!ValidationHelper.ValidateStudent(name, number, department))
                return;

            try
            {
                Student s = new Student(0, name, number, department);
                bool success = _studentService.AddStudent(s, _currentUserRole);

                if (success)
                {
                    MessageBox.Show("Student added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudentsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId <= 0)
            {
                MessageBox.Show("Please select a student from the grid to update.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name       = txtStudentName.Text.Trim();
            string number     = txtStudentNumber.Text.Trim();
            string department = GetDepartment();

            if (!ValidationHelper.ValidateStudent(name, number, department))
                return;

            try
            {
                Student s = new Student(_selectedStudentId, name, number, department);
                bool success = _studentService.UpdateStudent(s, _currentUserRole);

                if (success)
                {
                    MessageBox.Show("Student updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudentsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId <= 0)
            {
                MessageBox.Show("Please select a student from the grid to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this student and all associated grades?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                bool success = _studentService.DeleteStudent(_selectedStudentId, _currentUserRole);
                if (success)
                {
                    MessageBox.Show("Student deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudentsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event 3: DataGridView CellClick – populate fields for editing
            if (e.RowIndex < 0) return;  // Guard: skip header row clicks

            try
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                // Safely read values checking for DBNull
                if (row.Cells["StudentId"].Value == null || row.Cells["StudentId"].Value == DBNull.Value)
                    return;

                _selectedStudentId   = Convert.ToInt32(row.Cells["StudentId"].Value);
                txtStudentName.Text  = row.Cells["StudentName"].Value.ToString();
                txtStudentNumber.Text = row.Cells["StudentNumber"].Value.ToString();
                cmbDepartment.Text   = row.Cells["Department"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting student row: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper: get department value from ComboBox safely
        private string GetDepartment()
        {
            if (cmbDepartment.SelectedItem != null)
                return cmbDepartment.SelectedItem.ToString();
            return cmbDepartment.Text.Trim();
        }

        private void ClearInputs()
        {
            _selectedStudentId = 0;
            txtStudentName.Clear();
            txtStudentNumber.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbDepartment.Text = string.Empty;
        }
    }
}
