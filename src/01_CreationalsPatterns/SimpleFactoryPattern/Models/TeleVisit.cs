namespace SimpleFactoryPattern
{
    public class TeleVisit : Visit
    {
        public override decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return 10;
        }
    }
}
