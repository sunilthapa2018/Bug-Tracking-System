using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bug_Tracking_Application.Programmer
{
    public partial class formAddBugSolution : Form
    {
        DBConnect dbConn = new DBConnect();
        String userId, reportId;        
        String textClassName, textMethodName, textLineNo, textErrorCode, textFixedCode;
        Boolean isFormValidationOk = true;

        public formAddBugSolution(String userId, String reportId)
        {
            InitializeComponent();
            this.userId = userId;
            this.reportId = reportId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateIfAnyFieldIsEmpty();
            if (!isFormValidationOk) { return; }
            insertNewRecordOnDatabase();
            reportBugSolved();
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

        private void txtMethodName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtErrorCode_TextChanged(object sender, EventArgs e)
        {
            checkText(txtErrorCode);
        }

        private void checkText(RichTextBox codeRichTextBox) {
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

        private void txtSolvedCode_TextChanged(object sender, EventArgs e)
        {
            checkText(txtSolvedCode);
        }

        //This function inserts new row of data to database and shows sucess message
        private void insertNewRecordOnDatabase()
        {
            string error = txtErrorCode.Text;
            string solution = txtSolvedCode.Text;
            string className = txtClassName.Text;
            string methodName = txtMethodName.Text;
            string line = txtLineNumber.Text;
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                dbConn.executeQuery("INSERT INTO bugsolve (solveid, reportid, solvedate, userid, error, solution, " +
                    "class, method, line)" + " VALUES " +
                    "(NULL, '" + reportId + "','" + date + "', '" + userId + "','" + error + "','" +
                    solution + "','" + className + "','" + methodName + "', '" + line + "');");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
            MessageBox.Show("You have sucessfully uploaded a bug solution");
            this.Close();
        }

        //Sets status of bugreports table to 'solved'
        private void reportBugSolved() {            
            dbConn.executeQuery("UPDATE bugreports SET status = 'solved' WHERE reportid = '" + reportId + "';");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAddSolution_Load(object sender, EventArgs e)
        {
            getBugAndAppName();
            WindowState = FormWindowState.Maximized;

        }

        //get bugs and app names from database and load it to textboxs
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
    }
}
