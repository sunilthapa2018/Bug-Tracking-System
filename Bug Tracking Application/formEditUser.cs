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
    public partial class formEditUser : Form
    {
        String userId;
        String userType, userName, password;
        String textOldPassword, textNewPassword, textConfirmPassword;
        DBConnect dbConn = new DBConnect();
        Encrypter encrypter = new Encrypter();
        Boolean isFormValidationOk = true;
        public formEditUser(String userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void formEditUser_Load(object sender, EventArgs e)
        {
            getUserDetails(userId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtOldPassword, null);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //initializing variables            
            textOldPassword = "";
            textNewPassword = "";
            textConfirmPassword = "";

            //assigning values to variables
            textOldPassword = txtOldPassword.Text;
            textNewPassword = txtNewPassword.Text;
            textConfirmPassword = txtConfirmPassword.Text;            

            validateForm();//calling form validation
            if (!isFormValidationOk){return;}//if form is not validated then exit this function           
            String conPass = encrypter.MD5Hash(txtConfirmPassword.Text);//converting password to md5 hash
            try
            {
                //update query for password
                String query = "UPDATE `userdetails` SET `password` = '" + conPass + "' WHERE `userdetails`.`userid` = '" 
                    + userId + "';";
                dbConn.executeQuery(query);//executing query
                MessageBox.Show("You have sucessfully changed your password.");
                //clearing text in text fields after sucessful data save.
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();

            }
            catch (Exception ex){MessageBox.Show("" + ex.StackTrace);}
        }
        private void validateForm()
        {
            Boolean isAnythingEmpty = false;
            isFormValidationOk = true;
            if (string.IsNullOrEmpty(textConfirmPassword))
            {
                //clearing error provider
                errorProvider1.SetError(txtConfirmPassword, null);
                errorProvider1.SetError(txtConfirmPassword, "Please Enter Confirm Password");
                txtConfirmPassword.Focus();
                isAnythingEmpty = true;
            }
            if (string.IsNullOrEmpty(textNewPassword))
            {
                errorProvider1.SetError(txtNewPassword, null);
                errorProvider1.SetError(txtNewPassword, "Please Enter New Password");
                txtNewPassword.Focus();
                isAnythingEmpty = true;

            }
            if (string.IsNullOrEmpty(textOldPassword))
            {
                errorProvider1.SetError(txtOldPassword, null);
                errorProvider1.SetError(txtOldPassword, "Please Enter Old Password");
                txtOldPassword.Focus();
                isAnythingEmpty = true;

            }
            if (isAnythingEmpty)
            {
                isFormValidationOk = false;
                return;
            }
            if (!textNewPassword.Equals(textConfirmPassword))
            {
                errorProvider1.SetError(txtConfirmPassword, null);
                errorProvider1.SetError(txtConfirmPassword, "Your Confirm Password doesn't match");
                isFormValidationOk = false;
                return;
            }
            String conPass = encrypter.MD5Hash(txtOldPassword.Text);
            if (!password.Equals(conPass))
            {
                errorProvider1.SetError(txtOldPassword, null);
                errorProvider1.SetError(txtOldPassword, "Your Old Password doesn't match");
                isFormValidationOk = false;
                return;
            }
        }

        private void getUserDetails(string userId)
        {
            getDataFromDatabase(userId);
            txtUsername.Text = userName;
            cboType.Text = userType.ToUpper();
            
        }

        private void getDataFromDatabase(string userId)
        {
            String query = "";
            //query = "SELECT username,password,type FROM userdetails WHERE userid = '" + userId + "';";
            query = "SELECT * FROM userdetails WHERE userid = '" + userId + "';";
            try
            {
                //declaring list inside a array
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class                    
                list = dbConn.Select(query, "userdetails");
                userName = list[1][0];
                password = list[2][0];
                userType = list[3][0];
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }//exception handling
        }
    }
}
