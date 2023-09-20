namespace StrategyPattern
{
    // Abstract Strategy
    public interface ICalculateDiscountStrategy : ICanDiscountStrategy, IDiscountStrategy
    {
        
       
    }

    // Abstract Strategy A
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

    // Abstract Strategy B
    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
        decimal NoDiscount();
    }




}
