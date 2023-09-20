namespace StrategyPattern.CanDiscountStrategies
{


    // Concrete Strategy B
    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private Gender gender;

        public GenderCanDiscountStrategy(Gender gender)
        {
            this.gender = gender;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }


    }


}
