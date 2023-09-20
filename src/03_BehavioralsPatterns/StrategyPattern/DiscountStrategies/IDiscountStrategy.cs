namespace StrategyPattern.DiscountStrategies
{
    // Abstract Strategy B
    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
        decimal NoDiscount();
    }




}
