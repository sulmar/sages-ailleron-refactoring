namespace SimpleFactoryPattern.VisitCalculators
{
    // Concrete Product A
    public class NfzVisitCalculator : IVisitCalculator
    {
        public decimal CalculateCost(Visit visit)
        {
            return decimal.Zero;
        }
    }
}
