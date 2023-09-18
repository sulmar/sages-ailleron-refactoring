using System;
using SimpleFactoryPattern.VisitCalculators;

namespace SimpleFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

           // VisitCalculateAmountTest();

             PaymentTest();
        }



        private static void PaymentTest()
        {
            while (true)
            {
                Console.Write("Podaj kwotę: ");

                decimal.TryParse(Console.ReadLine(), out decimal totalAmount);

                Console.Write("Wybierz rodzaj płatności: (G)otówka (K)karta płatnicza (P)rzelew: ");

                var paymentType = Enum.Parse<PaymentType>(Console.ReadLine());

                Payment payment = new Payment(paymentType, totalAmount);

                PaymentView paymentView = PaymentViewFactory.Create(paymentType);
                paymentView.Show(payment);

                string icon = IconFactory.Create(payment.PaymentType);
                Console.WriteLine(icon);
            }

        }

      

        private static void VisitCalculateAmountTest()
        {
            VisitCalculatorFactory visitCalculatorFactory = new VisitCalculatorFactory();

            while (true)
            {
                Console.Write("Podaj rodzaj wizyty: (N)FZ (P)rywatna (F)irma: ");
                string visitType = Console.ReadLine();

                Console.Write("Podaj czas wizyty w minutach: ");
                if (double.TryParse(Console.ReadLine(), out double minutes))
                {
                    TimeSpan duration = TimeSpan.FromMinutes(minutes);

                    Visit visit = new Visit { Duration = duration };

                    IVisitCalculator visitCalculator = visitCalculatorFactory.Create(visitType);

                    decimal totalAmount = visitCalculator.CalculateCost(visit);

                    Console.ForegroundColor = ConsoleColorFactory.Create(totalAmount);

                    Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }
    }
}
