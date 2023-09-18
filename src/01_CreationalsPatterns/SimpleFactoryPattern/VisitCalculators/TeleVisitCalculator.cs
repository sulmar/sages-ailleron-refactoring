namespace SimpleFactoryPattern.VisitCalculators
{
    // Concrete Product C
    public class TeleVisitCalculator : IVisitCalculator
    {
        private readonly decimal rate;

        public TeleVisitCalculator()
            : this(10m)
        {

        }

        public TeleVisitCalculator(decimal rate)
        {
            this.rate = rate;
        }

        public decimal CalculateCost(Visit visit)
        {
            return rate;
        }
    }
}
