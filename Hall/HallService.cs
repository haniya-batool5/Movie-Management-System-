using Project_in_c_.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Hall
{
    internal class HallService
    {
        private HallRepository repo = new HallRepository();
        private CustomerService customerService = new CustomerService();
        public List<HallModel> GetAll()
        {
            return repo.load();
        }


        private int IndexOf(List<HallModel> halls, string name)
        {
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].name.ToLower() == name.ToLower()) return i;
            }
            return -1;
        }
        public string AddHall(string name, int capacity)
        {
            if (name == "" || name.Contains(",")) return "Invalid hall name.";
            if (capacity <= 0) return "Capacity must be more than 0.";

            List<HallModel> halls = repo.load();
            if (IndexOf(halls, name) != -1) return "This hall already exists.";

            HallModel h = new HallModel();
            h.name = name;
            h.capacity = capacity;
            halls.Add(h);
            repo.Save(halls);
            return "";
        }

        public string DeleteHall(string name)
        {
            List<HallModel> halls = repo.load();
            int index = IndexOf(halls, name);
            if (index == -1) return "Hall not found.";

            if (customerService.BookedSeats(halls[index].name) > 0)
                return "Cannot delete a hall that has bookings.";

            halls.RemoveAt(index);
            repo.Save(halls);
            return "";
        }
    }
}

