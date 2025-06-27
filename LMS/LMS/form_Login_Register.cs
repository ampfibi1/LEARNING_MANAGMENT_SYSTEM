using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace LMS
{
    public partial class form_Login_Register : BaseForm
    {
        private string connString = @"Data Source=ABDULLAH-TAMJID\SQLEXPRESS01;Initial Catalog=LMS_TEST;Integrated Security=True";

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
            string user_name = txtUserName.Text;
            string password = txtPassword.Text;


            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password) )
            {
                MessageBox.Show("fill all field.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClearAllFields();

            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                string query = $"select id,role from user_info where user_name='{user_name}' and password='{password}'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int role = (int)reader["role"];
                    int userId = (int)reader["id"];


                    if (role == 0) OpenDashboard(new User_Dashboard(userId));
                    else OpenDashboard(new Admin_Dashboard(userId));
                }
                else
                {
                    MessageBox.Show("invalid user and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
            string user_name = txtRegisterUser.Text; 
            string gmail = txtRegisterGmail.Text; 
            string password = txtRegisterPassword.Text;
            string confirm_password = txtRegisterCPassword.Text;

            if (password != confirm_password)
            {
                MessageBox.Show("password and confirm pass not same.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(gmail) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm_password))
            {
                MessageBox.Show("fill all field.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearRegisterFields();
            string defaultImagePath = @"P:\LMS\LMS\Resources\unnamed.png";
            byte[] img;

            if (!File.Exists(defaultImagePath))
            {
                MessageBox.Show("Default image not found.");
                return;
            }
            
            try
            {
                FileStream stream = new FileStream(defaultImagePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(stream);
                img = br.ReadBytes((int)stream.Length);

                SqlConnection con = new SqlConnection(connString);
                con.Open();

                string query = $"insert into user_info (user_name,gmail,password,profile_pic) values('{user_name}','{gmail}','{password}',@pic)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@pic", img);

                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRegisterFields();
                }
                else
                {
                    MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
