namespace StrategyPattern
{


    // Concrete Strategy B
    public class GenderPercentageCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private Gender gender;
        private decimal percentage;

        public GenderPercentageCalculateDiscountStrategy(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }

        public decimal Discount(Order order)
        {
            return order.Amount * percentage;
        }

        public decimal NoDiscount()
        {
            return decimal.Zero;
        }
    }

    
}
