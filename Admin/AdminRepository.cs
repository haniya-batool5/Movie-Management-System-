using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Admin
{
    internal class AdminRepository
    {
      
        
        private string file = "AdminLogin.txt";

        public void SaveLoginAttempt(string username, bool isSuccessful)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"{username},{(isSuccessful ? "Successful" : "Failed")}");
            }
        }
    
}
}
