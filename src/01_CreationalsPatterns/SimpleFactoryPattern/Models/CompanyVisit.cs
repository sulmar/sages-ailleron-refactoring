namespace SimpleFactoryPattern
{
    public class CompanyVisit : Visit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public override decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return (decimal)duration.TotalHours * pricePerHour * companyDiscountPercentage;
        }
    }
}
