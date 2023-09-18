namespace SimpleFactoryPattern
{

    public interface IVisitCalculator
    {
        decimal CalculateCost(TimeSpan duration, decimal pricePerHour);
    }
}
