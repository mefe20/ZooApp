namespace Zoo.Models
{
    public class Bird : Animal
    {
        public double FlightSpeed { get; set; }

        public override string Description
        {
            get
            {
                return $"Bird: {Name}, FlightSpeed: {FlightSpeed} km/h, Predator: {IsPredator}";
            }
        }
    }
}
