using System;
using System.Windows.Forms;
using StudentGradesManager.Models;
using StudentGradesManager.Services;

namespace StudentGradesManager.Forms
{
    public partial class LoginForm : Form
    {
        private UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Event 1: Form Load – pre-fill default credentials for easy testing
            txtUsername.Text = "Admin";
            txtPassword.Text = "1234";
            txtUsername.SelectAll();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Event 2: Button Click – authenticate user
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Authenticate using ADO.NET SqlDataReader (in UserService)
                User loggedInUser = _userService.AuthenticateUser(username, password);

                if (loggedInUser != null)
                {
                    // Open MainForm and pass the logged-in User object
                    MainForm mainForm = new MainForm(loggedInUser);

                    // When MainForm closes (e.g., Logout), show LoginForm again
                    mainForm.FormClosed += (s, args) =>
                    {
                        if (!this.IsDisposed)
                        {
                            txtPassword.Clear();
                            this.Show();
                        }
                    };

                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
