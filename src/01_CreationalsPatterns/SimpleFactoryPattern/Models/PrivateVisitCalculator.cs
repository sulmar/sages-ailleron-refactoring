namespace SimpleFactoryPattern
{
  
    public class PrivateVisitCalculator : IVisitCalculator
    {
        public decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return (decimal)duration.TotalHours * pricePerHour;
        }
    }
}
