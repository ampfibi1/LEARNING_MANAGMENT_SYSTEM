using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace LMS
{
    public partial class Admin_Dashboard : BaseForm
    {
        private string upload_note_file = "";
        private string upload_material_file = "";
        private readonly int userId; 
        public Admin_Dashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId; 
            pnlHome.Visible = true;
            pnlNotes.Visible = false;
            pnlMaterial.Visible = false;
            pnlNotes_addNew.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTopbar_Click(object sender, EventArgs e)
        {

        }

        
        private void hide_all_main_pnl(Panel pnl)
        {
            pnlNotes.Visible = false;
            pnlMaterial.Visible = false;
            pnlHome.Visible = false;

            pnl.Visible = true;
        }
        private void load_DGVgrid()
        {
            using (var db = new LMS_TESTEntities())
            {
                noteBindingSource.DataSource =
                    db.notes.Include(n => n.user_info).
                    Where(n => n.status == 0).ToList();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_Login_Register loginpage = new form_Login_Register();
            loginpage.Show();
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
                        course_name = course_name,
                        status = 1
                    };

                    db.notes.Add(newNote);
                    db.SaveChanges();
                    load_DGVgrid();
                    MessageBox.Show("Note uploaded successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed: " + ex.Message);
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

        private void btnNotes_delete_new_notes_Click(object sender, EventArgs e)
        {
            if (dgv_notes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            note selectedNote = (note)dgv_notes.SelectedRows[0].DataBoundItem;
            int select_notesID = selectedNote.notes_id;

            using (var db = new LMS_TESTEntities())
            {
                var noteToDelete = db.notes.Find(select_notesID);
                if (noteToDelete != null)
                {
                    db.notes.Remove(noteToDelete);
                    db.SaveChanges();
                    MessageBox.Show("Note deleted successfully.");
                }
            }

            load_DGVgrid(); 
        }


        private void btnNotes_approve_Click(object sender, EventArgs e)
        {
            if (dgv_notes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to approve.");
                return;
            }

            note selectedNote = (note)dgv_notes.SelectedRows[0].DataBoundItem;
            int select_notesID = selectedNote.notes_id;

            using (var db = new LMS_TESTEntities())
            {
                var noteToApprove = db.notes.Find(select_notesID);
                if (noteToApprove != null)
                {
                    noteToApprove.status = 1;
                    db.SaveChanges();
                    MessageBox.Show("Note approved successfully.");
                }
            }
            load_DGVgrid();
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

        private void btnClose_btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            pnlbtnAddNew_pnlMaterial.Visible = false;
        }

        private void btnAddNew_pnlMaterial_Click(object sender, EventArgs e)
        {
            pnlbtnAddNew_pnlMaterial.Visible = true;
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
                        course_name = course_name,
                        status = 1
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
                    Where(n => n.status == 0).ToList();
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

        private void btnApprove_pnlMaterial_Click(object sender, EventArgs e)
        {
            if (dgv_pnlMaterial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to approve.");
                return;
            }

            material selectedmaterial = (material)dgv_pnlMaterial.SelectedRows[0].DataBoundItem;
            int select_materialID = selectedmaterial.m_id;

            using (var db = new LMS_TESTEntities())
            {
                var mToApprove = db.materials.Find(select_materialID);
                if (mToApprove != null)
                {
                    mToApprove.status = 1;
                    db.SaveChanges();
                    MessageBox.Show("Note approved successfully.");
                }
            }
            load_dgv_pnlMaterial();
        }

        private void btnDelete_pnlMaterial_Click(object sender, EventArgs e)
        {
            if (dgv_pnlMaterial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            material selectedmaterial = (material)dgv_pnlMaterial.SelectedRows[0].DataBoundItem;
            int select_materialID = selectedmaterial.m_id;

            using (var db = new LMS_TESTEntities())
            {
                var mToDelete = db.materials.Find(select_materialID);
                if (mToDelete != null)
                {
                    db.materials.Remove(mToDelete);
                    db.SaveChanges();
                    MessageBox.Show("Note deleted successfully.");
                }
            }

            load_dgv_pnlMaterial();
        }
    }
}
