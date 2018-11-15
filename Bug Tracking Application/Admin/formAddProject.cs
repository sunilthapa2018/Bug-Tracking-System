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
    public partial class formAddProject : Form
    {
        DBConnect dbConn = new DBConnect();        
        public formAddProject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            errorProvider1.SetError(txtProjectName, null);
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                errorProvider1.SetError(txtProjectName, "Please Enter Project Name");
                txtProjectName.Focus();
            }
            else {                
                if (checkIfProjectAlreadyExist(txtProjectName.Text))
                {
                    errorProvider1.SetError(txtProjectName, "Project Name Already Registered. Please Enter New Name.");
                    txtProjectName.Focus();
                }
                else {
                    try
                    {
                        //sending sql command to dbConnect class 
                        dbConn.executeQuery("INSERT INTO project (pid, pname) VALUES " +
                            "(NULL, '" + txtProjectName.Text + "');");
                        MessageBox.Show("A New Project has been Registered");
                        txtProjectName.Text = "";
                        txtProjectName.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.StackTrace);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //This function checks if project name already exists in our program
        //Returns true if project name doesnot exists
        //Returns false if project name exists
        private Boolean checkIfProjectAlreadyExist(string textProjectName)
        {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM project where pname = '" + textProjectName + "'");
            if (numOfRows != 0)
            {               
                return true;
            }
            else {
                return false;
            }
        }

        private void txtProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void formAddProject_Load(object sender, EventArgs e)
        {

        }
    }
}
