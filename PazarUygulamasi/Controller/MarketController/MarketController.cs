using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi.Controller.MarketController
{
    class MarketController
    {
        private int marketId;
        private string marketAd;
        private string marketTelefon;
        private DataTable marketCiroList;
        private int marketNetKazanc;

        public MarketController(int id)
        {
            getMarketInformation(id);
            setMarketCiroList(getSQLMarketCiroList(getMarketId()));
            getSQLMarketNetKanac(getMarketId());
        }

        public int getMarketId()
        {
            return marketId;
        }
        public void setMarketId(int marketId)
        {
            this.marketId = marketId;
        }
        public string getMarketAd()
        {
            return marketAd;
        }
        public void setMarketAd(string marketAd)
        {
            this.marketAd = marketAd;
        }
        public string getMarketTelefon()
        {
            return marketTelefon;
        }
        public void setMarketTelefon(string marketTelefon)
        {
            this.marketTelefon = marketTelefon;
        }

        public void setMarketCiroList(DataTable marketCiroList)
        {
            this.marketCiroList = marketCiroList;
        }

        public int getMarketNetKazanc()
        {
            return marketNetKazanc;
        }
        public void setMarketNetKazanc(int marketNetKazanc)
        {
            this.marketNetKazanc = marketNetKazanc;
        }
        public DataTable getMarketCiroList()
        {
            return marketCiroList;
        }



        private void getMarketInformation(int id)
        {
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            try
            {         
                SqlCommand command = new SqlCommand("SP_SELECT_MARKET", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@yonetici", SqlDbType.VarChar).Value = id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                setMarketId(Convert.ToInt32(reader[0].ToString()));
                setMarketAd(reader[1].ToString());
                setMarketTelefon(reader[2].ToString());
            }
            catch
            {
                MessageBox.Show("Market Bilgileri Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
        }

        private DataTable getSQLMarketCiroList(int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SP_SELECT_MARKETCIRO", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Market Ciro Listesi Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;     
        }
        public static DataTable getSQLSearchByUrun(String urunAd, int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SP_SEARCH_URUNAD", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = urunAd;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Ürün aranırken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;
        }
        public static DataTable getSQLSearchByMusteri(String musteriAd, int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SP_SEARCH_USERAD", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@musteriAd", SqlDbType.VarChar).Value = musteriAd;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Ürün aranırken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;
        }

        public static DataTable getSQLSearchByUrunAdet(int min,int max, int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SP_SEARCH_URUNADET", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@min", SqlDbType.VarChar).Value = min;
            command.Parameters.Add("@max", SqlDbType.VarChar).Value = max;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Ürün aranırken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;
        }

        private void getSQLMarketNetKanac(int marketId)
        {
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            

            try
            {
                SqlCommand command = new SqlCommand("SP_SELECT_NETKAZANC", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                setMarketNetKazanc(Convert.ToInt32(reader[0].ToString()));
            }
            catch
            {
                MessageBox.Show("Market NetKazanc Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }

        }


    }
}
