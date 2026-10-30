using Project_in_c_.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Hall
{
    internal class HallUI
    {
        private HallService hallService = new HallService();
        private CustomerService customerService = new CustomerService();

        public void AddHall()
        {
            Console.Write("Enter hall name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Enter capacity (seats): ");
            int capacity;
            int.TryParse(Console.ReadLine(), out capacity);

            string error = hallService.AddHall(name, capacity);
            if (error == "")
                Console.WriteLine("Hall added successfully.");
            else
                Console.WriteLine(error);
        }

        public void DeleteHall()
        {
            Console.Write("Enter hall name to delete: ");
            string name = Console.ReadLine().Trim();

            string error = hallService.DeleteHall(name);
            if (error == "")
                Console.WriteLine("Hall deleted successfully.");
            else
                Console.WriteLine(error);
        }

        public void ViewHalls()
        {
            List<HallModel> halls = hallService.GetAll();
            if (halls.Count == 0)
            {
                Console.WriteLine("No halls found.");
                return;
            }

            Console.WriteLine($"{"No",-4}{"Hall",-25}Booked / Capacity");
            for (int i = 0; i < halls.Count; i++)
            {
                int booked = customerService.BookedSeats(halls[i].name);
                Console.WriteLine($"{i + 1,-4}{halls[i].name,-25}{booked} / {halls[i].capacity}");
            }
        }
    }
}

