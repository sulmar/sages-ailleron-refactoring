using System;

namespace TemplateMethodPattern
{
    public class SpecialDatePercentageOrderCalculator : PercentageOrderCalculator
    {
        private readonly DateTime when;

        public SpecialDatePercentageOrderCalculator(DateTime when, decimal percentage) : base(percentage)
        {
            this.when = when;
        }

        public override bool CanDiscount(Order order) => order.OrderDate == when;
    }
}
