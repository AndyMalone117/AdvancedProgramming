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
            string pass = txtPass.Text;

            string status = log.CheckUser(user, pass);



                if(status == "no")
                {
                    MessageBox.Show("invalid login");
                }
                else
                {
                
                StudentForm home = new StudentForm();
                home.Show();

                
            }

        }

        //DAO dao = new DAO();
        //SqlDataAdapter da;
        //DataTable dt;
        //BindingSource bs;

        //public void UpdateGrid()
        //{
        //    dt = new DataTable();
        //    bs = new BindingSource();
        //    da = new SqlDataAdapter();

        //    SqlCommand cmd = dao.OpenCon().CreateCommand();
        //    cmd.CommandText = "uspGetStudent";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    da.SelectCommand = cmd;
        //    da.Fill(dt);
        //    bs.DataSource = dt;
        //    dgv.DataSource = bs;

        //    MessageBox.Show("Data Added", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStu = new AddStudent();
            addStu.Show();

        }
    }
}
