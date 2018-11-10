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
    public partial class formEditBugSolution : Form
    {
        DBConnect dbConn = new DBConnect();
        String userId;
        public formEditBugSolution(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formEditBugSolution_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (!value.Equals("No Rows Found"))
            {
                int solveId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int reportId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                formEditSolution formEditSolution = new formEditSolution(userId, "" + solveId, "" + reportId);
                formEditSolution.Show();
            }
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

        private void getData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                List<string>[] list = new List<string>[7];
                String solveid, reportId, bugsId, bugName, appName, query;

                solveid = "";
                reportId = "";
                bugsId = "";
                bugName = "";
                appName = "";
                
                
                query = "";

                int selectedIndex = cboStatus.SelectedIndex;

                if (selectedIndex == 0)
                {
                    query = "SELECT bugsolve.solveid, bugsolve.reportid, bugreports.bugid, bugsolve.error, bugsolve.solution," +
                    " bugsolve.class, bugsolve.method, bugsolve.line, bugreports.status FROM bugsolve INNER JOIN bugreports ON " +
                        "bugsolve.reportid = bugreports.reportid WHERE bugsolve.userid = '" + userId + "';";
                }
                else if (selectedIndex == 1)
                {
                    query = "SELECT bugsolve.solveid, bugsolve.reportid, bugreports.bugid, bugsolve.error, bugsolve.solution," +
                    " bugsolve.class, bugsolve.method, bugsolve.line, bugreports.status FROM bugsolve INNER JOIN bugreports ON " +
                        "bugsolve.reportid = bugreports.reportid WHERE bugsolve.userid = '" + userId + "' AND " +
                        "bugreports.status = 'solved';";
                }
                else if (selectedIndex == 2)
                {
                    query = "SELECT bugsolve.solveid, bugsolve.reportid, bugreports.bugid, bugsolve.error, bugsolve.solution," +
                    " bugsolve.class, bugsolve.method, bugsolve.line, bugreports.status FROM bugsolve INNER JOIN bugreports ON " +
                        "bugsolve.reportid = bugreports.reportid WHERE bugsolve.userid = '" + userId + "' AND " +
                        "bugreports.status = 'not solved';";
                }
                else { }
                //sending sql command to dbConnect class  
                list = dbConn.Select(query, "joinType5");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    solveid = list[0][i];
                    reportId = list[1][i];
                    bugsId = list[2][i];
                    bugName = getBugName(bugsId);
                    appName = getAppName(bugsId);                    

                    this.dataGridView1.Rows.Add(solveid, reportId, bugName, appName, list[3][i], list[4][i], list[5][i], 
                        list[6][i], list[7][i], list[8][i]);
                }
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
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
        private string getUserName(String bugId)
        {
            String userName = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails WHERE userid = '" + userId + "';", "userdetails");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    userName = list[1][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return userName;
        }

        private void formEditBugSolution_Load_1(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
        }
    }
}
