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
    public partial class formAddBugAppointment : Form
    {        
        DBConnect dbConn = new DBConnect();
        public formAddBugAppointment()
        {
            InitializeComponent();            
        }

        private void btnAppointBug_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string Status = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (!value.Equals("No Rows Found"))
            {
                if (Status.Equals("not assigned"))
                {
                    //getting integer value from string data
                    int reportId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    formAppointBug formAppointBug = new formAppointBug("" + reportId);
                    formAppointBug.Show();
                }
                else {
                    MessageBox.Show("This bug has already been assigned. " +
                        "So please select bug that has not been assigned to anyone.");
                }
                
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

        private void formAddBugAppointment_Load(object sender, EventArgs e)
        {            
            WindowState = FormWindowState.Maximized;            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;            
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;            
            cboStatus.SelectedIndex = 0;           
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
                List<string>[] list = new List<string>[8];
                String reportId, bugsId, bugName, appName, uid, uname, query;

                reportId = "";
                bugsId = "";
                bugName = "";
                appName = "";
                uid = "";
                uname = "";
                query = "";

                int selectedIndex = cboStatus.SelectedIndex;

                if (selectedIndex == 0)
                {
                    query = "SELECT * FROM bugreports;";
                }
                else if (selectedIndex == 1)
                {                    
                    query = "SELECT * FROM bugreports WHERE assignstatus = 'assigned';";
                }
                else if (selectedIndex == 2)
                {
                    query = "SELECT * FROM bugreports WHERE assignstatus = 'not assigned';";
                }
                else { }
                //sending sql command to dbConnect class  
                list = dbConn.Select(query, "bugreports");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    reportId = list[0][i];
                    bugsId = list[1][i];
                    bugName = getBugName(bugsId);
                    appName = getAppName(bugsId);
                    uid = list[3][i];
                    uname = getUserName(uid);
                    this.dataGridView1.Rows.Add(reportId, bugsId, bugName, appName, list[2][i], uname, list[4][i],
                        list[7][i]);
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
        //this function takes bugId as input and returns appName i.e. project name
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
                if (list[0].Count() <= 0) {
                    userName = "User Is Removed";
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return userName;
        }
    }
}
