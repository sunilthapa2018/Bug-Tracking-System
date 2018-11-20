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
using MySql.Data.MySqlClient;

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
        String fileName;
        DBConnect dbConn = new DBConnect();        
        MySqlConnection connection = new MySqlConnection("DATASOURCE=localhost;PORT=3306;DATABASE=bugtrackerdatabase;UID=root;PASSWORD='';SSLMODE=none;");
        MySqlCommand cmd;
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
            picScreenshot.SizeMode = PictureBoxSizeMode.Zoom;


        }
        //reads project names from database and laod it to combobox i.e. cboAppName
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
        //setting panel and visiblity style of 1
        private void setPanelStyle1() {
            lblTitle.Text = "Enter A New Bug and Report";
            txtBugName.Visible = true;
            cboBugName.Visible = false;
            btnAddNewBug.Size = new Size(145, 30);
            btnAddNewError.Size = new Size(140, 25);
            panelOneActive = true;
        }
        //setting panel and visiblity style of 2
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
                fileName = opf.FileName;
                picScreenshot.Image = Image.FromFile(opf.FileName);
                picScreenshot.SizeMode = PictureBoxSizeMode.Zoom;                               
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

        //adding new bug and new report to our database and showing sucess message
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

            byte[] ImageData;
            //opeaning selected image and converting image to byte array
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            //saving new bug report-- inserting values to bugreports table
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");                
                string CmdString = "INSERT INTO bugreports (bugid, description, userid, reportdate, " +
                "screenshot, status, assignstatus)" + " VALUES (@bugid,@desc,@userid,@reportdate,@screenshot," +
                "'Not Solved', 'Not Assigned')";
                cmd = new MySqlCommand(CmdString, connection);
                cmd.Parameters.Add("@bugid", MySqlDbType.Int16, 10);
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar, 500);
                cmd.Parameters.Add("@userid", MySqlDbType.Int16, 10);
                cmd.Parameters.Add("@reportdate", MySqlDbType.VarChar, 10);
                cmd.Parameters.Add("@screenshot", MySqlDbType.Blob);

                cmd.Parameters["@bugid"].Value = bugid;
                cmd.Parameters["@desc"].Value = description;
                cmd.Parameters["@userid"].Value = userId;
                cmd.Parameters["@reportdate"].Value = date;
                cmd.Parameters["@screenshot"].Value = ImageData;

                connection.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("A New bug report has been uploaded");
                    clearAll();
                }

                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            finally {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            };
            
        }

        //adding new report to old bug to our database and showing sucess message
        private void insertNewBugRecordOnDatabase()
        {
            //getting bug id
            bugid = getBugId(cboBugName.SelectedItem.ToString());

            /*MemoryStream ms = new MemoryStream();
            picScreenshot.Image.Save(ms, picScreenshot.Image.RawFormat);
            byte[] img = ms.ToArray();*/

            byte[] ImageData;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);

            //saving new bug report-- inserting values to bugreports table
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");                
                string CmdString = "INSERT INTO bugreports (bugid, description, userid, reportdate, " +
                "screenshot, status, assignstatus)" + " VALUES (@bugid,@desc,@userid,@reportdate,@screenshot," +
                "'Not Solved', 'Not Assigned')";
                cmd = new MySqlCommand(CmdString, connection);
                cmd.Parameters.Add("@bugid", MySqlDbType.Int16, 10);
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar, 500);
                cmd.Parameters.Add("@userid", MySqlDbType.Int16, 10);
                cmd.Parameters.Add("@reportdate", MySqlDbType.VarChar, 10);
                cmd.Parameters.Add("@screenshot", MySqlDbType.Blob);

                cmd.Parameters["@bugid"].Value = bugid;
                cmd.Parameters["@desc"].Value = description;
                cmd.Parameters["@userid"].Value = userId;
                cmd.Parameters["@reportdate"].Value = date;
                cmd.Parameters["@screenshot"].Value = ImageData;

                connection.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("A New bug report has been uploaded");
                    clearAll();
                }

                connection.Close();

            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            };

        }
        //this function clears all fields
        void clearAll() {
            txtBugName.Clear();
            txtDescription.Clear();
            picScreenshot.Image = null;

        }        

        //this function takes bName as input and returns bugId
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

        //this function takes bName as input and loads cboBugName with bug names
        private void getBugNames(String bName)
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from bug where appname = '" + bName + "'", "bug");
                int listSize = list.Count();
                int listSize2 = list.Length;
                for (int i = 0; i < list[0].Count(); i++)
                {
                    cboBugName.Items.Add(list[1][i]);
                }
            }
            catch (Exception ex){MessageBox.Show("" + ex.StackTrace);}            
        }

        //checks if bug already exists in our system
        //return true if bug is already existed
        //return false if bug does not exist
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

        //checks if an appName has bug in our system
        //return true if it has bug
        //return false if it doesn't have bug
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

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }
        private void checkPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
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

        //shows bugnames if an appname has a bug linked
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

        //checks if any field is empty in our form
        private void validateIfAnyFieldIsEmpty()
        {            
            textBugname = "";
            textDescription = "";
            comboAppName = "";
            isFormValidationOk = true;
            Boolean isAnythingEmpty = false;
            
            textBugname = txtBugName.Text;
            textDescription = txtDescription.Text;
            comboAppName = cboAppName.Text;
            
            errorProvider.SetError(txtDescription, null);
            errorProvider.SetError(cboAppName, null);
            errorProvider.SetError(txtBugName, null);
            errorProvider.SetError(picScreenshot, null);
            if (!lblImageSelected.Visible) {
                errorProvider.SetError(picScreenshot, "Please Select A Screenshot");
                txtDescription.Focus();
                isAnythingEmpty = true;
            }
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
