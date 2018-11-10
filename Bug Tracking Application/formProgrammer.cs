using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Programmer
{    
    public partial class formProgrammer : Form
    {
        formEditUser formEditUser;
        string userId;
        public formProgrammer(string userName, string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formLogin = new formLogin();
            formLogin.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void assignedBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formEditUser.Visible)
            {
                formEditUser = new formEditUser(userId);
                formEditUser.MdiParent = this;
                formEditUser.Show();
            }
            else
            {
                formEditUser.Activate();
            }
        }

        private void formProgrammer_Load(object sender, EventArgs e)
        {

        }
    }
}
