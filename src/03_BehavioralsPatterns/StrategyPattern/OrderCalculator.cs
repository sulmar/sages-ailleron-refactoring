namespace StrategyPattern
{


    public class OrderCalculator
    {
        private readonly ICalculateDiscountStrategy calculateDiscountStrategy;

        public OrderCalculator(ICalculateDiscountStrategy calculateDiscountStrategy)
        {
            this.calculateDiscountStrategy = calculateDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (calculateDiscountStrategy.CanDiscount(order))       // Predykat
            {
                return calculateDiscountStrategy.Discount(order);   // Upust
            }
            else
                return calculateDiscountStrategy.NoDiscount();    // Brak upustu
        }
    }


    
}
