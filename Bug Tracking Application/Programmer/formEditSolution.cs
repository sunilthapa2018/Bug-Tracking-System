using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bug_Tracking_Application.Programmer
{    
    public partial class formEditSolution : Form
    {
        DBConnect dbConn = new DBConnect();
        String userId, solveId , reportId;
        String textClassName, textMethodName, textLineNo, textErrorCode, textFixedCode;
        Boolean isFormValidationOk = true;
        public formEditSolution(String userId, String solveId, String reportId)
        {
            InitializeComponent();
            this.userId = userId;
            this.solveId = solveId;
            this.reportId = reportId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateIfAnyFieldIsEmpty();
            if (!isFormValidationOk) { return; }
            editRecordOnDatabase();
            reportBugSolved();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBugName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtAppName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtClassName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }
        //checks which button is pressed
        //only process if enter key is pressed
        private void checkPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void txtLineNumber_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtErrorCode_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtSolvedCode_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtMethodName_KeyDown(object sender, KeyEventArgs e)
        {
            checkPress(e);
        }

        private void txtErrorCode_TextChanged(object sender, EventArgs e)
        {
            checkText(txtErrorCode);
        }

        private void txtSolvedCode_TextChanged(object sender, EventArgs e)
        {
            checkText(txtSolvedCode);
        }

        private void formEditSolution_Load(object sender, EventArgs e)
        {
            getBugAndAppName();
            getDetailsFromDB();
        }

        //loads data from database to textboxes
        private void getDetailsFromDB()
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class                
                list = dbConn.Select("Select * from bugsolve WHERE solveid = '" + solveId + "';", "bugsolve");
                for (int i = 0; i < list[0].Count(); i++)
                {              
                    txtErrorCode.Text = list[4][0];
                    txtSolvedCode.Text = list[5][0];
                    txtClassName.Text = list[6][0];
                    txtMethodName.Text = list[7][0];
                    txtLineNumber.Text = list[8][0];
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        //checks if anyfield is empty or invalid
        //makes isFormValidationOk true if everything is valid
        //makes isFormValidationOk false if anything is invalid
        private void validateIfAnyFieldIsEmpty()
        {            
            textClassName = "";
            textMethodName = "";
            textLineNo = "";
            textErrorCode = "";
            textFixedCode = "";
            isFormValidationOk = true;
            Boolean isAnythingEmpty = false;
            
            textClassName = txtClassName.Text;
            textMethodName = txtMethodName.Text;
            textLineNo = txtLineNumber.Text;
            textErrorCode = txtErrorCode.Text;
            textFixedCode = txtSolvedCode.Text;
            
            errorProvider1.SetError(txtSolvedCode, null);
            errorProvider1.SetError(txtErrorCode, null);


            if (string.IsNullOrEmpty(textFixedCode))
            {
                //setting errorporvider and giving error message
                errorProvider1.SetError(txtSolvedCode, "Please Enter Solved Codes");
                txtSolvedCode.Focus();
                isAnythingEmpty = true;
            }

            if (string.IsNullOrEmpty(textErrorCode))
            {
                //setting errorporvider and giving error message
                errorProvider1.SetError(txtErrorCode, "Please Enter Error Codes");
                txtErrorCode.Focus();
                isAnythingEmpty = true;
            }

            if (isAnythingEmpty)
            {
                isFormValidationOk = false;
            }
        }

        //edit a record in database and show sucess message
        private void editRecordOnDatabase()
        {
            string error = txtErrorCode.Text;
            string solution = txtSolvedCode.Text;
            string className = txtClassName.Text;
            string methodName = txtMethodName.Text;
            string line = txtLineNumber.Text;
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");                
                String query = "UPDATE bugsolve SET " +
                    "error ='" + txtErrorCode.Text + "'," +
                    "solution = '" + txtSolvedCode.Text + "'," +
                    "class ='" + txtClassName.Text + "'," +
                    "method ='" + txtMethodName.Text + "'," +
                    "line ='" + txtLineNumber.Text + "' WHERE solveid = '" + solveId + "';";
                dbConn.executeQuery(query);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            MessageBox.Show("You have sucessfully Edited a bug solution");
            this.Close();
        }

        //Sets status of bugreports table to 'solved'
        private void reportBugSolved()
        {
            dbConn.executeQuery("UPDATE bugreports SET status = 'solved' WHERE reportid = '" + reportId + "';");
        }

        //read bug and app name from database and load it to respective textboxes
        private void getBugAndAppName()
        {
            try
            {
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class                
                list = dbConn.Select("Select * from bugreports WHERE reportid = '" + reportId + "';", "bugreports");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    List<string>[] list2 = new List<string>[4];
                    //sending sql command to dbConnect class
                    list2 = dbConn.Select("Select * from bug WHERE bugid = '" + list[1][0] + "';", "bug");
                    txtBugName.Text = list2[1][0];
                    txtAppName.Text = list2[2][0];

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }
        private void checkText(RichTextBox codeRichTextBox)
        {
            // getting keywords/functions
            string keywords = @"\b(public|private|partial|static|namespace|class|using|void|foreach|in|String|string|Boolean|int)\b";
            MatchCollection keywordMatches = Regex.Matches(codeRichTextBox.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(Console)\b";
            MatchCollection typeMatches = Regex.Matches(codeRichTextBox.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(codeRichTextBox.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(codeRichTextBox.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = codeRichTextBox.SelectionStart;
            int originalLength = codeRichTextBox.SelectionLength;
            Color originalColor = Color.Black;

            // MANDATORY - focuses a label before highlighting (avoids blinking)
            lblTitle.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            codeRichTextBox.SelectionStart = 0;
            codeRichTextBox.SelectionLength = codeRichTextBox.Text.Length;
            codeRichTextBox.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                codeRichTextBox.SelectionStart = m.Index;
                codeRichTextBox.SelectionLength = m.Length;
                codeRichTextBox.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                codeRichTextBox.SelectionStart = m.Index;
                codeRichTextBox.SelectionLength = m.Length;
                codeRichTextBox.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                codeRichTextBox.SelectionStart = m.Index;
                codeRichTextBox.SelectionLength = m.Length;
                codeRichTextBox.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                codeRichTextBox.SelectionStart = m.Index;
                codeRichTextBox.SelectionLength = m.Length;
                codeRichTextBox.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            codeRichTextBox.SelectionStart = originalIndex;
            codeRichTextBox.SelectionLength = originalLength;
            codeRichTextBox.SelectionColor = originalColor;

            // giving back the focus
            codeRichTextBox.Focus();
        }

    }
}
