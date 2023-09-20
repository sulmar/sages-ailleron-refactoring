namespace TemplateMethodPattern
{
    public abstract class PercentageOrderCalculator : OrderCalculator
    {
        private decimal percentage;

        protected PercentageOrderCalculator(decimal percentage)
        {
            this.percentage = percentage;
        }

        public override decimal Discount(Order order)
        {
            return order.Amount * percentage;
        }

    }



}
