using System;

namespace TemplateMethodPattern
{
    public class SpecialDateFixedOrderCalculator : FixedOrderCalculator
    {
        private readonly DateTime when;

        public SpecialDateFixedOrderCalculator(DateTime when, decimal amount) : base(amount)
        {
            this.when = when;
        }

        public override bool CanDiscount(Order order) => order.OrderDate == when;
    }
}
