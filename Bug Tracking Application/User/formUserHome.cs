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
    public partial class formUserHome : Form
    {
        DBConnect dbConn = new DBConnect();
        formUserReportBug formReportBug;
        formUserEditBugReport formUserEditBugReport;
        formEditUser formEditUser;
        string userId;
        public formUserHome(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;            
            formReportBug = new formUserReportBug(userId);
            formUserEditBugReport = new formUserEditBugReport(userId);
            formEditUser = new formEditUser(userId);
            loadFormDetails();
        }

        private void loadFormDetails()
        {
            int numOfBugs = dbConn.Count("SELECT Count(*) FROM bugreports where userid = '" + userId + "';");
            int numOfBugsSolved = dbConn.Count("SELECT Count(*) FROM bugreports where userid = '" + userId 
                + "' AND status = 'solved';");
            int numOfBugsUnsolved = dbConn.Count("SELECT Count(*) FROM bugreports where userid = '" + userId 
                + "' AND status = 'not solved';");
            lblBugsFound.Text = numOfBugs.ToString();
            lblBugsSolved.Text = numOfBugsSolved.ToString();
            lblBugsUnsolved.Text = numOfBugsUnsolved.ToString();            
        }

        private void formUserHome_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAddBugReport_Click(object sender, EventArgs e)
        {
            if (!formReportBug.Visible)
            {
                formReportBug = new formUserReportBug(userId);
                formReportBug.MdiParent = this.ParentForm; //this refers to f1's parent, the MainForm
                formReportBug.Show();
            }
            else
            {
                formReportBug.Activate();
            }
        }

        private void btnEditBugReport_Click(object sender, EventArgs e)
        {
            if (!formUserEditBugReport.Visible)
            {
                formUserEditBugReport = new formUserEditBugReport(userId);
                formUserEditBugReport.MdiParent = this.ParentForm;
                formUserEditBugReport.Show();
            }
            else
            {
                formUserEditBugReport.Activate();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!formEditUser.Visible)
            {
                formEditUser = new formEditUser(userId);
                formEditUser.MdiParent = this.ParentForm;
                formEditUser.Show();
            }
            else
            {
                formEditUser.Activate();
            }
        }
    }
}
