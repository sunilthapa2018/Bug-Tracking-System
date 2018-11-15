using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application.Admin
{
    public partial class formEditProjectNames : Form
    {
        DBConnect dbConn = new DBConnect();
        public formEditProjectNames()
        {
            InitializeComponent();
        }

        private void formEditProjectNames_Load(object sender, EventArgs e)
        {
            //making datagridview select whole row on cell select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //making datagridview alternate rows color different
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            getProjectNames();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getProjectNames();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //this function reads projectNames from database and load it to datagridview
        private void getProjectNames()
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<string>[] list = new List<string>[4];
                //sending sql command to dbConnect class
                list = dbConn.Select("Select * from project;", "project");
                for (int i = 0; i < list[0].Count(); i++)
                {
                    this.dataGridView1.Rows.Add(list[0][i], list[1][i]);
                }
                if (list[0].Count() <= 0)
                {
                    dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("No Rows Found");
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.StackTrace); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (!value.Equals("No Rows Found"))
            {
                int projectId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                formEditProjectName formEditProjectName = new formEditProjectName("" + projectId);
                formEditProjectName.Show();
            }
        }
    }
}
