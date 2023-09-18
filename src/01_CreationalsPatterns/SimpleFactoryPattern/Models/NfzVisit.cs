namespace SimpleFactoryPattern
{
    public class NfzVisit : Visit
    {
        public override decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return 0;
        }
    }
}
