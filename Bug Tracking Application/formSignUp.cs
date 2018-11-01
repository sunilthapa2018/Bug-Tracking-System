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
    
    public partial class formSignUp : Form
    {
        String textUsername, textPassword, textConfirmPassoword, comboType;
        Boolean isFormValidationOk = true;
        DBConnect dbConn = new DBConnect();
        public formSignUp()
        {
            InitializeComponent();
        }

        private void formSignUp_Load(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsername, null);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassword, null);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formLogin = new formLogin();                                
            formLogin.ShowDialog();
            this.Close();
            
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //initializing variables
            textUsername = "";
            textPassword = "";
            textConfirmPassoword = "";
            comboType = "";

            textUsername = txtUsername.Text;
            textPassword = txtPassword.Text;
            textConfirmPassoword = txtConfirmPassword.Text;
            comboType = cboType.Text;

            validateForm();
            if (!isFormValidationOk) {
                return;
            }            
            if (checkIfUserAlreadyExist()) {
                errorProvider1.SetError(txtUsername, null);
                errorProvider1.SetError(txtUsername, "User Already Registered,Please Enter New Username");
                txtUsername.Focus();
                return;
            }
            
            Encrypter encrypter = new Encrypter();
            String conPass = encrypter.MD5Hash(txtPassword.Text);
            try {
                dbConn.executeQuery("INSERT INTO userdetails (userid, username, password, type) VALUES " +
                    "(NULL, '" + textUsername + "','" + conPass + "', '" + comboType.ToLower() + "');");                
                MessageBox.Show("A New User have been Registered");
            }
            catch (Exception ex) {
                MessageBox.Show("" + ex.StackTrace);
            }
            


            
        }
        private void validateForm() {
            Boolean isAnythingEmpty = false;
            isFormValidationOk = true;
            if (string.IsNullOrEmpty(textConfirmPassoword))
            {
                errorProvider1.SetError(txtConfirmPassword, null);
                errorProvider1.SetError(txtConfirmPassword, "Please Enter Confirm Password");
                txtConfirmPassword.Focus();
                isAnythingEmpty = true;                
            }
            if (string.IsNullOrEmpty(textPassword))
            {
                errorProvider1.SetError(txtPassword, null);
                errorProvider1.SetError(txtPassword, "Please Enter Password");
                txtPassword.Focus();
                isAnythingEmpty = true;
                
            }
            if (string.IsNullOrEmpty(textUsername))
            {
                errorProvider1.SetError(txtUsername, null);
                errorProvider1.SetError(txtUsername, "Please Enter Username");
                txtUsername.Focus();
                isAnythingEmpty = true;
                
            }
            if (isAnythingEmpty || !textPassword.Equals(textConfirmPassoword))
            {
                isFormValidationOk = false;
                return;
            }
            if (!textPassword.Equals(textConfirmPassoword))
            {
                errorProvider1.SetError(txtConfirmPassword, null);
                errorProvider1.SetError(txtConfirmPassword, "Your Confirm Password doesn't match");
                isFormValidationOk = false;
                return;
            }
        }
        private Boolean checkIfUserAlreadyExist() {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM userdetails where username = '" + textUsername + "'");
            if (numOfRows != 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
