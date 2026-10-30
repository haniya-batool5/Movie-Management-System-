using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Movies
{
    internal class MovieUI
    {
      private MovieService service=new MovieService();
        public void AddMovie()
        {
            Console.Clear();
            MovieModel m = new MovieModel();
            Console.Write("Enter the Movie Name: ");
            m.SetName(Console.ReadLine());
            Console.Write("Enter the Movie Price: ");
            m.SetPrice(int.Parse(Console.ReadLine()));
            Console.Write("Enter the Movie Genre: ");
            m.SetGenre(Console.ReadLine());
            string add = service.AddMovie(m);
            if (add == "")
                Console.WriteLine("Movie Added Successfully!");
            else
                Console.WriteLine(add);
        }
        public void UpdateMovie()
        {
            Console.Clear();
            Console.Write("Enter the Genre of the Movie: ");
            string genre = Console.ReadLine();
            Console.Write("Enter the Name of the Movie that you wanted to update: ");
            string name = Console.ReadLine();
            Console.Write("Enter the New Name of the Movie : ");
            string newname = Console.ReadLine();
            Console.Write("Enter the New Price: ");
            int newprice = int.Parse(Console.ReadLine());
            if (service.UpdateMovie(name, newname, newprice, genre))
            {
                Console.WriteLine("Movie Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Movie Not Found");
            }

        }
        public void ViewAllMovies()
        {
            Console.Clear();
            List<string> genres = service.ShowGenreList();

            if (genres.Count == 0)
            {
                Console.WriteLine("NO Movies Found");
            }
            else
            {
                for (int i = 0; i < genres.Count; i++)
                {
                    List<MovieModel> movies = service.ShowMoviesByGenre(genres[i]);
                    Console.WriteLine("--------" + genres[i] + "-------");
                    int count = 1;
                    for (int j = 0; j < movies.Count; j++)
                    {
                        if (movies[j].genre == genres[i])
                        {
                            Console.WriteLine($"{count} \t {movies[j].name} \t\t\t Rs: {movies[j].price}");
                            count++;
                        }
                    }
                }
            }
        }
        public void DeleteMovie()
        {
            Console.Clear();
            Console.Write("Enter the movie name you Wanted to Delete: ");
            string name = Console.ReadLine();
            if (service.DeleteMovie(name))
            {
                Console.WriteLine("Movie Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Movie Not Found");
            }
        }
        public void FindPrice()
        {
            Console.Clear();
            Console.Write("Enter the Name of the Movie : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Genre of the Movie: ");
            string genre = Console.ReadLine();
            float price = service.FindPrice(name, genre);
            if (price != -1)
            {
                Console.WriteLine($"Rs: {price}");
            }
            else
            {
                Console.WriteLine("Movie Not Found");
            }
        }
        public void ShowMoviesByGenres()
        {
            Console.Clear();
            List<string> genres = service.ShowGenreList();
            if (genres.Count == 0)
            {
                Console.WriteLine("No Movie Found");
            }
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"{i + 1} \t {genres[i]}");
            }
            Console.Write("Choose genre number: ");
            int choice;
            choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > genres.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }
            Console.WriteLine("--------" + genres[choice - 1] + "-------");
            List<MovieModel> movies = service.ShowMoviesByGenre(genres[choice - 1]);
            for (int j = 0; j < movies.Count; j++)
            {
                Console.WriteLine($"{j + 1} \t {movies[j].name} \t Rs: {movies[j].price}");
            }
        }
        public void ApplyingDiscount()
        {
            Console.Clear();
            String name, genre;
            int discount;
            Console.Write("Enter the Name of the Movie : ");
            name = Console.ReadLine();
            Console.Write("Enter the Genre of the Movie: ");
            genre = Console.ReadLine();
            Console.Write("Enter Discount : ");
            discount = int.Parse(Console.ReadLine());
            if (service.ApplyingDiscount(name, genre, discount))
            {
                Console.WriteLine("Discount is applied Successfully");
            }
            else
            {
                Console.WriteLine("No record of movie found you entered");
            }
        }
    }
}
