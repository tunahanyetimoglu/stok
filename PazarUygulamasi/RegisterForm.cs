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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonKayit_Click(object sender, EventArgs e)
        {
            DAOUser.insertlogin(textBoxEmail.Text);
            DAOUser.insertUser(textBoxAd.Text,textBoxSoyad.Text,textBoxGsm.Text,textBoxYas.Text,textBoxAdress.Text,textBoxEmail.Text);
            this.Close();
        }
    }
}
