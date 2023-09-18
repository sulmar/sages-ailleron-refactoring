namespace SimpleFactoryPattern
{
    public class TeleVisitCalculator : IVisitCalculator
    {
        public decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return 10;
        }
    }
}
