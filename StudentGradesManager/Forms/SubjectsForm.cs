using System;
using System.Data;
using System.Windows.Forms;
using StudentGradesManager.Helpers;
using StudentGradesManager.Models;
using StudentGradesManager.Services;

namespace StudentGradesManager.Forms
{
    public partial class SubjectsForm : Form
    {
        private SubjectService _subjectService;
        private string _currentUserRole;
        private int _selectedSubjectId = 0;

        public SubjectsForm(string userRole)
        {
            InitializeComponent();
            _subjectService = new SubjectService();
            _currentUserRole = userRole;
        }

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
            LoadSubjectsData();
        }

        private void ApplyRolePermissions()
        {
            if (_currentUserRole != "Admin")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                lblRoleNotice.Visible = true;
            }
        }

        private void LoadSubjectsData()
        {
            try
            {
                // Data Binding: Database -> SqlDataAdapter -> DataTable -> DataGridView
                DataTable dt = _subjectService.GetAllSubjects();
                dgvSubjects.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load subjects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtSubjectName.Text.Trim();
            string hoursText = txtHours.Text.Trim();

            if (!ValidationHelper.ValidateSubject(name, hoursText))
            {
                return;
            }

            try
            {
                int hours = int.Parse(hoursText);
                Subject s = new Subject(0, name, hours);
                bool success = _subjectService.AddSubject(s, _currentUserRole);

                if (success)
                {
                    MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadSubjectsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSubjectId <= 0)
            {
                MessageBox.Show("Please select a subject from the grid to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtSubjectName.Text.Trim();
            string hoursText = txtHours.Text.Trim();

            if (!ValidationHelper.ValidateSubject(name, hoursText))
            {
                return;
            }

            try
            {
                int hours = int.Parse(hoursText);
                Subject s = new Subject(_selectedSubjectId, name, hours);
                bool success = _subjectService.UpdateSubject(s, _currentUserRole);

                if (success)
                {
                    MessageBox.Show("Subject updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadSubjectsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSubjectId <= 0)
            {
                MessageBox.Show("Please select a subject from the grid to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this subject and all associated grades?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool success = _subjectService.DeleteSubject(_selectedSubjectId, _currentUserRole);
                if (success)
                {
                    MessageBox.Show("Subject deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadSubjectsData();
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

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event: DataGridView CellClick – guard against header row click
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];

                if (row.Cells["SubjectId"].Value == null || row.Cells["SubjectId"].Value == DBNull.Value)
                    return;

                _selectedSubjectId  = Convert.ToInt32(row.Cells["SubjectId"].Value);
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
                txtHours.Text       = row.Cells["Hours"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting subject row: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _selectedSubjectId = 0;
            txtSubjectName.Clear();
            txtHours.Clear();
        }
    }
}
