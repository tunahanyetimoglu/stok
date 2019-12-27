using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PazarUygulamasi.DAO
{
    public class DAOConnection
    {
        public static SqlConnection connectionOpen()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-ILQ2O4D;Database= pazarSistemi;Trusted_Connection=True;";

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("SQL Bağlantı Sırasında Hatası Oluştur. Lütten Bağlantınızı veya Bağlantı Metninizi kontrol ediniz.");
            }
            return connection;
        }

        public static bool connectionClose(SqlConnection connection)
        {
            bool state;

            try
            {
                connection.Close();
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    state = true;
                }
                else
                {
                    state = false;
                }
            }catch (Exception)
            {
                MessageBox.Show("SQL Bağlantı Kapatma sırasında hata oluştu. Lütfen Bağlantı kapatma işleminizi kontrol ediniz.");
                return false;
            }
            return state;
        }
    }
}