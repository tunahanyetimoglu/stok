using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi.Controller.ProductController
{
    class ProductController
    {
        // Veri tabanında ürün detayları siktir et sonra urunKategori not null yapmayı unutma!
        int marketId = 1;
        public ProductController()
        {
            setFruitList(getSQLProductList("SP_SELECT_PRODUCTS",1,marketId));
            setVegetableList(getSQLProductList("SP_SELECT_PRODUCTS", 2, marketId));
            setMilkAndBreakfastList(getSQLProductList("SP_SELECT_PRODUCTS",3, marketId));
            setGidaList(getSQLProductList("SP_SELECT_PRODUCTS",4, marketId));
            setSugarList(getSQLProductList("SP_SELECT_PRODUCTS",5, marketId));
            setIcecekList(getSQLProductList("SP_SELECT_PRODUCTS",6, marketId));
            setTemizlikList(getSQLProductList("SP_SELECT_PRODUCTS",7, marketId));

        }
        private DataTable fruitList;
        private DataTable vegetableList;
        private DataTable milkAndBreakfastList;
        private DataTable gidaList;
        private DataTable sugarList;
        private DataTable icecekList;
        private DataTable temizlikList;

        public DataTable getFruitList()
        {
            return fruitList;
        }
        public void setFruitList(DataTable fruitList)
        {
            this.fruitList = fruitList;
        }
        
        public DataTable getGidaList()
        {
            return gidaList;
        }
        public void setGidaList(DataTable gidaList)
        {
            this.gidaList = gidaList;
        }

        public DataTable getSugarList()
        {
            return sugarList;
        }
        public void setSugarList(DataTable sugarList)
        {
            this.sugarList = sugarList;
        }

        public DataTable getIcecekList()
        {
            return icecekList;
        }
        public void setIcecekList(DataTable icecekList)
        {
            this.icecekList = icecekList;
        }
        public DataTable getTemizlikList()
        {
            return temizlikList;
        }
        public void setTemizlikList(DataTable temizlikList)
        {
            this.temizlikList = temizlikList;
        }
      
        public DataTable getMilkAndBreakfastList()
        {
            return milkAndBreakfastList;
        }
        public void setMilkAndBreakfastList(DataTable milkAndBreakfastList)
        {
            this.milkAndBreakfastList = milkAndBreakfastList;
        }
        public DataTable getVegetableList()
        {
            return vegetableList;
        }
        public void setVegetableList(DataTable vegetableList)
        {
            this.vegetableList = vegetableList;
        }



        public static DataTable getProductsOnMarket(int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SP_SELECT_MarketProductUnique", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Unique Urun Listesi Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;

        }
        private static DataTable getSQLProductList(String procedure, int kategoriId, int marketId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@urunKategoriId", SqlDbType.VarChar).Value = kategoriId;
            command.Parameters.Add("@marketId", SqlDbType.VarChar).Value = marketId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Liste Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;
        }

        public  void insertSQLProduct(string ad, string skt, float fiyat, int adet, int kategorid)
        {
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_PRODUCT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = ad;
                cmd.Parameters.Add("@urunSKT", SqlDbType.VarChar).Value = skt;
                cmd.Parameters.Add("@urunFiyat", SqlDbType.VarChar).Value = fiyat;
                cmd.Parameters.Add("@urunAdetKilo", SqlDbType.VarChar).Value = adet;
                cmd.Parameters.Add("@urunKategoriId", SqlDbType.VarChar).Value = kategorid;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Başarıyla Eklendi");
            }
            catch
            {
                MessageBox.Show("Ürün Eklenirken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
        }
    }
}
