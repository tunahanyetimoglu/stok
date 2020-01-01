using PazarUygulamasi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PazarUygulamasi
{
    public partial class ManagementPage : Form
    {
        private LoginScreen loginForm;
        private int userId;
        DAOUrunler products;
        DAOMarket market;

        int scr_val , page;
        DataTable list;

        SqlDataAdapter da;

        private List<int> urunIds;

        public ManagementPage(Form callingForm)
        {
            InitializeComponent();
            loginForm = callingForm as LoginScreen;
            userId = loginForm.userId;
            labelName.Text = DAO.DAOUser.getUserName(userId);
            labelSurname.Text = DAO.DAOUser.getUserSurName(userId);
            labelEmail.Text = DAO.DAOUser.getUserEmail(userId);
            listAllDataTables();
            listMarketInformation();
            listMarketInformation2();

            urunIds = new List<int>();
            DataTable dtt = DAOUrunler.listProductsOnMarket(market.marketId);
            foreach (DataRow row in dtt.Rows)
            {
                urunIds.Add(Convert.ToInt32(row.ItemArray[0].ToString()));
                comboBoxUrunler.Items.Add(row.ItemArray[1]);
            }

        }

        private void listAllDataTables()
        {
            products  = new DAOUrunler();
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
            labelKar.Text = market.marketNetKazanc.ToString();
            dataGridViewCiro.DataSource = market.marketCiroList;

            page = Convert.ToInt32(dataGridViewCiro.Rows.Count);

        }

        private void listMarketInformation2()
        {

            String sql = " Select tb_Market.marketAd as Market, tb_User_Detail.Name as İsim, tb_User_Detail.Surname as Soyisim, tb_Urun.urunAd as Ürün, " +
                " tb_CariHesap.satilanAdet as SatılanAdet, tb_CariHesap.toplamFiyat as AlınanÜcret, tb_CariHesap.toplamMaliyet as Maliyet " +
                "from tb_CariHesap " +
                "inner join tb_Market on tb_CariHesap.marketId = tb_Market.marketId " +
                "inner join tb_User_Detail on tb_CariHesap.userId = tb_User_Detail.userId " +
                "inner join tb_Urun on tb_CariHesap.urunId = tb_Urun.urunId where tb_Market.marketId = 1";

            list = new DataTable();
            SqlConnection connection = DAOConnection.connectionOpen();
            SqlCommand command = new SqlCommand(sql, connection);
            da = new SqlDataAdapter(command);
            try
            {
                da.Fill(list);
            dataGridViewCiro.DataSource = list;
            page = Convert.ToInt32(dataGridViewCiro.Rows.Count);
            }
            catch
            {
                MessageBox.Show("CİRO LİSTESİ HATALI!");
            }
            finally
            {
                DAOConnection.connectionClose(connection);
            }


        }
        private void ManagementPage_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("https://tunahanyetimoglu.com");
            proc.StartInfo = startInfo;
            proc.Start();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            productAddScreen PAS = new productAddScreen();
            this.Hide();
            PAS.ShowDialog();
            this.Show();
            listAllDataTables();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButtonUrun.Checked == true)
            {
                if (comboBoxUrunler.SelectedItem == null)
                {
                    comboBoxUrunler.SelectedItem = "Armut";
                }
                dataGridViewCiro.DataSource = DAOMarket.listSearchByUrun(comboBoxUrunler.SelectedItem.ToString());
            }else if( radioButtonMusteri.Checked == true)
            {
                if(textBoxMusteri.Text == "")
                {
                    MessageBox.Show("İsim gir len");
                }
                else
                {
                     dataGridViewCiro.DataSource = DAOMarket.listSearchByMusteri(textBoxMusteri.Text);
                }
            }else if(radioButtonAdet.Checked == true)
            {
                

                dataGridViewCiro.DataSource = DAOMarket.listSearchByUrunAdet(Convert.ToInt32(numericUpDownMin.Value), Convert.ToInt32(numericUpDownMax.Value));
            }
              
        }
        private void radioButtonUrun_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUrun.Checked == true)
            {
                numericUpDownMax.Visible = false;
                numericUpDownMin.Visible = false;
                labelAlt.Visible = false;
                labelUst.Visible = false;
                textBoxMusteri.Visible = false;
                comboBoxUrunler.Visible = true;
            }
        }

     

        private void radioButtonMusteri_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMusteri.Checked == true)
            {
                numericUpDownMax.Visible = false;
                numericUpDownMin.Visible = false;
                labelAlt.Visible = false;
                labelUst.Visible = false;
                textBoxMusteri.Visible = true;
                comboBoxUrunler.Visible = false;
            }
        }

        private void radioButtonAdet_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdet.Checked == true)
            {
                numericUpDownMax.Visible = true;
                numericUpDownMin.Visible = true;
                labelAlt.Visible = true;
                labelUst.Visible = true;
                textBoxMusteri.Visible = false;
                comboBoxUrunler.Visible = false;
            }
        }

        private void dataGridViewCiro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            listMarketInformation2();
        }

        private void dataGridViewTemizlik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            scr_val = scr_val - 5;
            if (scr_val <= 0)
            {
                scr_val = 0;
            }
            list.Clear();
            da.Fill(scr_val, 5, list);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            scr_val = scr_val + 5;
            if (scr_val > page)
            {
                scr_val = 10;
            }
            list.Clear();
            da.Fill(scr_val, 5, list);
        }
    }
}
