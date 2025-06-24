using System;
using System.Windows.Forms;

namespace LMS
{
    public class BaseForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
