using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BIZ
{
    public class Update : AddData
    {
        public void UpdateGrid(DataGridView dgv)
        {
            dgv.DataSource = UpdateGridView(); 
        }

        public void EditMethod(string selectRow, int numstu, string fname, string sname, string  email, string phone, string add1, 
            string add2, string city, string county, string level, string course)
        {
           EditStudent(selectRow, numstu, fname, sname, email, phone, add1, add2, city, county, level, course);
        }
    }
}
