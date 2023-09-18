namespace SimpleFactoryPattern
{
  
    public class PrivateVisitCalculator : IVisitCalculator
    {
        private readonly decimal pricePerHour;

        public PrivateVisitCalculator()
            : this(100m)
        {
            
        }

        public PrivateVisitCalculator(decimal pricePerHour)
        {
            this.pricePerHour = pricePerHour;
        }

        public decimal CalculateCost(Visit visit)
        {
            return (decimal)visit.Duration.TotalHours * pricePerHour;
        }
    }
}
