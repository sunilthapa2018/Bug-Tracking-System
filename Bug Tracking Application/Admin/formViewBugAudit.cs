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
    public partial class formViewBugAudit : Form
    {
        DBConnect dbConn = new DBConnect();
        Boolean assignMsgShown = false;
        
        public formViewBugAudit()
        {
            InitializeComponent();
        }

        private void formViewBugAudit_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            getBugNames();
            cboBugName.SelectedIndex = 0;            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboBugName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }

        //get bugnames from database and load it to combobox i.e cboBugName
        private void getBugNames()
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug;", "bug");
                for (int i = 0; i < list[0].Count(); i++)
                {                    
                    cboBugName.Items.Add(list[1][i]);
                }                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
        //Reading data from database and loading data to datagridview1
        private void getData()
        {
            string bugid = getBugId(cboBugName.SelectedItem.ToString());
            try
            {
                dataGridView1.Rows.Clear();
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bugreports WHERE bugid = '" + bugid + "';", "bugreports");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    this.dataGridView1.Rows.Add(list[4][i], list[0][i], getUserName(list[3][i]), "Bug Is Added");
                    assignMsgShown = false;
                    getBugAppointment(list[0][i]);
                    getBugSolved(list[0][i]);
                }
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
        //add 1 row of data to datagridview only if bug is solved
        private void getBugSolved(String reportId)
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bugsolve WHERE reportid = '" + reportId + "';", "bugsolve");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    this.dataGridView1.Rows.Add(list[3][i], reportId, getUserName(list[2][i]), "Bug Is Solved.");
                }
                if (list[0].Count() <= 0 && assignMsgShown == false) {
                    this.dataGridView1.Rows.Add("", "", "", "Bug Is Not Solved Yet.");
                }
            }
            
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        //add 1 row of data to datagridview only if bug is appointed by admin
        private void getBugAppointment(String reportId)
        {
            try
            {                
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bugassign WHERE reportid = '" + reportId + "';", "bugassign");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    this.dataGridView1.Rows.Add(list[2][i], reportId, "Admin", "Bug Is Assigned to " + getUserName(list[3][i]));                    
                }
                if (list[0].Count() <= 0)
                {
                    this.dataGridView1.Rows.Add("", "", "", "Bug Is Not Assigned Yet.");
                    assignMsgShown = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        //this function takes bugName as input and returns bugId
        private string getBugId(String bugName)
        {
            String bugId = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug WHERE bugName = '" + bugName + "';", "bug");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    bugId = list[0][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return bugId;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (!value.Equals("No Rows Found"))
            {
                String date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Bug Audit History";
                printer.SubTitle = "Bug Name : " + cboBugName.SelectedItem.ToString() + Environment.NewLine +
                    "Date Printed : " + date;
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;                
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Bug Tracking Application";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
            }
            else {
                MessageBox.Show("No Rows found to be printed.");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            

        }
    }
}
