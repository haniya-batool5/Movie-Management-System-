using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Movies
{
    internal class MovieService

    {
        private MovieRepository repo=new MovieRepository();
        private List<MovieModel> result = new List<MovieModel>();
       
        public List<MovieModel> ShowMoviesByGenre(string genre) {
            List<MovieModel> movie=repo.Load();
            for (int i = 0; i < movie.Count; i++)

            {
                if (movie[i].genre == genre)                     
                {
                    result.Add(movie[i]);
                }
            }
            return result;
        }
       
        public List<String> ShowGenreList()
        {
            List<MovieModel> movies=repo.Load();
            List<string> genrenames = new List<string>();
            for (int i = 0; i < movies.Count; i++) {
                bool alreadyAdded = false;

                for (int j = 0; j < genrenames.Count; j++)       
                {
                    if (genrenames[j] == movies[i].genre)
                    {
                        alreadyAdded = true;
                        break;
                    }
                }
                if (!alreadyAdded)
                {
                    genrenames.Add(movies[i].genre);
                }
            }
            return genrenames;
        }
        public int IndexOf(List<MovieModel> movies,string name,string genre)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                int index = -1;
                if (movies[i].name.ToLower() == name.ToLower() && movies[i].genre.ToLower() == genre.ToLower()) 
                {
                    index= i;
                    return index;

                }
               
            }
            return -1;
        }
        public int IndexOf(List<MovieModel> movies, string name)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                int index = -1;
                if (movies[i].name.ToLower() == name.ToLower()) 
                {
                    index = i;
                    return index;

                }

            }
            return -1;
        }
        public string AddMovie(MovieModel movie)
        {

            List<MovieModel> movies = repo.Load();
            if (IndexOf(movies, movie.name, movie.genre) != -1)                              
                return "This movie already exists in " + movie.genre;

            movies.Add(movie);
            repo.Save(movies);
            return "";
        }
        public bool UpdateMovie(string name,string newname,int newprice,string genre)
        {
            List<MovieModel> movies = repo.Load();
            
            int index=IndexOf(movies,name,genre);
            if(index != -1) {
                movies[index].name = newname;
                movies[index].price = newprice;
                repo.Save(movies);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public bool DeleteMovie(string name) {
           List<MovieModel> movies = repo.Load();
            int index = IndexOf(movies, name);
            if (index != -1)
            {
                movies.RemoveAt(index);
                repo.Save(movies);
                return true;
            }
            return false;
        }
        public List<MovieModel> ViewAll()
        {
            return repo.Load();
        }
        public float FindPrice(string name, string genre) { 
          List<MovieModel> movies= repo.Load();
            int index = IndexOf(movies, name,genre);
            if(index!=-1)
            return movies[index].price;
            return -1;
        }
        public bool ApplyingDiscount(string moviename, string genre, int discount)
        {
           List<MovieModel> movies=repo.Load();
            int index = IndexOf(movies, moviename);
            movies[index].price = movies[index].price - (movies[index].price * discount / 100);
            if (index != -1)
            {
                repo.Save(movies);
                return true;
            }
            return false;
        }
    }
}
