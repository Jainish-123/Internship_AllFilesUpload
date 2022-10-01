using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classADO_7
{
    public class test
    {
        private string conStr;
        private SqlConnection con;

        public void connection()
        {
            conStr = @"Data Source = DESKTOP-TA8BLLL\SQLEXPRESS; Initial Catalog = webapi; Integrated Security = true;";
            con = new SqlConnection(conStr);
        }

        public void InsertAllFile(string path)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("insert into AllFile(File_Path) values('" + path + "')", con);
            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }
    }
}
