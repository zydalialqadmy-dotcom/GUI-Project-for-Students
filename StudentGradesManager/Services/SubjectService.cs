using System;
using System.Data;
using System.Data.SQLite;
using StudentGradesManager.Models;

namespace StudentGradesManager.Services
{
    public class SubjectService
    {
        // Load all subjects into a DataTable
        public DataTable GetAllSubjects()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    string query = "SELECT SubjectId, SubjectName, Hours FROM Subjects ORDER BY SubjectId DESC";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading subjects: " + ex.Message);
            }
            return dt;
        }

        // Add subject – Admin only
        public bool AddSubject(Subject subject, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can add subjects.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Subjects (SubjectName, Hours) VALUES (@Name, @Hours)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",  subject.SubjectName);
                        cmd.Parameters.AddWithValue("@Hours", subject.Hours);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding subject: " + ex.Message);
            }
        }

        // Update subject – Admin only
        public bool UpdateSubject(Subject subject, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can update subjects.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Subjects SET SubjectName = @Name, Hours = @Hours " +
                                   "WHERE SubjectId = @SubjectId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                        cmd.Parameters.AddWithValue("@Name",      subject.SubjectName);
                        cmd.Parameters.AddWithValue("@Hours",     subject.Hours);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating subject: " + ex.Message);
            }
        }

        // Delete subject – Admin only
        public bool DeleteSubject(int subjectId, string currentUserRole)
        {
            if (currentUserRole != "Admin")
                throw new InvalidOperationException("Permission denied! Only Admin can delete subjects.");

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Subjects WHERE SubjectId = @SubjectId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting subject: " + ex.Message);
            }
        }
    }
}
