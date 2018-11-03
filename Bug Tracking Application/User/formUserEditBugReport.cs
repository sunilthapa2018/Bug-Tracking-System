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
            //selecting first item in each comboboxes
            getProjectNames();
            showAllBugs();
            cboAppName.SelectedIndex = 0;
            
            cboBugName.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Right) {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                //int positionXYMouseRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex > 0)
                {
                    //dataGridView1.ClearSelection();
                    //dataGridView1.Rows[rowIndex].Selected = true;
                    
                    

                }

                
            }*/
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
            cboBugName.Items.Clear();
            cboBugName.Items.Add("All");
            cboBugName.SelectedIndex = 0;
            if (cboAppName.SelectedIndex > 0)
            {
                showBugNames();
            }
            else if (cboAppName.SelectedIndex == 0)
            {
                showAllBugs();
            }
            else { }

                        
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
        private void getDataInDGV() {
            //Declaring variables
            int cboAppIndex, cboBugIndex, cboStatusIndex;
            String cboAppItem, cboBugItem, cboStatusItem;
            String query;
            //clearing all rows of datagridview
            dataGridView1.Rows.Clear();
            //getting selected index of a combobox into a variable
            cboAppIndex = cboAppName.SelectedIndex;
            cboBugIndex = cboBugName.SelectedIndex;
            cboStatusIndex = cboStatus.SelectedIndex;
            //initializing variables
            cboAppItem = "";
            cboBugItem = "";
            cboStatusItem = "";
            query = "";
            //If any of the combo box has no value then exit this function
            if (cboAppIndex < 0 || cboBugIndex < 0 || cboStatusIndex < 0){return;}

            //if one of the combobox has selected index greater than 0 then load values
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
                        "bugreports.bugid = bug.bugid;";                
            }
            //if index of statusbox is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex == 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bugreports.status = '" + cboStatusItem + "';";                
            }
            //if index of bug name is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex > 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.bugname = '" + cboBugItem + "';";                
            }
            //if index of app name and statusbox is greater then 0
            else if (cboAppIndex == 0 && cboBugIndex > 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.bugname = '" + cboBugItem + "' AND bugreports.status='" +
                        cboStatusItem + "';";                
            }
            //if index of app name is greater then 0
            else if (cboAppIndex > 0 && cboBugIndex == 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "';";                
            }
            else if (cboAppIndex > 0 && cboBugIndex == 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bugreports.status='" +
                        cboStatusItem + "';";                
            }
            else if (cboAppIndex > 0 && cboBugIndex > 0 && cboStatusIndex == 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bug.bugname='" +
                        cboBugItem + "';";                
            }
            //if all 3 combobox has selected index greater than 0
            else if (cboAppIndex > 0 && cboBugIndex > 0 && cboStatusIndex > 0)
            {
                query = "SELECT bugreports.reportid, bugreports.bugid, bug.bugname, bug.appname, bugreports.description, " +
                        "bugreports.reportdate, bugreports.status FROM bugreports INNER JOIN bug ON " +
                        "bugreports.bugid = bug.bugid Where bug.appname = '" + cboAppItem + "' AND bug.bugname='" +
                        cboBugItem + "' AND bugreports.status='" + cboStatusItem + "';";                
            }
            try
            {
                //declaring list inside a array
                List<string>[] list = new List<string>[7];
                //sending sql command to dbConnect class                    
                list = dbConn.Select(query, "join");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    //adding data retrived to datagridview
                    this.dataGridView1.Rows.Add(list[0][i], list[1][i], list[2][i], list[3][i], list[4][i], list[5][i], list[6][i]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }//exception handling
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int reportId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            formUserEditReport formUserEditReport = new formUserEditReport(""+reportId);
            formUserEditReport.Show();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
