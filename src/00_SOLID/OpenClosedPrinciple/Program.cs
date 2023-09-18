// Zasada otwarte – zamknięte (Open/Closed Principle) - OCP

// Każda klasa powinna być otwarta na rozbudowę ale zamknięta na modyfikacje.
// Oznacza to, że taka klasa pozwala na rozszerzenie swojego zachowania
// bez modyfikowania kodu źródłowego.

ITaxCalculator standardTaxCalculator = new StandardTaxCalculator();
ITaxCalculator progressiveTaxCalculator = new ProgressiveTaxCalculator(50_000);

decimal standardTax = standardTaxCalculator.CalculateTax(60000);
decimal progressiveTax = progressiveTaxCalculator.CalculateTax(60000);

Console.WriteLine($"Standard Tax: {standardTax}");
Console.WriteLine($"Progressive Tax: {progressiveTax}");

public interface ITaxCalculator
{
    decimal CalculateTax(decimal income);
}

public class StandardTaxCalculator : ITaxCalculator
{
    public decimal CalculateTax(decimal income)
    {
        return income * 0.2m; // Standard tax rate of 20%
    }
}

public class ProgressiveTaxCalculator : ITaxCalculator
{
    private decimal incomeLimit;

    public ProgressiveTaxCalculator(decimal incomeLimit)
    {
        this.incomeLimit = incomeLimit;
    }

    public decimal CalculateTax(decimal income)
    {
        decimal tax = 0;

        if (income <= incomeLimit)    // Magic Number
        {
            tax = income * 0.1m; // 10% tax for income up to 50000
        }
        else
        {
            tax = income * 0.3m; // 30% tax for income above 50000
        }

        return tax;
    }
}
