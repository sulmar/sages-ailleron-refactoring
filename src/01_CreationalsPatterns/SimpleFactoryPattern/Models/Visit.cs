using System;

namespace SimpleFactoryPattern
{

    public class VisitFactory
    {
        public static Visit Create(string symbol, TimeSpan duration, decimal pricePerHour)
        {
            return symbol switch // Match Patterns
            {
                "N" => new NfzVisit(duration, pricePerHour),
                "P" => new PrivateVisit(duration, pricePerHour),
                "F" => new CompanyVisit(duration, pricePerHour),
                _ => throw new NotSupportedException(nameof(symbol)),
            };
        }
    }

    public class NfzVisit : Visit
    {
        public NfzVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
           
        }

        public override decimal CalculateCost()
        {
            return 0;
        }
    }

    public class PrivateVisit : Visit
    {
        public PrivateVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }


        public override decimal CalculateCost()
        {
            return (decimal)Duration.TotalHours * PricePerHour;
        }
    }

    public class CompanyVisit : Visit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public CompanyVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

      

        public override decimal CalculateCost()
        {
            return (decimal)Duration.TotalHours * PricePerHour * companyDiscountPercentage;
        }
    }

    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public static string Symbol { get; private set; }

        public Visit(TimeSpan duration, decimal pricePerHour)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public abstract decimal CalculateCost();       
    }
}
