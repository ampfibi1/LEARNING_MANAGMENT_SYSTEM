using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class User_Dashboard : BaseForm
    {
        public User_Dashboard()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Home";
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Notes";
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            lblTopbar.Text = "Course Material";
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
      

    }
}
