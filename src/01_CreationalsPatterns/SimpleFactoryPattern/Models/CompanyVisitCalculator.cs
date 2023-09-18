namespace SimpleFactoryPattern
{
    public class CompanyVisitCalculator : IVisitCalculator
    {
        private readonly decimal companyDiscountPercentage;
        private readonly decimal pricePerHour;

        public CompanyVisitCalculator()
            : this(100m)
        {
            
        }

        public CompanyVisitCalculator(decimal pricePerHour, decimal companyDiscountPercentage = 0.9m)
        {
            this.companyDiscountPercentage = companyDiscountPercentage;
            this.pricePerHour = pricePerHour;
        }

        public decimal CalculateCost(Visit visit)
        {
            return (decimal)visit.Duration.TotalHours * pricePerHour * companyDiscountPercentage;
        }
    }
}
