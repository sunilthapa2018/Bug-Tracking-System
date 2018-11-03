using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Bug_Tracking_Application
{
    public partial class formLogin : Form
    {
        String username,userId, password, type;
        String textUsername, textPassword;
        Boolean isFormValidationOk = true;
        public formLogin()
        {
            InitializeComponent();
            

        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtUsername, null);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassword, null);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text)) {
                    btnSignIn.PerformClick();
                }
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn.PerformClick();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();//hiding this form
            Form formSignUp = new formSignUp();                                
            formSignUp.ShowDialog();//opening formSignUp form
            this.Close();//close this form if formSignUp is closed


        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //initializing variables
            textUsername = "";
            textPassword = "";

            Encrypter encrypter = new Encrypter();
            
            textUsername = txtUsername.Text;
            //if password field is not empty then only encrypt it. Else leave it empty
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                textPassword = encrypter.MD5Hash(txtPassword.Text);
            }

            //checking if any field is empty
            validateIfAnyFieldIsEmpty();
            if (!isFormValidationOk){return;}//if form is not validated, dont execute futher lines of code

            //getting username and password from database
            if (!getDataFromDatabase()) { return; }
            
            //Check if password is correct            
            if (password.Equals(textPassword))
            {
                openUserDashboard();
            }
            //show invalid password error
            else
            {
                MessageBox.Show("Your Password doesn't match.");
            }

        }
        private void validateIfAnyFieldIsEmpty()
        {

            isFormValidationOk = true;
            Boolean isAnythingEmpty = false;
            //clearing errorprovider
            errorProvider1.SetError(txtPassword, null);
            errorProvider1.SetError(txtUsername, null);

            if (string.IsNullOrEmpty(textPassword))
            {
                //setting errorporvider and giving error message
                errorProvider1.SetError(txtPassword, "Please Enter Password");
                txtPassword.Focus();//focusing a textfield
                isAnythingEmpty = true;
            }
            if (string.IsNullOrEmpty(textUsername))
            {
                //setting errorporvider and giving error message
                errorProvider1.SetError(txtUsername, "Please Enter Username");
                txtUsername.Focus();//focusing a textfield
                isAnythingEmpty = true;
            }
            //if there is any field empty then setting form validation to false
            if (isAnythingEmpty)
            {
                isFormValidationOk = false;
                return;
            }
        }
        private Boolean getDataFromDatabase() {
            DBConnect dbConn = new DBConnect();

            int numOfRows = dbConn.Count("SELECT Count(*) FROM userdetails where username = '" + textUsername + "'");
            if (numOfRows > 0)
            {                
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from userdetails where username = '" + textUsername + "'", "userdetails");
                userId = list[0][0];
                username = list[1][0];
                password = list[2][0];
                type = list[3][0];
                return true;
            }
            else{
                MessageBox.Show("This user is not Registered");
                return false;
            }

            
        }
        

        private void openUserDashboard()
        {
            //if username and password both are valid open dashboard                
            if (type.Equals("admin"))
            {
                //open admin dashboard
                MessageBox.Show("Admin");
                return;
            }
            if (type.Equals("programmer"))
            {
                //open programmer dashboard
                MessageBox.Show("programmer");
                return;
            }
            if (type.Equals("user"))
            {
                //open user dashboard
                this.Hide();
                formUser formUser = new formUser(username,userId);
                formUser.ShowDialog();
                this.Close();
                
            }
        }
 
    }
}
