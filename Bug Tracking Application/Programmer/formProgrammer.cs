using System;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Programmer
{    
    public partial class formProgrammer : Form
    {
        formProgrammerHome formProgrammerHome;
        formEditUser formEditUser;
        formAddSolutions formAddSolutions;
        formViewAssignedBugs formViewAssignedBugs;
        formEditBugSolution formEditBugSolution;

        public string userId;
        public string userName;
        public formProgrammer(string userName, string userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formProgrammerHome.Visible)
            {
                formProgrammerHome = new formProgrammerHome(userId);
                formProgrammerHome.MdiParent = this;
                formProgrammerHome.Show();
            }
            else
            {
                formProgrammerHome.Activate();
            }
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAddSolutions.Visible)
            {
                formAddSolutions = new formAddSolutions(userId);
                formAddSolutions.MdiParent = this;
                formAddSolutions.Show();
            }
            else
            {
                formAddSolutions.Activate();
            }
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
            if (!formViewAssignedBugs.Visible)
            {
                formViewAssignedBugs = new formViewAssignedBugs(userId);
                formViewAssignedBugs.MdiParent = this;
                formViewAssignedBugs.Show();
            }
            else
            {
                formViewAssignedBugs.Activate();
            }
        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formEditBugSolution.Visible)
            {
                formEditBugSolution = new formEditBugSolution(userId);
                formEditBugSolution.MdiParent = this;
                formEditBugSolution.Show();
            }
            else
            {
                formEditBugSolution.Activate();
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

        private void formProgrammer_Load(object sender, EventArgs e)
        {            
            formProgrammerHome = new formProgrammerHome(userId);
            formProgrammerHome.MdiParent = this;
            formProgrammerHome.Show();
            formEditUser = new formEditUser(userId);
            formAddSolutions = new formAddSolutions(userId);
            formViewAssignedBugs = new formViewAssignedBugs(userId);
            formEditBugSolution = new formEditBugSolution(userId);
        }        

    }
}
