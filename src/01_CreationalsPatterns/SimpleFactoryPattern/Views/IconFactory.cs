namespace SimpleFactoryPattern
{
    public class IconFactory
    {
        public static string Create(PaymentType paymentType)
        {
            return GetIcon(paymentType);
        }

        private static string GetIcon(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Cash: return "[100]";
                case PaymentType.CreditCard: return "[abc]";
                case PaymentType.BankTransfer: return "[-->]";

                default: return string.Empty;
            }
        }
    }
}
