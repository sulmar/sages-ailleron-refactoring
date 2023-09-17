// Zasada podstawiania Liskov (Liskov Substitution Principle) - LSP  
// w miejscu klasy bazowej można użyć dowolnej klasy pochodnej (zgodność wszystkich metod).

// Przykład łamiący zasadę podstawiania Liskov



public class Car
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Engine started.");
    }

    public virtual void Accelerate()
    {
        Console.WriteLine("Car is accelerating.");
    }
}

public class ElectricCar : Car
{
    public override void StartEngine()
    {
        Console.WriteLine("Electric motor started.");
    }

    public override void Accelerate()
    {
        Console.WriteLine("Electric car is accelerating.");
    }

    public void ChargeBattery()
    {
        Console.WriteLine("Battery is charging.");
    }
}

