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
    public partial class formAdmin : Form
    {
        formAdminHome formAdminHome;
        String userId, userName;
        public formAdmin(String userName, String userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            formAdminHome = new formAdminHome(userId);
            formAdminHome.MdiParent = this;
            formAdminHome.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formAdminHome.Visible)
            {
                formAdminHome = new formAdminHome(userId);
                formAdminHome.MdiParent = this;
                formAdminHome.Show();
            }
            else
            {
                formAdminHome.Activate();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formLogin = new formLogin();
            formLogin.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
