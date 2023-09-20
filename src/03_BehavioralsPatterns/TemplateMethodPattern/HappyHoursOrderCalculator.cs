namespace TemplateMethodPattern
{

    public abstract class FixedOrderCalculator : OrderCalculator
    {
        private decimal amount;

        protected FixedOrderCalculator(decimal amount)
        {
            this.amount = amount;
        }

        public override decimal Discount(Order order)
        {
            return amount;
        }
    }

}
