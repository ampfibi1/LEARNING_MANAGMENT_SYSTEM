using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using LMS.dbConnection;
using LMS.Services;


namespace LMS
{
    public partial class User_Dashboard : BaseForm
    {

        private static readonly HttpClient client = new HttpClient();
        
        int userId;
        string imageLocation = "";

        private UserDB db;
        private ChatBotService chatService;


        public User_Dashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            pnlHome.Visible = true;
            pnlSettings.Visible = false ;
            pnlChatBot.Visible = false ;
            pnlNotes.Visible = false;
            pnlMaterial.Visible = false;

            txtNewPass.UseSystemPasswordChar = true;
            txtConfirmPass.UseSystemPasswordChar = true;

            db = new UserDB();
            chatService = new ChatBotService();

            Load_profile_pic();
            Load_display_mode();
        }

        private void Load_display_mode()
        {
            bool f = db.display_mode_search(userId);
            this.BackColor = f ? Color.AliceBlue : Color.DarkGray;
        }
        private void Load_profile_pic()
        {
            MemoryStream ms = db.load_image(userId); 
            if (ms != null)
            {
                profilePic.Image = Image.FromStream(ms);
                profilePic1.Image = Image.FromStream(ms);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Home";
            hide_all_main_pnl(pnlHome);
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Notes";
            hide_all_main_pnl(pnlNotes);
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Course Material";
            hide_all_main_pnl(pnlMaterial);
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Course Solution";
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Courses";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Settings";
            hide_all_main_pnl(pnlSettings);
        }

        private void hide_all_main_pnl(Panel pnl)
         {
            pnlSettings.Visible = false;
            pnlChatBot.Visible = false;
            pnlNotes.Visible = false;
            pnlMaterial.Visible = false;
            pnlHome.Visible = false;

            pnl.Visible = true;
         }

        private void btnProfilePic_edit_Click(object sender, EventArgs e)
        {

        }

        private void btnCngUser_Click(object sender, EventArgs e)
        {
            pnlSe3.Height = 120; 
        }

        private void btnUCng_Click(object sender, EventArgs e)
        {
            pnlSe3.Height = 44;
            string uname = txtCngUser.Text; 
            
            if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("Fill user name");
                return;
            }
            txtCngUser.Clear();
            string query = $"UPDATE user_info SET user_name='{uname}' WHERE id = {userId}";

            db.update_info(query);
           
        }

        private void btnCngMail_Click(object sender, EventArgs e)
        {
            pnlSe4.Height = 120;
        }

        private void btnChangeMail_Click(object sender, EventArgs e)
        {
            pnlSe4.Height = 44;
            string mail = txtChangeMail.Text;

            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Fill G-mail");
                return;
            }
            txtCngUser.Clear();
            string query = $"UPDATE user_info SET gmail='{mail}' WHERE id = {userId}";

            db.update_info(query);
        }

        private void btnCngPass_Click(object sender, EventArgs e)
        {
            pnlSe5.Height = 230; 
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            pnlSe5.Height = 55;
            string npass = txtNewPass.Text; 
            string cpass = txtConfirmPass.Text;
            
            if(string.IsNullOrEmpty(npass) || string.IsNullOrEmpty(cpass))
            {
                MessageBox.Show("Fill the password fiels");
                return;
            }
            if (npass != cpass) 
            {
                MessageBox.Show("New password & Confirm password not match");
                return;
            }
            txtCngUser.Clear();
            string query = $"UPDATE user_info SET password='{npass}' WHERE id = {userId}";

            db.update_info(query);
        }

        private void btnDeepseek_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Chat-Bot";
            hide_all_main_pnl(pnlChatBot);
        }

        private async void btnUserSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserChat.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            AddChatMessage(userInput, true); // User message
            string response = await chatService.GetResponseAsync(userInput);

            AddChatMessage(response, false); // Bot message

            txtUserChat.Clear();
        }
        private void AddChatMessage(string message, bool isUser)
        {
            Label messageLabel = new Label();
            messageLabel.AutoSize = true;
            messageLabel.MaximumSize = new Size(pnlChat_bot_user.Width - 40, 0); // wrap text
            messageLabel.Text = message;
            messageLabel.Padding = new Padding(10);
            messageLabel.BackColor = isUser ? Color.LightGreen : Color.LightGray;
            messageLabel.Font = new Font("Segoe UI", 10);
            messageLabel.Margin = new Padding(10);

            pnlChat_bot_user.Controls.Add(messageLabel);
            pnlChat_bot_user.ScrollControlIntoView(messageLabel);
        }
        
        private void btnSeEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PNG files (*.png)|*.png|JPG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dlg.FileName.ToString();

                bool f = db.UpdateProfilePicture(userId, imageLocation);
                
                if (f)
                {
                    MessageBox.Show("Profile picture updated successfully.");
                    Load_profile_pic();
                }
                else
                {
                    MessageBox.Show("No user found to update.");
                }
            }
        }
        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = !checkBox_pass.Checked;
        }

        private void checkBox_cPass_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = !checkBox_cPass.Checked;
        }

        private void btnSe_light_mode_click(object sender, EventArgs e)
        {
            string query = $"UPDATE user_info SET display_mode = {1} WHERE id = {userId}";
            db.update_info(query);
            Load_display_mode();
        }

        private void btnSe_Dark_mode_click(object sender, EventArgs e)
        {
            string query = $"UPDATE user_info SET display_mode = {0} WHERE id = {userId}";
            db.update_info(query);
            Load_display_mode();
        }
    }
}
