using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BIZ;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HashCode hc = new HashCode();

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Login log = new Login();


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = hc.PassHash(txtPass.Text);

            string status = log.CheckUser(user, pass);

            if (status == "no")
            {
                MessageBox.Show("invalid login");
            }
            else
            {
                StudentForm home = new StudentForm();
                home.Show();

                txtUser.Clear();
                txtPass.Clear();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
