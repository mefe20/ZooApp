namespace Zoo.Models
{
    public class Fish : Animal
    {
        public bool IsDeepWater { get; set; }

        public override string Description
        {
            get
            {
                return $"Fish: {Name}, DeepWater: {IsDeepWater}, Predator: {IsPredator}";
            }
        }
    }
}
