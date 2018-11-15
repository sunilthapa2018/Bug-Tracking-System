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

    public partial class formEditBugAppointment : Form
    {
        DBConnect dbConn = new DBConnect();
        public formEditBugAppointment()
        {
            InitializeComponent();
        }
        private void formEditBugAppointment_Load(object sender, EventArgs e)
        {
            //opening this form fullscreen
            WindowState = FormWindowState.Maximized;
            //making datagridview select whole row on cell select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            if (!value.Equals("No Rows Found"))
            {
                int assignId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                formEditBugAppoint formEditBugAppoint = new formEditBugAppoint("" + assignId);
                formEditBugAppoint.Show();
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

        //Reading data from database and loading data to datagridview1
        private void getData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                List<string>[] list = new List<string>[8];
                String assignid, reportId, bugsId, bugName, appName, uid, uname, aname, query;

                assignid = "";
                reportId = "";
                bugsId = "";
                bugName = "";
                appName = "";
                uid = "";
                uname = "";
                aname = "";
                query = "";



                query = "SELECT bugassign.assignid, bugassign.reportid, bugreports.bugid, bugreports.description, bugreports.userid, " +
                    "bugreports.reportdate, bugassign.userid, bugassign.assigndate, bugreports.status FROM bugassign INNER JOIN bugreports ON " +
                        "bugassign.reportid = bugreports.reportid;";

                //sending sql command to dbConnect class  
                list = dbConn.Select(query, "joinType5");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    assignid = list[0][i];
                    reportId = list[1][i];
                    bugsId = list[2][i];
                    bugName = getBugName(bugsId);
                    appName = getAppName(bugsId);
                    uid = list[4][i];
                    uname = getUserName(uid);
                    aname = getUserName(list[6][i]);

                    this.dataGridView1.Rows.Add(assignid, reportId, bugsId, bugName, appName, list[3][i], uname, list[5][i], aname,
                        list[7][i], list[8][i]);
                }
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
        //this function takes userId as input and returns userName
        private string getUserName(String userId)
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
    }
}
