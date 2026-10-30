using Project_in_c_.Hall;
using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Admin
{
    public class AdminUI

    {
       AdminService adminService=new AdminService();
        MovieUI movieUI=new MovieUI();
        HallUI hallUI=new HallUI();
        public string AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("____________________________________");
            Console.WriteLine("              Admin Menu            ");
            Console.WriteLine("____________________________________");
            Console.WriteLine("1. Add movie ");
            Console.WriteLine("2. Update movie ");
            Console.WriteLine("3. Delete movie ");
            Console.WriteLine("4. View movie ");
            Console.WriteLine("5. Add hall ");
            Console.WriteLine("6. Delete hall ");
            Console.WriteLine("7. View hall ");
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
                Console.Write("Enter the admin password: ");
                string password = Console.ReadLine();

                if (adminService.Login(username, password))
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
        public void AdminChoices()
        {
            while(true)
            {
                string option = AdminMenu();
                switch (option)
                {
                    case "1": movieUI.AddMovie(); break;
                    case "2": movieUI.UpdateMovie(); break;
                    case "3": movieUI.DeleteMovie(); break;
                    case "4": movieUI.ViewAllMovies(); break;
                    case "5": hallUI.AddHall(); break;
                    case "6": hallUI.DeleteHall(); break;
                    case "7": hallUI.ViewHalls(); break;
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
