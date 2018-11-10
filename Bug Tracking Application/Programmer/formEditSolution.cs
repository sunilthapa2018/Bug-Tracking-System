﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void formEditSolution_Load(object sender, EventArgs e)
        {
            getBugAndAppName();
            getDetailsFromDB();
        }

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

        private void validateIfAnyFieldIsEmpty()
        {
            //initializing variables
            textClassName = "";
            textMethodName = "";
            textLineNo = "";
            textErrorCode = "";
            textFixedCode = "";
            isFormValidationOk = true;
            Boolean isAnythingEmpty = false;

            //assigning values to variables
            textClassName = txtClassName.Text;
            textMethodName = txtMethodName.Text;
            textLineNo = txtLineNumber.Text;
            textErrorCode = txtErrorCode.Text;
            textFixedCode = txtSolvedCode.Text;

            //clearing error provider
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
        private void reportBugSolved()
        {
            dbConn.executeQuery("UPDATE bugreports SET status = 'solved' WHERE reportid = '" + reportId + "';");
        }

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
