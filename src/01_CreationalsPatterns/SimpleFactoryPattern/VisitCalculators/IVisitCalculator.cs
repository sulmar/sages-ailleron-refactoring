namespace SimpleFactoryPattern.VisitCalculators
{
    // Abstract Product
    public interface IVisitCalculator
    {
        decimal CalculateCost(Visit visit);
    }
}
