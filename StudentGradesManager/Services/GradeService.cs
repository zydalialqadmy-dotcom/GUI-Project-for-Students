using System;
using System.Data;
using System.Data.SQLite;
using StudentGradesManager.Models;

namespace StudentGradesManager.Services
{
    public class GradeService
    {
        // Read all grades joined with StudentName & SubjectName, adding C# dynamic Result & Evaluation
        public DataTable GetAllGrades()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    string query = @"
                        SELECT 
                            g.GradeId, 
                            g.StudentId, 
                            s.StudentName, 
                            g.SubjectId, 
                            sub.SubjectName, 
                            g.Grade
                        FROM Grades g
                        INNER JOIN Students s ON g.StudentId = s.StudentId
                        INNER JOIN Subjects sub ON g.SubjectId = sub.SubjectId
                        ORDER BY g.GradeId DESC";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                    DataTable rawDt = new DataTable();
                    adapter.Fill(rawDt);

                    // Build formatted DataTable for WinForms UI
                    dt.Columns.Add("GradeId", typeof(int));
                    dt.Columns.Add("StudentId", typeof(int));
                    dt.Columns.Add("StudentName", typeof(string));
                    dt.Columns.Add("SubjectId", typeof(int));
                    dt.Columns.Add("SubjectName", typeof(string));
                    dt.Columns.Add("Grade", typeof(decimal));
                    dt.Columns.Add("Result", typeof(string));
                    dt.Columns.Add("Evaluation", typeof(string));

                    foreach (DataRow row in rawDt.Rows)
                    {
                        decimal gradeValue = Convert.ToDecimal(row["Grade"]);

                        // Dynamic C# Calculation for Result & Evaluation
                        Grade g = new Grade
                        {
                            GradeId = Convert.ToInt32(row["GradeId"]),
                            StudentId = Convert.ToInt32(row["StudentId"]),
                            StudentName = row["StudentName"].ToString(),
                            SubjectId = Convert.ToInt32(row["SubjectId"]),
                            SubjectName = row["SubjectName"].ToString(),
                            GradeValue = gradeValue
                        };

                        dt.Rows.Add(
                            g.GradeId,
                            g.StudentId,
                            g.StudentName,
                            g.SubjectId,
                            g.SubjectName,
                            g.GradeValue,
                            g.GetResult(),
                            g.GetEvaluation()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading grades: " + ex.Message);
            }
            return dt;
        }

        // Add Grade (Allowed for Admin & Teacher)
        public bool AddGrade(int studentId, int subjectId, decimal gradeValue)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (@StudentId, @SubjectId, @Grade)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                        cmd.Parameters.AddWithValue("@Grade", gradeValue);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding grade: " + ex.Message);
            }
        }

        // Update Grade (Allowed for Admin & Teacher)
        public bool UpdateGrade(int gradeId, int studentId, int subjectId, decimal gradeValue)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Grades SET StudentId = @StudentId, SubjectId = @SubjectId, Grade = @Grade WHERE GradeId = @GradeId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GradeId", gradeId);
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                        cmd.Parameters.AddWithValue("@Grade", gradeValue);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating grade: " + ex.Message);
            }
        }

        // Delete Grade (Allowed for Admin & Teacher)
        public bool DeleteGrade(int gradeId)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Grades WHERE GradeId = @GradeId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GradeId", gradeId);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting grade: " + ex.Message);
            }
        }
    }
}
