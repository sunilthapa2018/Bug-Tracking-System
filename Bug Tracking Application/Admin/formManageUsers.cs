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
    public partial class formManageUsers : Form
    {
        DBConnect dbConn = new DBConnect();
        public formManageUsers()
        {
            InitializeComponent();
        }

        private void formManageUsers_Load(object sender, EventArgs e)
        {
            //making datagridview select whole row on cell select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            getUserNames();
        }

        private void getUserNames()
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails;", "userdetails");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    this.dataGridView1.Rows.Add(list[0][i], list[1][i], list[3][i], list[4][i]);
                }
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (!value.Equals("No Rows Found"))
            {
                string status = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string putStatus = "";
                string msg = "", msg2 = "";
                if (status.Equals("active"))
                {
                    putStatus = "inactive";
                    msg = "Deactivate";
                    msg2 = "Deactivated";
                }
                else {
                    putStatus = "active";
                    msg = "Activate";
                    msg2 = "Activated";
                }
                DialogResult myResult;
                myResult = MessageBox.Show("Are you sure you want to " +  msg + " this user?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (myResult == DialogResult.Yes)
                {
                    // confirm delete
                    int userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);                    
                    dbConn.executeQuery("UPDATE userdetails SET status = '" + putStatus + "' WHERE userid = '" + userId + "';");
                    MessageBox.Show("You have sucessfully "+ msg2 + " a user.");
                    getUserNames();
                }               
                
            }
        }
        private void activateUser() {

        }
        private void deactivateUser()
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getUserNames();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
