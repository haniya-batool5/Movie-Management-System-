using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Movies
{
    internal class MovieModel
    {
        public string name;
        public string genre;
        public float price;

        public MovieModel()
        {

        }
        public MovieModel(string name, string genre, float price)
        {
            this.name = name;
            this.genre = genre;
            this.price = price;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName(string name)
        {
            return this.name;
        }
        public float GetPrice(float price) { 
            return this.price;
        }
        public void SetPrice(int price) { 
        this.price = price;
        }
        public string GetGenre(String genre) {
            return this.genre;

        }
        public void SetGenre(String genre) { 
        this.genre= genre;
        }
        public override string ToString()
        {
            return $"{name},{genre},{price}";
        }
    }
}
