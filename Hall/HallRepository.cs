using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_c_.Hall
{
    internal class HallRepository
    {
        private readonly string file = "hall.txt";
        public List<HallModel> load()
        {
            if (!File.Exists(file))
            {
                File.WriteAllLines(file, new string[]
                {
                    "Lost in the spotlight,50",
                    "Echo stage,50",
                    "Dreams capes,50"
                });
            }
            List<HallModel> halls = new List<HallModel>();
            using(StreamReader sr = new StreamReader(file)) {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "") continue;
                    string[] part = line.Split(',');
                    if (part.Length != 2) continue;

                    int capacity;
                    if (!int.TryParse(part[1].Trim(), out capacity)) continue;

                    HallModel h = new HallModel();
                    h.name = part[0].Trim();
                    h.capacity = capacity;
                    halls.Add(h);
                }
                return halls;
            }
        }
        public void Save(List<HallModel> halls)
        {
            using (StreamWriter SW = new StreamWriter(file, false))
            {
                foreach (HallModel h in halls)
                {
                    SW.WriteLine(h.name + "," + h.capacity);
                }
            }
        }
    }
}
