using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application
{
    
    public partial class formUser : Form
    {
        
        formUserHome formHome;
        formUserReportBug formReportBug;
        formUserEditBugReport formUserEditBugReport;
        formEditUser formEditUser;
        string userId;
        
        public formUser(string userName,string userId)
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome, " + userName;            
            this.userId = userId;
            
        }

        private void formUser_Load(object sender, EventArgs e)
        {            
            formReportBug = new formUserReportBug(userId);
            formUserEditBugReport = new formUserEditBugReport(userId);
            formEditUser = new formEditUser(userId);
            WindowState = FormWindowState.Maximized;
            formHome = new formUserHome(userId);
            formHome.MdiParent = this;
            formHome.Show();

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formHome.Visible)
            {
                formHome = new formUserHome(userId);
                formHome.MdiParent = this;
                formHome.Show();
            }
            else
            {
                formHome.Activate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formLogin = new formLogin();
            formLogin.ShowDialog();
            this.Close();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (!formReportBug.Visible)
            {
                formReportBug = new formUserReportBug(userId);
                formReportBug.MdiParent = this;
                formReportBug.Show();                
            }
            else {
                formReportBug.Activate();
            }            
        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formUserEditBugReport.Visible)
            {
                formUserEditBugReport = new formUserEditBugReport(userId);
                formUserEditBugReport.MdiParent = this;
                formUserEditBugReport.Show();
            }
            else
            {
                formUserEditBugReport.Activate();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
