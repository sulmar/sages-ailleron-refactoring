using System;

namespace StrategyPattern
{
    // Concrete Strategy A
    public class HappyHoursPercentageCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private decimal percentage;

        public HappyHoursPercentageCalculateDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
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
