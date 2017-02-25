using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using BIZ;
using DAL;


namespace StudentManagementSystem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToDb_Click(object sender, EventArgs e)
        {
           
            //int sNum = int.Parse(txtNum.Text);
            string fname = txtFn.Text;
            string lname = txtSur.Text;
            string email = txtEmail.Text;
            string phone =txtPhone.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string city = txtCity.Text;
            string county = cmbCounty.SelectedItem.ToString();
            string level = "Postgrad";
            if (rdoPost.Checked)
            {
                level = "Postgrad";
            }
            else if (rdoUnder.Checked)
            {
                level = "Undergrad";
            }

            string course = cmbCourse.SelectedItem.ToString();
            Student ans = new Student(fname, lname, email, phone, address1, address2, city, county, level, course);

           

            //AddNewCustomer

            ans.addNewStudentToDB();
            DAO dao = new DAO();
            SqlCommand cmd = new SqlCommand();
            MessageBox.Show("Data Added", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);



            cmd.ExecuteNonQuery();
            dao.CloseCon();

            txtFn.Clear();
            txtSur.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtCity.Clear();

            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            XmlSerializer serialiser;
            XmlWriter xmlWriter;
            string filePath = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();

            //int sNum = int.Parse(txtNum.Text);
            string fname = txtFn.Text;
            string lname = txtSur.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address1 = txtAddress1.Text;
            string address2 = txtAddress2.Text;
            string city = txtCity.Text;
            string county = cmbCounty.SelectedItem.ToString();
            string level = "Postgrad";
            if (rdoPost.Checked)
            {
                level = "Postgrad";
            }
            else if (rdoUnder.Checked)
            {
                level = "Undergrad";
            }

            string course = cmbCourse.SelectedItem.ToString();
            Student ans = new Student(fname, lname, email, phone, address1, address2, city, county, level, course);

            //if (ans.Validate())
            //{
                sfdFile.InitialDirectory = "C:\\";
                sfdFile.Filter = "xml Files (*.xml)|*.xml";

                if (sfdFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = sfdFile.FileName;

                    serialiser = new XmlSerializer(typeof(Student));
                    xmlWriter = XmlWriter.Create(filePath);
                    serialiser.Serialize(xmlWriter, ans);
                    MessageBox.Show("Successfully Added");
                    ans.addNewStudentToDB();

                    txtFn.Clear();
                    txtSur.Clear();
                    txtEmail.Clear();
                    txtPhone.Clear();
                    txtAddress1.Clear();
                    txtAddress2.Clear();
                    txtCity.Clear();
                    this.Close();
                }

            //}
            //else
            //{
                MessageBox.Show("Invalid Details");
            //}

            //AddNewCustomer


            


        }
    }
}
