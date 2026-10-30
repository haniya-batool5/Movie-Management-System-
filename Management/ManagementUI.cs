using Project_in_c_.Admin;
using Project_in_c_.Customer;
using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Management
{
    internal class ManagementUI
    {
        ManagementService ManagementService = new ManagementService();
        CustomerUI customerUI = new CustomerUI();
        MovieUI movieUI = new MovieUI();
        public string ManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("____________________________________");
            Console.WriteLine("           Management Menu          ");
            Console.WriteLine("____________________________________");
            Console.WriteLine("1. View customer booking  ");
            Console.WriteLine("2. Search Customer by Name ");
            Console.WriteLine("3. View total Revenue ");
            Console.WriteLine("4. View Revenue by genre ");
            Console.WriteLine("5. View total tickets sold ");
            Console.WriteLine("6. Cancel Booking ");
            Console.WriteLine("7. Apply discount for movie ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Logout ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the choice ");
            string option = Console.ReadLine();
            return option;
        }
        public bool Login()
        {
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                Console.Clear();
                Console.WriteLine("Login attempt " + attempt + " of 3");
                Console.Write("Enter the username: ");
                string username = Console.ReadLine().Trim();
                Console.Write("Enter the management password: ");
                string password = Console.ReadLine();

                if (ManagementService.Login(username, password))
                {
                    return true;
                }

                Console.WriteLine("Username or password is invalid.");
                if (attempt < 3)
                {
                    Console.WriteLine("Attempts left: " + (3 - attempt));
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Too many attempts. Access denied.");
            return false;
        }
        public void managementchoice()
        {
           
            while (true)
            {
                string option = ManagementMenu();
                switch (option)
                {
                    case "1": customerUI.ViewALLBooking(); break;
                    case "2": customerUI.SearchCustomer(); break;
                    case "3": customerUI.TotalRevenue(); break;
                    case "4": customerUI.RevenueReport(); break;
                    case "5": customerUI.TotalTicketsSold(); break;
                    case "6": customerUI.CancelBooking(); break;
                    case "7": movieUI.ApplyingDiscount(); break;
                    case "8": Console.WriteLine("Logged out."); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                if (option == "8")
                {
                    break;
                }

                if (option != "8")
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}

