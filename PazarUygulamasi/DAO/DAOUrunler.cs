using PazarUygulamasi.Controller.ProductController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarUygulamasi.DAO
{
    public class DAOUrunler
    {
         ProductController products = new ProductController();
        public  DataTable listFruits()
        {
            return products.getFruitList();
        }
        public  DataTable listVegetables()
        {
            return products.getVegetableList();
        }
        public  DataTable listMilk()
        {

            return products.getMilkAndBreakfastList();
        }
        public  DataTable listGida()
        {
            return products.getGidaList();
        }
        public  DataTable listSugar()
        {

            return products.getSugarList();
        }
        public  DataTable listIcecek()
        {
            return products.getIcecekList();
        }
        public  DataTable listTemizlik()
        {

            return products.getTemizlikList();
        }
        public static DataTable listProductsOnMarket(int id)
        {
            return ProductController.getProductsOnMarket(id);
        }
        public  void insertProduct(string ad, string skt, float fiyat, int adet, int kategorid, float maliyet)
        {
            products.insertSQLProduct(ad, skt, maliyet,fiyat, kategorid);
            products.insertSQLMarketProduct(ad, adet);
            
        }
        public static void updateMagazaStok(List<string> productList , List<int> adetList)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                ProductController.updateMagazaUrun(productList[i],adetList[i]);
            }
        }
    }
}
