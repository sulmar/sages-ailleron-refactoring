using StrategyPattern.CanDiscountStrategies;
using StrategyPattern.DiscountStrategies;

namespace StrategyPattern
{


    public class OrderCalculator
    {
        private readonly ICanDiscountStrategy _canDiscountStrategy;
        private readonly IDiscountStrategy _discountStrategy;

        public OrderCalculator(ICanDiscountStrategy canDiscountStrategy, IDiscountStrategy discountStrategy)
        {
            _canDiscountStrategy = canDiscountStrategy;
            _discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (_canDiscountStrategy.CanDiscount(order))       // Predykat
            {
                return _discountStrategy.Discount(order);   // Upust
            }
            else
                return _discountStrategy.NoDiscount();    // Brak upustu
        }
    }


    
}
