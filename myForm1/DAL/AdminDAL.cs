using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace myForm1.DAL
{
    public class AdminDAL
    {
        public string sqlStr = @"server=DESKTOP-G68E64T\SQLEXPRESS2012; database=Assignment4;Integrated Security=SSPI";
        public bool CheckAdminLogin(string login, string pass)
        {
            bool ok;
            if (login == "" || pass == "")
            {
                return false;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(sqlStr))
                {
                    conn.Open();
                    string query = "select * from Admin Where Login = '{0}' AND Password= '{1}'";
                    query = String.Format(query, login, pass);
                    SqlCommand checkCommand = new SqlCommand(query, conn);
                    SqlDataReader reader = checkCommand.ExecuteReader();
                    ok = reader.Read();
                    reader.Close();
                }
                return ok;
            }
        }


        public DataTable GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(sqlStr))
            {
                conn.Open();

                String query = "Select UserID,Name,Login,Address,Age from Users";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }
}
