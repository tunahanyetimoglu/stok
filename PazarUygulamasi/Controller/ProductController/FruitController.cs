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
    class FruitController
    {
        // Veri tabanında ürün detayları siktir et sonra urunKategori not null yapmayı unutma!

        public FruitController()
        {
            setFruitList(getSQLListFruit());
        }
        private DataTable fruitList;

        public DataTable getFruitList()
        {
            return fruitList;
        }
        public void setFruitList(DataTable fruitList)
        {
            this.fruitList = fruitList;
        }
        private static DataTable getSQLListFruit()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = DAO.DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand("SELECT * from tb_Urun_Detay", connection);
            //command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch
            {
                MessageBox.Show("Meyve Listesi Doldurulurken Hata Oluştu");
            }
            finally
            {
                DAO.DAOConnection.connectionClose(connection);
            }
            return dataTable;
        }
    }
}
