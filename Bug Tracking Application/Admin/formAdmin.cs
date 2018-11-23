using System;
using System.Windows.Forms;


namespace Bug_Tracking_Application.Admin
{   
    public partial class formAdmin : Form
    {
        formAdminHome formAdminHome;
        formAddAdmin formAddAdmin;
        formAddProject formAddProject;
        formAddBugAppointment formAddBugAppointment;
        formViewBugAppointment formViewBugAppointment;
        formEditBugAppointment formEditBugAppointment;
        formEditUser formEditUser;
        formViewProjectNames formViewProjectNames;
        formEditProjectNames formEditProjectNames;
        formViewBugAudit formViewBugAudit;
        formManageUsers formManageUsers;
        String userId, userName;
        public formAdmin(String userName, String userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
            lblWelcome.Text = "User Type : ADMIN   Welcome, " + userName;
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            formAdminHome = new formAdminHome(userId);
            formAddAdmin = new formAddAdmin();
            formAddProject = new formAddProject();
            formAddBugAppointment = new formAddBugAppointment();
            formViewBugAppointment = new formViewBugAppointment();
            formEditBugAppointment = new formEditBugAppointment();
            formEditUser = new formEditUser(userId);
            formViewProjectNames = new formViewProjectNames();
            formEditProjectNames = new formEditProjectNames();
            formViewBugAudit = new formViewBugAudit();
            formManageUsers = new formManageUsers();
            formAdminHome.MdiParent = this;
            formAdminHome.Show();
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAdminHome.Visible)
            {
                formAdminHome = new formAdminHome(userId);
                formAdminHome.MdiParent = this;
                formAdminHome.Show();
            }
            else
            {
                formAdminHome.Activate();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formLogin = new formLogin();
            formLogin.ShowDialog();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAddAdmin.Visible)
            {
                formAddAdmin = new formAddAdmin();
                formAddAdmin.MdiParent = this;
                formAddAdmin.Show();
            }
            else
            {
                formAddAdmin.Activate();
            }
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAddProject.Visible)
            {
                formAddProject = new formAddProject();
                formAddProject.MdiParent = this;
                formAddProject.Show();
            }
            else
            {
                formAddProject.Activate();
            }
        }

        private void appointBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAddBugAppointment.Visible)
            {
                formAddBugAppointment = new formAddBugAppointment();
                formAddBugAppointment.MdiParent = this;
                formAddBugAppointment.Show();
            }
            else
            {
                formAddBugAppointment.Activate();
            }
        }

        private void bugAppointedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formViewBugAppointment.Visible)
            {
                formViewBugAppointment = new formViewBugAppointment();
                formViewBugAppointment.MdiParent = this;
                formViewBugAppointment.Show();
            }
            else
            {
                formViewBugAppointment.Activate();
            }
        }

        private void bugsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formEditBugAppointment.Visible)
            {
                formEditBugAppointment = new formEditBugAppointment();
                formEditBugAppointment.MdiParent = this;
                formEditBugAppointment.Show();
            }
            else
            {
                formEditBugAppointment.Activate();
            }
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

        private void projectsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!formViewProjectNames.Visible)
            {
                formViewProjectNames = new formViewProjectNames();
                formViewProjectNames.MdiParent = this;
                formViewProjectNames.Show();
            }
            else
            {
                formViewProjectNames.Activate();
            }
        }

        private void projectsToolStripMenuItem2_Click(object sender, EventArgs e)
        {            
            if (!formEditProjectNames.Visible)
            {
                formEditProjectNames = new formEditProjectNames();
                formEditProjectNames.MdiParent = this;
                formEditProjectNames.Show();
            }
            else
            {
                formEditProjectNames.Activate();
            }

        }

        private void bugHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formViewBugAudit.Visible)
            {
                formViewBugAudit = new formViewBugAudit();
                formViewBugAudit.MdiParent = this;
                formViewBugAudit.Show();
            }
            else
            {
                formViewBugAudit.Activate();
            }
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!formManageUsers.Visible)
            {
                formManageUsers = new formManageUsers();
                formManageUsers.MdiParent = this;
                formManageUsers.Show();
            }
            else
            {
                formManageUsers.Activate();
            }
        }

        private void liveRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveRepo liveRepo = new LiveRepo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
