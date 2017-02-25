using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data;
using System.Windows.Forms;


namespace DAL
{
    public class AddData : DAO
    {
        public void AddNewStudent(string fname, string lname,string email, string phone, 
            string address1, string address2, string city, string county, string level, string course)
        {
            SqlCommand cmd = new SqlCommand

            ("INSERT INTO Students ( FirstName, Surname, Email, Phone, Address1, Address2, City, County, Level, Course) VALUES (@fn,@ln, @email,@phone, @address1,@address2, @city, @county, @level, @course)", OpenCon());
            cmd.Parameters.AddWithValue("fn", fname);
            cmd.Parameters.AddWithValue("ln", lname);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("address1", address1);
            cmd.Parameters.AddWithValue("address2", address2);
            cmd.Parameters.AddWithValue("city", city);
            cmd.Parameters.AddWithValue("county", county);
            cmd.Parameters.AddWithValue("level", level);
            cmd.Parameters.AddWithValue("course", course);

            cmd.ExecuteNonQuery();
            CloseCon();

        }

        public void EditStudent(string selectRow, int numstu, string fname, string lname, string email, string phone,
           string address1, string address2, string city, string county, string level, string course)
        {
            string edit = "UPDATE Students SET Email = @email, Phone = @phone, Address1 = @address1, Address2 = @address2,City = @city, County = @county, Level = @level Where FirstName=@fn AND Surname=@ln";
            SqlCommand cmd = new SqlCommand(edit, OpenCon());
            cmd.Parameters.AddWithValue("num", numstu);
            cmd.Parameters.AddWithValue("fn", fname);
            cmd.Parameters.AddWithValue("ln", lname);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("address1", address1);
            cmd.Parameters.AddWithValue("address2", address2);
            cmd.Parameters.AddWithValue("city", city);
            cmd.Parameters.AddWithValue("county", county);
            cmd.Parameters.AddWithValue("level", level);
            cmd.Parameters.AddWithValue("course", course);

            cmd.ExecuteNonQuery();
            CloseCon();

        }

        SqlDataAdapter da;
        DataTable dt;
        BindingSource bs;

        public BindingSource UpdateGridView()
        {
            dt = new DataTable();
            bs = new BindingSource();
            da = new SqlDataAdapter();

            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspGetStudents";
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            bs.DataSource = dt;


            return bs;
        }
    }
}
