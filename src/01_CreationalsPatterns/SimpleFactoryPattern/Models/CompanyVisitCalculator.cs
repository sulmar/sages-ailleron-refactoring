namespace SimpleFactoryPattern
{
    public class CompanyVisitCalculator : IVisitCalculator
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public decimal CalculateCost(TimeSpan duration, decimal pricePerHour)
        {
            return (decimal)duration.TotalHours * pricePerHour * companyDiscountPercentage;
        }
    }
}
