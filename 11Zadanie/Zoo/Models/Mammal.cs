namespace Zoo.Models
{
    public class Mammal : Animal
    {
        public string Habitat { get; set; }

        public override string Description
        {
            get
            {
                return $"Mammal: {Name}, Habitat: {Habitat}, Predator: {IsPredator}";
            }
        }
    }
}
