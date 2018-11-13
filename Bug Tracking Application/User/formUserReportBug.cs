using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application
{
    public partial class formUserReportBug : Form
    {
        String bugName,description,appName;
        String userId;
        String bugid;
        String textBugname, textDescription, comboAppName;
        Boolean isFormValidationOk = true;
        Boolean panelOneActive = true;
        Boolean imageShown = false;
        DBConnect dbConn = new DBConnect();
        public formUserReportBug(String userId)
        {
            InitializeComponent();
            this.userId = userId;            
        }

        private void formUserReportBug_Load(object sender, EventArgs e)
        {            
            WindowState = FormWindowState.Maximized;
            cboBugName.Visible = false;
            getProjectNames();
            cboAppName.SelectedIndex = 0;
            txtBugName.Focus();
            setPanelStyle1();
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;


        }
        private void getProjectNames() {
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
        private void setPanelStyle1() {
            lblTitle.Text = "Enter A New Bug and Report";
            txtBugName.Visible = true;
            cboBugName.Visible = false;
            btnAddNewBug.Size = new Size(145, 30);
            btnAddNewError.Size = new Size(140, 25);
            panelOneActive = true;
        }
        private void setPanelStyle2()
        {
            lblTitle.Text = "Enter A New Report to old Bug";
            txtBugName.Visible = false;
            cboBugName.Visible = true;
            btnAddNewBug.Size = new Size(140, 25);
            btnAddNewError.Size = new Size(145, 30);
            panelOneActive = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bugName = txtBugName.Text.ToLower();
            appName = cboAppName.SelectedItem.ToString().ToLower();
            description = txtDescription.Text;

            validateIfAnyFieldIsEmpty();
            if (!isFormValidationOk) { return; }

            if (panelOneActive)
            {
                if (checkIfBugAlreadyExist())
                {
                    errorProvider.SetError(txtBugName, null);
                    errorProvider.SetError(txtBugName, "Bug Already Registered,Please Enter New Bug name.");
                    txtBugName.Focus();
                    return;
                }
                insertNewBugToDatabase();
            }
            else {
                insertNewBugRecordOnDatabase();
            }
            

        }

        private void btnAddNewError_Click(object sender, EventArgs e)
        {
            setPanelStyle2();
            cboBugName.Items.Clear();
            cboBugName.Items.Add("--Select--");
            cboBugName.SelectedIndex = 0;            
            showBugNames();
        }

        private void btnAddNewBug_Click(object sender, EventArgs e)
        {
            setPanelStyle1();
        }

        private void btnImportScreenshot_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png)|*.jpg; *.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {                
                picScreenshot.Image = Image.FromFile(opf.FileName);                
                picScreenshot.SizeMode = PictureBoxSizeMode.StretchImage;                
                lblImageSelected.Visible = true;
                imageShown = true;
                
            }
            else {
                if (imageShown)
                {
                    lblImageSelected.Visible = true;

                }
                else {
                    lblImageSelected.Visible = false;
                }

            }
        }

        private void insertNewBugToDatabase() {
            
            //saving new bug-- inserting values to bug table
            try
            {
                dbConn.executeQuery("INSERT INTO bug (bugid, bugname, appname, createddate) VALUES " +
                    "(NULL, '" + bugName + "','" + appName + "', '" + DateTime.Now.ToString("MM/dd/yyyy") + "');");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.StackTrace);
                    
            }
            //getting bug id
            bugid = getBugId(bugName);

            MemoryStream ms = new MemoryStream();
            picScreenshot.Image.Save(ms, picScreenshot.Image.RawFormat);
            byte[] img = ms.ToArray();

            //saving new bug report-- inserting values to bugreports table
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                dbConn.executeQuery("INSERT INTO bugreports (reportid, bugid, description, userid, reportdate, " +
                    "screenshot, status, assignstatus)" + " VALUES " +
                    "(NULL, '" + bugid + "','" + description + "', '" + userId + "','" + date + "','" +
                    img + "','Not Solved', 'Not Assigned');");
            }
            catch (Exception ex){MessageBox.Show("" + ex.StackTrace);}
            MessageBox.Show("A New bug report has been uploaded");
        }
        private void insertNewBugRecordOnDatabase()
        {
            //getting bug id
            bugid = getBugId(cboBugName.SelectedItem.ToString());
            MemoryStream ms = new MemoryStream();
            picScreenshot.Image.Save(ms, picScreenshot.Image.RawFormat);
            byte[] img = ms.ToArray();

            //saving new bug report-- inserting values to bugreports table
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                dbConn.executeQuery("INSERT INTO bugreports (reportid, bugid, description, userid, reportdate, " +
                    "screenshot, status, assignstatus)" + " VALUES " +
                    "(NULL, '" + bugid + "','" + description + "', '" + userId + "','" + date + "','" +
                    img + "','Not Solved', 'Not Assigned');");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            MessageBox.Show("A New report has been uploaded for an old bug");
        }
    
    
        private string getBugId(String bName) {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug where bugname = '" + bName + "'", "bug");
                bugid = list[0][0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.StackTrace);
            }
            return bugid;
        }
        private void getBugNames(String aName)
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug where appname = '" + aName + "'", "bug");
                int listSize = list.Count();
                int listSize2 = list.Length;
                for (int i = 0; i < list[0].Count(); i++)
                {
                    cboBugName.Items.Add(list[1][i]);
                }
            }
            catch (Exception ex){MessageBox.Show("" + ex.StackTrace);}            
        }
        private Boolean checkIfBugAlreadyExist()
        {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM bug where bugname = '" + bugName + "'");
            if (numOfRows > 0)
            {
                return true;
            }
            else
            {
                return false;
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


        private void txtBugName_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtBugName, null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboAppName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboBugName.Items.Clear();
            cboBugName.Items.Add("--Select--");
            cboBugName.SelectedIndex = 0;
            if (cboAppName.SelectedIndex > 0)
            {
                errorProvider.SetError(cboAppName, null);
            }
            if (cboBugName.Visible)
            {
                showBugNames();
            }
            
        }
        private void showBugNames() {
            String apName = cboAppName.SelectedItem.ToString().ToLower();
            if (cboAppName.SelectedIndex > 0)
            {
                if (hasBug(apName))
                {
                    getBugNames(apName);
                }
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtDescription, null);
        }

        private void validateIfAnyFieldIsEmpty()
        {
            //initializing variables
            textBugname = "";
            textDescription = "";
            comboAppName = "";
            isFormValidationOk = true;
            Boolean isAnythingEmpty = false;

            //assigning values to variables
            textBugname = txtBugName.Text;
            textDescription = txtDescription.Text;
            comboAppName = cboAppName.Text;

            //clearing error provider
            errorProvider.SetError(txtDescription, null);
            errorProvider.SetError(cboAppName, null);
            errorProvider.SetError(txtBugName, null);

            if (string.IsNullOrEmpty(textDescription))
            {
                //setting errorporvider and giving error message
                errorProvider.SetError(txtDescription, "Please Enter Bug Description");
                txtDescription.Focus();
                isAnythingEmpty = true;
            }
            
            if (cboAppName.SelectedIndex==0)
            {
                //setting errorporvider and giving error message
                errorProvider.SetError(cboAppName, "Please Select a Application");
                cboAppName.Focus();
                isAnythingEmpty = true;
            }
            if (panelOneActive)
            {
                if (string.IsNullOrEmpty(textBugname))
                {
                    //setting errorporvider and giving error message
                    errorProvider.SetError(txtBugName, "Please Enter Bug Name");
                    txtBugName.Focus();
                    isAnythingEmpty = true;
                }
            }
            else {
                if (cboBugName.SelectedIndex == 0)
                {
                    //setting errorporvider and giving error message
                    errorProvider.SetError(cboBugName, "Please Select a Bug Name");
                    cboAppName.Focus();
                    isAnythingEmpty = true;
                }
            }

            if (isAnythingEmpty)
            {
                isFormValidationOk = false;                
            }
        }
    }

}
