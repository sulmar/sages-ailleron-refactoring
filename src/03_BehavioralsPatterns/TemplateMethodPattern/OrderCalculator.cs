namespace TemplateMethodPattern
{
    public abstract class OrderCalculator
    {
        public abstract bool CanDiscount(Order order);
        public abstract decimal Discount(Order order);
        public virtual decimal NoDiscount()
        {
            return decimal.Zero;
        }


        public decimal CalculateDiscount(Order order)                   // Template Method (Szablon)
        {
            if (CanDiscount(order))    // Warunek (Predikat)
            {
                return Discount(order);                                       // Wartość upustu (Discount)
            }
            
            return NoDiscount();                                              // Brak upustu (NoDiscount)
        }
    }



}
