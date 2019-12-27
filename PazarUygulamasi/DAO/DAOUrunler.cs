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
        public static DataTable listFruits()
        {
            FruitController fruits = new FruitController();
            return fruits.getFruitList();
        }
    }
}
