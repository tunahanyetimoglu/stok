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
    public partial class ManagementPage : Form
    {
        private LoginScreen loginForm;
        private int userId; 
        public ManagementPage(Form callingForm)
        {
            InitializeComponent();
            loginForm = callingForm as LoginScreen;
            userId = loginForm.userId;
            labelName.Text = DAO.DAOUser.getUserName(userId);
            labelSurname.Text = DAO.DAOUser.getUserSurName(userId);
            labelEmail.Text = DAO.DAOUser.getUserEmail(userId);

            dataGridViewMeyve.DataSource = DAO.DAOUrunler.listFruits();
        }
        private void ManagementPage_Load(object sender, EventArgs e)
        {

        }

        private void buttonMeyveSebze_Click(object sender, EventArgs e)
        {

        }

    }
}
