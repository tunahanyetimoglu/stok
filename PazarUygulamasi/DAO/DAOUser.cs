using PazarUygulamasi.Controller.UserController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarUygulamasi.DAO
{
    public class DAOUser
    {
        
        // KARDEŞİM ŞU USERCONTROLLE NESNE URETIMINI DYNAMIC OLARKA TEKE INDIR YOKSA AMK !!!!!
        public static int getUserId(string email)
        {
            UserController user = new UserController(email);
            return user.getUserId();
        }
        public static string getUserName(int id)
        {
            UserController user = new UserController(id);
            return user.getUserName();
        }
        public static string getUserSurName(int id)
        {
            UserController user = new UserController(id);
            return user.getUserSurName();
        }
        public static string getUserEmail(int id)
        {
            UserController user = new UserController(id);
            return user.getUserEmail();
        }
    }
}
