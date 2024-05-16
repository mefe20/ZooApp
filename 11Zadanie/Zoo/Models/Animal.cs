namespace Zoo.Models
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public bool IsPredator { get; set; }
        public abstract string Description { get; }
    }
}
