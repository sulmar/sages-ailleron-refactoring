namespace SimpleFactoryPattern
{
    // Factory
    public class PaymentViewFactory
    {
        public static PaymentView Create(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Cash:
                    return new CashPaymentView();
                case PaymentType.CreditCard:
                    return new CreditCardPaymentView();
                case PaymentType.BankTransfer:
                    return new BankTransferPaymentView();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
