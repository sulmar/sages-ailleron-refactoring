using System;

namespace SimpleFactoryPattern
{

    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public static string Symbol { get; private set; }

        public Visit()
        {
            VisitDate = DateTime.Now;            
        }

        public abstract decimal CalculateCost(TimeSpan duration, decimal pricePerHour);       
    }
}
