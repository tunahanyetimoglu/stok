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
        private string urun = "Armut";
        private static int fiyat;
        private int price;
        private List<string> productList; 
        private static List<float> priceList;
        private List<int> adetList;

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

            priceList = new List<float>();
            productList = new List<string>();
            adetList = new List<int>();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(urun))
            {
                listBox1.Items.Add(urun);
                productList.Add(urun);
                price = price * Convert.ToInt32(numericUpDown1.Value);
                adetList.Add(Convert.ToInt32(numericUpDown1.Value));
                priceList.Add(price);
                fiyat = fiyat + price;
                labelPrice.Text = fiyat.ToString();
            }
        }

        private void dataGridViewTemizlik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewTemizlik.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewTemizlik.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewTemizlik.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void buttonMeyveSebze_Click(object sender, EventArgs e)
        {
            panelMeyve.Visible = true;
            panelKahvalti.Visible = false;
        }

        private void buttonSutKahvalti_Click(object sender, EventArgs e)
        {
            panelKahvalti.Visible = true;
            panelGida.Visible = false;

        }

        private void buttonAburCubur_Click(object sender, EventArgs e)
        {
            panelDrink.Visible = false;

            panelKahvalti.Visible = true;
            panelGida.Visible = true;
        }

        private void buttonIcecek_Click(object sender, EventArgs e)
        {
            panelTemizlik.Visible = false;
            panelKahvalti.Visible = true;
            panelGida.Visible = true;
            panelDrink.Visible = true;
        }

        private void buttonTemizlik_Click(object sender, EventArgs e)
        {
            panelKahvalti.Visible = true;
            panelGida.Visible = true;
            panelDrink.Visible = true;
            panelTemizlik.Visible = true;
        }

        private void dataGridViewMeyve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                
                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewMeyve.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewMeyve.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewMeyve.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                fiyat = fiyat - Convert.ToInt32(priceList[listBox1.SelectedIndex]);
                priceList.RemoveAt(listBox1.SelectedIndex);
                adetList.RemoveAt(listBox1.SelectedIndex);
                productList.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                labelPrice.Text = fiyat.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAOUrunler.updateMagazaStok(productList,adetList);
            DAOMarket.insertMagazaCiro(productList, adetList, priceList,userId);
            listAllDataTables();
            labelPrice.Text = "0";
            listBox1.Items.Clear();
            priceList.Clear();
            adetList.Clear();
            productList.Clear();
        }

        private void dataGridViewSebze_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewSebze.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewSebze.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewSebze.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void dataGridViewGida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewGida.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewGida.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewGida.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void dataGridViewIcecek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewIcecek.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewIcecek.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewIcecek.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void dataGridViewMilk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewMilk.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewMilk.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewMilk.Rows[e.RowIndex].Cells[1].Value);
            }
        }

        private void dataGridViewSugar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                numericUpDown1.Maximum = Convert.ToDecimal(dataGridViewSugar.Rows[e.RowIndex].Cells[3].Value);
                urun = dataGridViewSugar.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToInt32(dataGridViewSugar.Rows[e.RowIndex].Cells[1].Value);
            }
        }
    }

}