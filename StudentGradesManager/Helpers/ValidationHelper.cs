using System;
using System.Windows.Forms;

namespace StudentGradesManager.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateStudent(string name, string number, string department)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the student name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                MessageBox.Show("Please enter the student number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Please select or enter the department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidateSubject(string name, string hoursText)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the subject name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoursText))
            {
                MessageBox.Show("Please enter the credit hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(hoursText, out int hours) || hours <= 0)
            {
                MessageBox.Show("Credit hours must be a positive whole number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidateGrade(int studentId, int subjectId, string gradeText, out decimal gradeValue)
        {
            gradeValue = 0;

            if (studentId <= 0)
            {
                MessageBox.Show("Please select a valid student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (subjectId <= 0)
            {
                MessageBox.Show("Please select a valid subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(gradeText))
            {
                MessageBox.Show("Please enter the grade value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(gradeText, out gradeValue) || gradeValue < 0 || gradeValue > 100)
            {
                MessageBox.Show("Grade must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
