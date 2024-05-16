using System.Collections.Generic;
using Zoo.Models;

namespace ZooApp
{
    public class Enclosure
    {
        public int Number { get; set; }
        public double Size { get; set; }
        public int MaxAnimals { get; set; }
        public int CurrentAnimals => Animals.Count;
        public List<Animal> Animals { get; set; }

        public Enclosure()
        {
            Animals = new List<Animal>();
        }
    }
}
