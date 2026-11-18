using System;
using System.Windows.Forms;
using StudentGradesManager.Models;

namespace StudentGradesManager.Forms
{
    public partial class MainForm : Form
    {
        public User CurrentUser { get; private set; }

        public MainForm(User user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                lblWelcomeStatus.Text = $"Welcome, {CurrentUser.Username} | Role: {CurrentUser.Role}";
            }

            // Open GradesForm by default as MDI child
            OpenGradesForm(0);
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenStudentsForm();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSubjectsForm();
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGradesForm(0); // Tab 0: Grade Entry
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGradesForm(2); // Tab 2: Reports
        }

        public void OpenStudentsForm()
        {
            CloseAllMdiChildren();
            StudentsForm form = new StudentsForm(CurrentUser.Role);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        public void OpenSubjectsForm()
        {
            CloseAllMdiChildren();
            SubjectsForm form = new SubjectsForm(CurrentUser.Role);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        public void OpenGradesForm(int selectedTabIndex = 0)
        {
            CloseAllMdiChildren();
            GradesForm form = new GradesForm(CurrentUser.Role);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.SelectTab(selectedTabIndex);
        }

        // Helper to close all currently open forms to prevent duplication/clutter
        private void CloseAllMdiChildren()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private bool _isLoggingOut = false;  // Flag to tell apart Logout vs manual close

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;

            // Close all MDI child forms first
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Close MainForm – LoginForm.FormClosed event will show LoginForm again
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If logging out – just close, LoginForm handles showing itself
            if (_isLoggingOut) return;

            // If user pressed X on MainForm – exit the whole application
            Application.Exit();
        }
    }
}
