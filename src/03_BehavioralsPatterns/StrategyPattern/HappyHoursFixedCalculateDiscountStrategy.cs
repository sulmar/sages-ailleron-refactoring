using System;

namespace StrategyPattern
{
    partial class HappyHoursFixedCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private decimal amount;

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
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
