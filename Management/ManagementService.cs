using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Management
{
    internal class ManagementService
    {
        ManagementRepository repo=new ManagementRepository();
        public bool Login(string username, string password)
        {
            if (username == "management" && password == "12345")
            {
                repo.SaveLoginAttempt(username, true);
                return true;
            }
            repo.SaveLoginAttempt(username, false);
            return false;
        }
    }
}
