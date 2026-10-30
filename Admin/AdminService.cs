using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Admin
{
    internal class AdminService
    {
        AdminRepository adminrepo=new AdminRepository();
        public bool Login(string username, string password)
        {
            if(username=="admin" &&  password=="12345")
                {
                adminrepo.SaveLoginAttempt(username, true);
                return true;
                }
            adminrepo.SaveLoginAttempt(username, false);
            return false;
        }
    }
}
