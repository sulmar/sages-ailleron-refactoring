namespace StrategyPattern.CanDiscountStrategies
{
    // Abstract Strategy A
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }




}
