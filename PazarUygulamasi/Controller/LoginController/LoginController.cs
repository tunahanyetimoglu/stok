using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi.Controller.LoginController
{
    class LoginController
    {
        public LoginController(string email, string password)
        {
            setPermission(loginControl(email,password));
        }

        private int permission;

        public int getPermission()
        {
            return permission;
        }

        public void setPermission(int permission)
        {
            this.permission = permission;
        }


        private int  loginControl(string userEmail,string password)
        {
            int permission = 0;

            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT userPermission FROM tb_User where userEmail=@email and userPassword=@password", connection);
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@email", userEmail);
                selectCommand.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();

                if( reader[0].ToString() == "1")
                {
                    permission = 1;
                }else
                {
                    permission = 2;
                }
                return permission;
            }catch
            {
                MessageBox.Show("Başarısız giriş denemesi.");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return permission;
        }
        
    }
}
