using Project_in_c_.Admin;
using Project_in_c_.Customer;
using Project_in_c_.Hall;
using Project_in_c_.Management;
using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_
{
    internal class Movie_Management_System
    {
        public void Start()
        {
            AdminUI adminUI = new AdminUI();
            MovieUI movieUI = new MovieUI();
            ManagementUI managementUI = new ManagementUI();
            CustomerUI customerUI= new CustomerUI();
            HallUI hallUI = new HallUI();
           
            while (true)
            {
                Console.Clear();
                string choice = MainMenu();
                if (choice == "1")
                {
                    bool loggedIn = adminUI.Login();
                    if (!loggedIn)
                    {
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        continue;
                    }
                    adminUI.AdminChoices();
                    
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    bool loggedIN = managementUI.Login();
                    
                    if (!loggedIN)
                    {
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        continue;
                    }
                    managementUI.managementchoice();
                    
                }
                else if (choice == "3")
                {
                    customerUI.BookTicket();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye!Thanks For using Movie Management System");
                    break;                       
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
        // class for the driver code
        public string MainMenu()
        {
            Console.WriteLine("________________________________________________");
            Console.WriteLine("              MOVIE MANAGEMENT SYSTEM           ");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("1. Admin Menu ");
            Console.WriteLine("2. Management Menu");
            Console.WriteLine("3. Customer");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4. Exit Application");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Your Choice: ");
            string option = Console.ReadLine();
            return option;
        }
    }
}
