using System;
using System.Windows.Forms;
using StudentGradesManager.Forms;
using StudentGradesManager.Services;

namespace StudentGradesManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Required for Windows Forms to work correctly
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Connect to SQL Server LocalDB and create DB/tables if not exist
            DatabaseService.InitializeDatabase();

            // Start the application from LoginForm
            Application.Run(new LoginForm());
        }
    }
}