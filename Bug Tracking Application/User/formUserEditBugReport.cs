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
    public partial class formUserEditBugReport : Form
    {
        String userId;
        DBConnect dbConn = new DBConnect();
        public formUserEditBugReport(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formUserEditBugReport_Load(object sender, EventArgs e)
        {
            //opening this form fullscreen
            WindowState = FormWindowState.Maximized;
            //making datagridview select whole row on cell select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;            
            getProjectNames();            
            showAllBugs();
            cboAppName.SelectedIndex = 0;
            cboBugName.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

        }

        private void menuEdit_Click(object sender, EventArgs e)
        {        
            btnEdit.PerformClick();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            getDataInDGV();
        }

        private void cboAppName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboBugName.Items.Clear(); //clearing items in combobox
            cboBugName.Items.Add("All"); //adding an item in combobox
            cboBugName.SelectedIndex = 0; //selecting 1st item in combobox
            if (cboAppName.SelectedIndex > 0)
            {
                //calling a function to add bugnames to a combobox
                showBugNames();
            }
            else if (cboAppName.SelectedIndex == 0)
            {
                //calling a function to add appnames to a combobox
                showAllBugs();
            }
            else { }
            //to load data in datagridview
            getDataInDGV();
        }

        private void cboBugName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataInDGV();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataInDGV();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getDataInDGV();
        }

        //reads data from database and add appnames to combobox i.e cboAppName
        private void getProjectNames()
        {
            try
            {
                List<string>[] list = new List<string>[2];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from project", "project");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    cboAppName.Items.Add(list[1][i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.StackTrace);
            }

        }

        //reads data from database and add bugnames to combobox i.e cboBugName
        private void showAllBugs()
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug", "bug");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    cboBugName.Items.Add(list[1][i]);
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        //shows bugnames if an appname has a bug linked
        private void showBugNames()
        {
            String apName = cboAppName.SelectedItem.ToString().ToLower();
            if (cboAppName.SelectedIndex > 0)
            {
                if (hasBug(apName))
                {
                    getBugNames(apName);
                }
            }
        }

        //checks if that particular app name has bug linked
        //return true if bug is found
        //return false if bug is not found
        private Boolean hasBug(String aName)
        {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM bug where appname = '" + aName + "'");
            if (numOfRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //reads bugs names from database and load it to a combobox i.e cboBugName
        private void getBugNames(String aName)
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug where appname = '" + aName + "'", "bug");               
                for (int i = 0; i < list[0].Count(); i++)
                {
                    cboBugName.Items.Add(list[1][i]);
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
        //load data in datagridview according to comboboxe's selection
        private void getDataInDGV() {            
            int cboAppIndex, cboBugIndex, cboStatusIndex;
            String cboAppItem, cboBugItem, cboStatusItem;
            String query;
            
            dataGridView1.Rows.Clear();
            
            cboAppIndex = cboAppName.SelectedIndex;
            cboBugIndex = cboBugName.SelectedIndex;
            cboStatusIndex = cboStatus.SelectedIndex;
            
            cboAppItem = "";
            cboBugItem = "";
            cboStatusItem = "";
            query = "";

            //If any of the combo box has no value then exit this function
            if (cboAppIndex < 0 || cboBugIndex < 0 || cboStatusIndex < 0){return;}

            //if none of the combobox has selected index greater than 0 then load values
            if (cboAppIndex > 0 || cboBugIndex > 0 || cboStatusIndex > 0)
            {                
                cboAppItem = cboAppName.SelectedItem.ToString();
                cboBugItem = cboBugName.SelectedItem.ToString();
                cboStatusItem = cboStatus.SelectedItem.ToString();
            }
            //if all 3 combobox has selected index 0
            if (cboAppIndex == 0 && cboBugIndex == 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid WHERE bugreports.userid = '" + userId + "';";                
            }
            //if index of statusbox is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex == 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bugreports.status = '" + cboStatusItem + "' AND " +
                        "bugreports.userid = '" + userId + "'; ";                
            }
            //if index of bug name is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex > 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.bugname = '" + cboBugItem + "' AND " +
                        "bugreports.userid = '" + userId + "'; ";
            }
            //if index of app name and statusbox is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex > 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.bugname = '" + cboBugItem + "' AND bugreports.status='" +
                        cboStatusItem + "' AND bugreports.userid = '" + userId + "'; ";
            }
            //if index of app name is greater then 0
            else if (cboAppIndex > 0 && cboBugIndex == 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND " +
                        "bugreports.userid = '" + userId + "'; ";
            }
            //if index of appname and status is greater then 0
            else if (cboAppIndex > 0 && cboBugIndex == 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bugreports.status='" +
                        cboStatusItem + "' AND bugreports.userid = '" + userId + "'; ";
            }
            //if index of appname and bugname is greater then 0
            else if (cboAppIndex > 0 && cboBugIndex > 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bug.bugname='" +
                        cboBugItem + "' AND bugreports.userid = '" + userId + "'; ";
            }
            //if all 3 combobox has selected index greater than 0
            else if (cboAppIndex > 0 && cboBugIndex > 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bug.bugname='" +
                        cboBugItem + "' AND bugreports.status='" + cboStatusItem + "' AND " +
                        "bugreports.userid = '" + userId + "'; ";
            }
            try
            {
                //declaring list inside a string array
                List<string>[] list = new List<string>[7];
                //sending sql command to dbConnect class                    
                list = dbConn.Select(query, "join");
                for (int i = 0; i < list[0].Count(); i++)
                {                   
                    this.dataGridView1.Rows.Add(list[0][i], list[1][i], list[2][i], list[3][i], list[4][i], list[5][i], list[6][i]);
                }
                //if number of row is 0 then show 'No Rows Found'
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (!value.Equals("No Rows Found"))
            {
                int reportId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                formUserEditReport formUserEditReport = new formUserEditReport("" + reportId);
                formUserEditReport.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
