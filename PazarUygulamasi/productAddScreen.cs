using PazarUygulamasi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi
{
    public partial class productAddScreen : Form
    {
        string ad;
        string skt;
        float fiyat;
        int adet;
        int kategorid;

        DAOUrunler products = new DAOUrunler();

        public productAddScreen()
        {
            InitializeComponent();
        }

        private void buttonEKLE_Click(object sender, EventArgs e)
        {
            refreshVariables();
            products.insertProduct(ad, skt, fiyat, adet, kategorid);
            this.Hide();
        }

        private void refreshVariables()
        {
            ad = textBoxAd.Text;
            skt = textBoxSKT.Text;
            fiyat = float.Parse(textBoxFiyat.Text);
            adet = Convert.ToInt32(textBoxAdet.Text);
            kategorid = Convert.ToInt32(comboBoxKategori.SelectedIndex + 1);

        }
    }
}
