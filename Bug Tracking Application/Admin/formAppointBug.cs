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
    public partial class formAppointBug : Form
    {
        DBConnect dbConn = new DBConnect();
        String reportId;
        public formAppointBug(String reportId)
        {
            InitializeComponent();
            this.reportId = reportId;
        }

        private void formAppointBug_Load(object sender, EventArgs e)
        {
            cboName.SelectedIndex = 0;
            getNames();
        }

        private void getNames()
        {
            String userName = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails WHERE type = 'programmer';", "userdetails");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    userName = list[1][i];
                    cboName.Items.Add(userName);
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        private void btnAppointBug_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(cboName, null);
            if (cboName.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboName, "Please Select a Name");
                cboName.Focus();
            }
            else {
                AppointBug();
            }
        }

        private void AppointBug()
        {
            string userId = getUserId(cboName.SelectedItem.ToString());
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                dbConn.executeQuery("INSERT INTO bugassign (assignid, reportid, assigndate, userid) VALUES " +
                    "(NULL, '" + reportId + "','" + date + "', '" + userId + "');");
                changeAppointStatus();
                MessageBox.Show("You have sucessfully Assigned a bug to " + cboName.SelectedItem.ToString());
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        private void changeAppointStatus()
        {
            dbConn.executeQuery("UPDATE bugreports SET assignstatus = 'assigned' WHERE reportid = '" + reportId + "';");
        }

        private string getUserId(string username)
        {
            String userId = "";
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails WHERE username = '" + username + "';", "userdetails");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    userId = list[0][0];                    
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            return userId;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cboName, null);
        }
    }
}
