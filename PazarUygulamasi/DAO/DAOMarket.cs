using PazarUygulamasi.Controller.MarketController;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PazarUygulamasi.DAO
{
    public class DAOMarket
    {
        public int marketId;
        public static int marketId2;
        public int marketNetKazanc;
        public string marketAd;
        public string marketTelefon;
        public DataTable marketCiroList;
        MarketController marketData;
        public DAOMarket(int id)
        {
            getMarketInformation(id);
        }

        public void getMarketInformation(int id)
        {
            marketData = new MarketController(id);
            marketId = marketData.getMarketId();
            marketAd = marketData.getMarketAd();
            marketTelefon = marketData.getMarketTelefon();
            marketCiroList = marketData.getMarketCiroList();
            marketNetKazanc = marketData.getMarketNetKazanc();
            marketId2 = marketId;
        }

        public static DataTable listSearchByUrun(String urunAd)
        {

            return MarketController.getSQLSearchByUrun(urunAd,marketId2);
        }

        public static DataTable listSearchByMusteri(String musteriAd)
        {

            return MarketController.getSQLSearchByMusteri(musteriAd, marketId2);
        }

        public static DataTable listSearchByUrunAdet(int min,int max)
        {

            return MarketController.getSQLSearchByUrunAdet(min,max, marketId2);
        }

    }
}