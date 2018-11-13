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
    public partial class formEditProjectName : Form
    {
        String projectId;
        DBConnect dbConn = new DBConnect();
        public formEditProjectName(String projectId)
        {
            InitializeComponent();
            this.projectId = projectId;
        }

        private void formEditProjectName_Load(object sender, EventArgs e)
        {
            getProjectName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtProjectName, null);
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                errorProvider1.SetError(txtProjectName, "Please Enter Project Name");
                txtProjectName.Focus();
            }
            else
            {
                if (checkIfProjectAlreadyExist(txtProjectName.Text))
                {
                    errorProvider1.SetError(txtProjectName, "Project Name Already Registered. Please Enter New Name.");
                    txtProjectName.Focus();
                }
                else
                {
                    saveProjectName();
                }
            }
        }
        private Boolean checkIfProjectAlreadyExist(string textProjectName)
        {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM project where pname = '" + textProjectName + "'");
            if (numOfRows != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getProjectName()
        {
            try
            {                
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from project WHERE pid = '" + projectId + "';", "project");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    txtProjectName.Text = list[1][i];
                }                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        private void saveProjectName() {
            try
            {                
                dbConn.executeQuery("UPDATE project SET pname = '" + txtProjectName.Text + "' WHERE pid = '" + projectId + "';");
                MessageBox.Show("You have sucessfully changed a project Name");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
    }
}
