using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Movies
{
    internal class MovieRepository
    {
        private readonly string file="movie.txt";
        public MovieRepository()
        {

        }

        public List<MovieModel> Load()
        {
            List <MovieModel> movies = new List<MovieModel>();
            using (StreamReader SR = new StreamReader(file))
            {
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    string[] part=line.Split(',');
                    MovieModel m1=new MovieModel();
                    m1.name= part[0].Trim();
                    m1.genre= part[1].Trim();
                    if (int.TryParse(part[2].Trim(), out int price))
                    {
                        m1.price = price;
                        movies.Add(m1);
                    }
                   
                }
            }
            return movies;
        }
        public void Save(List<MovieModel> movies)
        {
            using (StreamWriter SW = new StreamWriter(file, false))
                foreach (MovieModel m in movies)
                {
                    SW.WriteLine(m.name + "," + m.genre + "," + m.price);
                }
       }
    }
}
