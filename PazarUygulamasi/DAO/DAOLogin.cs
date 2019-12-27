using PazarUygulamasi.Controller.LoginController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PazarUygulamasi.DAO
{
    public class DAOLogin
    {
        public static int getPermission(string email, string password)
        {
            LoginController permission = new LoginController(email, password);
            return permission.getPermission();
        }
    }
}
 