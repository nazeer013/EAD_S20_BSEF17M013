using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myForm1.DAL
{
    class UserDAL
    {
        public string sqlStr = @"server=DESKTOP-G68E64T\SQLEXPRESS2012; database=Assignment4;Integrated Security=SSPI";

        public int checkUserLogin(UserDTO data)
        {
            int userId;
            if (data.Login == "" || data.Password == "")
            {
                return -1;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(sqlStr))
                {
                    conn.Open();
                    string validateQuery = "select * from Users Where Login = '{0}' AND Password= '{1}'";
                    validateQuery = String.Format(validateQuery, data.Login, data.Password);
                    SqlCommand checkCommand = new SqlCommand(validateQuery, conn);
                    SqlDataReader reader = checkCommand.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        userId = reader.GetInt32(0);
                    }
                    else
                    {
                        userId = 0;
                    }
                    reader.Close();
                }
            }
            return userId;
        }


        public int insertNewUser(UserDTO data)
        {
            if (data.Name == "" || data.Login == "" || data.Password == "" || data.Email == "" || data.Address == "" ||

                    data.NIC == "" || data.Age < 0 || data.Gender == ' ' || data.ImageName == "")
            {
                return -1;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(sqlStr))
                {
                    conn.Open();
                    string duplicateCheckQuery = "select * from Users Where Login = '{0}' OR Email = '{1}'";
                    duplicateCheckQuery = String.Format(duplicateCheckQuery, data.Login, data.Email);
                    SqlCommand checkCommand = new SqlCommand(duplicateCheckQuery, conn);
                    SqlDataReader reader = checkCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        return -2;
                    }
                    reader.Close();
                    string query = "insert into Users (Name,Login,Password,Email,Gender,Address,Age,NIC,DOB,IsCricket,Hockey,Chess,ImageName,CreatedOn ) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')";
                    query = String.Format(query, data.Name, data.Login, data.Password, data.Email, data.Gender, data.Address, data.Age, data.NIC, data.DOB, data.IsCricket, data.Hockey, data.Chess, data.ImageName, data.CreatedOn.ToString());
                    SqlCommand command = new SqlCommand(query, conn);
                    int userId = command.ExecuteNonQuery();
                    if (userId > 0)
                    {
                        query = "SELECT MAX(UserID) FROM Users";
                        SqlCommand lastIDcommand = new SqlCommand(query, conn);
                        SqlDataReader insertReader = lastIDcommand.ExecuteReader();
                        insertReader.Read();
                        userId = insertReader.GetInt32(0);
                        insertReader.Close();
                    }
                    return userId;
                }
            }

        }

        public int updateUser(int id, UserDTO data)
        {
            int userId;
            using (SqlConnection conn = new SqlConnection(sqlStr))
            {
                conn.Open();
                string dataQuery = String.Format("Select * from Users Where UserID = {0}", id);
                SqlCommand command = new SqlCommand(dataQuery, conn);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (data.Name == "")
                        data.Name = reader.GetString(1);
                    if (data.Login == "")
                        data.Login = reader.GetString(2);
                    if (data.Password == "")
                        data.Password = reader.GetString(3);
                    if (data.Email == "")
                        data.Email = reader.GetString(4);
                    if (data.Gender == ' ')
                        data.Gender = reader.GetChar(5);
                    if (data.Address == "")
                        data.Address = reader.GetString(6);
                    if (data.Age == 0)
                        data.Age = reader.GetInt32(7);
                    if (data.NIC == "")
                        data.NIC = reader.GetString(8);
                    if (data.DOB == DateTime.Now)
                        data.DOB = reader.GetDateTime(9);
                    if (data.IsCricket == "")
                        data.IsCricket = reader.GetString(10);
                    if (data.Hockey == "")
                        data.Hockey = reader.GetString(11);
                    if (data.Chess == "")
                        data.Chess = reader.GetString(12);
                    if (data.ImageName == "")
                        data.ImageName = reader.GetString(13);
                }
                reader.Close();
                string query = "Update Users SET Name = '{0}', Login='{1}',Password='{2}',Email='{3}',Gender='{4}',Address='{5}',Age='{6}',NIC='{7}',DOB='{8}',IsCricket='{9}',Hockey='{10}',Chess='{11}',ImageName='{12}' WHERE UserID = '{13}'";

                query = String.Format(query, data.Name, data.Login, data.Password, data.Email, data.Gender, data.Address, data.Age, data.NIC, data.DOB, data.IsCricket, data.Hockey, data.Chess, data.ImageName, id);
                command = new SqlCommand(query, conn);
                userId = command.ExecuteNonQuery();
            }
            return userId;
        }

        public UserDTO getUser(int id)
        {
            UserDTO user = new UserDTO();
            using (SqlConnection conn = new SqlConnection(sqlStr))
            {
                conn.Open();
                String query = String.Format("Select * from Users Where UserID = {0}", id);
                SqlCommand command = new SqlCommand(query, conn);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.UserID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Login = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Gender = Convert.ToChar(reader.GetString(5));
                    user.Address = reader.GetString(6);
                    user.Age = reader.GetInt32(7);
                    user.NIC = reader.GetString(8);
                    user.DOB = reader.GetDateTime(9);
                    user.IsCricket = reader.GetBoolean(10).ToString();
                    user.Hockey = reader.GetBoolean(11).ToString();
                    user.Chess = reader.GetBoolean(12).ToString();
                    user.ImageName = reader.GetString(13);
                }
                else
                {
                    user.UserID = -1;
                }
            }
            return user;
        }
    }
}
