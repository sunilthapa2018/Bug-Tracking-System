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
    public partial class formUserEditReport : Form
    {

        String reportId;
        DBConnect dbConn = new DBConnect();
        String appName, bugName, desc;
        byte[] imageByte;
        Boolean imageShown = false;
        String fileName;
        MySqlConnection connection = new MySqlConnection("DATASOURCE=localhost;PORT=3306;DATABASE=bugtrackerdatabase;UID=root;PASSWORD='';SSLMODE=none;");
        MySqlCommand cmd;
        public formUserEditReport(String reportId)
        {
            InitializeComponent();
            this.reportId = reportId;
        }

        private void formUserEditReport_Load(object sender, EventArgs e)
        {
            appName = "";
            bugName = "";
            desc = "";
            fillBugDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDescription, null);
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                //setting errorporvider and giving error message
                errorProvider1.SetError(txtDescription, "Please Enter Description");
                txtBugName.Focus();
            }
            else {
                if (lblNewImageSelected.Visible)
                {
                    //save new image and description to database
                    saveDetails();
                }
                else {
                    //save description only to database
                    try
                    {
                        dbConn.executeQuery("UPDATE bugreports SET description = '" + txtDescription.Text + "' WHERE reportid = '" + reportId + "';");
                        MessageBox.Show("You have sucessfully changed Bug Details");
                        this.Close();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
                }
            }
        }
        //save details that are changed to database
        void saveDetails() {
            byte[] ImageData;
            //opeaning selected image and converting image to byte array
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            //Updating bug report-- changing values of bugreports table
            try
            {                               
                string CmdString = "UPDATE bugreports SET description = @desc, screenshot = @screenshot WHERE reportid = @reportid";
                cmd = new MySqlCommand(CmdString, connection);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@screenshot", ImageData);
                cmd.Parameters.AddWithValue("@reportid", reportId);

                connection.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    connection.Close();
                    MessageBox.Show("You have sucessfully changed Bug Details");
                    this.Close();
                }   

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

        private void txtAppName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtBugName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
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

        //fills bug details in this form
        private void fillBugDetails() {
            getDatasFromDb();
            txtAppName.Text = appName;
            txtBugName.Text = bugName;
            txtDescription.Text = desc;
            imageByte = dbConn.imageByte;            
            picScreenshot.SizeMode = PictureBoxSizeMode.Zoom;
            picScreenshot.Image = ByteArrayToImage(imageByte);
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
                lblNewImageSelected.Visible = true;
                imageShown = true;

            }
            else
            {
                if (imageShown)
                {
                    lblNewImageSelected.Visible = true;
                }
                else
                {
                    lblNewImageSelected.Visible = false;
                }

            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }            
        }

        //reads data from database and assign it to variables
        private void getDatasFromDb() {
            String query = "";
            query = "SELECT bug.appname, bug.bugname, bugreports.description, bugreports.screenshot " +
                "FROM bugreports INNER JOIN bug ON bugreports.bugid = bug.bugid Where bugreports.reportid = '" + 
                reportId + "';";
            try
            {
                //declaring list inside a array
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class                    
                list = dbConn.Select(query, "joinType3");
                appName = list[0][0];
                bugName = list[1][0];
                desc = list[2][0];
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }
            
        }


    }
}
