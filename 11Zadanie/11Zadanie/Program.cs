using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Zoo Search App!");

        Zoo zoo = new Zoo("City Zoo");

        Enclosure enclosure1 = new Enclosure(1, "1", 5);
        Enclosure enclosure2 = new Enclosure(2, "2", 3);
        Enclosure enclosure3 = new Enclosure(3, "3", 2);
        Enclosure enclosure4 = new Enclosure(4, "4", 4);

        enclosure1.Animals.Add(new Fish { Name = "Goldfish", IsPredator = false, DeepWater = false });
        enclosure1.Animals.Add(new Bird { Name = "Eagle", IsPredator = true, FlightSpeed = 120 });
        enclosure2.Animals.Add(new Mammal { Name = "Lion", IsPredator = true, Habitat = "Savannah" });
        enclosure2.Animals.Add(new Fish { Name = "Piranha", IsPredator = true, DeepWater = true });
        enclosure3.Animals.Add(new Bird { Name = "Parrot", IsPredator = false, FlightSpeed = 20 });
        enclosure3.Animals.Add(new Mammal { Name = "Monkey", IsPredator = false, Habitat = "Forest" });
        enclosure4.Animals.Add(new Fish { Name = "Shark", IsPredator = true, DeepWater = true });
        enclosure4.Animals.Add(new Bird { Name = "Owl", IsPredator = true, FlightSpeed = 80 });
        enclosure4.Animals.Add(new Mammal { Name = "Elephant", IsPredator = false, Habitat = "Jungle" });

        zoo.Enclosures.Add(enclosure1);
        zoo.Enclosures.Add(enclosure2);
        zoo.Enclosures.Add(enclosure3);
        zoo.Enclosures.Add(enclosure4);

        Console.WriteLine("Do you want to search the zoo by enclosure number? (y/n)");
        string response = Console.ReadLine();

        if (response.ToLower() == "y")
        {
            Console.WriteLine("Enter the number of the enclosure you want to search:");
            int enclosureNumber;
            if (int.TryParse(Console.ReadLine(), out enclosureNumber))
            {
                bool found = false;

                foreach (var enclosure in zoo.Enclosures)
                {
                    if (enclosure.Number == enclosureNumber)
                    {
                        Console.WriteLine($"Animals in enclosure {enclosure.Number}:");
                        foreach (var animal in enclosure.Animals)
                        {
                            Console.WriteLine(animal.Description());
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Enclosure number {enclosureNumber} not found in the zoo.");
                }
            }
            else
            {
                Console.WriteLine("Invalid enclosure number.");
            }
        }
        else
        {
            Console.WriteLine("Exiting the program.");
        }
    }
}

class Zoo
{
    public string Name { get; set; }
    public List<Enclosure> Enclosures { get; set; }

    public Zoo(string name)
    {
        Name = name;
        Enclosures = new List<Enclosure>();
    }
}

class Enclosure
{
    public int Number { get; set; }
    public string Size { get; set; }
    public int MaxAnimalCount { get; set; }
    public int CurrentAnimalCount { get; set; }
    public List<Animal> Animals { get; set; }

    public Enclosure(int number, string size, int maxAnimalCount)
    {
        Number = number;
        Size = size;
        MaxAnimalCount = maxAnimalCount;
        CurrentAnimalCount = 0;
        Animals = new List<Animal>();
    }
}

class Animal
{
    public string Name { get; set; }
    public bool IsPredator { get; set; }

    public virtual string Description()
    {
        return $"Name: {Name}, Predator: {IsPredator}";
    }
}

class Fish : Animal
{
    public bool DeepWater { get; set; }

    public override string Description()
    {
        return base.Description() + $", Deep water: {DeepWater}";
    }
}

class Bird : Animal
{
    public double FlightSpeed { get; set; }

    public override string Description()
    {
        return base.Description() + $", Flight speed: {FlightSpeed} km/h";
    }
}

class Mammal : Animal
{
    public string Habitat { get; set; }

    public override string Description()
    {
        return base.Description() + $", Habitat: {Habitat}";
    }
}
