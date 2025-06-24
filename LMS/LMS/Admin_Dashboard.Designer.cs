
namespace LMS
{
    partial class Admin_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.elipseDashboard = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.picNavbar = new System.Windows.Forms.PictureBox();
            this.lblNavbar = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblLogout = new System.Windows.Forms.Label();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnCourse = new Guna.UI2.WinForms.Guna2Button();
            this.btnSolution = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaterial = new Guna.UI2.WinForms.Guna2Button();
            this.btnNotes = new Guna.UI2.WinForms.Guna2Button();
            this.profilePicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelSettingsMenu = new System.Windows.Forms.Panel();
            this.pnlTopbar = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTopbar = new System.Windows.Forms.Label();
            this.btnDeepseek = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnSetting = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNavbar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.pnlTopbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // elipseDashboard
            // 
            this.elipseDashboard.BorderRadius = 20;
            this.elipseDashboard.TargetControl = this;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNavbar.Controls.Add(this.picNavbar);
            this.pnlNavbar.Controls.Add(this.lblNavbar);
            this.pnlNavbar.Controls.Add(this.btnExit);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.ShadowDecoration.Parent = this.pnlNavbar;
            this.pnlNavbar.Size = new System.Drawing.Size(1200, 45);
            this.pnlNavbar.TabIndex = 2;
            // 
            // picNavbar
            // 
            this.picNavbar.Image = global::LMS.Properties.Resources.unnamed;
            this.picNavbar.Location = new System.Drawing.Point(10, 2);
            this.picNavbar.Name = "picNavbar";
            this.picNavbar.Size = new System.Drawing.Size(42, 40);
            this.picNavbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNavbar.TabIndex = 2;
            this.picNavbar.TabStop = false;
            // 
            // lblNavbar
            // 
            this.lblNavbar.AutoSize = true;
            this.lblNavbar.Font = new System.Drawing.Font("Gadugi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavbar.ForeColor = System.Drawing.Color.Gray;
            this.lblNavbar.Location = new System.Drawing.Point(61, 9);
            this.lblNavbar.Name = "lblNavbar";
            this.lblNavbar.Size = new System.Drawing.Size(482, 28);
            this.lblNavbar.TabIndex = 1;
            this.lblNavbar.Text = "LMS (Learning Managment System) | Admin";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.CheckedState.Parent = this.btnExit;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.HoverState.Image = global::LMS.Properties.Resources.icons8_close_48;
            this.btnExit.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.Image = global::LMS.Properties.Resources.icons8_close_48__1_;
            this.btnExit.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExit.Location = new System.Drawing.Point(1140, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedState.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(60, 45);
            this.btnExit.TabIndex = 0;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BorderRadius = 30;
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.lblLogout);
            this.pnlSidebar.Controls.Add(this.btnHome);
            this.pnlSidebar.Controls.Add(this.btnCourse);
            this.pnlSidebar.Controls.Add(this.btnSolution);
            this.pnlSidebar.Controls.Add(this.btnMaterial);
            this.pnlSidebar.Controls.Add(this.btnNotes);
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.pnlSidebar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.pnlSidebar.Location = new System.Drawing.Point(-58, 130);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.ShadowDecoration.Parent = this.pnlSidebar;
            this.pnlSidebar.Size = new System.Drawing.Size(294, 580);
            this.pnlSidebar.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.CheckedState.Parent = this.btnLogout;
            this.btnLogout.HoverState.Image = global::LMS.Properties.Resources.icons8_logout_50__1_;
            this.btnLogout.HoverState.Parent = this.btnLogout;
            this.btnLogout.Image = global::LMS.Properties.Resources.icons8_logout_50;
            this.btnLogout.Location = new System.Drawing.Point(82, 498);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.PressedState.Parent = this.btnLogout;
            this.btnLogout.Size = new System.Drawing.Size(51, 50);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseTransparentBackground = true;
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.BackColor = System.Drawing.Color.Transparent;
            this.lblLogout.Font = new System.Drawing.Font("Gadugi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.Gray;
            this.lblLogout.Location = new System.Drawing.Point(128, 509);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(87, 28);
            this.lblLogout.TabIndex = 1;
            this.lblLogout.Text = "Logout";
            // 
            // btnHome
            // 
            this.btnHome.Animated = true;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.btnHome.BorderRadius = 5;
            this.btnHome.CheckedState.Parent = this.btnHome;
            this.btnHome.CustomImages.Parent = this.btnHome;
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.HoverState.Image = global::LMS.Properties.Resources.icons8_home_48;
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = global::LMS.Properties.Resources.icons8_home_48__1_;
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.ImageSize = new System.Drawing.Size(30, 30);
            this.btnHome.Location = new System.Drawing.Point(72, 84);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnHome.ShadowDecoration.Parent = this.btnHome;
            this.btnHome.Size = new System.Drawing.Size(207, 44);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            // 
            // btnCourse
            // 
            this.btnCourse.Animated = true;
            this.btnCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.btnCourse.BorderRadius = 5;
            this.btnCourse.CheckedState.Parent = this.btnCourse;
            this.btnCourse.CustomImages.Parent = this.btnCourse;
            this.btnCourse.FillColor = System.Drawing.Color.Transparent;
            this.btnCourse.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourse.ForeColor = System.Drawing.Color.White;
            this.btnCourse.HoverState.Image = global::LMS.Properties.Resources.icons8_classroom_50;
            this.btnCourse.HoverState.Parent = this.btnCourse;
            this.btnCourse.Image = global::LMS.Properties.Resources.icons8_course_80;
            this.btnCourse.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCourse.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCourse.Location = new System.Drawing.Point(70, 332);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnCourse.ShadowDecoration.Parent = this.btnCourse;
            this.btnCourse.Size = new System.Drawing.Size(207, 44);
            this.btnCourse.TabIndex = 2;
            this.btnCourse.Text = "Course";
            // 
            // btnSolution
            // 
            this.btnSolution.Animated = true;
            this.btnSolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.btnSolution.BorderRadius = 5;
            this.btnSolution.CheckedState.Parent = this.btnSolution;
            this.btnSolution.CustomImages.Parent = this.btnSolution;
            this.btnSolution.FillColor = System.Drawing.Color.Transparent;
            this.btnSolution.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolution.ForeColor = System.Drawing.Color.White;
            this.btnSolution.HoverState.Image = global::LMS.Properties.Resources.icons8_knowledge_sharing_501;
            this.btnSolution.HoverState.Parent = this.btnSolution;
            this.btnSolution.Image = global::LMS.Properties.Resources.icons8_course_501;
            this.btnSolution.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSolution.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSolution.Location = new System.Drawing.Point(69, 270);
            this.btnSolution.Name = "btnSolution";
            this.btnSolution.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnSolution.ShadowDecoration.Parent = this.btnSolution;
            this.btnSolution.Size = new System.Drawing.Size(207, 44);
            this.btnSolution.TabIndex = 2;
            this.btnSolution.Text = "Solution";
            // 
            // btnMaterial
            // 
            this.btnMaterial.Animated = true;
            this.btnMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.btnMaterial.BorderRadius = 5;
            this.btnMaterial.CheckedState.Parent = this.btnMaterial;
            this.btnMaterial.CustomImages.Parent = this.btnMaterial;
            this.btnMaterial.FillColor = System.Drawing.Color.Transparent;
            this.btnMaterial.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterial.ForeColor = System.Drawing.Color.White;
            this.btnMaterial.HoverState.Image = global::LMS.Properties.Resources.icons8_press_kit_48;
            this.btnMaterial.HoverState.Parent = this.btnMaterial;
            this.btnMaterial.Image = global::LMS.Properties.Resources.icons8_press_kit_48__1_;
            this.btnMaterial.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMaterial.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMaterial.Location = new System.Drawing.Point(72, 208);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMaterial.ShadowDecoration.Parent = this.btnMaterial;
            this.btnMaterial.Size = new System.Drawing.Size(207, 44);
            this.btnMaterial.TabIndex = 2;
            this.btnMaterial.Text = " Material";
            // 
            // btnNotes
            // 
            this.btnNotes.Animated = true;
            this.btnNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.btnNotes.BorderRadius = 5;
            this.btnNotes.CheckedState.Parent = this.btnNotes;
            this.btnNotes.CustomImages.Parent = this.btnNotes;
            this.btnNotes.FillColor = System.Drawing.Color.Transparent;
            this.btnNotes.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotes.ForeColor = System.Drawing.Color.White;
            this.btnNotes.HoverState.Image = global::LMS.Properties.Resources.icons8_notes_50;
            this.btnNotes.HoverState.Parent = this.btnNotes;
            this.btnNotes.Image = global::LMS.Properties.Resources.icons8_task_50;
            this.btnNotes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNotes.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNotes.Location = new System.Drawing.Point(72, 146);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnNotes.ShadowDecoration.Parent = this.btnNotes;
            this.btnNotes.Size = new System.Drawing.Size(207, 44);
            this.btnNotes.TabIndex = 2;
            this.btnNotes.Text = "Notes";
            // 
            // profilePicture
            // 
            this.profilePicture.BackColor = System.Drawing.Color.Transparent;
            this.profilePicture.Image = global::LMS.Properties.Resources.unnamed;
            this.profilePicture.Location = new System.Drawing.Point(24, 49);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.profilePicture.ShadowDecoration.Parent = this.profilePicture;
            this.profilePicture.Size = new System.Drawing.Size(161, 156);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePicture.TabIndex = 4;
            this.profilePicture.TabStop = false;
            this.profilePicture.UseTransparentBackground = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.guna2GradientPanel1);
            this.pnlMain.Controls.Add(this.pnlTopbar);
            this.pnlMain.Location = new System.Drawing.Point(255, 51);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(945, 650);
            this.pnlMain.TabIndex = 5;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.panelSettingsMenu);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 82);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(945, 568);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // panelSettingsMenu
            // 
            this.panelSettingsMenu.Location = new System.Drawing.Point(790, 20);
            this.panelSettingsMenu.Name = "panelSettingsMenu";
            this.panelSettingsMenu.Size = new System.Drawing.Size(0, 0);
            this.panelSettingsMenu.TabIndex = 0;
            this.panelSettingsMenu.Visible = false;
            // 
            // pnlTopbar
            // 
            this.pnlTopbar.BorderRadius = 20;
            this.pnlTopbar.Controls.Add(this.lblTopbar);
            this.pnlTopbar.Controls.Add(this.btnDeepseek);
            this.pnlTopbar.Controls.Add(this.btnSetting);
            this.pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(160)))), ((int)(((byte)(225)))));
            this.pnlTopbar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopbar.Name = "pnlTopbar";
            this.pnlTopbar.ShadowDecoration.Parent = this.pnlTopbar;
            this.pnlTopbar.Size = new System.Drawing.Size(945, 76);
            this.pnlTopbar.TabIndex = 2;
            // 
            // lblTopbar
            // 
            this.lblTopbar.AutoSize = true;
            this.lblTopbar.BackColor = System.Drawing.Color.Transparent;
            this.lblTopbar.Font = new System.Drawing.Font("Gadugi", 26F, System.Drawing.FontStyle.Bold);
            this.lblTopbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTopbar.Location = new System.Drawing.Point(26, 13);
            this.lblTopbar.Name = "lblTopbar";
            this.lblTopbar.Size = new System.Drawing.Size(148, 52);
            this.lblTopbar.TabIndex = 2;
            this.lblTopbar.Text = "Home";
            this.lblTopbar.Click += new System.EventHandler(this.lblTopbar_Click);
            // 
            // btnDeepseek
            // 
            this.btnDeepseek.BackColor = System.Drawing.Color.Transparent;
            this.btnDeepseek.CheckedState.Parent = this.btnDeepseek;
            this.btnDeepseek.HoverState.Image = global::LMS.Properties.Resources.icons8_deepseek_50__1_;
            this.btnDeepseek.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDeepseek.HoverState.Parent = this.btnDeepseek;
            this.btnDeepseek.Image = global::LMS.Properties.Resources.icons8_deepseek_50;
            this.btnDeepseek.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDeepseek.Location = new System.Drawing.Point(864, 12);
            this.btnDeepseek.Name = "btnDeepseek";
            this.btnDeepseek.PressedState.Parent = this.btnDeepseek;
            this.btnDeepseek.Size = new System.Drawing.Size(51, 50);
            this.btnDeepseek.TabIndex = 1;
            this.btnDeepseek.UseTransparentBackground = true;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.CheckedState.Parent = this.btnSetting;
            this.btnSetting.HoverState.Image = global::LMS.Properties.Resources.icons8_settings_50;
            this.btnSetting.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSetting.HoverState.Parent = this.btnSetting;
            this.btnSetting.Image = global::LMS.Properties.Resources.icons8_setting_50;
            this.btnSetting.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSetting.Location = new System.Drawing.Point(807, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.PressedState.Parent = this.btnSetting;
            this.btnSetting.Size = new System.Drawing.Size(51, 50);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.UseTransparentBackground = true;
            // 
            // Admin_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlNavbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adimn_Dashboard";
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNavbar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.pnlTopbar.ResumeLayout(false);
            this.pnlTopbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse elipseDashboard;
        private Guna.UI2.WinForms.Guna2Panel pnlNavbar;
        private System.Windows.Forms.PictureBox picNavbar;
        private System.Windows.Forms.Label lblNavbar;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlSidebar;
        private Guna.UI2.WinForms.Guna2ImageButton btnLogout;
        private System.Windows.Forms.Label lblLogout;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnCourse;
        private Guna.UI2.WinForms.Guna2Button btnSolution;
        private Guna.UI2.WinForms.Guna2Button btnMaterial;
        private Guna.UI2.WinForms.Guna2Button btnNotes;
        private Guna.UI2.WinForms.Guna2CirclePictureBox profilePicture;
        private System.Windows.Forms.Panel pnlMain;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Panel panelSettingsMenu;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTopbar;
        private System.Windows.Forms.Label lblTopbar;
        private Guna.UI2.WinForms.Guna2ImageButton btnDeepseek;
        private Guna.UI2.WinForms.Guna2ImageButton btnSetting;
    }
}