// Component B
public class PaymentGateway
{
    private IMediator _mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount}...");

        // Simulate successful payment
        _mediator.Notify(this, "PaymentSuccess");
    }
}
