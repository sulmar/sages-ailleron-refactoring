namespace NamingConvention
{
    class Calculator
    {
        public decimal CalculateAndDisplayAmount(int quantity, decimal price)
        {
            var amount = Calculate(quantity, price);

            DisplayAmount(amount);

            return amount;
        }

        public decimal Calculate(int quantity, decimal price)
        {
            var amount = quantity * price;

            return amount;
        }

        public static void DisplayAmount(decimal amount)
        {
            Console.WriteLine(amount);
        }
    }
}