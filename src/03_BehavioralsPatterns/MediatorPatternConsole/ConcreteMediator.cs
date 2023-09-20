
// Concrete Mediator
public class ConcreteMediator : IMediator
{
    private ShoppingCart _shoppingCart;
    private PaymentGateway _paymentGateway;

    public ConcreteMediator(ShoppingCart shoppingCart, PaymentGateway paymentGateway)
    {
        _shoppingCart = shoppingCart;
        _shoppingCart.SetMediator(this);

        _paymentGateway = paymentGateway;
        _paymentGateway.SetMediator(this);
    }

    public void Notify(object sender, string ev)
    {
        if (sender == _shoppingCart && ev == "Checkout")
        {
            Console.WriteLine("Mediator triggers payment processing...");
            _paymentGateway.ProcessPayment(_shoppingCart.TotalPrice);
        }
        else if (sender == _paymentGateway && ev == "PaymentSuccess")
        {
            Console.WriteLine("Mediator notifies shopping cart of payment success.");
            _shoppingCart.Reset();
        }
    }


}
