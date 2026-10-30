using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Customer
{
    internal class CustomerModel
    {
        public string name;
        public int age;
        public string moviename;
        public string genre;
        public float price;
        public string hall;
        public CustomerModel() { }
        public CustomerModel(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void SetName(string name)
        {
            this.name=name;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetAge(int age)
        {
          this.age=age;
        }
       public int getAge()
       { 
            return age; 
       }

    }
}
