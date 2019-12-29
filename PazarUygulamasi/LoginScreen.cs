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
    public partial class LoginScreen : Form
    {
        public int userId;

        public LoginScreen()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            int permission = DAO.DAOLogin.getPermission(textBoxUsername.Text,textBoxPassword.Text);

            if(permission == 1)
            {
                userId = DAO.DAOUser.getUserId(textBoxUsername.Text);
                ManagementPage managementPage = new ManagementPage(this);
                this.Hide();
                managementPage.ShowDialog();
                // Application.Exit();
                this.Show();

            }else if (permission == 2)
            {

                userId = DAO.DAOUser.getUserId(textBoxUsername.Text);
                MusteriScreen musteriPage = new MusteriScreen(this);
                this.Hide();
                musteriPage.ShowDialog();
                // Application.Exit();
                this.Show();
            }
            else
            {
                
                MessageBox.Show("SEN HAYIDIR ABİİ");
            }
        }
    }
}
