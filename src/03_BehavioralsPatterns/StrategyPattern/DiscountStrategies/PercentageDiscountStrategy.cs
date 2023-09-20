namespace StrategyPattern.DiscountStrategies
{
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private decimal percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
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
