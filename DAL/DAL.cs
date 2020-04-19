
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL
    {
        public static List<Folders> GetFolders(int ID)
        {
            List<Folders> l1 = new List<Folders>();
            string connString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog = Assignment3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlQuery = "Select * from UserTable where Parent=" + ID;
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read() == true)
            {
                Folders f1 = new Folders();
                f1.ID = (int)reader.GetValue(0);
                f1.Name = (string)reader.GetValue(1);
                f1.Parent = (int)reader.GetValue(2);
                l1.Add(f1);
            }
            conn.Close();
            return l1;
        }
        public static int CreateFolder(int ID, string Name)
        {
            //DataBase Logic
            string connString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog = Assignment3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlQuery = "Insert into UserTable(Name,Parent) values('" + Name + "','" + ID + "');";
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.ExecuteNonQuery();
            sqlQuery = "Select ID from UserTable where Name=" + "'" + Name + "'";
            command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                int val = (int)reader.GetValue(0);
                conn.Close();
                return val;
            }
            else
            {
                conn.Close();
                return -1;
            }
            //return Redirect("~/Users/SignUp");
        }
        public static int ReturnParent(int Child)
        {
            string connString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog = Assignment3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlQuery = "Select Parent from UserTable where ID=" + Child;
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();
            int parent = -1;
            if (reader.Read() == true)
            {
                parent = (int)reader.GetValue(0);
            }
            conn.Close();
            return parent;
        }
    }

}