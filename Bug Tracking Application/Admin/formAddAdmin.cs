﻿using System;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Admin
{
    public partial class formAddAdmin : Form
    {
        String textUsername, textPassword, textConfirmPassoword, comboType;
        Boolean isFormValidationOk = true;
        DBConnect dbConn = new DBConnect();
        public formAddAdmin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {            
            textUsername = "";
            textPassword = "";
            textConfirmPassoword = "";
            comboType = "";

            textUsername = txtUsername.Text;
            textPassword = txtPassword.Text;
            textConfirmPassoword = txtConfirmPassword.Text;
            comboType = cboType.Text;

            //First Validate our form data
            validateForm();
            //if form validation is not ok then dont execute further lines of code
            if (!isFormValidationOk){return;}
            //to check if username is already registered in our database
            if (checkIfUserAlreadyExist())
            {
                errorProvider1.SetError(txtUsername, null);
                errorProvider1.SetError(txtUsername, "User Already Registered,Please Enter New Username");
                txtUsername.Focus();
                return;
            }

            Encrypter encrypter = new Encrypter();
            //getting md5 hashed code to conPass
            String conPass = encrypter.MD5Hash(txtPassword.Text);
            try
            {
                dbConn.executeQuery("INSERT INTO userdetails (userid, username, password, type, status) VALUES " +
                    "(NULL, '" + textUsername + "','" + conPass + "', '" + comboType.ToLower() + "','active');");
                MessageBox.Show("A New ADMIN has been Registered");
                txtConfirmPassword.Clear();
                txtPassword.Clear();
                txtUsername.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.StackTrace);
            }
        }

        private void formAddAdmin_Load(object sender, EventArgs e)
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignUp.PerformClick();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //check if anything is empty or invalid
        private void validateForm()
        {
            Boolean isAnythingEmpty = false;
            isFormValidationOk = true;
            errorProvider1.SetError(txtConfirmPassword, null);
            errorProvider1.SetError(txtPassword, null);
            errorProvider1.SetError(txtUsername, null);
            if (string.IsNullOrEmpty(textConfirmPassoword))
            {
                errorProvider1.SetError(txtConfirmPassword, "Please Enter Confirm Password");
                txtConfirmPassword.Focus();
                isAnythingEmpty = true;
            }
            if (string.IsNullOrEmpty(textPassword))
            {
                errorProvider1.SetError(txtPassword, "Please Enter Password");
                txtPassword.Focus();
                isAnythingEmpty = true;
            }
            if (string.IsNullOrEmpty(textUsername))
            {
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
                errorProvider1.SetError(txtConfirmPassword, "Your Confirm Password doesn't match");
                isFormValidationOk = false;
                return;
            }
        }
        //This function checks if username already exists in our program
        //Returns true if username doesnot exists
        //Returns false if username exists
        private Boolean checkIfUserAlreadyExist()
        {
            int numOfRows = dbConn.Count("SELECT Count(*) FROM userdetails where username = '" + textUsername + "'");
            if (numOfRows != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
