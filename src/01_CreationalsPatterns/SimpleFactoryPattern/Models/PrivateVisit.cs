namespace SimpleFactoryPattern
{
    public class PrivateVisit : Visit
    {
        public override decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return (decimal)duration.TotalHours * pricePerHour;
        }
    }
}
