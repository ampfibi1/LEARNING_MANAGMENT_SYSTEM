using System;
using System.Windows.Forms;

namespace LMS
{
    public partial class form_Login_Register : BaseForm
    {
        public form_Login_Register()
        {
            InitializeComponent();
            pnlLoginAnimation.Visible = false;
            txtPassword.UseSystemPasswordChar = true;
            txtRegisterCPassword.UseSystemPasswordChar = true;
            txtRegisterPassword.UseSystemPasswordChar = true;
        }

        // Toggle Panels
        private void btnLoginAnimation_Click(object sender, EventArgs e)
        {
            ShowRegisterPanel();
        }

        private void btnRegisterAnimation_Click(object sender, EventArgs e)
        {
            ShowLoginPanel();
        }

        private void ShowLoginPanel()
        {
            pnlLoginAnimation.Visible = true;
            pnlRegsiterAnimation.Visible = false;
        }

        private void ShowRegisterPanel()
        {
            pnlLoginAnimation.Visible = false;
            pnlRegsiterAnimation.Visible = true;
        }

        // Exit Application
        private void btn_Exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Handle global key presses (Enter, Up, Down)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (!pnlLoginAnimation.Visible)
                    PerformLogin();
                else if (!pnlRegsiterAnimation.Visible)
                    PerformRegister();

                return true;
            }

            // Down Arrow Navigation
            if (keyData == Keys.Down)
            {
                HandleDownKey();
                return true;
            }

            // Up Arrow Navigation
            if (keyData == Keys.Up)
            {
                HandleUpKey();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Down Arrow Key Navigation
        private void HandleDownKey()
        {
            if (!pnlLoginAnimation.Visible)
            {
                if (txtUserName.Focused)
                    txtPassword.Focus();
                else if (txtPassword.Focused)
                    btnLogin.Focus();
            }
            else if (!pnlRegsiterAnimation.Visible)
            {
                if (txtRegisterUser.Focused)
                    txtRegisterGmail.Focus();
                else if (txtRegisterGmail.Focused)
                    txtRegisterPassword.Focus();
                else if (txtRegisterPassword.Focused)
                    txtRegisterCPassword.Focus();
                else if (txtRegisterCPassword.Focused)
                    btnRegister.Focus();
            }
        }

        // Up Arrow Key Navigation
        private void HandleUpKey()
        {
            if (!pnlLoginAnimation.Visible)
            {
                if (btnLogin.Focused)
                    txtPassword.Focus();
                else if (txtPassword.Focused)
                    txtUserName.Focus();
            }
            else if (!pnlRegsiterAnimation.Visible)
            {
                if (btnRegister.Focused)
                    txtRegisterCPassword.Focus();
                else if (txtRegisterCPassword.Focused)
                    txtRegisterPassword.Focus();
                else if (txtRegisterPassword.Focused)
                    txtRegisterGmail.Focus();
                else if (txtRegisterGmail.Focused)
                    txtRegisterUser.Focus();
            }
        }

        // Login Button Click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        // Login Logic
        private void PerformLogin()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "user" && password == "user")
            {
                OpenDashboard(new User_Dashboard());
            }
            else if (username == "admin" && password == "admin")
            {
                OpenDashboard(new Admin_Dashboard());
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Open Dashboard
        private void OpenDashboard(Form dashboard)
        {
            this.Hide();
            dashboard.Show();
            ClearAllFields();
        }

        // Clear Fields
        private void ClearAllFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            ClearRegisterFields();
        }

        private void ClearRegisterFields()
        {
            txtRegisterUser.Clear();
            txtRegisterGmail.Clear();
            txtRegisterPassword.Clear();
            txtRegisterCPassword.Clear();
        }

        // Register Button Click
        private void btnRegister_Click(object sender, EventArgs e)
        {
            PerformRegister();
        }

        // Register Logic
        private void PerformRegister()
        {
            ClearRegisterFields();
            MessageBox.Show("Registration logic not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox_hvlogin_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox_hvlogin.Checked;
        }

        private void checkBox_reg_cPass_CheckedChanged(object sender, EventArgs e)
        {
            txtRegisterCPassword.UseSystemPasswordChar = !checkBox_reg_cPass.Checked;
        }

        private void checkBox_reg_pass_CheckedChanged(object sender, EventArgs e)
        {
            txtRegisterPassword.UseSystemPasswordChar = !checkBox_reg_pass.Checked;
        }
    }
}
