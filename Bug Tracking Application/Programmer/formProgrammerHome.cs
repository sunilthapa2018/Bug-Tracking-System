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
    public partial class formProgrammerHome : Form
    {
        DBConnect dbConn = new DBConnect();
        String userId;        
        public formProgrammerHome(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formProgrammerHome_Load(object sender, EventArgs e)        {
            WindowState = FormWindowState.Maximized;           
            loadFormDetails();
            
        }

        //reads data from database and load all data to textfields
        private void loadFormDetails()
        {
            int numOfAppointedBugs = dbConn.Count("SELECT Count(*) FROM bugassign where userid = '" + userId + "';");
            int numOfBugsSolved = dbConn.Count("SELECT Count(*) FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid WHERE bugassign.userid = '" + userId + "' AND status = 'solved';");

            int numOfBugsUnsolved = dbConn.Count("SELECT Count(*) FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid WHERE bugassign.userid = '" + userId + "' AND status = 'not solved';");
            lblBugsAppointed.Text = numOfAppointedBugs.ToString();
            lblBugsSolved.Text = numOfBugsSolved.ToString();
            lblBugsUnsolved.Text = numOfBugsUnsolved.ToString();
        }
    }
}
