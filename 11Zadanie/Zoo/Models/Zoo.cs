using System.Collections.Generic;
using System.Linq;
using ZooApp;

namespace Zoo.Models
{
    public class Zoo
    {
        public string Name { get; set; }
        public List<Enclosure> Enclosures { get; set; }

        public Zoo()
        {
            Enclosures = new List<Enclosure>();
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            Enclosures.Add(enclosure);
        }

        public void RemoveEnclosure(int number)
        {
            Enclosures.RemoveAll(e => e.Number == number);
        }

        public void UpdateEnclosure(Enclosure updatedEnclosure)
        {
            var enclosure = Enclosures.FirstOrDefault(e => e.Number == updatedEnclosure.Number);
            if (enclosure != null)
            {
                enclosure.Number = updatedEnclosure.Number;
                enclosure.Size = updatedEnclosure.Size;
                enclosure.MaxAnimals = updatedEnclosure.MaxAnimals;
                enclosure.Animals = updatedEnclosure.Animals;
            }
        }

        public void SortEnclosuresByNumber(bool ascending = true)
        {
            if (ascending)
            {
                Enclosures = Enclosures.OrderBy(e => e.Number).ToList();
            }
            else
            {
                Enclosures = Enclosures.OrderByDescending(e => e.Number).ToList();
            }
        }
    }
}
