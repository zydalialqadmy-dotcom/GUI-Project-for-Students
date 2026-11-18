using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace StudentGradesManager.Services
{
    public static class DatabaseService
    {
        // SQLite database file – created automatically in the application folder
        // No SQL Server installation required!
        private static string _dbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "StudentGradesDB.db");

        public static string ConnectionString
        {
            get { return "Data Source=" + _dbPath + ";Version=3;"; }
        }

        // Returns a new (unopened) SQLiteConnection
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        // Called once at startup – creates DB file + tables + sample data if they don't exist
        public static void InitializeDatabase()
        {
            try
            {
                // SQLite creates the .db file automatically if it doesn't exist
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    CreateTablesAndSeedData(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private static void CreateTablesAndSeedData(SQLiteConnection conn)
        {
            // ---------- Users Table ----------
            string createUsers = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId   INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role     TEXT NOT NULL
                );";
            RunSQL(conn, createUsers);

            // Seed default users only if table is empty
            if (GetCount(conn, "Users") == 0)
            {
                RunSQL(conn, "INSERT INTO Users (Username, Password, Role) VALUES ('Admin',   '1234', 'Admin');");
                RunSQL(conn, "INSERT INTO Users (Username, Password, Role) VALUES ('Teacher', '1234', 'Teacher');");
            }

            // ---------- Students Table ----------
            string createStudents = @"
                CREATE TABLE IF NOT EXISTS Students (
                    StudentId     INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentName   TEXT NOT NULL,
                    StudentNumber TEXT NOT NULL,
                    Department    TEXT NOT NULL
                );";
            RunSQL(conn, createStudents);

            if (GetCount(conn, "Students") == 0)
            {
                RunSQL(conn, "INSERT INTO Students (StudentName, StudentNumber, Department) VALUES ('Ahmed Ali',    'S1001', 'Computer Science');");
                RunSQL(conn, "INSERT INTO Students (StudentName, StudentNumber, Department) VALUES ('Sara Mohamed', 'S1002', 'Information Technology');");
                RunSQL(conn, "INSERT INTO Students (StudentName, StudentNumber, Department) VALUES ('Omar Hassan',  'S1003', 'Software Engineering');");
            }

            // ---------- Subjects Table ----------
            string createSubjects = @"
                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectId   INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    Hours       INTEGER NOT NULL
                );";
            RunSQL(conn, createSubjects);

            if (GetCount(conn, "Subjects") == 0)
            {
                RunSQL(conn, "INSERT INTO Subjects (SubjectName, Hours) VALUES ('Programming 1',    3);");
                RunSQL(conn, "INSERT INTO Subjects (SubjectName, Hours) VALUES ('Database Systems', 3);");
                RunSQL(conn, "INSERT INTO Subjects (SubjectName, Hours) VALUES ('Visual Programming', 4);");
            }

            // ---------- Grades Table ----------
            // Only the numeric Grade is stored.
            // Result and Evaluation are calculated in C# (Grade.GetResult / GetEvaluation).
            string createGrades = @"
                CREATE TABLE IF NOT EXISTS Grades (
                    GradeId   INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentId INTEGER NOT NULL REFERENCES Students(StudentId) ON DELETE CASCADE,
                    SubjectId INTEGER NOT NULL REFERENCES Subjects(SubjectId) ON DELETE CASCADE,
                    Grade     REAL NOT NULL
                );";
            RunSQL(conn, createGrades);

            if (GetCount(conn, "Grades") == 0)
            {
                RunSQL(conn, "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (1, 1, 95.50);");
                RunSQL(conn, "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (1, 2, 88.00);");
                RunSQL(conn, "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (2, 1, 72.00);");
                RunSQL(conn, "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (2, 3, 45.00);");
                RunSQL(conn, "INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES (3, 2, 64.50);");
            }
        }

        // Run a non-query SQL command on an already-open connection
        private static void RunSQL(SQLiteConnection conn, string sql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Get row count of a table (used for seed-data check)
        private static int GetCount(SQLiteConnection conn, string tableName)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM " + tableName, conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
