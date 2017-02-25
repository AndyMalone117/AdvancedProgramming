using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;

namespace BIZ
{
    public class Login : DAO
    {
        public string UserLoginName { get; set; }

        public string CheckUser(string user, string pass)
        {
            SqlDataReader dr = null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Staff WHERE Username=@user AND Password=@pass", OpenCon());
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string yes = "Login Successful";
                return yes;


            }
            else
            {
                string no = "no";
                return no;
            }
        }
    }
}
