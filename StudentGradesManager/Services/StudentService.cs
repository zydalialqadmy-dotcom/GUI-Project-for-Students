using System;
using System.Data;
using System.Data.SQLite;
using StudentGradesManager.Models;

namespace StudentGradesManager.Services
{
    public class StudentService
    {
        // Load all students into a DataTable using SQLiteDataAdapter
        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    // Data Binding: Database -> SQLiteDataAdapter -> DataTable -> DataGridView
                    string query = "SELECT StudentId, StudentName, StudentNumber, Department " +
                                   "FROM Students ORDER BY StudentId DESC";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading students: " + ex.Message);
            }
            return dt;
        }

        // Add new student – Admin only (enforced here AND in UI)
        public bool AddStudent(Student student, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can add students.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Students (StudentName, StudentNumber, Department) " +
                                   "VALUES (@Name, @Number, @Department)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",       student.StudentName);
                        cmd.Parameters.AddWithValue("@Number",     student.StudentNumber);
                        cmd.Parameters.AddWithValue("@Department", student.Department);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding student: " + ex.Message);
            }
        }

        // Update student – Admin only
        public bool UpdateStudent(Student student, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can update students.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Students SET StudentName = @Name, " +
                                   "StudentNumber = @Number, Department = @Department " +
                                   "WHERE StudentId = @StudentId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId",  student.StudentId);
                        cmd.Parameters.AddWithValue("@Name",       student.StudentName);
                        cmd.Parameters.AddWithValue("@Number",     student.StudentNumber);
                        cmd.Parameters.AddWithValue("@Department", student.Department);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);
            }
        }

        // Delete student – Admin only
        public bool DeleteStudent(int studentId, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can delete students.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    // Related grades are deleted automatically (ON DELETE CASCADE)
                    string query = "DELETE FROM Students WHERE StudentId = @StudentId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
        }
    }
}
