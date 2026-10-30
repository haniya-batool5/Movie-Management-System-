using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Customer
{
    internal class CustomerService
    {
        CustomerRepository repo=new CustomerRepository();
        MovieService movieService=new MovieService();
        public string AddCustomer(CustomerModel c)
        {
            repo.Add(c);
            return "";
        }
        
        public List<CustomerModel> ViewCustomerBooking()
        {
            List<CustomerModel> customers = repo.Load();
            return customers;
        }
        public List<CustomerModel> SerachCustomer(string name)
        {
            List<CustomerModel> customers = repo.Load();
            List<CustomerModel> res = new List<CustomerModel>();
            for (int i = 0; i < customers.Count; i++) 
            {
                if (customers[i].name == name)
                {
                  res.Add(customers[i]);
                }
            }
            return res;
            
        }
        public bool CancelBooking(string name)
        {
            List<CustomerModel> customers = repo.Load();
            bool isfound = false;
            int index = -1;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].name == name)
                {
                    isfound = true;
                    index = i;
                    break;
                }
            }
            if (isfound)
            {
               customers.RemoveAt(index);
                repo.Save(customers);
                return true;
            }
            return false;
        }
        public float TotalRevenue()
        {
            List<CustomerModel> customers = repo.Load();
            float total = 0;
            for (int i = 0; i < customers.Count; i++) 
            {
                total += customers[i].price;
            }
            return total;
        }
        public float RevenueByGenre(string genre)
        {
            List<CustomerModel> customers = repo.Load();
            float total = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].genre == genre)
                {
                    total += customers[i].price;
                }
            }
            return total;
            
        
        }
        public int TotalTicketsSold()
        {
            List<CustomerModel> customers = repo.Load();
            int total = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                total++;
            }
          return (total);
        }
        public int[] TicketsByAgeGroup()
        {
            List<CustomerModel> customers = repo.Load();
            int child = 0;
            int adult = 0;
            int senior = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                int age = customers[i].age;

                if (age < 13) child++;
                else if (age < 60) adult++;
                else senior++;
            }

            int[] counts = { child, adult, senior };    
            return counts;
        }
        public int BookedSeats(string hallname)
        {
            List<CustomerModel> customers = repo.Load();
            int count = 0;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].hall == hallname) count++;       // one booking = one seat
            }
            return count;
        }


    }
}
