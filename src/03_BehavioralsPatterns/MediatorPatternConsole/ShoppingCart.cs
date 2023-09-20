// Component A
public class ShoppingCart
{
    private IMediator _mediator;
    private decimal _totalPrice = 0;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }


    public void AddItemToCart(Product product)
    {
        _totalPrice += product.Price;
        Console.WriteLine($"Added {product.Name} to the cart. Total Price: {_totalPrice}");
    }

    public void Checkout()
    {
        Console.WriteLine("Checkout initiated.");

        _mediator.Notify(this, "Checkout");
    }

    public decimal TotalPrice => _totalPrice;

    public void Reset()
    {
        _totalPrice = 0;
    }
}
