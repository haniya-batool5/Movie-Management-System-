using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Management
{
    internal class ManagementRepository
    {
        private string file = "ManagementLogin.txt";

        public void SaveLoginAttempt(string username, bool isSuccessful)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"{username},{(isSuccessful ? "Successful" : "Failed")}");
            }
        }
    }
}
