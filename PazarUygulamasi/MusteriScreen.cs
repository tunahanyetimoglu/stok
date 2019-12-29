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
    public partial class MusteriScreen : Form
    {
        private LoginScreen loginForm;
        private int userId;
        private string meyve;
        private int stok;

        DAOUrunler products;
        DAOMarket market;

        public MusteriScreen(Form callingForm)
        {

            InitializeComponent();
            loginForm = callingForm as LoginScreen;
            userId = loginForm.userId;
            labelName.Text = DAO.DAOUser.getUserName(userId);
            labelSurname.Text = DAO.DAOUser.getUserSurName(userId);
            labelEmail.Text = DAO.DAOUser.getUserEmail(userId);

            listAllDataTables();
            listMarketInformation();

        }
        private void listAllDataTables()
        {
            products = new DAOUrunler();
            dataGridViewMeyve.DataSource = products.listFruits();
            dataGridViewSebze.DataSource = products.listVegetables();
            dataGridViewMilk.DataSource = products.listMilk();
            dataGridViewGida.DataSource = products.listGida();
            dataGridViewSugar.DataSource = products.listSugar();
            dataGridViewIcecek.DataSource = products.listIcecek();
            dataGridViewTemizlik.DataSource = products.listTemizlik();
        }
        private void listMarketInformation()
        {
            market = new DAOMarket(userId);
            labelMarketAd.Text = market.marketAd;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void MusteriScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMeyve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}