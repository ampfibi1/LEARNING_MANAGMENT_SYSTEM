using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using LMS.dbConnection;
using LMS.Services;
using System.Data.Entity; 
using System.Linq;

namespace LMS
{
    public partial class User_Dashboard : BaseForm
    {

        private static readonly HttpClient client = new HttpClient();

        int userId;
        string imageLocation = "";
        bool mode;
        string upload_note_file = "";
        string upload_material_file = "";


        private UserDB db;
        private ChatBotService chatService;


        public User_Dashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            pnlHome.Visible = true;
            pnlSettings.Visible = false;
            pnlChatBot.Visible = false;
            pnlNotes.Visible = false;
            pnlMaterial.Visible = false;
            pnlNotes_addNew.Visible = false;
            pnlbtnAddNew_pnlMaterial.Visible = false; 

            txtNewPass.UseSystemPasswordChar = true;
            txtConfirmPass.UseSystemPasswordChar = true;

            db = new UserDB();
            chatService = new ChatBotService();

            mode = db.display_mode_search(userId);
            Load_profile_pic();
            Load_display_mode();
            Load_Home();
        }
        private void Load_Home()
        {
            using (var db = new LMS_TESTEntities())
            {
                noteBindingSource1.DataSource =
                    db.notes.Include(n => n.user_info)
                    .Where(n => n.status == 1 && n.user_id == userId)
                    .ToList();

                noteBindingSource2.DataSource =
                    db.notes.Include(n => n.user_info)
                    .Where(n => n.status == 0 && n.user_id == userId)
                    .ToList();
            }
        }

        private void Load_display_mode()
        {
            this.BackColor = mode ? Color.AliceBlue : Color.DarkGray;
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
            load_DGVgrid();
            hide_all_main_pnl(pnlNotes);
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Course Material";
            load_dgv_pnlMaterial();
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

            if (string.IsNullOrEmpty(npass) || string.IsNullOrEmpty(cpass))
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
            if (mode) return;
            string query = $"UPDATE user_info SET display_mode = {1} WHERE id = {userId}";
            db.update_info(query);
            mode = true;
            Load_display_mode();
        }

        private void btnSe_Dark_mode_click(object sender, EventArgs e)
        {
            if (!mode) return;
            string query = $"UPDATE user_info SET display_mode = {0} WHERE id = {userId}";
            db.update_info(query);
            mode = false;
            Load_display_mode();
        }

        private void btnNotes_add_new_notes_Click(object sender, EventArgs e)
        {
            pnlNotes_addNew.Visible = true;
        }

        private void btnClose_pnlNotes_addNew_Click(object sender, EventArgs e)
        {
            pnlNotes_addNew.Visible = false;
        }

        private void btnFile_pnlNotes_addNew_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Text Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are You Sure", "ADD", MessageBoxButtons.OK);
                    if (dialog == DialogResult.OK)
                    {
                        upload_note_file = dlg.FileName;
                        //uploadFile(filename);
                        //byte[] contents = File.ReadAllBytes(upload_note_file);
                    }
                }
                else { return; }
            }
        }
        private void btnUpload_pnlNotes_addNew_Click(object sender, EventArgs e)
        {
            string course_name = txtCourseName_pnlNotes_addNew.Text;

            if (string.IsNullOrEmpty(course_name) || string.IsNullOrEmpty(upload_note_file))
            {
                MessageBox.Show("Fill All Field");
                return;
            }
            uploadFile(upload_note_file);
            Load_Home();
            txtCourseName_pnlNotes_addNew.Clear();
            upload_note_file = "";
        }
        private void uploadFile(string filename)
        {
            try
            {
                byte[] contents = File.ReadAllBytes(filename);
                string fileName = Path.GetFileName(filename);
                string course_name = txtCourseName_pnlNotes_addNew.Text;

                using (var db = new LMS_TESTEntities())
                {
                    note newNote = new note
                    {
                        file_name = fileName,
                        pdf_file = contents,
                        user_id = userId,
                        course_name = course_name
                    };

                    db.notes.Add(newNote);
                    db.SaveChanges();
                    load_DGVgrid();
                    MessageBox.Show("Note pending!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message);
            }
        }

        private void load_DGVgrid()
        {
            using (var db = new LMS_TESTEntities())
            {
                noteBindingSource.DataSource =
                    db.notes.Include(n => n.user_info).
                    Where(n => n.status == 1).ToList();
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_Login_Register loginpage = new form_Login_Register();
            loginpage.Show();
        }

        private void btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            pnlbtnAddNew_pnlMaterial.Visible = true;
        }

        private void btnClose_btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            pnlbtnAddNew_pnlMaterial.Visible = false;
        }

        private void btnFile_btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Documents (*.pdf;*.ppt;*.pptx;*.doc;*.docx)|*.pdf;*.ppt;*.pptx;*.doc;*.docx", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are You Sure", "ADD", MessageBoxButtons.OK);
                    if (dialog == DialogResult.OK)
                    {
                        upload_material_file = dlg.FileName;
                        //uploadFile(filename);
                        //byte[] contents = File.ReadAllBytes(upload_note_file);
                    }
                }
                else { return; }
            }
        }

        private void btnUpload_btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            string course_name = txtCourse_btnAddNew_pnlMaterial.Text;

            if (string.IsNullOrEmpty(course_name) || string.IsNullOrEmpty(upload_material_file))
            {
                MessageBox.Show("Fill All Field");
                return;
            }
            uploadMFile(upload_material_file);
            txtCourseName_pnlNotes_addNew.Clear();
            upload_note_file = "";
        }

        private void uploadMFile(string filename)
        {
            try
            {
                byte[] contents = File.ReadAllBytes(filename);
                string fileName = Path.GetFileName(filename);
                string course_name = txtCourse_btnAddNew_pnlMaterial.Text;

                using (var db = new LMS_TESTEntities())
                {
                    material metarial = new material
                    {
                        file_name = fileName,
                        file_path = contents,
                        user_id = userId,
                        course_name = course_name
                    };

                    db.materials.Add(metarial);
                    db.SaveChanges();
                    load_dgv_pnlMaterial();
                    MessageBox.Show("Materials uploaded successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message);
            }
        }

        private void load_dgv_pnlMaterial()
        {
            using (var db = new LMS_TESTEntities())
            {
                materialBindingSource.DataSource =
                    db.materials.Include(n => n.user_info).
                    Where(n => n.status == 1).ToList();
            }
        }

        private void btnDownloadNotes_Click(object sender, EventArgs e)
        {
            if (dgv_notes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Row Not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            note selectedNote = (note)dgv_notes.SelectedRows[0].DataBoundItem;
            int select_notesID = selectedNote.notes_id;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "All Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you Sure?", "Sure", MessageBoxButtons.OK);
                    if (dialog == DialogResult.OK)
                    {
                        string filename = sfd.FileName;
                        download_notes(filename, select_notesID);
                    }
                }
            }
        }
        private void download_notes(string filename, int notesId)
        {
            try
            {
                using (var db = new LMS_TESTEntities())
                {
                    var noteToDownload = db.notes.FirstOrDefault(n => n.notes_id == notesId);

                    if (noteToDownload != null)
                    {
                        File.WriteAllBytes(filename, noteToDownload.pdf_file);
                        MessageBox.Show("Successfully Downloaded", "Download", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Note not found", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during download: " + ex.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_materials_Click(object sender, EventArgs e)
        {
            if (dgv_pnlMaterial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Row Not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            material selected = (material)dgv_pnlMaterial.SelectedRows[0].DataBoundItem;
            int select_materialID = selected.m_id;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "All Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you Sure?", "Sure", MessageBoxButtons.OK);
                    if (dialog == DialogResult.OK)
                    {
                        string filename = sfd.FileName;
                        download_material(filename, select_materialID);
                    }
                }
            }
        }
        private void download_material(string filename, int materialId)
        {
            try
            {
                using (var db = new LMS_TESTEntities())
                {
                    var noteToDownload = db.materials.FirstOrDefault(n => n.m_id == materialId);

                    if (noteToDownload != null)
                    {
                        File.WriteAllBytes(filename, noteToDownload.file_path);
                        MessageBox.Show("Successfully Downloaded", "Download", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Note not found", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during download: " + ex.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnSeacrh_pnlMaterial_Click(object sender, EventArgs e)
        {
            string search = txtSearch_pnlMaterial.Text.ToUpper();
            using (var db = new LMS_TESTEntities())
            {
                if (string.IsNullOrEmpty(search))
                {
                    noteBindingSource.DataSource =
                    db.materials.Include(m => m.user_info).
                    Where(m => m.status == 1).ToList();
                    return;
                }
                noteBindingSource.DataSource =
                    db.materials.Include(n => n.user_info).
                    Where(n => n.status == 1 && n.course_name.ToUpper() == search).ToList();
            }
        }

        private void btnNotes_course_search_Click(object sender, EventArgs e)
        {
            string search = txtNotes_Course_search.Text.ToUpper();
            using (var db = new LMS_TESTEntities())
            {
                if (string.IsNullOrEmpty(search))
                {
                    noteBindingSource.DataSource =
                    db.notes.Include(n => n.user_info).
                    Where(n => n.status == 1).ToList();
                    return;
                }
                noteBindingSource.DataSource =
                    db.notes.Include(n => n.user_info).
                    Where(n => n.status == 1 && n.course_name.ToUpper() == search).ToList();
            }
        }
    }
}
