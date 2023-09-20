namespace StrategyPattern.DiscountStrategies
{

    public class FixedDiscountStrategy : IDiscountStrategy
    {
        private decimal amount;

        public FixedDiscountStrategy(decimal amount)
        {
            this.amount = amount;
        }

        public decimal Discount(Order order)
        {
            return amount;
        }

        public decimal NoDiscount()
        {
            return decimal.Zero;
        }
    }
}
