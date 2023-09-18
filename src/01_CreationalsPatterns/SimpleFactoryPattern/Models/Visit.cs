using System;

namespace SimpleFactoryPattern
{
    public class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public Visit()
        {
            VisitDate = DateTime.Now;            
        }

    }

    public class SpecialVisit : Visit
    {

    }
}
