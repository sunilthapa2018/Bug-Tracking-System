using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Programmer
{
    public partial class formViewAssignedBugs : Form
    {
        DBConnect dbConn = new DBConnect();
        string userId;
        public formViewAssignedBugs(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formViewAssignedBugs_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }

        //Reading data from database and loading data to datagridview1
        private void getData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                List<string>[] list = new List<string>[7];
                String reportId, bugsId, bugName, appName, uid, uname, query;

                reportId = "";
                bugsId = "";
                bugName = "";
                appName = "";
                uid = "";
                uname = "";
                query = "";

                int selectedIndex = cboStatus.SelectedIndex;

                //if selected item = 'all'
                if (selectedIndex == 0)
                {
                    query = "SELECT bugassign.reportid, bugreports.bugid, bugreports.description, bugreports.userid," +
                    " bugreports.reportdate, bugassign.assigndate, bugreports.status FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid WHERE bugassign.userid = '" + userId + "';";
                }
                //if selected item = 'solved'
                else if (selectedIndex == 1)
                {
                    query = "SELECT bugassign.reportid, bugreports.bugid, bugreports.description, bugreports.userid, " +
                    "bugreports.reportdate, bugassign.assigndate, bugreports.status FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid Where bugassign.userid = '" + userId + "' AND " +
                        "bugreports.status = 'solved';";
                }
                //if selected item = 'not solved'
                else if (selectedIndex == 2)
                {
                    query = "SELECT bugassign.reportid, bugreports.bugid, bugreports.description, bugreports.userid, " +
                    "bugreports.reportdate, bugassign.assigndate, bugreports.status FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid Where bugassign.userid = '" + userId + "' AND " +
                        "bugreports.status = 'not solved';";
                }
                else { }
                //sending sql command to dbConnect class  
                list = dbConn.Select(query, "joinType4");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    reportId = list[0][i];
                    bugsId = list[1][i];
                    bugName = getBugName(bugsId);
                    appName = getAppName(bugsId);
                    uid = list[3][i];
                    uname = getUserName(uid);

                    this.dataGridView1.Rows.Add(reportId, bugsId, bugName, appName, list[2][i], uname, list[4][i],
                        list[5][i], list[6][i]);
                }
                //if number of row is 0 then show 'No Rows Found'
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
        //this function takes bugId as input and returns bugName
        private string getBugName(String bugId)
        {
            String bugName = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug WHERE bugid = '" + bugId + "';", "bug");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    bugName = list[1][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return bugName;
        }

        //this function takes bugId as input and returns appName
        private string getAppName(String bugId)
        {
            String appName = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug WHERE bugid = '" + bugId + "';", "bug");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    appName = list[2][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return appName;
        }

        //this function takes uId as input and returns userName
        private string getUserName(String uId)
        {
            String userName = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails WHERE userid = '" + uId + "';", "userdetails");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    userName = list[1][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return userName;
        }
    }
}
