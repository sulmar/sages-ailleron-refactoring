namespace StrategyPattern
{
    // Abstract Strategy
    public interface ICalculateDiscountStrategy
    {
        bool CanDiscount(Order order);
        decimal Discount(Order order);
        decimal NoDiscount();
    }


    
}
