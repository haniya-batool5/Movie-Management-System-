using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Customer
{
    internal class CustomerRepository
    {
        private readonly string file = "customer.txt";
        public CustomerRepository() 
        { 
        }
        public List<CustomerModel> Load()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            using (StreamReader SR = new StreamReader(file))
            {
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    if (line.Trim() == "") continue;      
                    string[] part = line.Split(',');
                    if (part.Length != 6) continue;         

                    int age;
                    float price;
                    if (!int.TryParse(part[1].Trim(), out age)) continue;
                    if (!float.TryParse(part[3].Trim(), out price)) continue;

                    CustomerModel c = new CustomerModel();
                    c.name = part[0].Trim();
                    c.age = age;
                    c.moviename = part[2].Trim();
                    c.price = price;
                    c.hall = part[4].Trim();
                    c.genre= part[5].Trim();
                    customers.Add(c);
                }
            }
            return customers;
        }
        public void Save(List<CustomerModel> customers)
        {
            using (StreamWriter SW = new StreamWriter(file, false)) 
            {
                foreach (CustomerModel c in customers)
                {
                    SW.WriteLine(c.name + "," + c.age + "," + c.moviename + "," + c.price + "," + c.hall+"," + c.genre);
                }
            }
            
        }
        public void Add(CustomerModel c)
        {
            using (StreamWriter SW = new StreamWriter(file, true))
            { 
                SW.WriteLine(c.name + "," + c.age + "," + c.moviename + "," + c.price + "," + c.hall+ "," + c.genre);
                
            }

            
        }

    }
}
