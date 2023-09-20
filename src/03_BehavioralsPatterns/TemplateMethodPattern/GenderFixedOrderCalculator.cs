namespace TemplateMethodPattern
{
    public class GenderFixedOrderCalculator : FixedOrderCalculator
    {
        private readonly Gender gender;

        public GenderFixedOrderCalculator(Gender gender, decimal amount)
            : base(amount) 
        {
            
        }

        public override bool CanDiscount(Order order) => order.Customer.Gender == gender;

        

    }

}
