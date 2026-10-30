using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Admin
{
    internal class AdminModel
    {
        private string name { get; set; }
        private string password { get; set; }

        public AdminModel(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public override string ToString()
        {
            return $"{name},{password}";
        }
    }
}
