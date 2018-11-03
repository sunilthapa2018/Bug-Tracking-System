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
    public partial class formUserEditReport : Form
    {

        String reportId;
        DBConnect dbConn = new DBConnect();
        String appName, bugName, desc;
        byte[] imageByte;
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

        }

        private void fillBugDetails() {
            getDatasFromDb();
            txtAppName.Text = appName;
            txtBugName.Text = bugName;
            txtDescription.Text = desc;            
            //picScreenshot.Image = ByteArrayToImage(imageByte);
        }
        /*public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
            
        }*/

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
                

                //imageByte = Encoding.UTF8.GetBytes(list[3][0]);
                imageByte = Encoding.ASCII.GetBytes(list[3][0]);
                /*for (int i = 0; i < list[0].Count(); i++)
                {
                    //adding data retrived to datagridview
                    //this.dataGridView1.Rows.Add(list[0][i], list[1][i], list[2][i], list[3][i], list[4][i], list[5][i], list[6][i]);
                }*/

            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }//exception handling
            
        }
    }
}
