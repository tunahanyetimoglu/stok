using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi.Controller.UserController
{
    class UserController
    {
        private int userId;
        private string userName;
        private string userSurName;
        private string userEmail;

        public UserController(string email)
        {
            setUserId(userSQLId(email));
        }
        public UserController(int id)
        {
            setUserName(userSQLName(id));
            setUserSurName(userSQLSurName(id));
            setUserEmail(userSQLEmail(id));
        }
        public void setUserEmail(string userEmail)
        {
            this.userEmail = userEmail;
        }
        public string getUserEmail()
        {
            return userEmail;
        }
        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public string getUserName()
        {
            return userName;
        }
        public string getUserSurName()
        {
            return userSurName;
        }
        public void setUserSurName(string userSurName)
        {
            this.userSurName = userSurName;
        }
        public int getUserId()
        {
            return userId;
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        private int userSQLId(string userEmail)
        {
            int id = 0;
            SqlConnection connection = DAO.DAOConnection.connectionOpen();

            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT userId FROM tb_User where userEmail=@email", connection);
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@email", userEmail);
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                id = Convert.ToInt32(reader[0].ToString());
                return id;
            }
            catch
            {
                MessageBox.Show("Kullanıcı ID'si Bulunamadı.");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return id;
        }
        private string userSQLName(int userId)
        {
            string userName = "";
            SqlConnection connection = DAO.DAOConnection.connectionOpen();

            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT Name FROM tb_User_Detail where userId=@id", connection);
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@id", userId);
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                userName = reader[0].ToString();
                return userName;
            }
            catch
            {
                MessageBox.Show("Kullanıcı ADI Bulunamadı.");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return userName;
        }

        private string userSQLSurName(int userId)
        {
            string userSurName = "";
            SqlConnection connection = DAO.DAOConnection.connectionOpen();

            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT Surname FROM tb_User_Detail where userId=@id", connection);
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@id", userId);
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                userSurName = reader[0].ToString();
                return userSurName;
            }
            catch
            {
                MessageBox.Show("Kullanıcı SoyAdi Bulunamadı.");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return userSurName;
        }

        private string userSQLEmail(int userId)
        {
            string userEmail = "";
            SqlConnection connection = DAO.DAOConnection.connectionOpen();

            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT userEmail FROM tb_User where userId=@id", connection);
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@id", userId);
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                userEmail = reader[0].ToString();
                return userEmail;
            }
            catch
            {
                MessageBox.Show("Kullanıcı SoyAdi Bulunamadı.");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return userEmail;
        }
    }
}
