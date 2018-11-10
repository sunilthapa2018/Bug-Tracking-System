using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Admin
{
    public partial class formAdminHome : Form
    {
        DBConnect dbConn = new DBConnect();
        String userId;
        public formAdminHome(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formAdminHome_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            loadFormDetails();
        }

        private void loadFormDetails()
        {
            int numOfBugs = dbConn.Count("SELECT Count(*) FROM bugreports;");
            int numOfBugsSolved = dbConn.Count("SELECT Count(*) FROM bugreports WHERE status = 'solved';");
            int numOfBugsUnsolved = dbConn.Count("SELECT Count(*) FROM bugreports WHERE status = 'not solved';");
            int numOfUsers = dbConn.Count("SELECT Count(*) FROM userdetails;");
            int numOfAppointedBugs = dbConn.Count("SELECT Count(*) FROM bugreports WHERE assignstatus = 'assigned';");
            int numOfUnAppointedBugs = dbConn.Count("SELECT Count(*) FROM bugreports WHERE assignstatus = 'not assigned';");
            lblBugsFound.Text = numOfBugs.ToString();
            lblBugsSolved.Text = numOfBugsSolved.ToString();
            lblBugsUnsolved.Text = numOfBugsUnsolved.ToString();
            lblNoOfUsers.Text = numOfUsers.ToString();
            lblApoBugs.Text = numOfAppointedBugs.ToString();
            lblUnApoBugs.Text = numOfUnAppointedBugs.ToString();
        }
    }
}
