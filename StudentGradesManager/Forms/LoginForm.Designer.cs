namespace StudentGradesManager.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();

            // -------------------------------------------------------
            // panelTop  (dark navy header bar)
            // -------------------------------------------------------
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(23, 42, 80);
            this.panelTop.Controls.Add(this.lblSubTitle);
            this.panelTop.Controls.Add(this.lblAppTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(460, 100);
            this.panelTop.TabIndex = 0;

            // lblAppTitle
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 18);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(300, 32);
            this.lblAppTitle.Text = "Student Grades Manager";

            // lblSubTitle
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblSubTitle.Location = new System.Drawing.Point(22, 58);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(200, 17);
            this.lblSubTitle.Text = "Visual Programming Project – 2026";

            // -------------------------------------------------------
            // panelForm  (white login card)
            // -------------------------------------------------------
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.lblUsername);
            this.panelForm.Controls.Add(this.txtUsername);
            this.panelForm.Controls.Add(this.lblPassword);
            this.panelForm.Controls.Add(this.txtPassword);
            this.panelForm.Controls.Add(this.btnLogin);
            this.panelForm.Controls.Add(this.btnExit);
            this.panelForm.Location = new System.Drawing.Point(0, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelForm.Size = new System.Drawing.Size(460, 220);
            this.panelForm.TabIndex = 1;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblUsername.Location = new System.Drawing.Point(30, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Username";

            // txtUsername
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 50);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(395, 28);
            this.txtUsername.TabIndex = 0;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.lblPassword.Location = new System.Drawing.Point(30, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";

            // txtPassword
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(395, 28);
            this.txtPassword.TabIndex = 1;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(23, 42, 80);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 165);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(185, 38);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(240, 165);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(185, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // -------------------------------------------------------
            // lblVersion  (footer)
            // -------------------------------------------------------
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(130, 330);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Text = "Default: Admin / 1234  |  Teacher / 1234";

            // -------------------------------------------------------
            // LoginForm
            // -------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.ClientSize = new System.Drawing.Size(460, 350);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login – Student Grades Manager";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblVersion;
    }
}
