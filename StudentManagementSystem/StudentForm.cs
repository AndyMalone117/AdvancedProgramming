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
using BIZ;
using DAL;


namespace StudentManagementSystem
{
    public partial class StudentForm : Form
    {
        DAO dao = new DAO();
        Update up = new Update();
        public static string row;
        public StudentForm()
        {
            InitializeComponent();
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStu = new AddStudent();
            addStu.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string del = "DELETE FROM Students WHERE StudentID = @stuID";
            SqlCommand cmd = new SqlCommand(del, dao.OpenCon());
            cmd.Parameters.AddWithValue("@stuID", dgv.SelectedRows[0].Cells[0].Value);
            cmd.ExecuteScalar();
            dao.CloseCon();
            up.UpdateGridView();
        }

        public void LoadDataGrid()
        {
            up.UpdateGrid(dgv);

            //if (dgv.Columns.Count > 0)
            //{
            //    dgv.Columns[0].HeaderText = "Student Number";
            //    dgv.Columns[1].HeaderText = "First Name";
            //    dgv.Columns[2].HeaderText = "Surname";
            //    dgv.Columns[3].HeaderText = "Email";
            //    dgv.Columns[4].HeaderText = "Phone";
            //    dgv.Columns[5].HeaderText = "Address Line 1";
            //    dgv.Columns[6].HeaderText = "Address Line 2";
            //    dgv.Columns[7].HeaderText = "City";
            //    dgv.Columns[8].HeaderText = "County";
            //    dgv.Columns[2].HeaderText = "Level";
            //    dgv.Columns[9].HeaderText = "Course";
            //}
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            up.UpdateGrid(dgv);
            LoadDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent addStu = new AddStudent();
            addStu.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditStudent editStu = new EditStudent();
            if (dgv.SelectedRows.Count > 0)
            {
                this.Hide();

                Student stu = new Student();

                string selectRow = dgv.SelectedRows[0].Cells[0].Value.ToString();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    stu.Num = row.Cells[0].Value.ToString();
                    stu.FirstName = row.Cells[1].Value.ToString();
                    stu.Surname = row.Cells[2].Value.ToString();
                    stu.Email = row.Cells[3].Value.ToString();
                    stu.Phone = row.Cells[4].Value.ToString();
                    stu.Address1 = row.Cells[5].Value.ToString();
                    stu.Address2 = row.Cells[6].Value.ToString();
                    stu.City = row.Cells[7].Value.ToString();
                    stu.County = row.Cells[8].Value.ToString();
                    if (row.Cells[9].Value.ToString() == "PostGrad")
                    {
                        stu.Level = "PostGrad";
                    }
                    else if (row.Cells[9].Value.ToString() == "UnderGrad")
                    {
                        stu.Level = "UnderGrad";

                    }
                    stu.Course = row.Cells[10].Value.ToString();
                    editStu.studentList.Add(stu);
                }

                editStu.Show();

            }
            else MessageBox.Show("Select a Row");

        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                this.Hide();

                EditStudent editStu = new EditStudent();

                Student stu = new Student();

                string selectRow = dgv.SelectedRows[0].Cells[0].Value.ToString();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    stu.Num = row.Cells[0].Value.ToString();
                    stu.FirstName = row.Cells[1].Value.ToString();
                    stu.Surname = row.Cells[2].Value.ToString();
                    stu.Email = row.Cells[3].Value.ToString();
                    stu.Phone = row.Cells[4].Value.ToString();
                    stu.Address1 = row.Cells[5].Value.ToString();
                    stu.Address2 = row.Cells[6].Value.ToString();
                    stu.City = row.Cells[7].Value.ToString();
                    stu.County = row.Cells[8].Value.ToString();
                    if (row.Cells[9].Value.ToString() == "PostGrad")
                    {
                        stu.Level = "PostGrad";
                    }
                    else if (row.Cells[9].Value.ToString() == "UnderGrad")
                    {
                        stu.Level = "UnderGrad";

                    }
                    stu.Course = row.Cells[10].Value.ToString();
                    editStu.studentList.Add(stu);
                }
                Console.WriteLine(stu.FirstName.ToString());

                editStu.Show();

            }
            else MessageBox.Show("Select a Row");


        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string del = "DELETE FROM Students WHERE StudentID = @stuID";
            SqlCommand cmd = new SqlCommand(del, dao.OpenCon());
            cmd.Parameters.AddWithValue("@stuID", dgv.SelectedRows[0].Cells[0].Value);
            cmd.ExecuteScalar();
            dao.CloseCon();
            up.UpdateGridView();
        }
    }
}
