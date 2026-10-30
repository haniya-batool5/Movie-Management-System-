using Project_in_c_.Hall;
using Project_in_c_.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Customer
{
    internal class CustomerUI
    {
        MovieService movieService=new MovieService();
        CustomerService customerService = new CustomerService();
        HallService hallService = new HallService();
        public void BookTicket()
        {
            Console.Clear();
            Console.Write("Enter Your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your Age: ");
            
            int age=int.Parse(Console.ReadLine());
            List<string> genres = movieService.ShowGenreList();
            if (genres.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            else
            {
                Console.Clear();
                for(int i = 0; i < genres.Count; i++)
                {
                    Console.WriteLine((i+1) + " " + genres[i]);
                }
            }
            Console.Write("Enter The Genre Number: ");
            int choice;
            choice=int.Parse(Console.ReadLine());
            if(choice<1|| choice> genres.Count)
            {
                Console.WriteLine("Invalid genre number.");
                return;
            }
            string genre=genres[choice-1];
            List<MovieModel> movies=movieService.ShowMoviesByGenre(genre);
            Console.Clear();
            Console.WriteLine("\n--- " + genre + " Movies ---");
            for(int i = 0;i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}  {movies[i].name}RS:{movies[i].price}");
            }
            Console.Write("Enter movie number: ");
            int movieChoice;
            movieChoice=int.Parse(Console.ReadLine());
            if (movieChoice < 1 || movieChoice > movies.Count)
            {
                Console.WriteLine("Invalid movie number.");
                return;
            }
            Console.Clear();
            List<HallModel> halls = hallService.GetAll();
            if (halls.Count == 0)
            {
                Console.WriteLine("No halls available.");
                return;
            }

            Console.WriteLine("\nChoose a hall:");
            for (int i = 0; i < halls.Count; i++)
            {
                int booked = customerService.BookedSeats(halls[i].name);
                Console.WriteLine($"{i + 1,-4}{halls[i].name,-25}{booked}/{halls[i].capacity} seats booked");
            }
            Console.Write("Enter hall number: ");
            int hallChoice;
            int.TryParse(Console.ReadLine(), out hallChoice);
            if (hallChoice < 1 || hallChoice > halls.Count)
            {
                Console.WriteLine("Invalid hall number.");
                return;
            }

            HallModel hall = halls[hallChoice - 1];
            if (customerService.BookedSeats(hall.name) >= hall.capacity)
            {
                Console.WriteLine("Sorry, this hall is full.");
                return;
            }
            MovieModel selected = movies[movieChoice - 1];

            CustomerModel c = new CustomerModel();
            c.name = name;
            c.age = age;
            c.moviename = selected.name;
            c.genre = genre;
            (c.price) = selected.price;
            c.hall = hall.name;
            string error = customerService.AddCustomer(c);          
            if (error == "")
            {
                Console.Clear();
                Console.WriteLine("\n======= TICKET =======");
                Console.WriteLine("Name  : " + c.name);
                Console.WriteLine("Age   : " + c.age);
                Console.WriteLine("Movie : " + c.moviename + " (" + c.genre + ")");
                Console.WriteLine("Hall  : " + c.hall);
                Console.WriteLine("Price : Rs. " + c.price);
                Console.WriteLine("========================");
                Console.Write("Press any key to continue");
                Console.ReadKey();
            }
            else
                Console.WriteLine(error);
        }
             
        public void RevenueReport()
        {
            Console.Clear();
            List<string> genres = movieService.ShowGenreList();

            Console.WriteLine($"{"Genre"}Revenue");
            for (int i = 0; i < genres.Count; i++)
            {
                float revenue = customerService.RevenueByGenre(genres[i]);
                Console.WriteLine($"{genres[i]}\tRs: {revenue}");
            
            }
        }
        public void TotalRevenue()
        {
            Console.Clear();
            Console.WriteLine("The Total Revenue is: ");
            Console.WriteLine(customerService.TotalRevenue());
        }

        public void CancelBooking()
        {
            Console.Clear();
            string name;
            Console.WriteLine("Enter the Name that you wanted to cancel the booking");
            name=Console.ReadLine();
            if(customerService.CancelBooking(name))
            {
                Console.WriteLine("Booking Cancelled");
            }
            else
            {
                Console.WriteLine($"No record found under {name} name");
            }
        }
        public void SearchCustomer()
        {
            Console.Clear();
            string name;
            Console.Write("Enter the Name that you wanted to search the booking");
            name = Console.ReadLine();
            List<CustomerModel> found=customerService.SerachCustomer(name);
            if (found.Count == 0)
            {
                Console.WriteLine($"No Booking found under {name} name");
            }
            else
            {
                Console.WriteLine("No.\tCustomer Name\tCustomer Age\tCustomer movie\t Movie Price\tHall\tGenre");
                for (int i = 0; i < found.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{found[i].name}\t\t{found[i].age}\t\t{found[i].moviename}\t\tRs.{found[i].price}\t\t{found[i].hall}");
                }
            }
        }
        public void ViewALLBooking()
        {
            Console.Clear();
            List<CustomerModel> customers = customerService.ViewCustomerBooking();
            Console.WriteLine("No.\tCustomer Name\tCustomer Age\tCustomer movie\t Movie Price\tHall\tGenre");
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{customers[i].name}\t\t{customers[i].age}\t\t{customers[i].moviename}\t\tRs.{customers[i].price}\t{customers[i].hall}\t{customers[i].genre}");
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("There is no customer record in it ");
            }
        }
        public void TotalTicketsSold()
        {
            Console.Clear();
            int total=customerService.TotalTicketsSold();
            if (total == 0) {
                Console.WriteLine("NO ticket sold");           
            }
            else
            {
                int[] count = customerService.TicketsByAgeGroup();
                Console.WriteLine("Category\tTickets");
                Console.WriteLine($"Child (under 13) : {count[0]}");
                Console.WriteLine($"Adult (13-59): {count[1]}");
                Console.WriteLine($"Senior Citizen: {count[2]}");
            }
        }
    }
}
