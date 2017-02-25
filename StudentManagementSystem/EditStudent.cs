using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIZ;

namespace StudentManagementSystem
{
    public partial class EditStudent : Form
    {
        Update update = new Update();
        StudentForm stu = new StudentForm();

        public List<Student> studentList = new List<Student>();

        public EditStudent()
        {
            InitializeComponent();
        }

        private void btnAddToDb_Click(object sender, EventArgs e)
        {
            string level = rdoPost.Text;
            StudentForm stu = new StudentForm();
            string selectRow = stu.dgv.SelectedRows.ToString();
            string fname = lblFName.Text;
            string sname = lblSName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string add1 = txtAddress1.Text;
            string add2 = txtAddress2.Text;
            string city = txtCity.Text;
            string course = lblCourse.Text;
            string county = cmbCounty.GetItemText(cmbCounty.SelectedItem);
            int numstu = Convert.ToInt32(lblNum.Text);
            
            if (rdoPost.Checked == true)
            {
                level = "Postgrad";
            }
            else if (rdoUnder.Checked == true)
            {
                level = "Undergrad";
            }
            update.EditMethod(selectRow, numstu, fname, sname, email, phone, add1, add2, city, county, level, course);
            this.Close();
            update.UpdateGrid(stu.dgv);
            stu.Show();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void EditStudent_Load(object sender, EventArgs e)
        {
            lblNum.Text = studentList[0].Num;
            lblFName.Text = studentList[0].FirstName;
            lblSName.Text = studentList[0].Surname;
            txtEmail.Text = studentList[0].Email;
            txtPhone.Text = studentList[0].Phone;
            txtAddress1.Text = studentList[0].Address1;
            txtAddress2.Text = studentList[0].Address2;
            txtCity.Text = studentList[0].City;
            cmbCounty.Text = studentList[0].County;
            if (studentList[0].Level == "PostGrad")
            {
                rdoPost.Checked = true;
            }
            else if (studentList[0].Level == "Undergrad")
            {
                rdoUnder.Checked = true;
            }
            lblCourse.Text = studentList[0].Course;

            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
